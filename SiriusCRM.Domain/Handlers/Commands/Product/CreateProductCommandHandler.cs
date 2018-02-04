using System.Threading.Tasks;
using SiriusCRM.Abstractions.Contracts.Commands.Product;
using SiriusCRM.Database.Context;
using SiriusCRM.Database.Handlers;

namespace SiriusCRM.Domain.Handlers.Commands.Product
{
    public class CreateProductCommandHandler : DatabaseCommandHandlerBase<CreateProductCommand>
    {
        public CreateProductCommandHandler(ISiriusContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateProductCommand command)
        {
            var product = new Database.Entities.Product
            {
                Name = command.Name,
                Price = command.Price,
                CategoryId = command.CategoryId,
                Producer = command.Producer
            };

            DbContext.Products.Add(product);

            await DbContext.SaveChangesAsync();
        }
    }
}