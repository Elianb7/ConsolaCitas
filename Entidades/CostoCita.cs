using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class CostoCita
    {
        public int Id { get; set; }
        public float CostoJornada { get; set; }

        // Relación con matrículas
        public List<Agenda> Agendas { get; set; }
        // Relación con los cursos
        public List<Especialidad> Especialidads { get; set; }
    }
}
