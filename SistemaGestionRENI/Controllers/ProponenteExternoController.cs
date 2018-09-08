using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI.Controllers
{
    public class ProponenteExternoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProponenteExternoController()
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
            ListProponenteExternoViewModel vmProponentes = new ListProponenteExternoViewModel();
            vmProponentes.Proponentes = _context.ProponenteExternoSet.Where(o => o.Activo == true).Include(d => d.Instituction).ToList();
            return View(vmProponentes);
        }

        public ActionResult New()
        {
            var instituciones = _context.InstitucionSet.Where(d => d.Activo == true).ToList();
            var viewModel = new ProponenteExternoViewModel()
            {
                Instituciones = instituciones
            };

            return View("ProponenteExternoForm", viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var proponenteExterno = _context.ProponenteExternoSet.SingleOrDefault(d => d.Id == Id);
            if (proponenteExterno == null)
                return HttpNotFound();

            var viewModel = new ProponenteExternoViewModel
            {
                Proponente = proponenteExterno,
                Instituciones = _context.InstitucionSet.Where(o => o.Activo == true).ToList()
            };

            return View("ProponenteExternoForm", viewModel);
        }

        public ActionResult Save(ProponenteExternoViewModel newProponenteViewModel)
        {
            if (newProponenteViewModel.Proponente.Id == 0)
            {
                newProponenteViewModel.Proponente.Activo = true;
                _context.ProponenteExternoSet.Add(newProponenteViewModel.Proponente);
            }
            else
            {
                var proponenteInDb =
                    _context.ProponenteExternoSet.SingleOrDefault(o => o.Id == newProponenteViewModel.Proponente.Id);
                if (proponenteInDb == null)
                    return HttpNotFound();
                proponenteInDb.Nombre = newProponenteViewModel.Proponente.Nombre;
                proponenteInDb.Descripcion = newProponenteViewModel.Proponente.Descripcion;
                proponenteInDb.Telefono = newProponenteViewModel.Proponente.Telefono;
                proponenteInDb.Email = newProponenteViewModel.Proponente.Email;
                proponenteInDb.InstitucionId = newProponenteViewModel.Proponente.InstitucionId;
            }

            //newProponenteViewModel.Proponente.Activo = true;
            //_context.ProponenteSet.Add(newProponenteViewModel.Proponente);
            _context.SaveChanges();
            return RedirectToAction("Index", "ProponenteExterno");
        }

        public ActionResult Delete(Proponente proponente)
        {
            var proponenteActual = _context.ProponenteExternoSet.SingleOrDefault(o => o.Id == proponente.Id);
            if (proponenteActual != null)
            {
                proponenteActual.Activo = false;
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "ProponenteExterno");
        }
    }
}