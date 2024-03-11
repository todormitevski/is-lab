using Concert.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Concert.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConcertModel> Concerts { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }
    }
}
