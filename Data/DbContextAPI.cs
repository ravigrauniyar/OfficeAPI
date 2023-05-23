using Microsoft.EntityFrameworkCore;
using OfficeAPI.Models.Domain;

namespace OfficeAPI.Data
{
    public class DbContextAPI : DbContext
    {
        public DbContextAPI(DbContextOptions<DbContextAPI> options) : base(options)
        {
        }
        public DbSet<ItemTodo> ItemTodos { get; set; }
    }
}
