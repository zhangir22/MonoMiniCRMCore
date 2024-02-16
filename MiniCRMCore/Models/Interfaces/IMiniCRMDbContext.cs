using Microsoft.EntityFrameworkCore;
using MiniCRMCore.Models;

namespace MiniCRMCore.Interfaces
{
    public interface IMiniCRMDbContext
    {
        string ConnectionString { get;}
        DbSet<User> Users { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Mission> Missions { get; set; }
        int SaveChanges(); 

    }
}
