using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiriusCRM.Abstractions.Contracts.Commands;
using SiriusCRM.Abstractions.Contracts.Commands.Category;
using SiriusCRM.Abstractions.Contracts.Queries;
using SiriusCRM.Abstractions.CQRS.Buses;
using SiriusCRM.WebApi.Controllers.Base;

namespace SiriusCRM.WebApi.Controllers
{
    [Route("api/category")]
    public class CategoryController : OnBusController
    {
        public CategoryController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpGet]
        public async Task<CategoriesResponse> GetCategories()
        {
            var categoriesResponse = await QueryBus.Execute<CategoriesQuery, CategoriesResponse>(new CategoriesQuery());

            return categoriesResponse;
        }

        [HttpPost]
        public async Task CreateCategory(CreateCategoryCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}