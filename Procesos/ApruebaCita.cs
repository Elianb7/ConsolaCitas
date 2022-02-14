using DBcontex;
using Entidades;
using Entidades.Operaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Procesos
{
    public class ApruebaCita
    {
        public AgendaContex db { get; set; }

        public ApruebaCita(AgendaContex db)
        {
            this.db = db;
        }

        public bool Aprobo(Usuario u, Medico medico)
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

            // Si no tiene agenda, no aprobó la cita
            if (tmpUsuario.Agendas == null) return false;

            // Preparar clase para el cálc de las calificaciones
            var configuracion = db.configuracion.Single();
            var calc = new PagoCitaCalc(configuracion);

            // Busco el medico
            foreach (var agend in tmpUsuario.Agendas)
            {
                foreach (var dets in agend.AgendaDets)
                {
                    if (dets.Especialidad.MedicoId == medico.Id)
                    {
                        // Si no tiene pagos entonces no aprobó la medico
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
