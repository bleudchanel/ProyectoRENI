using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaGestionRENI.Models;

namespace SistemaGestionRENI.Controllers
{
    public class CondicionConvenioController : Controller
    {
        private ApplicationDbContext _context;

        public CondicionConvenioController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: CondicionConvenio
        public ActionResult Index()
        {
            ListCodicionConvenioViewModel vm = new ListCodicionConvenioViewModel();
            vm.CondicionesConvenio = _context.CondicionConvenioSet.Where(o => o.Activo == true).ToList();
            return View(vm);
        }

        public ActionResult New()
        {
            return View();
        }

        public ActionResult Save(CondicionConvenio condicionConvenio)
        {
            condicionConvenio.Activo = true;
            _context.CondicionConvenioSet.Add(condicionConvenio);
            _context.SaveChanges();

            return RedirectToAction("Index", "CondicionConvenio");
        }

        public ActionResult Delete(CondicionConvenio condicionConvenio)
        {
            var condicion = _context.CondicionConvenioSet.Where(o => o.Id == condicionConvenio.Id).FirstOrDefault();
            if (condicion != null)
            {
                condicion.Activo = false;
                _context.SaveChanges();
            }
            else
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index", "CondicionConvenio");
        }
    }
}