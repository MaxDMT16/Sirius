using System.Threading.Tasks;
using SiriusCRM.Abstractions.CQRS.Contracts;
using SiriusCRM.Abstractions.CQRS.Handlers;
using SiriusCRM.Database.Context;

namespace SiriusCRM.Database.Handlers
{
    public abstract class DatabaseCommandHandlerBase<TCommand> : ICommandHandler<TCommand>
        where TCommand : ICommand
    {
        protected ISiriusContext DbContext { get; }

        protected DatabaseCommandHandlerBase(ISiriusContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task Execute(TCommand command);
    }
}