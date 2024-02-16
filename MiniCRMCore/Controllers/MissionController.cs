using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCRMCore.Data.Services.Interfaces;
using MiniCRMCore.Data.Services;
using MiniCRMCore.Data;
using MiniCRMCore.Interfaces;
using MiniCRMCore.Models;
using System.Reflection;

namespace MiniCRMCore.Controllers
{
    public class MissionController : Controller
    {
        private readonly IMissionService _missonService;
        private readonly IRepository<Mission> missionRepository; 
        public MissionController(MiniCRMDbContext db)
        {
            _missonService = new MissionService(db);
            missionRepository = new RepositoryMission(db,_missonService);
        }
        public ActionResult Index()
        {
            return View(_missonService.GetAll());
        }

        public ActionResult Details(int id)
        {
            return View(_missonService.GetById(id));
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Create(Mission mission)
        {
            missionRepository.Create(mission);
            return View("Index");
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id)
        {
            missionRepository.Update(_missonService.GetById(id));
            return View("Index");
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            missionRepository.Delete(id);
            return View("Index");
        }
    }
}
