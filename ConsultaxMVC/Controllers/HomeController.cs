using ConsultaxMVC.Data;
using ConsultaxMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConsultaxMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ConsultaxTable _context;
        public HomeController(ILogger<HomeController> logger, ConsultaxTable context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["project"] = _context.AllProjects.ToList();
            ViewData["service"] = _context.AllServices.ToList();
            ViewData["altSection"] = _context.AltSections.ToList();
            ViewData["blog"] = _context.Blogs.Include(x=>x.Category).ToList();
            ViewData["secOne"] = _context.SectionOnes.ToList();
            ViewData["testim"] = _context.Testimonials.ToList();
            ViewData["who"] = _context.whoWeAres.ToList();
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
