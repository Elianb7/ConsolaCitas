using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Configuracion
    {
        public int Config { get; set; }
        public string NombreClinica { get; set; }
        public float pago { get; set; }
        public float iva { get; set; }
        public float pFinal { get; set; }
        //Relacion modalidad 
        public Modalidad ModalidadC { get; set; }
        public int ModalidadId { get; set; }
    }
}
