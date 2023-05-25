using Business_Layer;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data_Layer
{
    public class DBContext : DbContext
    {
        public DBContext()
        {

        }
        public DBContext(DbContextOptions options): base(options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-GK4F9OM\\SQLEXPRESS ;Database=YordanGeorgievDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       public  DbSet<Category> Categories { get; set; }
       public  DbSet<Interest> Interests { get; set; }
       public DbSet<User> Users { get; set; }
      

    }
}
