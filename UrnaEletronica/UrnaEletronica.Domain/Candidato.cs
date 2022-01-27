using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UrnaEletronica.Dominio
{
    public class Candidato
    {
        public string Nome { get; set; }
        public string NomeVice { get; set; }
        public DateTime DataDeRegistro { get; set; }
        [Key]
        public int Legenda { get; set; }
        public IEnumerable<Voto> Votos { get; set; }
    }
}
