using System;

namespace SiriusCRM.Database.Entities
{
    public class Product : EntityBase
    {
        public string Name { get; set; }
        public string Producer { get; set; }
        public decimal Price { get; set; }

        public Guid CategoryId { get; set; }
        public Category Category { get; set; }
    }
}