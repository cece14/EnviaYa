using LogicaNegocio.EntidadesDominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class LogisticaContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Seguimiento> Seguimientos { get; set; }
        public DbSet<EnvioEstandar> EnvioEstandar { get; set; }
        public DbSet<EnvioUrgente> EnvioUrgente { get; set; }

        public DbSet<Auditoria> Auditorias { get; set; }



        public LogisticaContext(DbContextOptions<LogisticaContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación uno a uno: Empleado - Usuario
            modelBuilder.Entity<Empleado>()
                .HasOne(e => e.Usuario)
                .WithOne(u => u.Empleado)
                .HasForeignKey<Usuario>(u => u.EmpleadoId)
                .OnDelete(DeleteBehavior.Cascade);

            // Herencia TPH para Envio
            modelBuilder.Entity<Envio>()
                .HasDiscriminator<string>("Tipo")
                .HasValue<EnvioEstandar>("Estandar")
                .HasValue<EnvioUrgente>("Urgente");

            // Value object 
            modelBuilder.Entity<Agencia>()
                .OwnsOne(a => a.Ubicacion);

            modelBuilder.Entity<Seguimiento>()
                .HasOne(s => s.Empleado)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            // Seguimiento → Envio (sin cascada)
            modelBuilder.Entity<Seguimiento>()
         .HasOne(s => s.Empleado)
         .WithMany()
         .OnDelete(DeleteBehavior.Cascade);



            // Value object Email como tipo embebido (Owned) para Cliente
            modelBuilder.Entity<Cliente>()
                .OwnsOne(c => c.Email, e =>
                {
                    e.Property(p => p.Valor).HasColumnName("Email_Valor");
                });
        }
    }
}