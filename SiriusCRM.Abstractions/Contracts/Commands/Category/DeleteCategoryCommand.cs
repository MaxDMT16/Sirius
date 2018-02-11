using System;
using SiriusCRM.Abstractions.CQRS.Contracts;

namespace SiriusCRM.Abstractions.Contracts.Commands.Category
{
    public class DeleteCategoryCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}