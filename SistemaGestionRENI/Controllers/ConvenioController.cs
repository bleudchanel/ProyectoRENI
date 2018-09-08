using SistemaGestionRENI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGestionRENI.ViewModels.Convenios;

namespace SistemaGestionRENI.Controllers
{
    public class ConvenioController : Controller
    {
        private ApplicationDbContext _context;

        public ConvenioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Convenio
        public ActionResult Index()
        {
            ListCoveniosViewModel vmConvenios = new ListCoveniosViewModel();
            vmConvenios.Convenios = _context.ConvenioSet.Where(o => o.Activo == true).Include(c => c.ClaseConvenio).Include(con => con.CondicionConvenio).Include(a => a.AlcanceConvenio).ToList();
            return View(vmConvenios);
        }

        public ActionResult New()
        {
            var indicadores = _context.IndicadorSet.Where(o => o.Activo == true).ToList();
            //if (indicadores == null)
            //    indicadores = new List<Indicador>();
            var dependenciasPrincipal = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
            var instituciones = _context.InstitucionSet.Where(o => o.Activo == true).ToList();
            var clasesConvenio = _context.ClaseConvenioSet.Where(o => o.Activo == true).ToList();
            var condicionesConvenio = _context.CondicionConvenioSet.Where(o => o.Activo == true).ToList();
            var proponentesInterno = _context.ProponenteSet.Where(o => o.Activo == true).ToList();
            var proponentesExterno = _context.ProponenteExternoSet.Where(o => o.Activo == true).ToList();
            var convenios = _context.ConvenioSet.Where(o => o.Activo == true && o.ClaseConvenioId == 1).ToList();
            var dependencias1 = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
            var dependencias2 = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
            var dependencias3 = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
            var alcancesConvenio = _context.AlcanceConvenioSet.Where(o => o.Activo == true).ToList();
            var viewModel = new ConvenioFormViewModel
            {
                Indicadores = indicadores,
                DependenciasPrincipal = dependenciasPrincipal,
                ClasesConvenio = clasesConvenio,
                CondicionesConvenio = condicionesConvenio,
                ProponentesInterno = proponentesInterno,
                ProponentesExterno = proponentesExterno,
                ConveniosPadre = convenios,
                Dependencias1 = dependencias1,
                Dependencias2 = dependencias2,
                Dependencias3 = dependencias3,
                AlcancesConvenios = alcancesConvenio,
                InstitucionesPrincipal = instituciones
            };

            return View("ConvenioForm", viewModel);
        }

        public ActionResult Save(ConvenioFormViewModel convenioFormViewModel)
        {
            ModelState["Convenio.Id"].Errors.Clear();
            if (!ModelState.IsValid)
            {
                convenioFormViewModel.DependenciasPrincipal = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.ClasesConvenio = _context.ClaseConvenioSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.CondicionesConvenio = _context.CondicionConvenioSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.ProponentesInterno = _context.ProponenteSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.ProponentesExterno = _context.ProponenteExternoSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.ConveniosPadre = _context.ConvenioSet.Where(o => o.Activo == true && o.ClaseConvenioId == 1).ToList();
                convenioFormViewModel.Dependencias1 = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.Dependencias2 = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.Dependencias3 = _context.DependenciaSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.AlcancesConvenios = _context.AlcanceConvenioSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.Indicadores = _context.IndicadorSet.Where(o => o.Activo == true).ToList();
                convenioFormViewModel.InstitucionesPrincipal =
                    _context.InstitucionSet.Where(o => o.Activo == true).ToList();
                return View("ConvenioForm", convenioFormViewModel);
            }

            if (convenioFormViewModel.Convenio.Id == 0)
            {
                convenioFormViewModel.Convenio.Activo = true;
                _context.ConvenioSet.Add(convenioFormViewModel.Convenio);
            }
            else
            {
                var convenioInDb =
                    _context.ConvenioSet.SingleOrDefault(o => o.Id == convenioFormViewModel.Convenio.Id);
                if (convenioInDb == null)
                    return HttpNotFound();
                convenioInDb.Nombre = convenioFormViewModel.Convenio.Nombre;
                convenioInDb.AnioFirma = convenioFormViewModel.Convenio.AnioFirma;
                convenioInDb.VigenciaDesde = convenioFormViewModel.Convenio.VigenciaDesde;
                convenioInDb.VigenciaHasta = convenioFormViewModel.Convenio.VigenciaHasta;
                convenioInDb.Objetivo = convenioFormViewModel.Convenio.Objetivo;
                convenioInDb.Obligaciones = convenioFormViewModel.Convenio.Obligaciones;
                convenioInDb.Derechos = convenioFormViewModel.Convenio.Derechos;
                convenioInDb.DependenciaConvenioId = convenioFormViewModel.Convenio.DependenciaConvenioId;
                convenioInDb.IndicadorId = convenioFormViewModel.Convenio.IndicadorId;
                convenioInDb.ClaseConvenioId = convenioFormViewModel.Convenio.ClaseConvenioId;
                convenioInDb.CondicionConvenioId = convenioFormViewModel.Convenio.CondicionConvenioId;
                convenioInDb.Descripcion = convenioFormViewModel.Convenio.Descripcion;
                convenioInDb.ProponenteIntId = convenioFormViewModel.Convenio.ProponenteIntId;
                convenioInDb.ProponenteExternoId = convenioFormViewModel.Convenio.ProponenteExternoId;
                convenioInDb.Dependencia1Id = convenioFormViewModel.Convenio.Dependencia1Id;
                convenioInDb.Dependencia2Id = convenioFormViewModel.Convenio.Dependencia2Id;
                convenioInDb.Dependencia3Id = convenioFormViewModel.Convenio.Dependencia3Id;
                convenioInDb.AlcanceConvenioId = convenioFormViewModel.Convenio.AlcanceConvenioId;
                convenioInDb.Resolucion = convenioFormViewModel.Convenio.Resolucion;
                convenioInDb.Correlativo = convenioFormViewModel.Convenio.Correlativo;
                convenioInDb.ObjetivoIndicador = convenioFormViewModel.Convenio.ObjetivoIndicador;
                convenioInDb.InstitucionId = convenioFormViewModel.Convenio.InstitucionId;
            }


            //convenioFormViewModel.Convenio.Activo = true;
            //_context.ConvenioSet.Add(convenioFormViewModel.Convenio);
            _context.SaveChanges();

            return RedirectToAction("Index", "Convenio");
        }

        public ActionResult Edit(int Id)
        {
            var convenio = _context.ConvenioSet.SingleOrDefault(d => d.Id == Id);
            if (convenio == null)
                return HttpNotFound();

            var viewModel = new ConvenioFormViewModel
            {
                Convenio = convenio,
                DependenciasPrincipal = _context.DependenciaSet.Where(o => o.Activo == true).ToList(),
                ClasesConvenio = _context.ClaseConvenioSet.Where(o => o.Activo == true).ToList(),
                CondicionesConvenio = _context.CondicionConvenioSet.Where(o => o.Activo == true).ToList(),
                ProponentesInterno = _context.ProponenteSet.Where(o => o.Activo == true).ToList(),
                ProponentesExterno = _context.ProponenteExternoSet.Where(o => o.Activo == true).ToList(),
                ConveniosPadre = _context.ConvenioSet.Where(o => o.Activo == true && o.ClaseConvenioId == 1).ToList(),
                Dependencias1 = _context.DependenciaSet.Where(o => o.Activo == true).ToList(),
                Dependencias2 = _context.DependenciaSet.Where(o => o.Activo == true).ToList(),
                Dependencias3 = _context.DependenciaSet.Where(o => o.Activo == true).ToList(),
                AlcancesConvenios = _context.AlcanceConvenioSet.Where(o => o.Activo == true).ToList(),
                Indicadores = _context.IndicadorSet.Where(o => o.Activo == true).ToList(),
                InstitucionesPrincipal = _context.InstitucionSet.Where(o => o.Activo == true).ToList()
            };

            return View("ConvenioForm", viewModel);
        }

        public ActionResult Delete(int Id)
        {
            var convenio = _context.ConvenioSet.SingleOrDefault(o => o.Id == Id);
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

        public ActionResult Details(int id)
        {
            var convenio = _context.ConvenioSet.Include(d => d.DependenciaConvenio).
                Include(x => x.ClaseConvenio).Include(p => p.CondicionConvenio).
                Include(o => o.AlcanceConvenio).Include(o => o.Indicador).
                Include(o => o.ProponenteInterno).Include(o => o.ProponenteInterno).
                Include(o => o.ProponenteExterno).Include(o => o.ProponenteExterno).
                Include(o => o.Dependencia1).Include(o => o.Dependencia2).
                Include(o => o.Dependencia3).Include(o => o.Institucion).SingleOrDefault(o => o.Id == id);
            if (convenio == null)
                return HttpNotFound();
            if (convenio.DependenciaConvenio == null)
                convenio.DependenciaConvenio = new Dependencia();
            if (convenio.Indicador == null)
            {
                var unidadMedida = new UnidadMedida { Nombre = "No Seleccionado"};
                convenio.Indicador = new Indicador {
                    Nombre = "No Seleccionado",
                    UnidadMedida = unidadMedida
                };
            }
            else
            {
                convenio.Indicador.UnidadMedida =
                    _context.UnidadMedidaSet.SingleOrDefault(o => o.Id == convenio.Indicador.UnidadMedidaId);
            }

            if (convenio.ProponenteInterno == null)
            {
                convenio.ProponenteInterno = new Proponente
                {
                    Nombre = "No Seleccionado",
                    Dependencia = new Dependencia() { Nombre = "No Seleccionado"}
                };
            }
            else
            {
                convenio.ProponenteInterno.Dependencia =
                    _context.DependenciaSet.SingleOrDefault(o => o.Id == convenio.ProponenteInterno.DependenciaId);

            }

            if (convenio.ProponenteExterno == null)
            {
                convenio.ProponenteExterno = new ProponenteExterno
                {
                    Nombre = "No Seleccionado",
                    Instituction = new Institucion() { Nombre = "No Seleccionado" }
                };
            }
            else
            {
                convenio.ProponenteExterno.Instituction =
                    _context.InstitucionSet.SingleOrDefault(o => o.Id == convenio.ProponenteExterno.InstitucionId);

            }

            if (convenio.Institucion == null)
                convenio.Institucion = new Institucion {Nombre = "No Seleccionado"};

            if (convenio.Dependencia1 == null)
                convenio.Dependencia1 = new Dependencia { Nombre = "No Seleccionado"};

            if (convenio.Dependencia2 == null)
                convenio.Dependencia2 = new Dependencia { Nombre = "No Seleccionado" };

            if (convenio.Dependencia3 == null)
                convenio.Dependencia3 = new Dependencia { Nombre = "No Seleccionado" };

            var viewModel = new DetailConvenioViewModel()
            {
                Convenio = convenio,
                Actividades = _context.ActividadConvenioSet.Where(o => o.ConvenioId == id && o.Activo == true).Include(o => o.Indicador).Include(o => o.TipoActividadConvenio).ToList(),
                Programas = _context.ProgramaConvenioSet.Where(o => o.ConvenioId == id && o.Activo == true).Include(o => o.Institucion).Include(o => o.Dependencia).Include(o => o.TipoPrograma).ToList()

            };

            foreach (var actividad in viewModel.Actividades)
            {
                if (actividad.Indicador == null)
                    actividad.Indicador = new Indicador()
                    {
                        Nombre = "No Seleccionado",
                        UnidadMedida = new UnidadMedida() {Nombre = "No Seleccionado"}
                    };
            }
            

            return View(viewModel);
        }
    }
}