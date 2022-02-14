using Entidades;
using System;
using System.Collections.Generic;

namespace CargaDeDatos
{
    public class DatosIniciales
    {
        public enum ListasTipo
        {
            Modalidad, Usuarios, Especilidades,
            Meidcos, SubMallasMedicas, MallasMedicas,
            Configuracion, PagoCitas,
            Agendas, Agendas_Dets, CostoCitas,
            Prerequisitos
        }
        public Dictionary<ListasTipo, object> Carga()
        {
            Modalidad matutina = new Modalidad()
            {
                
                NonbreModalidad = "Matutina",
                Estado = ModalidadEstado.Matutina

            };
            //  Diruna
            Modalidad diurna = new Modalidad()
            {
                NonbreModalidad = "Diurna",
                Estado = ModalidadEstado.Diruna

            };
            // Nocturna
            Modalidad nocturna = new Modalidad()
            {
                NonbreModalidad = "Nocturna",
                Estado = ModalidadEstado.Nocturna

            };

            //Lista Modalidad
            List<Modalidad> listaModalidad = new List<Modalidad>()
            {
                // MATUTINA
                 matutina,
                // DIURNA
                  diurna,
                // NOCTURNA
                 nocturna
            };
            Configuracion configMatutina = new Configuracion()
            {
                NombreClinica = "LM Clinica",
                pago = 30.00f,
                iva = 0.12f,
                pFinal = 33.60f,
                ModalidadC = matutina
            };

          
            

            //Lista Confiuracion
            List<Configuracion> listaConfiguracion = new List<Configuracion>()
            {
                configMatutina 
            };
            // Medicos 
            Medico medico1 = new Medico()
            {
                Nombre = "Raul",
                Apellido = "Gonzales",
                Area = "Laboratorio",

            };

            Medico medico2 = new Medico()
            {
                Nombre = "Laura",
                Apellido = "Manzon",
                Area = "Pediatría",
            };

            Medico medico3 = new Medico()
            {
                Nombre = "Camilo",
                Apellido = "Moran",
                Area = "Ginecología ",
            };

            Medico medico4 = new Medico()
            {
                Nombre = "Rafael",
                Apellido = "De Cuba",
                Area = "Psiquiatría",

            };

            Medico medico5 = new Medico()
            {
                Nombre = "Maria",
                Apellido = "La Del Barrio",
                Area = "Odontología",
            };

            Medico medico6 = new Medico()
            {
                Nombre = "Ricardo",
                Apellido = "Pinola",
                Area = " Medicina general ",
            };

            Medico medico7 = new Medico()
            {
                Nombre = "Andres",
                Apellido = "Paez",
                Area = " Medicina complementaria ",
            };

            Medico medico8 = new Medico()
            {
                Nombre = "Jhony",
                Apellido = "Laurence",
                Area = "Traumatología",
            };

            Medico medico9 = new Medico()
            {
                Nombre = "Marcelo",
                Apellido = "Alba",
                Area = "Cardiología",
            };

            Medico medico10 = new Medico()
            {
                Nombre = "Rosario",
                Apellido = "Bravo",
                Area = "Radiología",
            };
            //Lista medicas
            List<Medico> listaMedicos = new List<Medico>()
            {
            medico1,medico2,medico3,medico4,medico5,medico6,medico7,medico8,medico9,medico10
            };

            //Costo Citas
            //diruna
            CostoCita costoMatutina = new CostoCita()
            {
                CostoJornada = 30.00f,

            };
            //nocturna
            CostoCita costoDiurna = new CostoCita()
            {
                CostoJornada = 30.00f,

            };
            CostoCita costoNocturna = new CostoCita()
            {
                CostoJornada = 30.00f,

            };
            List<CostoCita> listaCostoCitas = new List<CostoCita>() { costoMatutina, costoDiurna, costoNocturna };
            //Usuarios citas
            Usuario Pedro = new Usuario()
            {
                Nombre = "Pedro ",
                Apellido = "Navaja",
                Cedula = 1706856566,
                Edad = 20,
                Email = "pedro234@g.com"
            };
            Usuario Maria = new Usuario()
            {
                Nombre = "María ",
                Apellido = "Barrio",
                Edad = 60,
                Cedula = 1856214569,
                Email = "mbarrio@h.com"
            };
            Usuario Jose = new Usuario()
            {
                Nombre = "José",
                Apellido = "Arimatea",
                Edad = 55,
                Cedula = 1702185456,
                Email = "belen999@g.com"
            };
            Usuario Karla = new Usuario()
            {
                Nombre = "Karla",
                Apellido = "Sanchez",
                Edad = 30,
                Cedula = 1706564782,
                Email = "karlasanchez123@h.com"
            };
            // lista usuarios
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                Jose, Karla, Maria,Pedro
            };
            //Prerequisitos malla doctor
            //malla doc 1 matutina nocturna
            MallaMedicacs mallaDoc1Matutina = new MallaMedicacs()
            {
                Costo = costoMatutina,
                Medico = medico1

            };
            //malla doc1  nocturna
            MallaMedicacs mallaDoc1Nocturna = new MallaMedicacs()
            {
                Costo = costoNocturna,
                Medico = medico1

            };
            //pre matutina
            Prerequisito PrematutinaDoc1 = new Prerequisito()
            {
                MallaMedicacs = mallaDoc1Matutina,
                Medico = medico1
            };
            //pre nocturna
            Prerequisito PreNocturnaDoc1 = new Prerequisito()
            {
                MallaMedicacs = mallaDoc1Nocturna,
                Medico = medico1
            };
            //Malla doc2 Diurna , nocturna 
            MallaMedicacs mallaDoc2Diruna = new MallaMedicacs()
            {
                Costo = costoDiurna,
                Medico = medico2

            };
            MallaMedicacs mallaDoc2Nocturna = new MallaMedicacs()
            {
                Costo = costoNocturna,
                Medico = medico2

            };
            //Prerrequisitos doctor 2
            Prerequisito PreDiurnaDoc2 = new Prerequisito()
            {
                MallaMedicacs = mallaDoc2Diruna,
                Medico = medico2
            };
            Prerequisito PreNocturnaDoc2 = new Prerequisito()
            {
                MallaMedicacs = mallaDoc1Nocturna,
                Medico = medico2
            };
            //Malla doc3 Matutina , Nocturna
            MallaMedicacs mallaDoc3Matutina = new MallaMedicacs()
            {
                Costo = costoMatutina,
                Medico = medico3

            };
            MallaMedicacs mallaDoc3Nocturna = new MallaMedicacs()
            {
                Costo = costoNocturna,
                Medico = medico3

            };
            //Prerrequisitos doctor 3 sub matutina , nocturna
            Prerequisito PreMatutinaDoc3 = new Prerequisito()
            {
                MallaMedicacs = mallaDoc3Matutina,
                Medico = medico3
            };
            //Prerrequisitos doctor 3 sub matutina , nocturna
            Prerequisito PreNocturnaDoc3 = new Prerequisito()
            {
                MallaMedicacs = mallaDoc3Nocturna,
                Medico = medico3
            };
            //Malla doc4  diurna , matutina
            MallaMedicacs mallaDoc4Matutina = new MallaMedicacs()
            {
                Costo = costoMatutina,
                Medico = medico4

            };
            MallaMedicacs mallaDoc4Diurna = new MallaMedicacs()
            {
                Costo = costoDiurna,
                Medico = medico4

            };
            //Prerrequisitos doctor 4 sub matutina , diurna
            Prerequisito PreMatutinaDoc4 = new Prerequisito()
            {
                MallaMedicacs = mallaDoc4Matutina,
                Medico = medico4
            };
            Prerequisito PreDiurnaDoc4 = new Prerequisito()
            {
                MallaMedicacs = mallaDoc4Diurna,
                Medico = medico4
            };
            //Lita submalla matutina
            List<MallaMedicacs> listaSubMallasMatutinaDiurnaVes = new List<MallaMedicacs>()
            {
                mallaDoc1Matutina , mallaDoc3Matutina , mallaDoc4Matutina , mallaDoc2Diruna , mallaDoc4Diurna,mallaDoc1Nocturna , mallaDoc3Nocturna ,mallaDoc2Nocturna
            };
    
            MallaMedicacs mallaMatutina = new MallaMedicacs()
            {
                Costo = costoMatutina,
                SubMallas = listaSubMallasMatutinaDiurnaVes
            };
            MallaMedicacs mallaDiurna = new MallaMedicacs()
            {
                Costo = costoDiurna,
                SubMallas = listaSubMallasMatutinaDiurnaVes
            };
            MallaMedicacs mallaNocturna = new MallaMedicacs()
            {
                Costo = costoNocturna,
                SubMallas = listaSubMallasMatutinaDiurnaVes
            };

            List<MallaMedicacs> listaMallasMedicas = new List<MallaMedicacs>()
            {
                mallaMatutina,mallaDiurna ,mallaNocturna
            };
            //lista pre
            List<Prerequisito> listaPrerequisitos = new List<Prerequisito>()
            {
               PrematutinaDoc1 , PreNocturnaDoc1 , PreDiurnaDoc2 , PreNocturnaDoc2 , PreNocturnaDoc3 , PreMatutinaDoc3
               ,PreDiurnaDoc4 , PreMatutinaDoc4
            };
            // Especilidad
            Especialidad especialidad = new Especialidad()
            {
                CostoCita = costoMatutina,
                Modalidad = matutina,
                Medico = medico1,
                NombreEspecilidad = medico1.Area,
            };

            Especialidad especialidad1 = new Especialidad()
            {
                CostoCita = costoDiurna,
                Modalidad = diurna,
                Medico = medico2,
                NombreEspecilidad = medico2.Area,
            };

            Especialidad especialidad2 = new Especialidad()
            {
                CostoCita = costoNocturna,
                Modalidad = nocturna,
                Medico = medico3,
                NombreEspecilidad = medico3.Area,
            };
            Especialidad especialidad3 = new Especialidad()
            {
                CostoCita = costoMatutina,
                Modalidad = matutina,
                Medico = medico4,
                NombreEspecilidad = medico4.Area,
            };
            // Lista Especialidad
            List<Especialidad> ListaEspecialidad = new List<Especialidad>()
            {
                especialidad , especialidad ,especialidad2 ,especialidad3

            };
            //Agenda
            //Cita Karla
            Agenda CitaKarla = new Agenda()
            {
                CostoCita = costoMatutina,
                Estado = AgendaEstado.Rechazada,
                Usuario = Karla,
                Modalidad = matutina,
                CreatedDate = DateTime.Now,
                FechaCita = new DateTime(2022, 12, 4),
                AgendaDets = new List<AgendaDets>() {
                new AgendaDets() {
                  Especialidad = especialidad,
                  PagoCita =  new PagoCita() {
                   pFinal = 33.60f , pago = 30.00f ,Iva = 0.12f
                  }
                }
                }
            };
            //Cita
            Agenda CitaMaria = new Agenda()
            {
                CostoCita = costoDiurna,
                Estado = AgendaEstado.Rechazada,
                Usuario = Maria,
                CreatedDate = DateTime.Now,
                Modalidad  = diurna,
                FechaCita = new DateTime(2022, 12, 6),
                AgendaDets = new List<AgendaDets>() {
                new AgendaDets() {
                  Especialidad = especialidad1,
                  PagoCita =  new PagoCita() {
                   pFinal = 30.60f , pago = 35.00f ,Iva = 0.12f
                  }
                }
                }
            };
            Agenda CitaPedro = new Agenda()
            {
                CostoCita = costoNocturna,
                Estado = AgendaEstado.Rechazada,
                Usuario = Pedro,
                Modalidad = nocturna,
                CreatedDate = DateTime.Now,
                FechaCita = new DateTime(2022, 12, 9),
                AgendaDets = new List<AgendaDets>() {
                new AgendaDets() {
                  Especialidad = especialidad2,
                  PagoCita =  new PagoCita() {
                   pFinal = 33.60f , pago = 30.00f ,Iva = 0.12f
                  }
                }
                }
            };
            Agenda CitaJose = new Agenda()
            {
                CostoCita = costoMatutina,
                Estado = AgendaEstado.Rechazada,
                Usuario = Jose,
                Modalidad = matutina,
                CreatedDate = DateTime.Now,
                FechaCita = new DateTime(2022, 12, 11),
                AgendaDets = new List<AgendaDets>() {
                new AgendaDets() {
                  Especialidad = especialidad3,
                  PagoCita =  new PagoCita() {
                   pFinal = 33.60f , pago = 30.00f ,Iva = 0.12f
                  }
                }
                }
            };
            var listaAgenda = new List<Agenda>()
            {
                CitaKarla , CitaMaria ,CitaPedro, CitaJose
            };
            Dictionary<ListasTipo, object> dicListasDatos = new Dictionary<ListasTipo, object>()
            {
                { ListasTipo.Modalidad, listaModalidad },
                { ListasTipo.Usuarios, listaUsuarios},
                { ListasTipo.Especilidades, ListaEspecialidad },
                { ListasTipo.CostoCitas, listaCostoCitas },
                { ListasTipo.SubMallasMedicas, listaSubMallasMatutinaDiurnaVes},
                { ListasTipo.MallasMedicas,listaMallasMedicas },
                { ListasTipo.Configuracion, listaConfiguracion},
                { ListasTipo.Agendas, listaAgenda },
                { ListasTipo.Meidcos, listaMedicos },
                { ListasTipo.Prerequisitos, listaPrerequisitos }

            };

            return dicListasDatos;
        }
    }
}