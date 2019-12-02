namespace ListaComprasWCF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ComprasContext : DbContext
    {
        public ComprasContext()
            : base("name=ComprasContext")
        {
        }

        public virtual DbSet<listacompra> listacompras { get; set; }
        public virtual DbSet<produto> produtoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<listacompra>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<listacompra>()
                .HasMany(e => e.produtoes)
                .WithOptional(e => e.listacompra)
                .HasForeignKey(e => e.id_lista);

            modelBuilder.Entity<produto>()
                .Property(e => e.nome)
                .IsUnicode(false);
        }
    }
}
