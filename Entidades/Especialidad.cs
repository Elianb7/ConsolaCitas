using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Especialidad
    {
        public int Id { get; set; }
        public string NombreEspecilidad { get; set;}
        //Doctor
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        //Relacion costo cita
        public CostoCita CostoCita { get; set; }
        public int CitaId { get; set; }
        //relacion con Modalidad
        public Modalidad Modalidad { get; set; }
        public int ModalidadId { get; set; }
        //Relaciones
        public List<AgendaDets> AgendasDets { get; set; }
    }
}
