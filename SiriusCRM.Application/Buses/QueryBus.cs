using System;
using System.Threading.Tasks;
using Autofac;
using FluentValidation;
using SiriusCRM.Abstractions.CQRS.Buses;
using SiriusCRM.Abstractions.CQRS.Contracts;
using SiriusCRM.Abstractions.CQRS.Handlers;

namespace SiriusCRM.Application.Buses
{
    public class QueryBus : IQueryBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public QueryBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task<TQueryResult> Execute<TQuery, TQueryResult>(TQuery query) 
            where TQueryResult : IQueryResult
            where TQuery : IQuery<TQueryResult>
        {
            var queryHandler = ResolveHandler<TQuery, TQueryResult>(query);

            await Validate<TQuery, TQueryResult>(query);

            return await queryHandler.Execute(query);
        }

        private IQueryHandler<TQuery, TQueryResult> ResolveHandler<TQuery, TQueryResult>(TQuery command)
            where TQuery : IQuery<TQueryResult>
            where TQueryResult : IQueryResult
        {
            var queryHandler = _lifetimeScope.ResolveOptional<IQueryHandler<TQuery, TQueryResult>>();

            if (queryHandler == null)
            {
                throw new InvalidOperationException("Can`t resolve query handler");
            }

            return queryHandler;
        }

        private async Task Validate<TQuery, TQueryResult>(TQuery query)
            where TQuery : IQuery<TQueryResult>
            where TQueryResult : IQueryResult
        {
            var validator = _lifetimeScope.ResolveOptional<IValidator<TQuery>>();

            if (validator == null)
            {
                throw new InvalidOperationException($"Can`t resolve validator for query ${typeof(TQuery)}");
            }

            var validationResult = await validator.ValidateAsync(query);

            if (validationResult == null)
            {
                throw new InvalidOperationException("Validation result is null");
            }

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }
        }
    }
}