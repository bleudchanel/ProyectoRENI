using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestionRENI.Controllers
{
    public class DependenciaController : Controller
    {
        private ApplicationDbContext _context;

        public DependenciaController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Dependencia
        public ActionResult Index()
        {
            ListDependenciaViewModel vmDependencias = new ListDependenciaViewModel();
            vmDependencias.Dependencias = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
            return View(vmDependencias);
        }

        [HttpPost]
        public ActionResult Save(Dependencia dependencia)
        {
            if (dependencia.Id == 0)
            {
                dependencia.Activo = true;
                _context.DependenciaSet.Add(dependencia);
            }
            else
            {
                var dependenciaInDb =
                    _context.DependenciaSet.SingleOrDefault(o => o.Id == dependencia.Id);
                if (dependenciaInDb == null)
                    return HttpNotFound();
                dependenciaInDb.Nombre = dependencia.Nombre;
                //dependenciaInDb.EsInterno = dependencia.EsInterno;
                dependenciaInDb.Abrev = dependencia.Abrev;
                //dependenciaInDb.Activo = dependencia.Pais;
            }

            //dependencia.Estado = true;
            //_context.DependenciaSet.Add(dependencia);
            _context.SaveChanges();
            return RedirectToAction("Index", "Dependencia");
        }

        public ActionResult New()
        {
            return View("DependenciaForm");
        }

        public ActionResult Edit(Dependencia dependencia)
        {
            var current = _context.DependenciaSet.SingleOrDefault(o => o.Id == dependencia.Id);
            if (current == null)
            {
                return HttpNotFound();
            }            
            return View("DependenciaForm", current);
        }

        public ActionResult Delete(Dependencia dependencia)
        {
            var condicion = _context.DependenciaSet.SingleOrDefault(o => o.Id == dependencia.Id);
            if (condicion != null)
            {
                condicion.Activo = false;
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Dependencia");
        }
    }
}