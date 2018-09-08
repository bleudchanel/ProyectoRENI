using SistemaGestionRENI.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaGestionRENI.Controllers
{

    public class ProponenteController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public ProponenteController()
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
            ListProponenteViewModel vmProponentes = new ListProponenteViewModel();
            vmProponentes.Proponentes = _context.ProponenteSet.Where(o => o.Activo == true).Include(d => d.Dependencia).ToList();
            return View(vmProponentes);
        }

        public ActionResult New()
        {
            var dependencias = _context.DependenciaSet.Where(d => d.Activo == true).ToList();
            var viewModel = new NewProponenteViewModel
            {
                Dependencias = dependencias
            };

            return View("ProponenteForm",viewModel);
        }

        public ActionResult Edit(int Id)
        {
            var proponente = _context.ProponenteSet.SingleOrDefault(d => d.Id == Id);
            if (proponente == null)
                return HttpNotFound();

            var viewModel = new NewProponenteViewModel
            {
                Proponente = proponente,
                Dependencias = _context.DependenciaSet.Where(o => o.Activo == true).ToList()
            };

            return View("ProponenteForm", viewModel);
        }

        public ActionResult Save(NewProponenteViewModel newProponenteViewModel)
        {
            if (newProponenteViewModel.Proponente.Id == 0)
            {
                newProponenteViewModel.Proponente.Activo = true;
                _context.ProponenteSet.Add(newProponenteViewModel.Proponente);
            }
            else
            {
                var proponenteInDb =
                    _context.ProponenteSet.SingleOrDefault(o => o.Id == newProponenteViewModel.Proponente.Id);
                if (proponenteInDb == null)
                    return HttpNotFound();
                proponenteInDb.Nombre = newProponenteViewModel.Proponente.Nombre;
                proponenteInDb.Descripcion = newProponenteViewModel.Proponente.Descripcion;
                proponenteInDb.Telefono = newProponenteViewModel.Proponente.Telefono;
                proponenteInDb.Email = newProponenteViewModel.Proponente.Email;
                proponenteInDb.DependenciaId = newProponenteViewModel.Proponente.DependenciaId;
            }

            //newProponenteViewModel.Proponente.Activo = true;
            //_context.ProponenteSet.Add(newProponenteViewModel.Proponente);
            _context.SaveChanges();
            return RedirectToAction("Index","Proponente");
        }

        public ActionResult Delete(Proponente proponente)
        {
            var proponenteActual = _context.ProponenteSet.SingleOrDefault(o => o.Id == proponente.Id);
            if (proponenteActual != null)
            {
                proponenteActual.Activo = false;
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "Proponente");
        }
    }
}