using Hangfire.Annotations;
using Lotfi.HangFire.SimpleExample.Model;
using Microsoft.EntityFrameworkCore;

namespace Lotfi.HangFire.SimpleExample.Controllers
{
    public class Lotfi1Context : DbContext
    {
        public Lotfi1Context([NotNullAttribute] DbContextOptions options) : base(options)
        {

        }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Lotfi1DB;Integrated Security=True;");
        }
        public DbSet<myDate> jobs { get; set; }
    }
}