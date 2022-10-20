using Microsoft.EntityFrameworkCore;

namespace dotnet.Models
{
     public partial class TesTalContext : DbContext
    {
        public TesTalContext()
        {
        }

        public TesTalContext(DbContextOptions<TesTalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TesTal> TesTal { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
