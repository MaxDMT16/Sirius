using Microsoft.EntityFrameworkCore;
using SiriusCRM.Database.Entities;

namespace SiriusCRM.Database.Context
{
    public interface ISiriusContext : IDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
    }
}