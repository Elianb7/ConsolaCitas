using DBcontex;
using Entidades;
using Entidades.Operaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procesos
{
    public class ApruebaMedCita
    {
        public AgendaContex db { get; set; }

        public ApruebaMedCita (AgendaContex db)
        {
            this.db = db;
        }

        public bool Aprobo(Usuario u)
        {
            // Consultar Usuario
            var tmpUsuario = db.usuarios
                .Include(ag => ag.Agendas)
                .ThenInclude(de => de.AgendaDets)
                .ThenInclude(pa => pa.PagoCita)
                .Include(ag => ag.Agendas)
                .ThenInclude(de => de.AgendaDets)
                .ThenInclude(espe => espe.Especialidad)
                .ThenInclude(m => m.Medico)
                .Single(us => us.Id == u.Id);

            // Si no tiene agenda, no aprobó la cita medica
            if (tmpUsuario.Agendas == null) return false;

            // Preparar clase para el pago de las citas
            var configuracion = db.configuracion.Single();
            var calc = new PagoCitaCalc(configuracion);

            // Busco el medico
            foreach (var agend in tmpUsuario.Agendas)
            {
                foreach (var dets in agend.AgendaDets)
                {
                    if (dets.Especialidad.MedicoId == dets.Especialidad.MedicoId)
                    {
                        // Si no tiene agendas entonces no aprobó la cita
                        if (dets.PagoCita == null) return false;

                        if (calc.Aprobado(dets.PagoCita))
                        {
                            return true;
                        }
                    }
                }

            }
            return false;

        }
    }
}
