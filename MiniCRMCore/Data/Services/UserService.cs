using MiniCRMCore.Data.Services.Interfaces;
using MiniCRMCore.Models;

namespace MiniCRMCore.Data.Services
{
    public class UserService : IUserService
    {
        private readonly MiniCRMDbContext _context;
        public UserService
            (MiniCRMDbContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public bool IfExist(User obj)
        {
            return _context.Users.ToHashSet().Contains(obj);
        }
    }
}
