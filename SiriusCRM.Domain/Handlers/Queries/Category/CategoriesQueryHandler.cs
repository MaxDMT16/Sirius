using System.Linq;
using System.Threading.Tasks;
using SiriusCRM.Abstractions.Contracts.Queries;
using SiriusCRM.Database.Context;
using SiriusCRM.Database.Handlers;

namespace SiriusCRM.Domain.Handlers.Queries.Category
{
    public class CategoriesQueryHandler : DatabaseQueryHandlerBase<CategoriesQuery, CategoriesResponse>
    {
        public CategoriesQueryHandler(ISiriusContext dbContext) : base(dbContext)
        {
        }

        public override async Task<CategoriesResponse> Execute(CategoriesQuery query)
        {
            var categoriesResponse = DbContext.Categories.Select(category => new CategoriesResponse.Category
            {
                Id = category.Id,
                Name = category.Name,
                Products = category.Products.Select(product => new CategoriesResponse.Product
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Producer = product.Producer
                }).ToList()
            });

            return new CategoriesResponse
            {
                Categories = categoriesResponse
            };
        }
    }
}