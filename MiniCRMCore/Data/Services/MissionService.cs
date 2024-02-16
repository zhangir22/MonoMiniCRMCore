using MiniCRMCore.Models;
using MiniCRMCore.Interfaces.IServices;
using MiniCRMCore.Data.Services.Interfaces;

namespace MiniCRMCore.Data.Services
{
    public class MissionService : IMissionService
    {
        private readonly MiniCRMDbContext _context;
        public MissionService(MiniCRMDbContext context) { _context = context; }
        public List<Mission> GetAll()
        {
            return _context.Missions.ToList();
        }

        public Mission GetById(int id)
        {
            return _context.Missions.FirstOrDefault(x => x.Id == id);
        }

        public bool IfExist(Mission obj)
        {
            return _context.Missions.Contains(obj);
        }
    }
}
