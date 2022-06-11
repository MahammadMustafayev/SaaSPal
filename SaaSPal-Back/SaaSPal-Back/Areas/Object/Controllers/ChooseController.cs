using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SaaSPal_Back.DAL;
using SaaSPal_Back.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaaSPal_Back.Areas.Object.Controllers
{
    [Area("Object")]
    [Authorize]
    public class ChooseController : Controller
    {
        private AppDbContext _context { get;  }
        public ChooseController(AppDbContext context)
        {
            _context = context;  
        }
        public IActionResult Index()
        {
            return View(_context.Chooses.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Choose choose)
        {
            if (choose == null) return BadRequest();
            _context.Chooses.Add(choose);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int id)
        {
            Choose choose = _context.Chooses.FirstOrDefault(x => x.Id == id);
            if (choose == null) return NotFound();
            return View(choose);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Choose choose)
        {
            Choose exsistchoose = _context.Chooses.FirstOrDefault(x => x.Id == choose.Id);
            if (exsistchoose == null)
            {
                ModelState.AddModelError("", "Incorrect");
            }
            exsistchoose.Title = choose.Title;
            exsistchoose.SubTitle = choose.SubTitle;
            exsistchoose.IsDeleted = choose.IsDeleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int id)
        {
            _context.Chooses.Find(id);
            _context.Chooses.FirstOrDefault(x => x.IsDeleted == true);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            
        }
    }
}
