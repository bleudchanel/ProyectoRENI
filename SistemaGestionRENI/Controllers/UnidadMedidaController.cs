using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestionRENI.Controllers
{
    public class UnidadMedidaController : Controller
    {
        private ApplicationDbContext _context;

        public UnidadMedidaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: UnidadMedida
        public ActionResult Index()
        {
            ListUnidadMedidaViewModel vm = new ListUnidadMedidaViewModel();
            var unidadesMedida = _context.UnidadMedidaSet.Where(o => o.Activo == true).ToList();
            vm.UnidadesMedida = unidadesMedida;
            return View(vm);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Save(UnidadMedida unidadMedida)
        {
            unidadMedida.Activo = true;
            _context.UnidadMedidaSet.Add(unidadMedida);
            _context.SaveChanges();
            return RedirectToAction("Index", "UnidadMedida");
        }
    }
}