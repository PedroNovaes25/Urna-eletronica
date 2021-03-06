using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Dominio;

namespace UrnaEletronica.Persistencia._BDContexto
{
    public class UrnaBDContext : DbContext
    {
        public UrnaBDContext(DbContextOptions<UrnaBDContext> opcoes) : base(opcoes)
        {}

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Candidato>().HasData
                (
                    new Candidato 
                    {
                        Nome = "Branco",
                        LegendaId = 8,
                        DataDeRegistro = DateTime.Today
                    },
                    new Candidato
                    {
                        Nome = "Nulo",
                        LegendaId = 9,
                        DataDeRegistro = DateTime.Today,
                    }
                );
        }

    }
}
