using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public enum ModalidadEstado { Matutina, Diruna,Nocturna}
    public class Modalidad
    {
        public int id { get; set;}

        public string NonbreModalidad { get; set; }
        public ModalidadEstado Estado { get; set; }

        //Relacion Con Agenda
        public List<Agenda> Agendas { get; set; }
        //
        public List<Especialidad> Especialidads { get; set; }


    }
}
