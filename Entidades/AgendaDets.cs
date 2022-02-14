using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class AgendaDets
    {
        public int id { get; set; }
        public string Hora { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime FechaCita { get; set; }

        //Relacion Agendas Agenda 
        public  int AngendaId { get; set; }   
        public Agenda Agenda { get; set; } 
        //Relacion Pagos
        public PagoCita PagoCita { get; set; }
        //Especialidad
        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; }
       
    }
}
