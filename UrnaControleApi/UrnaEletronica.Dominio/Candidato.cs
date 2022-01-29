using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UrnaEletronica.Dominio
{
    public class Candidato
    {
        [Key]
        public int LegendaId { get; set; }
        public string Nome { get; set; }
        public string NomeVice { get; set; }
        public DateTime DataDeRegistro { get; set; }
        public string Legenda { get; set; }
        public virtual List<Voto> Votos { get; set; }
    }
}
