using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Prerequisito
    {
        public int MallaMedicaId { get; set; }
        public int MedicoId { get; set; }
        // Relaciones
        public MallaMedicacs MallaMedicacs { get; set; }
        public Medico Medico { get; set; }
    }
}
