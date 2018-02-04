using System;
using System.Collections.Generic;
using SiriusCRM.Abstractions.CQRS.Contracts;

namespace SiriusCRM.Abstractions.Contracts.Queries
{
    public class CategoriesResponse : IQueryResult
    {
        public IEnumerable<Category> Categories { get; set; }

        public class Category
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public IEnumerable<Product> Products { get; set; }
        }

        public class Product
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Producer { get; set; }
        }
    }
}