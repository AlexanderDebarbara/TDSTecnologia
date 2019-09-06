using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Entities;

namespace TDSTecnologia.Site.Infrastructure.Map
{
    public class PermissaoMapConfiguration : IEntityTypeConfiguration<Permissao>
    {
        public void Configure(EntityTypeBuilder<Permissao> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(n => n.Descricao).HasColumnName("descricao")
                .IsRequired()
                .HasMaxLength(400);
            builder.ToTable("tb03_permissao");

        }
    }
}
