using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestionRENI.Controllers
{
    public class MovilidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovilidadController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Proponente
        public ActionResult Index()
        {
            ListMovilidadViewModel vmMovilidades = new ListMovilidadViewModel();
            vmMovilidades.Movilidades = _context.MovilidadSet.Where(o => o.Activo == true).Include(d => d.Programa).Include(o => o.Institucion).Include(o => o.Dependencia).ToList();
            return View(vmMovilidades);
        }
    }
}