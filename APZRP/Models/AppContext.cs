using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APZRP.Models
{
    public class AppContext :IdentityDbContext
    {
        public AppContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> ApplicationUsers { get; set; }
    }
}
