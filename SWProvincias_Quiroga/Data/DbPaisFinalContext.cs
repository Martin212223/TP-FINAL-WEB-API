using Microsoft.EntityFrameworkCore;
using SWProvincias_Quiroga.Models;

namespace SWProvincias_Quiroga.Data
{
    public class DbPaisFinalContext : DbContext
    {
        public DbPaisFinalContext(DbContextOptions<DbPaisFinalContext> options) : base(options) { }

        public DbSet<Provincia> Provincias { get; set; }

        public DbSet<Ciudad> Ciudades { get; set; }
    }
}
