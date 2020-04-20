using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevIO.Data.Mappings
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(f => f.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(f => f.Numero)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(f => f.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(f => f.Complemento)
               .HasColumnType("varchar(150)");

            builder.Property(f => f.Bairro)
               .IsRequired()
               .HasColumnType("varchar(100)");

            builder.Property(f => f.Cidade)
              .IsRequired()
              .HasColumnType("varchar(100)");

            builder.Property(f => f.Estado)
             .IsRequired()
             .HasColumnType("varchar(40)");



            builder.ToTable("Enderecos");
        }
    }
}
