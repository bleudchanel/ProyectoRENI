using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestionRENI.Controllers
{
    public class ConvenioController : Controller
    {
        private ApplicationDbContext _context;

        public ConvenioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Convenio
        public ActionResult Index()
        {
            ListCoveniosViewModel vmConvenios = new ListCoveniosViewModel();
            vmConvenios.Convenios = _context.ConvenioSet.Where(o => o.Activo == true).ToList();
            return View(vmConvenios);
        }
    }
}