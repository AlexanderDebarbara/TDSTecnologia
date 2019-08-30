using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Dominio;
using TDSTecnologia.Site.Core.Entities;

namespace TDSTecnologia.Site.Infrastructure.Map
{
    class CursoMapConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar")
                .HasColumnName("nome");

            builder.Property(x => x.Turno)
               .HasConversion(DominioConverter.ConverterDomTurno());

            builder.Property(x => x.Modalidade)
               .HasConversion(DominioConverter.ConverterDomModalidade());

            builder.Property(x => x.Nivel)
               .HasConversion(DominioConverter.ConverterDomNivel());

            builder.ToTable("tb01_curso");
        }
    }
}
