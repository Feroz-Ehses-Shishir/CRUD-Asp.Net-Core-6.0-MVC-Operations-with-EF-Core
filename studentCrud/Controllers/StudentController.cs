using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentCrud.DB;
using studentCrud.Models.DomainModel;

namespace studentCrud.Controllers
{
    public class StudentController : Controller
    {
        private readonly appDbContext db;

        public StudentController(appDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(student x)
        {
            var k = new student()
            {
                Id = Guid.NewGuid(),
                Name = x.Name,
                StudentId = x.StudentId,
                Department = x.Department
            };

            await db.AddAsync(k);
            await db.SaveChangesAsync();

            return RedirectToAction("Show");
        }

        [HttpGet]
        public async Task<IActionResult> Show() 
        {
            var x = await db.students.ToListAsync();

            return View(x);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid Id)
        {
            var x = await db.students.FindAsync(Id);

            return View(x);
        }

        [HttpPost]
        public async Task<IActionResult> Update(student x)
        {
            var k = await db.students.FindAsync(x.Id);

            k.Id = x.Id;
            k.Name = x.Name;
            k.StudentId = x.StudentId;
            k.Department = x.Department;

            await db.SaveChangesAsync();

            return RedirectToAction("Show");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var x = await db.students.FindAsync(Id);
            db.students.Remove(x);
            await db.SaveChangesAsync();

            return RedirectToAction("Show");
        }
    }
}