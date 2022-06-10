using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaaSPal_Back.DAL;
using SaaSPal_Back.Models;
using SaaSPal_Back.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SaaSPal_Back.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Chooses = _context.Chooses.Take(6).ToList()
            };
            return View(homeVM);
        }

        

        
    }
}
