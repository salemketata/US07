using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using US07.Models;

namespace US07.Controllers
{
    public class UltrasSfaxiensController : Controller
    {
        private ApplicationDbContext _context;

        public UltrasSfaxiensController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: UltrasSfaxiens
        public ActionResult Index()
        {
            return View();
        }
    }
}