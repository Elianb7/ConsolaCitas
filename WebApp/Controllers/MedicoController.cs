using Microsoft.AspNetCore.Mvc;
using Entidades;
using DBcontex;
using System.Collections.Generic;

namespace WebApp.Controllers
{
    public class MedicoController : Controller
    {
        private readonly AgendaContex db;

        public MedicoController (AgendaContex db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Medico> listaMaterias = db.medicos;
            return View(listaMaterias);
        }

        // GET
        //  Presenta el formulario vacio listo para crear una entidad
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST
        //  Guarda una materia
        [HttpPost]
        public IActionResult Create(Medico medico)
        {
            db.medicos.Add(medico);
            db.SaveChanges();

            TempData["mensaje"] = $"La materia {medico.Nombre} se ha creado correctamente";

            return RedirectToAction("Index");
        }

        // Presenta el formulario con la identidad seleccionada para actualizar
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Medico medico = db.medicos.Find(id);

            return View(medico);
        }

        [HttpPost]
        public IActionResult Edit(Medico medico)
        {
            db.medicos.Update(medico);
            db.SaveChanges();

            TempData["mensaje"] = $"La materia {medico.Nombre} se ha actualizado correctamente";

            return RedirectToAction("Index");
        }

        // Presenta el formulario con la identidad seleccionada para borrar
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Medico medico = db.medicos.Find(id);

            return View(medico);
        }

        [HttpPost]
        public IActionResult Delete(Medico medico)
        {
            db.medicos.Remove(medico);
            db.SaveChanges();

            TempData["mensaje"] = $"La materia {medico.Nombre} se ha borrado correctamente";

            return RedirectToAction("Index");
        }
    }
}
