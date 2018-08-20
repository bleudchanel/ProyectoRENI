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
        private ApplicationDbContext _context;
        
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
            vmProponentes.Proponentes = _context.ProponenteSet.Include(d => d.Dependencia).ToList();
            return View(vmProponentes);
        }

        public ActionResult New()
        {
            var dependencias = _context.DependenciaSet.Where(d => d.Estado == true).ToList();
            var viewModel = new NewProponenteViewModel
            {
                Dependencias = dependencias
            };

            return View(viewModel);
        }

        public ActionResult Save(NewProponenteViewModel newProponenteViewModel)
        {
            _context.ProponenteSet.Add(newProponenteViewModel.Proponente);
            _context.SaveChanges();
            return RedirectToAction("Index","Proponente");
        }
    }
}