using Microsoft.EntityFrameworkCore;
using NginxDashCore.Data.Entities;

namespace NginxDashCore.Data
{
    public class NginxDashContext : DbContext
    {
        public NginxDashContext(DbContextOptions options) : base(options) { }

        internal DbSet<Domain> Domains { get; set; }
        internal DbSet<Subdomain> Subdomains { get; set; }
        
    }
}