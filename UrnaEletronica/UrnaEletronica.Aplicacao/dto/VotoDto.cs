using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica.Aplicacao.dto
{
    public class VotoDto
    {
        public int CandidatoId { get; set; }
        public DateTime DataDeVoto { get { return DateTime.Today; } }
    }
}
