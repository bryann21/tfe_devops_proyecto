using Microsoft.EntityFrameworkCore;
using MiProyectoWeb.Models;

namespace MiProyectoWeb.Data
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public required DbSet<Estado> Estados { get; set; }
        public required DbSet<Cliente> Clientes { get; set; }
        public required DbSet<Personal> Personales { get; set; }
        public required DbSet<Departamento> Departamentos { get; set; }
        public required DbSet<Tecnico> Tecnicos { get; set; }
        public required DbSet<Camioneta> Camionetas { get; set; }
        public required DbSet<Oficina> Oficinas { get; set; }
        public required DbSet<Smart> Smarts { get; set; }
        public required DbSet<Conexion> Conexiones { get; set; }
        public required DbSet<Nota> Notas { get; set; }
        public required DbSet<DetalleNota> DetalleNotas { get; set; }
        public required DbSet<Dano> Danos { get; set; }
        public required DbSet<DanoDia> DanosDia { get; set; }
        public required DbSet<Reagendar> Reagendar { get; set; }
        public required DbSet<DetalleReagendado> DetalleReagendados { get; set; }
        public required DbSet<Plan> Planes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ========================= PERSONAL - DEPARTAMENTO =========================

            modelBuilder.Entity<Personal>()
            .HasKey(p => p.IdPer);


                

            // ========================= DEPARTAMENTO =========================
            modelBuilder.Entity<Departamento>()
            .HasKey(d => d.IdDep);

            // ========================= TECNICO - CAMIONETA =========================
            modelBuilder.Entity<Tecnico>()
                .HasKey(t => t.IdTec);

            // ========================= OFICINA - PERSONAL =========================
            modelBuilder.Entity<Oficina>()
                .HasKey(o => o.IdOfi);
            // ========================= SMART - CONEXION =========================
            modelBuilder.Entity<Smart>()
                .HasKey(s => s.IdSmart);

            modelBuilder.Entity<Conexion>()
                .HasKey(c => c.IdCon);

            modelBuilder.Entity<Conexion>()
                .HasOne(c => c.Smart)
                .WithMany(s => s.Conexiones)
                .HasForeignKey(c => c.IdSmart);

            // ========================= NOTA - DETALLE_NOTA =========================
            modelBuilder.Entity<Nota>()
                .HasKey(n => n.IdNota);

            modelBuilder.Entity<DetalleNota>()
            .HasOne(dn => dn.Nota)
            .WithMany(n => n.Detalles)
            .HasForeignKey(dn => dn.IdNota);

            // ========================= DANOS =========================
            modelBuilder.Entity<Dano>()
                .HasKey(d => d.IdDano);

            modelBuilder.Entity<DanoDia>()
                .HasKey(dd => dd.IdDanoDia);

            // ========================= REAGENDAR =========================
            modelBuilder.Entity<Reagendar>()
                .HasKey(r => r.IdRea);

            modelBuilder.Entity<DetalleReagendado>()
                .HasKey(dr => dr.IdDetRea);

            // ========================= PLAN =========================
            modelBuilder.Entity<Plan>()
                .HasKey(p => p.IdPla);

            // ========================= ESTADO =========================
            modelBuilder.Entity<Estado>()
                .HasKey(e => e.IdEst);

            // ========================= CLIENTE =========================
            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.CedCli);
        }
    }
}
