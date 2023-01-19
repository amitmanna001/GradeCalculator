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
    public class LoginController : Controller
    {
        private readonly GradeCalculatorContext _context;

        public LoginController(GradeCalculatorContext context)
        {
            _context = context;
        }


        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Login login)
        {

            var status = _context.Registration.Where(m => m.Email == login.Email && m.Password == login.Password).FirstOrDefault();

            if (status != null)
            {

                 return RedirectToAction("SuccessPage", "Login");

            }

            ViewData["loginfailed"] = "Invalid Email or Password";
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



        private bool LoginExists(int id)
        {
          return _context.Login.Any(e => e.loginid == id);
        }
    }
}
