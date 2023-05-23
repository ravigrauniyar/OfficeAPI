using Microsoft.EntityFrameworkCore;
using OfficeAPI.Models;

namespace OfficeAPI.Data
{
    public class LoginTodoContext : DbContext
    {
        public LoginTodoContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<LoginItemTodo> LoginItems { get; set; }
    }
}
