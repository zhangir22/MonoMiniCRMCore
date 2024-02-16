using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniCRMCore.Data;
using MiniCRMCore.Data.Services;
using MiniCRMCore.Data.Services.Interfaces;
using MiniCRMCore.Interfaces;
using MiniCRMCore.Models;

namespace MiniCRMCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRepository<Employee> _employeeRepository; 
        public EmployeeController(MiniCRMDbContext db) 
        {
            _employeeService = new EmployeeService(db);
            _employeeRepository = new RepositoryEmployee(db);
        }
        public ActionResult Index()
        {
            return View(_employeeService.GetAll());
        }
         
        public ActionResult Details(int id)
        {
            return View(_employeeService.GetById(id));
        }

        // GET: HomeController1/Create
        public ActionResult Create()
        {
            return View();
        } 
        [HttpPost]

        public ActionResult Create(Employee employee)
        {
            _employeeRepository.Create(employee);
            return View("Index");
        }
         
        public ActionResult Edit()
        {
            return View();
        }
         
        [HttpPost] 
        public ActionResult Edit(int id)
        {
            _employeeRepository.Update(_employeeService.GetById(id));
            return View("Index");
        }
         
        public ActionResult Delete()
        {
            return View();
        }
         
        [HttpPost] 
        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return View("Index");
        }
    }
}
