using MiniCRMCore.Interfaces;
using MiniCRMCore.Interfaces.IServices;
using MiniCRMCore.Models;

namespace MiniCRMCore.Data
{
    public class RepositoryUser : IRepository<User>, ICRUDService<User> 
    {

        private readonly MiniCRMDbContext _context;
        
        public RepositoryUser(MiniCRMDbContext context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            if(entity != null)
            {
                if(_context.Users.FirstOrDefault(x=>x.Id == entity.Id) == null)
                {
                    _context.Users.Add(entity);
                }
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            if (id > 0)
            {
                var entity = _context.Users.FirstOrDefault(x => x.Id == id);
                if( entity != null)
                {
                    _context.Users.Remove(entity);
                }
            }
            
        }

        public void Update(User entity)
        {
            if (entity != null)
            {
                if( entity.Id > 0 )
                {
                    if(_context.Users.FirstOrDefault(x=>x.Id == entity.Id) != null)
                    {
                        _context.Users.Update(entity);
                    }
                }
            }
            _context.SaveChanges();
        }
    }
}
