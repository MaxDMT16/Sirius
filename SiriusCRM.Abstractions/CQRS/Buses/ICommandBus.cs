using System.Threading.Tasks;
using SiriusCRM.Abstractions.CQRS.Contracts;

namespace SiriusCRM.Abstractions.CQRS.Buses
{
    public interface ICommandBus
    {
        Task Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}