using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrnaEletronica.Aplicacao.dto
{
    public class CandidatoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(50, MinimumLength = 3,ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string NomeVice { get; set; }
        public DateTime DataDeRegistro { get { return DateTime.Now; } }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(2, 2, ErrorMessage = "{0} a legenda para prefeito é são de dois dígitos")]
        public int Legenda { get; set; }
        public IEnumerable<VotoDto> Votos { get; set; }
    }
}
