using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiriusCRM.Abstractions.Contracts.Commands.Category;
using SiriusCRM.Database.Context;
using SiriusCRM.Database.Handlers;

namespace SiriusCRM.Domain.Handlers.Commands.Category
{
    public class DeleteCategoryCommandHandler : DatabaseCommandHandlerBase<DeleteCategoryCommand>
    {
        public DeleteCategoryCommandHandler(ISiriusContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(DeleteCategoryCommand command)
        {
            var category = await DbContext.Categories.FirstOrDefaultAsync(c => c.Id == command.Id);

            if (category == null)
            {
                throw new InvalidOperationException($"Category with id {category.Id} not found");
            }

            DbContext.Categories.Remove(category);

            await DbContext.SaveChangesAsync();
        }
    }
}