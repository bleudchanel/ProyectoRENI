using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestionRENI.Controllers
{
    public class ProgramaMovilidadController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProgramaMovilidadController()
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
            ListProgramaMovilidadViewModel vmProgramas = new ListProgramaMovilidadViewModel();
            vmProgramas.Programas = _context.ProgramaMovilidadSet.Where(o => o.Activo == true).Include(d => d.Convenio).ToList();
            return View(vmProgramas);
        }

        public ActionResult New()
        {
            var convenios = _context.ConvenioSet.Where(d => d.Activo == true && d.ClaseConvenio.Nombre == "MARCO").ToList();
            var viewModel = new ProgramaMovilidadFormViewModel
            {
                Convenios = convenios
            };

            return View("ProgramaMovilidadForm", viewModel);
        }
    }
}