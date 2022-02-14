using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PagoCita
    {
        public int id { get; set; }
        public float pago { get; set; }
        public float pFinal { get; set; }
        public float Iva { get; set; }
        // Relación Uno a Uno
        public int AngendaDetId { get; set; }
        public  AgendaDets AgendaDets { get; set; }
        // Composición de las notas
      

        public float PagoFinal(float pago,float iva)
        {
            // Cálculo
            float calcula = 0;
            calcula = pago * iva+pago;
            calcula = MathF.Round(calcula, 2);
            return calcula;
        }
        public bool Aprobado(float pago , float iva ,float pFinal)
        {
            bool res;
            res = PagoFinal(pago , iva) == pFinal;
            return res;
        }
    }
}
