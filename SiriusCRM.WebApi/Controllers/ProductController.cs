using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiriusCRM.Abstractions.Contracts.Commands.Product;
using SiriusCRM.Abstractions.CQRS.Buses;
using SiriusCRM.WebApi.Controllers.Base;

namespace SiriusCRM.WebApi.Controllers
{
    [Route("api/product")]
    public class ProductController : OnBusController
    {
        public ProductController(ICommandBus commandBus, IQueryBus queryBus) : base(commandBus, queryBus)
        {
        }

        [HttpPost]
        public async Task CreateProduct(CreateProductCommand command)
        {
            await CommandBus.Execute(command);
        }
    }
}