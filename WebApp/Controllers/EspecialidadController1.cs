using DBcontex;
using Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Controllers
{
    public class EspecialidadController1 : Controller
    {
        readonly AgendaContex db;

        public EspecialidadController1(AgendaContex db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Especialidad> listaEspecialidad =
               db.especialidads
                   .Include(especialidad => especialidad.CostoCita)
                   .Include(especialidad => especialidad.Medico)
                   .Include(especialidad => especialidad.Modalidad).ToList();

            return View(listaEspecialidad);
        }

        //  Presenta el formulario vacio listo para crear una entidad
       /* [HttpGet]
        public IActionResult Create()
        {
            //lista empleados
            var listaCosto = db.costoCitas
                .Select(empleado => new
                {
                    Id = empleado.Id,
                    CostoCita = empleado.CostoJornada
                }).ToList();
            //preparar listas
            var selectListaCosto = new SelectList(listaCosto, "CostoId", "Costo");

            //Ingreso Viebag
            ViewBag.selectListCosto = selectListaCosto;

            return View();
        }

        //  Guarda un curso
        [HttpPost]
        public IActionResult Create(Especialidad especialidad)
        {
            db.especialidads.Add(especialidad);
            db.SaveChanges();

            TempData["mensaje"] = $"El curso {especialidad.NombreEspecilidad} se ha creado correctamente";

            return RedirectToAction("Index");
        } */

    }
}
