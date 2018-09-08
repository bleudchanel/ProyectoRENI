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

            return View("IndicadorForm",viewModel);
        }

        public ActionResult Save(NewIndicadorViewModel newIndicadorViewModel)
        {
            if (newIndicadorViewModel.Indicador.Id == 0)
            {
                newIndicadorViewModel.Indicador.Activo = true;
                _context.IndicadorSet.Add(newIndicadorViewModel.Indicador);
            }
            else
            {
                var indicadorInDb =
                    _context.IndicadorSet.SingleOrDefault(o => o.Id == newIndicadorViewModel.Indicador.Id);
                if (indicadorInDb == null)
                    return HttpNotFound();
                indicadorInDb.Nombre = newIndicadorViewModel.Indicador.Nombre;
                indicadorInDb.UnidadMedidaId = newIndicadorViewModel.Indicador.UnidadMedidaId;
                indicadorInDb.Valor = newIndicadorViewModel.Indicador.Valor;
            }
           
            _context.SaveChanges();
            return RedirectToAction("Index", "Indicador");
        }

        public ActionResult Edit(int id)
        {
            var indicador = _context.IndicadorSet.SingleOrDefault(o => o.Id == id);
            if (indicador == null)
                return HttpNotFound();

            var viewModel = new NewIndicadorViewModel
            {
                Indicador = indicador,
                UnidadesMedida = _context.UnidadMedidaSet.Where(o => o.Activo == true).ToList()
            };

            return View("IndicadorForm", viewModel);
        }

        public ActionResult Delete(Indicador indicador)
        {
            var indicadorCurrent = _context.IndicadorSet.SingleOrDefault(o => o.Id == indicador.Id);
            if (indicadorCurrent == null)
                return HttpNotFound();

            indicadorCurrent.Activo = false;
            _context.SaveChanges();
            return RedirectToAction("Index", "Indicador");

        }
    }
}