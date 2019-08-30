using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TDSTecnologia.Site.Core.Dominio;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Map;

namespace TDSTecnologia.Site.Infrastructure.Data
{
    public class AppContexto : DbContext
    {
        public AppContexto(DbContextOptions<AppContexto> opcoes) : base(opcoes)
        {
        }

        public DbSet<Curso> CursoDao { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CursoMapConfiguration());
        }
    }
}
