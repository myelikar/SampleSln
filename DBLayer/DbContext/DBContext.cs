using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbLayer.DBContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<CUser> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
