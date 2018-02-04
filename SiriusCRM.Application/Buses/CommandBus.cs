﻿using System;
using System.Threading.Tasks;
using Autofac;
using FluentValidation;
using SiriusCRM.Abstractions.CQRS.Buses;
using SiriusCRM.Abstractions.CQRS.Contracts;
using SiriusCRM.Abstractions.CQRS.Handlers;

namespace SiriusCRM.Application.Buses
{
    public class CommandBus : ICommandBus
    {
        private readonly ILifetimeScope _lifetimeScope;

        public CommandBus(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public async Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandHandler = ResolveHandler(command);

            await Validate(command);

            await commandHandler.Execute(command);
        }

        private ICommandHandler<TCommand> ResolveHandler<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var commandHandler = _lifetimeScope.ResolveOptional<ICommandHandler<TCommand>>();

            if (commandHandler == null)
            {
                throw new InvalidOperationException("Can`t resolve command handler");
            }

            return commandHandler;
        }

        private async Task Validate<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            var validator = _lifetimeScope.ResolveOptional<IValidator<TCommand>>();

            if (validator == null)
            {
                throw new InvalidOperationException($"Can`t resolve validator for command ${typeof(TCommand)}");
            }

            var validationResult = await validator.ValidateAsync(command);

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