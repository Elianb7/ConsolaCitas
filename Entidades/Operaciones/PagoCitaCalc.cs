using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Operaciones
{
    public class PagoCitaCalc
    {
        public float pago { get; set; }
        public float iva { get; set; }
        public float pFinal { get; set; }

        public PagoCitaCalc(Configuracion configuracion)
        {
            this.pago = configuracion.pago;
            this.iva = configuracion.iva;
            this.pFinal = configuracion.pFinal;
        }

        public float PagoFinal(PagoCita pagoCita)
        {
            float respuesta;

            respuesta = pagoCita.pago*iva+pagoCita.pago;

            respuesta = (float)Math.Round((double)respuesta, 2);

            return respuesta;
        }

        public bool Aprobado(PagoCita pagoCita)
        {
            return PagoFinal(pagoCita) == pFinal;
        }
    }
}
