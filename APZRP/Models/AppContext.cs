using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using APZRP.Models;

namespace APZRP.Models
{
    public class AppContext :IdentityDbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<AppUser> ApplicationUsers { get; set; }

        public DbSet<APZRP.Models.Query> Query { get; set; }
    }
}
