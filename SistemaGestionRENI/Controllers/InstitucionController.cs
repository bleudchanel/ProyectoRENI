using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI.Controllers
{
    public class InstitucionController : Controller
    {
        private ApplicationDbContext _context;

        public InstitucionController()
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
            ListInstitucionViewModel vmInstitucion = new ListInstitucionViewModel();
            vmInstitucion.Instituciones = _context.InstitucionSet.Where(o => o.Activo == true).ToList();
            return View(vmInstitucion);
        }

        [HttpPost]
        public ActionResult Save(Institucion institucion)
        {
            if (institucion.Id == 0)
            {
                institucion.Activo = true;
                _context.InstitucionSet.Add(institucion);
            }
            else
            {
                var institucionInDb =
                    _context.InstitucionSet.SingleOrDefault(o => o.Id == institucion.Id);
                if (institucionInDb == null)
                    return HttpNotFound();
                institucionInDb.Nombre = institucion.Nombre;
                //dependenciaInDb.EsInterno = institucion.EsInterno;
                institucionInDb.Abrev = institucion.Abrev;
                institucionInDb.Ubicacion = institucion.Ubicacion;
                institucionInDb.EsPrivado = institucion.EsPrivado;
                institucionInDb.ActividadInstitucion = institucion.ActividadInstitucion;
                //dependenciaInDb.Activo = institucion.Pais;
            }

            //institucion.Estado = true;
            //_context.DependenciaSet.Add(institucion);
            _context.SaveChanges();
            return RedirectToAction("Index", "Institucion");
        }

        public ActionResult New()
        {
            return View("InstitucionForm");
        }

        public ActionResult Edit(Institucion institucion)
        {
            var current = _context.InstitucionSet.SingleOrDefault(o => o.Id == institucion.Id);
            if (current == null)
            {
                return HttpNotFound();
            }
            return View("InstitucionForm", current);
        }

        public ActionResult Delete(Institucion institucion)
        {
            var current = _context.InstitucionSet.SingleOrDefault(o => o.Id == institucion.Id);
            if (current != null)
            {
                current.Activo = false;
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Institucion");
        }

    }
}