using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica.Dominio
{
    public class Voto
    {
        public int Id { get; set; }
        public int CandidatoId { get; set; }
        public virtual Candidato Candidato { get; set; }
        public DateTime DataDeVoto { get; set; }
    }
}
