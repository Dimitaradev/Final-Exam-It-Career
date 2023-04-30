using CoolEvents_Final_IT_Career.Models;
using CoolEvents_Final_IT_Career.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace CoolEvents_Final_IT_Career.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Users>()
                .HasIndex(x => x.UserName)
                .IsUnique();
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Events> Events { get; set; }
        public DbSet<Orders> Orders { get; set; }

     //   public DbSet<OrderCreateViewModel> OrderCreateViewModel { get; set; } = default!;
    }
}