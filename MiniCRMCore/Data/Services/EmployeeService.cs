using MiniCRMCore.Data.Services.Interfaces;
using MiniCRMCore.Interfaces.IServices;
using MiniCRMCore.Models;

namespace MiniCRMCore.Data.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly MiniCRMDbContext _context;
        public EmployeeService(MiniCRMDbContext context) { _context = context; }
        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.SingleOrDefault(x => x.Id == id);
        }

        public bool IfExist(Employee obj)
        {
            return _context.Employees.ToHashSet().Contains(obj);
        }
    }
}
