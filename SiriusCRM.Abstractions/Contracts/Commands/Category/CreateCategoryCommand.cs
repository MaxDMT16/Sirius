using SiriusCRM.Abstractions.CQRS.Contracts;

namespace SiriusCRM.Abstractions.Contracts.Commands.Category
{
    public class CreateCategoryCommand : ICommand
    {
        public string Name { get; set; }
    }
}