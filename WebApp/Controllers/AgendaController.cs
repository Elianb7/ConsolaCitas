using DBcontex;
using Entidades;
using Entidades.Operaciones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Procesos;
using System.Linq;

namespace WebApp.Controllers
{
    public class AgendaController : Controller
    {
        private readonly AgendaContex db;

        public AgendaController(AgendaContex db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var listaAgendas = db.agendas
               .Include(c => c.CostoCita)
               .Include(u => u.Usuario)
               .Include(m => m.Modalidad)
               ;
            return View(listaAgendas);
        }
        // Pantalla para la validación de la matrícula
        public IActionResult Validar(int id)
        {
            var agend = db.agendas
                .Include(agenda => agenda.CostoCita)
                .Include(agenda => agenda.Usuario)
                .Include(agenda => agenda.Modalidad)
                .Include(agenda => agenda.AgendaDets)
                    .ThenInclude(agenda_dets => agenda_dets.PagoCita)
                .Include(agenda => agenda.AgendaDets)
                    .ThenInclude(agenda_dets => agenda_dets.Especialidad)
                        .ThenInclude(especialidad => especialidad.Medico)
                .Single(agenda => agenda.Id == id)   // Consulta Id agenda
                ;

            // Preparar la clase para el cálculo de las calificaciones
            var configuracion = db.configuracion.Single();
            PagoCitaCalc pagoCitaCalc = new PagoCitaCalc(configuracion);

            ViewBag.pagoCitaCalc = pagoCitaCalc;

            return View(agend);
        }

        [HttpPost]
        public IActionResult Validar(Agenda agenda)
        {

            ApruebaMedCita apru = new ApruebaMedCita(db);
      

            //Consulta usauarios
            var tempUsuario = db.usuarios
                  .Find(agenda.Id);

            if (apru.Aprobo(tempUsuario))
            {
                agenda.Estado = AgendaEstado.Aprobada;
                TempData["mensaje"] = $"La cita  del usuario{agenda.Usuario.Nombre} fue aprobada";
            }else {

                agenda.Estado = AgendaEstado.Rechazada;
                TempData["mensaje"] = $"La cita del usuario {agenda.Usuario.Nombre} fue rechazada ";
            }
            agenda.Usuario = null;
            agenda.Usuario = tempUsuario;
            db.agendas.Update(agenda);
            db.SaveChanges();


            return RedirectToAction("Index");
        }

    }

}

