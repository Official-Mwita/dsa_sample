using DSA.Data;
using DSA.Models;
using Microsoft.AspNetCore.Mvc;

namespace DSA.Controllers
{
    public class StudentController : Controller
    {
        private ApplicationDbContext _db;

        public StudentController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Student student)
        {
            if (ModelState.IsValid)
            {
                _db.Student_DSA.Add(student);
                TempData["Success"] = student.FirstName + " added successfully"; //Important to display one time message for any action
                _db.SaveChanges();

                return RedirectToAction("Students", "Home");
            }
            return View();
        }

    }
}
