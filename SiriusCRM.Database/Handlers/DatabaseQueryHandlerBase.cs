using System.Threading.Tasks;
using SiriusCRM.Abstractions.CQRS.Contracts;
using SiriusCRM.Abstractions.CQRS.Handlers;
using SiriusCRM.Database.Context;

namespace SiriusCRM.Database.Handlers
{
    public abstract class DatabaseQueryHandlerBase<TQuery, TQueryResult> : IQueryHandler<TQuery, TQueryResult> 
        where TQueryResult : IQueryResult 
        where TQuery : IQuery<TQueryResult>
    {
        protected ISiriusContext DbContext { get; }

        protected DatabaseQueryHandlerBase(ISiriusContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TQueryResult> Execute(TQuery query);
    }
}