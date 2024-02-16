using Azure.Core.Pipeline;
using Microsoft.EntityFrameworkCore;
using MiniCRMCore.Interfaces;
using MiniCRMCore.Models;

namespace MiniCRMCore.Data
{
    public class MiniCRMDbContext : DbContext, IMiniCRMDbContext
    {
        public MiniCRMDbContext(DbContextOptions<MiniCRMDbContext> options):base(options)
        { }
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        public string ConnectionString
        {
            get
            {
                return Database.GetConnectionString();
            }
   
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Mission> Missions { get; set; }
    }
}
