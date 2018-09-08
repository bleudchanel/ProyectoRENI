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
            return View("UnidadMedidaForm");
        }

        public ActionResult Save(UnidadMedida unidadMedida)
        {
            if (unidadMedida.Id == 0)
            {
                unidadMedida.Activo = true;
                _context.UnidadMedidaSet.Add(unidadMedida);
            }
            else
            {
                var unidadMedidaInDb =
                    _context.UnidadMedidaSet.SingleOrDefault(o => o.Id == unidadMedida.Id);
                if (unidadMedidaInDb == null)
                    return HttpNotFound();
                unidadMedidaInDb.Nombre = unidadMedida.Nombre;
                unidadMedidaInDb.Descripcion = unidadMedida.Descripcion;
                //unidadMedidaInDb.Valor = newIndicadorViewModel.Indicador.Valor;
            }

            //_context.SaveChanges();

            //unidadMedida.Activo = true;
            //_context.UnidadMedidaSet.Add(unidadMedida);
            _context.SaveChanges();
            return RedirectToAction("Index", "UnidadMedida");
        }

        public ActionResult Delete(int Id)
        {
            var unidadMedida = _context.UnidadMedidaSet.SingleOrDefault(o => o.Id == Id);
            if (unidadMedida == null)
                return HttpNotFound();

            unidadMedida.Activo = false;
            _context.SaveChanges();
            return RedirectToAction("Index","UnidadMedida");
        }

        public ActionResult Edit(int id)
        {
            var unidadMedida = _context.UnidadMedidaSet.SingleOrDefault(o => o.Id == id);
            if (unidadMedida == null)
                return HttpNotFound();

            return View("UnidadMedidaForm", unidadMedida);
        }
    }
}