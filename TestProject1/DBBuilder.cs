using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consola;
using ConsolaCitas;
using DBcontex;

namespace TesAprobCredito
{
    public class DBBuilder
    {

        private DBBuilder() { }

        private static AgendaContex db;

        public static AgendaContex GetDB()
        {
            if (db == null)
            {
                Grabar grabar = new Grabar();
                grabar.DatosIni();
                db = AgendaBuilder.Crear();
            }
            return db;
        }
    }
}
