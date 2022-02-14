using Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace DBcontex
{
    public class AgendaContex : DbContext
    {

        public AgendaContex(DbContextOptions<AgendaContex> options)
       : base(options)
        {

        }

        //Se asegura del borrado y la creacion de la base de datos
        public void PreparaDB()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relacion 1 muchos Agenda Usuario
            modelBuilder.Entity<Agenda>()
              .HasOne(agenda => agenda.Usuario)
              .WithMany(usuario => usuario.Agendas)
              .HasForeignKey(agenda => agenda.UserId);
            //Relacion Agenda Modalidad
            modelBuilder.Entity<Agenda>()
            .HasOne(modalidad => modalidad.Modalidad)
            .WithMany(agenda => agenda.Agendas)
            .HasForeignKey(modalidad => modalidad.ModalidadId);
            //Relacion Costo Cita
             modelBuilder.Entity<Agenda>()
            .HasOne(cita => cita.CostoCita)
            .WithMany(agenda => agenda.Agendas)
            .HasForeignKey(cita => cita.CitaId);

            //Matriculas det
            //Relacion Agenda Angenda dets 
            modelBuilder.Entity<AgendaDets>()
              .HasOne(agenda => agenda.Agenda)
              .WithMany(dets => dets.AgendaDets)
              .OnDelete(DeleteBehavior.NoAction)
              .HasForeignKey(agenda => agenda.AngendaId);
            // Agendadets Especialidad
            modelBuilder.Entity<AgendaDets>()
              .HasOne(especialidad => especialidad.Especialidad)
              .WithMany(agenda => agenda.AgendasDets)
              .HasForeignKey(especialidad => especialidad.EspecialidadId);
    
            //Relacion Agenda Dets Pagos
            modelBuilder.Entity<AgendaDets>()
              .HasOne(pagos => pagos.PagoCita)
              .WithOne(dets => dets.AgendaDets)
              .HasForeignKey<PagoCita>( pagos=> pagos.AngendaDetId);

            //Configuracion Prerequisitos
            //Clave primaria compuesta
            modelBuilder.Entity<Prerequisito>()
              .HasKey(prerequisito => new
              {
                  prerequisito.MallaMedicaId,
                  prerequisito.MedicoId
              });
            // Prerequisitos y malla (Desactivar Delete OnCascade)
            modelBuilder.Entity<Prerequisito>()
                .HasOne(prerequisito => prerequisito.MallaMedicacs)
                .WithMany(malla => malla.PreRequisitos)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(prerequisito => prerequisito.MallaMedicaId);

            modelBuilder.Entity<Prerequisito>()
                .HasOne(prerequisito => prerequisito.Medico)
                .WithMany(materia => materia.Prerequisitos)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(prerequisito => prerequisito.MedicoId);

            // Configuracion
            // La clase configuración tiene clave primaria de tipo distinta que int
            modelBuilder.Entity<Configuracion>()
                .HasKey(configuracion => configuracion.NombreClinica);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // Si no se ha configurado la conección la configura con SqlServer
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server=Server=MSI\\SQLEXPRESS; Initial Catalog=Agenda; trusted_connection=true;");
                // .LogTo(Console.WriteLine, LogLevel.Information);  // Para activar el modo debug
            }
        }
        // Declaración de las entidades del modelo
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Medico> medicos { get; set; }
        public DbSet<Especialidad> especialidads { get; set; }
        public DbSet<Agenda> agendas { get; set; }
        public DbSet<AgendaDets> agendasDets { get; set; }
        public DbSet<CostoCita> costoCitas { get; set; }
        public DbSet<PagoCita> pagoCitas { get; set; }
        public DbSet<MallaMedicacs> mallasMedicas { get; set; }
        public DbSet<Prerequisito> prerequisitos { get; set; }
        public DbSet<Modalidad> modalidads { get; set; }
        public DbSet<Configuracion> configuracion { get; set; }

    }
}