using System;
using System.Collections.Generic;
using SiriusCRM.Abstractions.CQRS.Contracts;

namespace SiriusCRM.Abstractions.Contracts.Commands.Category
{
    public class DeleteCategoryCommand : ICommand
    {
        public IEnumerable<Guid> Ids { get; set; }
    }
}