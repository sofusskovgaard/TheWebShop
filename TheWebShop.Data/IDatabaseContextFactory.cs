using Microsoft.EntityFrameworkCore.Design;

namespace TheWebShop.Data
{
    public interface IDatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
    {
    }
}