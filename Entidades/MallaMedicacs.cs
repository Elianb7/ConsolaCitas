using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MallaMedicacs
    {
        public int id { get; set; }
        public string nombreMalla { get; set; }

        // Relación con pago de la cita
        public int CitaId { get; set; }
        public CostoCita Costo { get; set; }
        // Relación con la Materia
        public int? MedicoId { get; set; }
        public Medico Medico { get; set; }
        // Grafo: Doctores prerequisitos
        public List<Prerequisito> PreRequisitos { get; set; }
        // Malla padre
        public MallaMedicacs MallaPadre { get; set; }
        public int? MallaPadreId { get; set; }
        // Sub mallas
        public List<MallaMedicacs> SubMallas { get; set; }
    }
}
