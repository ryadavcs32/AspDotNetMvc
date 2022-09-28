using Microsoft.EntityFrameworkCore;
using MyApp.Models;

namespace MyApp.DataAccessLayer.Data
{
    public class ApplicationDbContextcs : DbContext
    {
        public ApplicationDbContextcs(DbContextOptions<ApplicationDbContextcs> options) : base(options)
        {

        }
        public DbSet<CategoryModel> Categories { get; set; }
    }
}
