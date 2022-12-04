using System.Reflection;
using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using WebAPi.Models;

namespace WebAPi.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Account>  Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<RequestItem> RequestItems { get; set; }
        public DbSet<ReturnItem> ReturnItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(a => a.Accounts)
                .WithOne(b => b.User)
                .HasForeignKey<Account>(b => b.Id);

            modelBuilder.Entity<Department>()
                .HasMany(a => a.Users)
                .WithOne(b => b.Departments);

            modelBuilder.Entity<AccountRole>()
                .HasKey(ar => new { ar.AccountId, ar.RoleId });
            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Accounts)
                .WithMany(a => a.AccountRoles)
                .HasForeignKey(ar => ar.AccountId);
            modelBuilder.Entity<AccountRole>()
                .HasOne(ar => ar.Role)
                .WithMany(r => r.AccountRoles)
                .HasForeignKey(ar => ar.RoleId);

            modelBuilder.Entity<RequestItem>()
                .HasOne(a => a.Accounts)
                .WithMany(ri => ri.RequestItems)
                .HasForeignKey(a => a.UserId);
            modelBuilder.Entity<RequestItem>()
                .HasOne(i => i.Items)
                .WithMany(r => r.RequestItems)
                .HasForeignKey(i => i.ItemId);

            modelBuilder.Entity<Status>()
                .HasMany(a => a.RequestItems)
                .WithOne(b => b.Status);

            modelBuilder.Entity<Category>()
                .HasMany(a => a.Items)
                .WithOne(b => b.Categories);

            modelBuilder.Entity<ReturnItem>()
                .HasOne(a => a.RequestItems)
                .WithOne(b => b.ReturnItems)
                .HasForeignKey<ReturnItem>(b => b.RequestItemId);

        }
    }
}
