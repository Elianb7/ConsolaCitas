using Entidades;
using DBcontex;
using System.Collections.Generic;
using  CargaDeDatos;
using static CargaDeDatos.DatosIniciales;
using ConsolaCitas;

namespace Consola
{
    public class Grabar
    {
        public void DatosIni()
        {
            DatosIniciales datos = new DatosIniciales();
            var listas = datos.Carga();

            // Extraer del diccionario las listas
            var listaConfiguracion = (List<Configuracion>)listas[ListasTipo.Configuracion];
            var listaAngendas = (List<Agenda>)listas[ListasTipo.Agendas];
            var listaModalidad = (List<Modalidad>)listas[ListasTipo.Modalidad];
            var listaUsuarios = (List<Usuario>)listas[ListasTipo.Usuarios];
            var listaCostoCitas = (List<CostoCita>)listas[ListasTipo.CostoCitas];
            var listaSubMallas = (List<MallaMedicacs>)listas[ListasTipo.SubMallasMedicas];
            var listaMallas = (List<MallaMedicacs>)listas[ListasTipo.MallasMedicas];
            var listaMedicos = (List<Medico>)listas[ListasTipo.Meidcos];
            var listaEspecialidad = (List<Especialidad>)listas[ListasTipo.Especilidades];
            var listaPrerequisitos = (List<Prerequisito>)listas[ListasTipo.Prerequisitos];

            using (AgendaContex db = AgendaBuilder.Crear())
            {
                // Se asegura que se borre y vuelva a crear la base de datos
                db.PreparaDB();
                // Agrega los listados
                db.mallasMedicas.AddRange(listaMallas);
                db.mallasMedicas.AddRange(listaSubMallas);
                db.medicos.AddRange(listaMedicos);
                db.configuracion.AddRange(listaConfiguracion);
                db.costoCitas.AddRange(listaCostoCitas);
                db.usuarios.AddRange(listaUsuarios);
                db.especialidads.AddRange(listaEspecialidad);
                db.modalidads.AddRange(listaModalidad);
                db.agendas.AddRange(listaAngendas);
                db.prerequisitos.AddRange(listaPrerequisitos);
                // Guarda todos los datos
                db.SaveChanges();
            }
        }
    }
}
