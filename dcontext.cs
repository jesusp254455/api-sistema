using api_sistema.modells;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace api_sistema
{
    public class dcontext:DbContext
    {
        public dcontext()
        {

        }
        public dcontext(DbContextOptions<dcontext> options) : base(options)
        {

        }
        public DbSet <t_usuario> t_usuario { get; set; }
        public DbSet<t_rol> t_rol { get; set; }
        public DbSet<t_tipodocumento> t_tipodocumento { get; set; }
        public DbSet<t_categoria> t_categoria { get; set; }
        public DbSet<t_producto> t_producto { get; set; }
        public DbSet<t_cliente> t_cliente { get; set; }
        public DbSet<t_fac_enc> t_fac_enc { get; set; }
        public DbSet<t_fact_deta> t_fact_deta { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<t_fac_enc>()
                   .HasMany(c => c.t_fact_deta)
                   .WithOne(e => e.T_fac_enc)
                   .HasForeignKey(p => p.fd_enc_id);
        }

    }

  
}
