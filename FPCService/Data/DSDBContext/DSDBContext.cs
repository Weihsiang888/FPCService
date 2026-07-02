using Microsoft.EntityFrameworkCore;

namespace FPCService.Data
{
    public partial class DSDBContext : DbContext
    {
        public DSDBContext()
        {
        }

        public DSDBContext(DbContextOptions<DSDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
