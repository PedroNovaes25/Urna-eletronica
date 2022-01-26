using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica.Dominio
{
    public class Voto
    {
        public Candidato CandidatoId { get; set; }
        public DateTime DataDeVoto { get; set; }
    }
}
