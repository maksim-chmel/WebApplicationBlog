using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace newProject.Models
{
    public class EFDatabaseContext : DbContext
    {
        public EFDatabaseContext(DbContextOptions<EFDatabaseContext> opts) : base(opts) { }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
