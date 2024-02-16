using MiniCRMCore.Interfaces;
using MiniCRMCore.Interfaces.IServices;
using MiniCRMCore.Models; 

namespace MiniCRMCore.Data
{
    public class RepositoryEmployee : IRepository<Employee>, ICRUDService<Employee>
    {
        private readonly MiniCRMDbContext _context;
        public RepositoryEmployee(MiniCRMDbContext context)
        {
            _context = context;
        }
        public void Create(Employee entity)
        {
            if (entity != null)
            { 
                if(_context.Employees.FirstOrDefault(
                    x=>x.FullName == entity.FullName &&
                    x.Age == entity.Age &&
                    x.Position == entity.Position) == null)
                    _context.Employees.Add(entity);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            if(id > 0)
            {
                var obj = _context.Employees.FirstOrDefault(x => x.Id == id);
                if ( obj != null)
                {
                    _context.Employees.Remove(obj);
                }
            }
            _context.SaveChanges();
        }

        public void Update(Employee entity)
        {
            if (entity != null)
            {
                if (entity.Id > 0)
                {
                    if (_context.Employees.FirstOrDefault(x => x.Id == entity.Id) != null)
                    {
                        _context.Employees.Update(entity);
                    }
                }
            }
            _context.SaveChanges();
        }
    }
}
