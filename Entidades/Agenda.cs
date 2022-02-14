using Entidades;
using System;
using System.Collections.Generic;

namespace Entidades
{
    public enum AgendaEstado {Aprobada , Rechazada}
    public class Agenda
    {
        public int Id { get; set; } 
        public string Hora { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime FechaCita { get; set; }

        public AgendaEstado Estado { get; set; } 
        
        //Relacion usario 
        public int UserId { get; set; }
        public Usuario Usuario { get; set; }
        //Relacion Costo cita
        public CostoCita CostoCita { get; set; }
        public int CitaId { get; set; }
        //Modalidad
        public Modalidad Modalidad { get; set; }
        public int ModalidadId { get; set; }
        //AgendasDet
        public List<AgendaDets> AgendaDets { get; set; }
       

    }
}
