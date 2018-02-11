using System;
using SiriusCRM.Abstractions.CQRS.Contracts;

namespace SiriusCRM.Abstractions.Contracts.Commands.Category
{
    public class UpdateCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}