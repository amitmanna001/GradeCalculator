using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradeCalculator.Data;
using GradeCalculator.Models;
using RegistrationLoginDemo.Models;


namespace GradeCalculator.Controllers
{
    public class StudentLoginController : Controller
    {
        private readonly GradeCalculatorContext _context;

        public StudentLoginController(GradeCalculatorContext context)
        {
            _context = context;
        }

        // GET: StudentLogin
        public async Task<IActionResult> Index()
        {
              return View(await _context.StudentLogin.ToListAsync());
        }

        // GET: StudentLogin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GCalculator == null)
            {
                return NotFound();
            }

            var studentLogin = await _context.GCalculator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentLogin == null)
            {
                return NotFound();
            }

            return View(studentLogin);
        }

        // GET: StudentLogin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentLogin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create(StudentLogin studentLogin)
        {
            var status = _context.GCalculator.Where(m => m.Student_Regno == studentLogin.StudentRegno).FirstOrDefault();
            if (status != null)
            {
                return RedirectToAction("Details", "StudentLogin");
            }
            ViewData["loginfailed"] = "Invalid Registration Number";
            return View();
        }
      

        public IActionResult SuccessPage()
        {
            return View();
        }

        public IActionResult FailedPage()
        {
            return View();
        }



        private bool StudentLoginExists(int id)
        {
          return _context.StudentLogin.Any(e => e.Id == id);
        }
    }
}
