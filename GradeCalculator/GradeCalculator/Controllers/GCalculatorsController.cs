using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GradeCalculator.Data;
using GradeCalculator.Models;
using Microsoft.AspNetCore.Hosting;

namespace GradeCalculator.Controllers
{
    public class GCalculatorsController : Controller
    {
        private readonly GradeCalculatorContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GCalculatorsController(GradeCalculatorContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: GCalculators
        public async Task<IActionResult> Index()
        {
              return View(await _context.GCalculator.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? SearchRegno)
        {
            ViewData["CurrentFilter"] = SearchRegno;
            var query = from b in _context.GCalculator select b;
            
            if (SearchRegno != null)
            {
                query = query.Where(b => b.Student_Regno == SearchRegno);

            }     
            
            return View(query);
        }

        // GET: GCalculators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GCalculator == null)
            {
                return NotFound();
            }

            var gCalculator = await _context.GCalculator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gCalculator == null)
            {
                return NotFound();
            }

            return View(gCalculator);
        }

        // GET: GCalculators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GCalculators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Student_Regno,Student_Name,Student_Dept,Subject1_Mark,Subject2_Mark,Subject3_Mark,Total_Mark,Average_Mark,Grade,ImageFile")] GCalculator gCalculator)
        {
            if (ModelState.IsValid)
            {
                gCalculator.Total_Mark = gCalculator.Subject1_Mark + gCalculator.Subject2_Mark + gCalculator.Subject3_Mark;
                gCalculator.Average_Mark = (gCalculator.Total_Mark) / 3;

                if (gCalculator.Average_Mark >= 75)
                    gCalculator.Grade = 'A';
                else
                    if (gCalculator.Average_Mark >= 65)
                    gCalculator.Grade = 'B';
                else
                     if (gCalculator.Average_Mark >= 55)
                    gCalculator.Grade = 'C';
                else
                        if (gCalculator.Average_Mark >= 45)
                    gCalculator.Grade = 'D';
                else
                    gCalculator.Grade = 'F';

                string wwwRootPath = _hostEnvironment.WebRootPath;
                string filename = Path.GetFileNameWithoutExtension(gCalculator.ImageFile.FileName);
                string extension = Path.GetExtension(gCalculator.ImageFile.FileName);
                gCalculator.Image_Path = filename = filename + extension;
                string path = Path.Combine(wwwRootPath + "/image/", filename);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await gCalculator.ImageFile.CopyToAsync(fileStream);
                }

                _context.Add(gCalculator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gCalculator);
        }

        // GET: GCalculators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GCalculator == null)
            {
                return NotFound();
            }

            var gCalculator = await _context.GCalculator.FindAsync(id);
            if (gCalculator == null)
            {
                return NotFound();
            }
            return View(gCalculator);
        }

        // POST: GCalculators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Student_Regno,Student_Name,Student_Dept,Subject1_Mark,Subject2_Mark,Subject3_Mark,Total_Mark,Average_Mark,Grade,ImageFile")] GCalculator gCalculator)
        {
            if (id != gCalculator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    gCalculator.Total_Mark = gCalculator.Subject1_Mark + gCalculator.Subject2_Mark + gCalculator.Subject3_Mark;
                    gCalculator.Average_Mark = (gCalculator.Total_Mark) / 3;

                    if (gCalculator.Average_Mark >= 75)
                        gCalculator.Grade = 'A';
                    else
                        if (gCalculator.Average_Mark >= 65)
                        gCalculator.Grade = 'B';
                    else
                         if (gCalculator.Average_Mark >= 55)
                        gCalculator.Grade = 'C';
                    else
                            if (gCalculator.Average_Mark >= 45)
                        gCalculator.Grade = 'D';
                    else
                        gCalculator.Grade = 'F';

                    string wwwRootPath = _hostEnvironment.WebRootPath;
                    string filename = Path.GetFileNameWithoutExtension(gCalculator.ImageFile.FileName);
                    string extension = Path.GetExtension(gCalculator.ImageFile.FileName);
                    gCalculator.Image_Path = filename = filename + extension;
                    string path = Path.Combine(wwwRootPath + "/image/", filename);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await gCalculator.ImageFile.CopyToAsync(fileStream);
                    }

                    _context.Update(gCalculator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GCalculatorExists(gCalculator.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gCalculator);
        }

        // GET: GCalculators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GCalculator == null)
            {
                return NotFound();
            }

            var gCalculator = await _context.GCalculator
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gCalculator == null)
            {
                return NotFound();
            }

            return View(gCalculator);
        }

        // POST: GCalculators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GCalculator == null)
            {
                return Problem("Entity set 'GradeCalculatorContext.GCalculator'  is null.");
            }
            var gCalculator = await _context.GCalculator.FindAsync(id);
            if (gCalculator != null)
            {
                _context.GCalculator.Remove(gCalculator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GCalculatorExists(int id)
        {
          return _context.GCalculator.Any(e => e.Id == id);
        }

        public JsonResult IsStudentRegisterNumberExist(int Student_Regno)
        {
            return Json(data: !_context.GCalculator.Any(e => e.Student_Regno == Student_Regno));
        }

       
    }
}
