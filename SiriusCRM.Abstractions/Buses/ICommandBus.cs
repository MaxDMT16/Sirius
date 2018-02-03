using System.Threading.Tasks;
using SiriusCRM.Abstractions.Contracts;

namespace SiriusCRM.Abstractions.Buses
{
    public interface ICommandBus
    {
        Task Execute<TCommand>(TCommand command)
            where TCommand : ICommand;
    }
}