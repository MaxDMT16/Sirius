using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SiriusCRM.Abstractions.Contracts.Commands.Category;
using SiriusCRM.Database.Context;
using SiriusCRM.Database.Handlers;

namespace SiriusCRM.Domain.Handlers.Commands.Category
{
    public class UpdateCategoryCommandHandler : DatabaseCommandHandlerBase<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandHandler(ISiriusContext dbContext) : base(dbContext)
        {
        }

        public override async Task Execute(UpdateCategoryCommand command)
        {
            var category = await DbContext.Categories.FirstOrDefaultAsync(c => c.Id == command.Id);

            if (category == null)
            {
                throw new InvalidOperationException($"Category wit id {command.Id} not found");
            }

            category.Name = command.Name;

            await DbContext.SaveChangesAsync();
        }
    }
}