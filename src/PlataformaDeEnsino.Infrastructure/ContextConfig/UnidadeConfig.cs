using Microsoft.EntityFrameworkCore;
using PlataformaDeEnsino.Core.Entities;

namespace PlataformaDeEnsino.Infrastructure.ContextConfig
{
    public class UnidadeConfig
    {
        public static void Unidade(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unidade>(u =>
            {
                u.ToTable("Unidade");
                u.HasKey(i => i.IdDaUnidada);
                u.Property(i => i.IdDaUnidada).IsRequired().ValueGeneratedOnAdd();
                u.Property(n => n.NomeDaUnidade).IsRequired().HasColumnType("varchar(150)").HasMaxLength(150);
                u.Property(d => d.DiretorioDaUnidade).IsRequired().HasColumnType("varchar(200)").HasMaxLength(200);
                u.HasOne(m => m.Modulo).WithMany(m => m.Unidades).HasForeignKey(m => m.IdDoModulo);
                u.HasOne(p => p.Professor).WithMany(p => p.Unidades).HasForeignKey(p => p.IdDoProfessor).IsRequired();
            });
        }
    }
}