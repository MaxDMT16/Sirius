using System;
using SiriusCRM.Abstractions.CQRS.Contracts;

namespace SiriusCRM.Abstractions.Contracts.Commands.Product
{
    public class CreateProductCommand : ICommand
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}