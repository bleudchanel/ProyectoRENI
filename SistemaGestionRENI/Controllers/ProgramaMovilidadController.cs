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
            vmProgramas.Programas = _context.ProgramaMovilidadSet.Where(o => o.Activo == true).Include(d => d.Convenio).Include(d => d.Convenio.DependenciaConvenio).Include(d => d.Convenio.Institucion).ToList();
            foreach(var prog in vmProgramas.Programas)
            {
                if(prog.Convenio.DependenciaConvenio == null)
                {
                    prog.Convenio.DependenciaConvenio = new Dependencia() { Abrev = "No Seleccionado" };
                }

                if (prog.Convenio.Institucion == null)
                {
                    prog.Convenio.Institucion = new Institucion() { Abrev = "No Seleccionado" };
                }
            }
            return View(vmProgramas);
        }

        public ActionResult New()
        {
            var convenios = _context.ConvenioSet.Where(d => d.Activo == true && d.ClaseConvenio.Nombre == "MARCO" && d.AdmiteProgramaMov == true).ToList();
            //var tiposPrograma = _context.TipoProgramaSet.Where()
            var viewModel = new ProgramaMovilidadFormViewModel
            {
                Convenios = convenios
            };

            return View("ProgramaMovilidadForm", viewModel);
        }

        public ActionResult Save(ProgramaMovilidadFormViewModel programaMovilidadViewModel)
        {
            ModelState["ProgramaMovilidad.Id"].Errors.Clear();
            if (!ModelState.IsValid)
            {
                var convenios = _context.ConvenioSet.Where(d => d.Activo == true && d.ClaseConvenio.Nombre == "MARCO" && d.AdmiteProgramaMov == true).ToList();
                //var tiposActividad = _context.TipoActividadConvenioSet.Where(o => o.Activo == true).ToList();
                programaMovilidadViewModel.Convenios = convenios;
                //programaMovilidadViewModel.TiposActividad = tiposActividad;
                return View("ProgramaMovilidadForm", programaMovilidadViewModel);
            }


            if (programaMovilidadViewModel.ProgramaMovilidad.Id == 0)
            {
                programaMovilidadViewModel.ProgramaMovilidad.Activo = true;
                programaMovilidadViewModel.ProgramaMovilidad.ConvenioId = programaMovilidadViewModel.ProgramaMovilidad.ConvenioId;
                _context.ProgramaMovilidadSet.Add(programaMovilidadViewModel.ProgramaMovilidad);
            }
            else
            {
                var programaMovilidadInDb =
                    _context.ProgramaMovilidadSet.SingleOrDefault(o => o.Id == programaMovilidadViewModel.ProgramaMovilidad.Id);
                if (programaMovilidadInDb == null)
                    return HttpNotFound();
                programaMovilidadInDb.Nombre = programaMovilidadViewModel.ProgramaMovilidad.Nombre;
                programaMovilidadInDb.Descripcion = programaMovilidadViewModel.ProgramaMovilidad.Descripcion;
                programaMovilidadInDb.FechaCreacion = programaMovilidadViewModel.ProgramaMovilidad.FechaCreacion;
                //programaMovilidadInDb.TipoActividadConvenioId = programaMovilidadViewModel.ProgramaMovilidad.ConvenioId;
                //programaMovilidadInDb.IndicadorId = programaMovilidadViewModel.ProgramaMovilidad.IndicadorId;
                //programaMovilidadInDb.Avance = programaMovilidadViewModel.ProgramaMovilidad.Avance;
                programaMovilidadInDb.ConvenioId = programaMovilidadViewModel.ProgramaMovilidad.ConvenioId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "ProgramaMovilidad");
        }

        public ActionResult Edit(int Id, int ConvenioId)
        {
            var programaMovilidad = _context.ProgramaMovilidadSet.SingleOrDefault(d => d.Id == Id);
            if (programaMovilidad == null)
                return HttpNotFound();

            var viewModel = new ProgramaMovilidadFormViewModel()
            {
                ProgramaMovilidad = programaMovilidad,
                Convenios = _context.ConvenioSet.Where(d => d.Activo == true && d.ClaseConvenio.Nombre == "MARCO" && d.AdmiteProgramaMov == true).ToList()
            };

            return View("ProgramaMovilidadForm", viewModel);
        }

        public ActionResult Delete(int Id)
        {
            var programaConvenio = _context.ProgramaMovilidadSet.SingleOrDefault(o => o.Id == Id);
            if (programaConvenio != null)
            {
                programaConvenio.Activo = false;
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "ProgramaMovilidad");
        }


        public ActionResult Details(int id)
        {
            var programaMovilidad = _context.ProgramaMovilidadSet.Include(d => d.Convenio)
                .Include(d => d.Convenio.DependenciaConvenio).Include(d => d.Convenio.Institucion).SingleOrDefault(o => o.Id == id);
            if (programaMovilidad == null)
                return HttpNotFound();
            if (programaMovilidad.Convenio.DependenciaConvenio == null)
                programaMovilidad.Convenio.DependenciaConvenio = new Dependencia() { Nombre = "No especificado"};
           
            if (programaMovilidad.Convenio.Institucion == null)
                programaMovilidad.Convenio.Institucion = new Institucion { Nombre = "No Seleccionado" };
            
            var viewModel = new DetailProgramaConvenioViewModel()
            {
                ProgramaMovilidad = programaMovilidad,
                Movilidades = _context.MovilidadSet.Where(o => o.ProgramaId == id && o.Activo == true).ToList()
                // Programas = _context.ProgramaConvenioSet.Where(o => o.ConvenioId == id && o.Activo == true).Include(o => o.Institucion).Include(o => o.Dependencia).Include(o => o.TipoPrograma).ToList()

            };

            foreach (var movilidad in viewModel.Movilidades)
            {
                //if (movilidad.Indicador == null)
                //    movilidad.Indicador = new Indicador()
                //    {
                //        Nombre = "No Seleccionado",
                //        UnidadMedida = new UnidadMedida() { Nombre = "No Seleccionado" }
                //    };
            }


            return View(viewModel);
        }

    }
}