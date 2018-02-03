using System.Threading.Tasks;
using SiriusCRM.Abstractions.Contracts;

namespace SiriusCRM.Abstractions.Handlers
{
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }
}