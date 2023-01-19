using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradeCalculator.Data;
using RegistrationLoginDemo.Models;

namespace GradeCalculator.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly GradeCalculatorContext _context;

        public RegistrationController(GradeCalculatorContext context)
        {
            _context = context;
        }

        

       

        // GET: Registration/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Registration/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,Password,ConfirmPassword,Email")] Registration registration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registration);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create","Login");
            }
            return View(registration);
        }


        private bool RegistrationExists(int id)
        {
          return _context.Registration.Any(e => e.UserId == id);
        }


        public JsonResult IsRegisterEmailExist(string? EmailId)
        {
            return Json(data: !_context.Registration.Any(e => e.Email == EmailId));
        }
    }
}
