using Consola;
using Entidades.Operaciones;
using Microsoft.EntityFrameworkCore;
using Procesos;
using System;
using System.Linq;

namespace ConsolaCitas
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Grabar grabar = new Grabar();
            grabar.DatosIni();

            using (var db = AgendaBuilder.Crear())
            {
                var tmpMedico = db.medicos
                    .Single(m => m.Id == 6);

                PrequiAp preAp = new PrequiAp(db);

                var lista = preAp.Prerequisitos(tmpMedico);


                Console.WriteLine("Los prerequisitos de: " + tmpMedico.Nombre + " son:");
                if (lista == null)
                {
                    Console.WriteLine("No tiene prerequisitos");
                }
                else
                {
                    foreach (var item in lista)
                    {
                        Console.WriteLine(item.MallaMedicacs + " " + item.Nombre);
                    }
                }


            }


            using (var db = AgendaBuilder.Crear())
            {
                var tmpMedico = db.medicos
                     .Where(medicos =>
                     medicos.Id == 5 ||
                     medicos.Id == 6 ||
                     medicos.Id == 7 ||
                     medicos.Id == 8 ||
                     medicos.Id == 9

                 ).ToList();


                var tmpUsuarios = db.usuarios
                .Single(usa => usa.Id == 2);

                ApruebaCita calc = new ApruebaCita(db);

                foreach (var med in tmpMedico)
                {
                    var resultado = calc.Aprobo(tmpUsuarios, med);

                    Console.WriteLine(
                        "El usuario " + tmpUsuarios.Nombre +
                        (resultado ? " SI " : " NO ") +
                        " Agendo su cita con el Doctor/a : " + med.Nombre
                    );


                }

            }
            using (var db = AgendaBuilder.Crear())
            {
                var tmpPago = db.pagoCitas.Single(p => p.id == 2);
                    
                     
                var configuracion = db.configuracion.Single();
                var calc = new PagoCitaCalc(configuracion);
                PagoCitaCalc pagoCitaCalc = new PagoCitaCalc(configuracion);
                pagoCitaCalc.PagoFinal(tmpPago);

                Console.WriteLine(pagoCitaCalc.PagoFinal(tmpPago));
            } 

            using (var db = AgendaBuilder.Crear())
            {


                var tmpusUsuario = db.usuarios
                    .Single(u => u.Id == 3);
                ApruebaMedCita vali = new ApruebaMedCita(db);
                vali.Aprobo(tmpusUsuario);
                Console.WriteLine("Nombre:" + tmpusUsuario.Nombre+" "+ vali.Aprobo(tmpusUsuario));
            }

        }

    }
}