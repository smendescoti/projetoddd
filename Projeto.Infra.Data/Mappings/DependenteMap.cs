using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class DependenteMap : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.ToTable("Dependente");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.Id)
                .HasColumnName("IdDependente");

            builder.Property(d => d.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(d => d.DataNascimento)
                .HasColumnName("DataNascimento")
                .IsRequired();

            builder.Property(d => d.Sexo)
                .HasColumnName("Sexo")
                .IsRequired();

            builder.Property(d => d.ClienteId)
                .HasColumnName("ClienteId")
                .IsRequired();

            #region Mapeamento de ForeignKey

            //Dependente TEM 1 Cliente / Cliente TEM Muitos Dependentes
            builder.HasOne(d => d.Cliente) //Dependente TEM 1 Cliente
                .WithMany(c => c.Dependentes) //Cliente TEM * Dependentes
                .HasForeignKey(d => d.ClienteId); //Chave estrangeira

            #endregion

        }
    }
}
