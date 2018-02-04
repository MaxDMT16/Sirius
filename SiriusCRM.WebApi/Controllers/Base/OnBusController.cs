using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiriusCRM.Abstractions.CQRS.Buses;

namespace SiriusCRM.WebApi.Controllers.Base
{
    [Produces("application/json")]
    [Route("api/OnBus")]
    public class OnBusController : Controller
    {
        public ICommandBus CommandBus { get; set; }
        public IQueryBus QueryBus { get; set; }

        public OnBusController(ICommandBus commandBus, IQueryBus queryBus)
        {
            CommandBus = commandBus;
            QueryBus = queryBus;
        }
    }
}