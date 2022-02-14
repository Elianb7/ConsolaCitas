using DBcontex;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolaCitas
{
    public class AgendaBuilder 
    {
        const string DBTipo = "DBTipo";
        enum DBTipoConn { SqlServer, Postgers, Memoria }
        static AgendaContex db;

        public static AgendaContex Crear()
        {
            string dbtipo;
            string conn;

            dbtipo = ConfigurationManager.AppSettings[DBTipo];

            if (dbtipo == null)
            {
                dbtipo = "Memoria";
                conn = "AgendaCitas";
            }
            else
            {
                conn = ConfigurationManager.ConnectionStrings[dbtipo].ConnectionString;
            }
            //lee la configuracion de que base usar del archivo App.config
          

            DbContextOptions<AgendaContex> contextOptions;
            switch (dbtipo)
            {
                case "SqlServer":
                    contextOptions = new DbContextOptionsBuilder<AgendaContex>()
                        .UseSqlServer(conn)
                        .Options;
                    break;
                case "Postgres":
                    contextOptions = new DbContextOptionsBuilder<AgendaContex>()
                        .UseNpgsql(conn)
                        .Options;
                    break;
                case "MySQL":
                    contextOptions = new DbContextOptionsBuilder<AgendaContex>()
                    .UseMySql(conn, ServerVersion.AutoDetect(conn))
                    .Options;
                    break;
                default: // Por defecto usa la memoria como base de datos
                    contextOptions = new DbContextOptionsBuilder<AgendaContex>()
                        .UseInMemoryDatabase(conn)
                        .Options;
                    break;
            }

            db = new AgendaContex(contextOptions);
            return db;
        }
    }
}

