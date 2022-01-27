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
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Voto> Votos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {


            //Testar se está correto
           // modelBuilder.Entity<Candidato>()
           //.HasMany(e => e.Votos)
           //.WithOne(rs => rs.Candidato)
           //.OnDelete(DeleteBehavior.Cascade);
        }
    }
}
