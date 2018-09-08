using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI.Controllers
{
    public class ProgramaConvenioController : Controller
    {

        private ApplicationDbContext _context;

        public ProgramaConvenioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New(int Id)
        {
            //var indicadores = _context.IndicadorSet.Where(o => o.Activo == true).ToList();
            //var tiposActividad = _context.TipoActividadConvenioSet.Where(o => o.Activo == true).ToList();
            var dependencias = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
            var instituciones = _context.InstitucionSet.Where(o => o.Activo == true).ToList();
            var tipos = _context.TipoProgramaSet.Where(o => o.Activo == true).ToList();
            var viewModel = new ProgramaConvenioViewModel()
            {
                ConvenioId = Id,
                Dependencias = dependencias,
                Instituciones = instituciones,
                TiposPrograma = tipos
            };

            return View("ProgramaConvenioForm", viewModel);
        }

        public ActionResult Save(ProgramaConvenioViewModel programaConvenioView)
        {
            ModelState["ProgramaConvenio.Id"].Errors.Clear();
            if (!ModelState.IsValid)
            {
                var dependencias = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
                var instituciones = _context.InstitucionSet.Where(o => o.Activo == true).ToList();
                var tipos = _context.TipoProgramaSet.Where(o => o.Activo == true).ToList();
                programaConvenioView.Dependencias = dependencias;
                programaConvenioView.Instituciones = instituciones;
                programaConvenioView.TiposPrograma = tipos;
                return View("ProgramaConvenioForm", programaConvenioView);
            }


            if (programaConvenioView.ProgramaConvenio.Id == 0)
            {
                programaConvenioView.ProgramaConvenio.Activo = true;
                programaConvenioView.ProgramaConvenio.ConvenioId = programaConvenioView.ConvenioId;
                _context.ProgramaConvenioSet.Add(programaConvenioView.ProgramaConvenio);
            }
            else
            {
                var programaInDb =
                    _context.ProgramaConvenioSet.SingleOrDefault(o => o.Id == programaConvenioView.ProgramaConvenio.Id);
                if (programaInDb == null)
                    return HttpNotFound();
                programaInDb.Nombres = programaConvenioView.ProgramaConvenio.Nombres;
                programaInDb.DocumentoIdentidad = programaConvenioView.ProgramaConvenio.DocumentoIdentidad;
                programaInDb.InstitucionId = programaConvenioView.ProgramaConvenio.InstitucionId;
                programaInDb.DependenciaId = programaConvenioView.ProgramaConvenio.DependenciaId;
                programaInDb.ProgramaMovEst = programaConvenioView.ProgramaConvenio.ProgramaMovEst;
                programaInDb.TipoProgramaId = programaConvenioView.ProgramaConvenio.TipoProgramaId;
                //programaInDb.IndicadorId = programaConvenioView.ProgramaConvenio.IndicadorId;
                //programaInDb.Avance = programaConvenioView.ProgramaConvenio.Avance;
                programaInDb.ConvenioId = programaConvenioView.ConvenioId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Convenio");
        }

        public ActionResult Delete(int Id)
        {
            var convenio = _context.ProgramaConvenioSet.SingleOrDefault(o => o.Id == Id);
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
            var programaConvenio = _context.ProgramaConvenioSet.SingleOrDefault(d => d.Id == Id);
            if (programaConvenio == null)
                return HttpNotFound();

            var viewModel = new ProgramaConvenioViewModel()
            {
                ProgramaConvenio = programaConvenio,
                Dependencias = _context.DependenciaSet.Where(o => o.Activo == true).ToList(),
                Instituciones = _context.InstitucionSet.Where(o => o.Activo == true).ToList(),
                TiposPrograma = _context.TipoProgramaSet.Where(o => o.Activo == true).ToList(),
                ConvenioId = ConvenioIdMaster
            };

            return View("ProgramaConvenioForm", viewModel);
        }


    }
}