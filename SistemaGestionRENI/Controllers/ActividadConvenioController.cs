using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security.Provider;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI.Controllers
{
    public class ActividadConvenioController : Controller
    {
        private ApplicationDbContext _context;

        public ActividadConvenioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New(int Id)
        {
            var indicadores = _context.IndicadorSet.Where(o => o.Activo == true).ToList();
            var tiposActividad = _context.TipoActividadConvenioSet.Where(o => o.Activo == true).ToList();
            var viewModel = new ActividadConvenioViewModel()
            {
                ConvenioId = Id,
                Indicadores = indicadores,
                TiposActividad = tiposActividad
            };

            return View("ActividadConvenioForm", viewModel);
        }

        public ActionResult Save(ActividadConvenioViewModel actividadConvenioViewModel)
        {
            ModelState["ActividadConvenio.Id"].Errors.Clear();
            if (!ModelState.IsValid)
            {
                var indicadores = _context.IndicadorSet.Where(o => o.Activo == true).ToList();
                var tiposActividad = _context.TipoActividadConvenioSet.Where(o => o.Activo == true).ToList();
                actividadConvenioViewModel.Indicadores = indicadores;
                actividadConvenioViewModel.TiposActividad = tiposActividad;
                return View("ActividadConvenioForm", actividadConvenioViewModel);
            }


            if (actividadConvenioViewModel.ActividadConvenio.Id == 0)
            {
                actividadConvenioViewModel.ActividadConvenio.Activo = true;
                actividadConvenioViewModel.ActividadConvenio.ConvenioId = actividadConvenioViewModel.ConvenioId;
                _context.ActividadConvenioSet.Add(actividadConvenioViewModel.ActividadConvenio);
            }
            else
            {
                var actividadInDb =
                    _context.ActividadConvenioSet.SingleOrDefault(o => o.Id == actividadConvenioViewModel.ActividadConvenio.Id);
                if (actividadInDb == null)
                    return HttpNotFound();
                actividadInDb.Nombre = actividadConvenioViewModel.ActividadConvenio.Nombre;
                actividadInDb.Descripcion = actividadConvenioViewModel.ActividadConvenio.Descripcion;
                actividadInDb.Observaciones = actividadConvenioViewModel.ActividadConvenio.Observaciones;
                actividadInDb.Fecha = actividadConvenioViewModel.ActividadConvenio.Fecha;
                actividadInDb.TipoActividadConvenioId = actividadConvenioViewModel.ActividadConvenio.TipoActividadConvenioId;
                actividadInDb.IndicadorId = actividadConvenioViewModel.ActividadConvenio.IndicadorId;
                actividadInDb.Avance = actividadConvenioViewModel.ActividadConvenio.Avance;
                actividadInDb.ConvenioId = actividadConvenioViewModel.ActividadConvenio.ConvenioId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Convenio");
        }

        public ActionResult Delete(int Id)
        {
            var convenio = _context.ActividadConvenioSet.SingleOrDefault(o => o.Id == Id);
            if (convenio != null)
            {
                convenio.Activo = false;
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Convenio");
        }

        public ActionResult Edit(int Id, int ConvenioIdMaster)
        {
            var actividadConvenio = _context.ActividadConvenioSet.SingleOrDefault(d => d.Id == Id);
            if (actividadConvenio == null)
                return HttpNotFound();

            var viewModel = new ActividadConvenioViewModel()
            {
                ActividadConvenio = actividadConvenio,
                TiposActividad = _context.TipoActividadConvenioSet.Where(o => o.Activo == true).ToList(),
                Indicadores = _context.IndicadorSet.Where(o => o.Activo == true).ToList(),
                ConvenioId = ConvenioIdMaster
            };

            return View("ActividadConvenioForm", viewModel);
        }

        //// GET: AcitvidadConvenio
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}