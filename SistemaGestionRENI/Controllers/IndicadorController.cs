using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI.Controllers
{
    public class IndicadorController : Controller
    {
        private ApplicationDbContext _context;

        public IndicadorController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Indicador
        public ActionResult Index()
        {
            ListIndicadorViewModel vm = new ListIndicadorViewModel();
            vm.Indicadores = _context.IndicadorSet.Include(i => i.UnidadMedida).Where(o => o.Activo == true).ToList();
            return View(vm);
        }

        public ActionResult New()
        {
            var unidadesMedida = _context.UnidadMedidaSet.Where(d => d.Activo == true).ToList();
            var viewModel = new NewIndicadorViewModel
            {
                UnidadesMedida = unidadesMedida
            };

            return View(viewModel);
        }

        public ActionResult Save(NewIndicadorViewModel newIndicadorViewModel)
        {
            newIndicadorViewModel.Indicador.Activo = true;
            _context.IndicadorSet.Add(newIndicadorViewModel.Indicador);
            _context.SaveChanges();
            return RedirectToAction("Index", "Indicador");
        }
    }
}