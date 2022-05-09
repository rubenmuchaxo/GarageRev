using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GarageRev.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //define table on the database
        public DbSet<GarageRev.Models.Carros> Carros { get; set; }
        public DbSet<GarageRev.Models.Utilizadores> Utilizadores { get; set; }
        public DbSet<GarageRev.Models.Fotografias> Fotografias { get; set; }
        public DbSet<GarageRev.Models.Reviews> Reviews { get; set; }
        public DbSet<GarageRev.Models.Categorias> Categorias { get; set; }

    }
}