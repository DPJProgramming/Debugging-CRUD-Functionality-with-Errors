using CPW219_CRUD_Troubleshooting.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CPW219_CRUD_Troubleshooting.Controllers
{
    public class StudentsController : Controller
    {
        private readonly SchoolContext context;

        public StudentsController(SchoolContext dbContext)
        {
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> products = StudentDb.GetStudents(context);
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student p)
        {
            if (ModelState.IsValid)
            {
                StudentDb.Add(p, context); 
                ViewData["Message"] = $"{p.Name} was added!";
                return View(); 
            }

            //Show web page with errors
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            //get the product by id
            Student p = StudentDb.GetStudent(context, id);

            //show it on web page
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Student p)
        {
            if (ModelState.IsValid)
            {
                StudentDb.Update(context, p);
                ViewData["Message"] = $"{p.Name} Updated!";
                return View();
            }
            //return view with errors
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student p = StudentDb.GetStudent(context, id);
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            //Get Student from database
            Student p = StudentDb.GetStudent(context, id);

            StudentDb.Delete(context, p);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id) {
            Student p = StudentDb.GetStudent(context, id);
            return View(p);
        }
    }
}
