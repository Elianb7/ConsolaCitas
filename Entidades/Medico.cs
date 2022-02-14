using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Medico
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Area { get; set; }

        //relacion especialidades
        public List<Especialidad> Especialidads { get; set;}
        // relacion con malla
        public MallaMedicacs MallaMedicacs { get; set; }
        // Relación con los prerequisitos del medico
        public List<Prerequisito> Prerequisitos { get; set; }

    }
}
