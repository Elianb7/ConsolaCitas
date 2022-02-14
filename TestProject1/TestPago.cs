using Entidades;
using Entidades.Operaciones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesAprobCredito;
using Xunit;

namespace TestProject1
{
    public class TestPago
    {
        [Theory]
        [InlineData(1,33.60f)]
     
        public void Prueba012(int id,float resEsperado) {
            float resCalc;
            string msg;

            var db = DBBuilder.GetDB();
            var pagoff = db.pagoCitas
                .Include(pp => pp.AgendaDets)
                .ThenInclude(det => det.Agenda)
                .ThenInclude(ag => ag.Usuario)
                .Single(pp => pp.id == id);

            var config = new Configuracion()
            {
                pFinal = 33.60f,
                pago = 30.00f,
                iva = 0.12f

            };
            var calc = new PagoCitaCalc(config);

            resCalc = calc.PagoFinal(pagoff);

            msg = $"{resCalc} distinto al resultado esperado:{pagoff.AgendaDets.Agenda.Usuario.Nombre}";

            Assert.True(resEsperado==resCalc , msg);
        }
    }
}
