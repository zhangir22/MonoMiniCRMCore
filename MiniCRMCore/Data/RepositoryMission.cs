using MiniCRMCore.Interfaces;
using MiniCRMCore.Interfaces.IServices;
using MiniCRMCore.Models;

namespace MiniCRMCore.Data
{
    public class RepositoryMission : IRepository<Mission>, ICRUDService<Mission>
    {
        private readonly MiniCRMDbContext _context;
        IService<Mission > _service;
        public RepositoryMission(MiniCRMDbContext context, IService<Mission> service)
        {
            _context = context;
            _service = service;
        } 
        public void Create(Mission entity)
        {
            if(entity != null) 
            {
                if(_context.Missions.FirstOrDefault(x=>x.Title == entity.Title) == null)
                {
                    _context.Missions.Add(entity);
                }
            }
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            if(id > 0) 
            {
                var obj = _service.GetById(id);
                if(obj != null)
                {
                    _context.Missions.Remove(obj);
                }
            }
            _context.SaveChanges();

        }

        public void Update(Mission entity)
        {
            if(entity != null)
            {
                if(_service.GetById(entity.Id) != null)
                {
                    _context.Missions.Update(entity);
                }
            }
            _context.SaveChanges();
        }
    }
}
