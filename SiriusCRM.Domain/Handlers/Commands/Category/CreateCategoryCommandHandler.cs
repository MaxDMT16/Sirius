using System.Threading.Tasks;
using SiriusCRM.Abstractions.Contracts.Commands.Category;
using SiriusCRM.Database.Context;
using SiriusCRM.Database.Handlers;

namespace SiriusCRM.Domain.Handlers.Commands.Category
{
    public class CreateCategoryCommandHandler : DatabaseCommandHandlerBase<CreateCategoryCommand>
    {
        public CreateCategoryCommandHandler(ISiriusContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(CreateCategoryCommand command)
        {
            var category = new Database.Entities.Category
            {
                Name = command.Name
            };

            DbContext.Categories.Add(category);
            await DbContext.SaveChangesAsync();
        }
    }
}