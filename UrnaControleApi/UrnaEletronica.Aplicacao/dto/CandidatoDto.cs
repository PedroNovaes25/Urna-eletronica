using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Dominio;

namespace UrnaEletronica.Aplicacao.dto
{
    public class CandidatoDto
    {

        public int LegendaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(50, MinimumLength = 3, ErrorMessage = "Intervalo permitido de 3 a 50 caracteres.")]
        public string NomeVice { get; set; }
        public DateTime DataDeRegistro { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório"),
        StringLength(4, MinimumLength = 2, ErrorMessage = "A legenda deve ter entre 2 e 4 carácteres ")]
        public string Legenda { get; set; }
        public virtual List<VotoDto> Votos { get; set; }

    }

    public static class ConverterCandidatoPara
    {

        public static Candidato MapearParaModelo(this CandidatoDto candidatoDto)
        {
            Candidato candidato = new Candidato()
            {
                Nome = candidatoDto.Nome,
                NomeVice = candidatoDto.NomeVice,
                LegendaId = candidatoDto.LegendaId,
                Legenda = candidatoDto.Legenda,
                Votos = candidatoDto.Votos.MapearParaModelo()
            };

            return candidato;
        }

        public static List<Candidato> MapearParaModelo(this List<CandidatoDto> candidatosDto)
        {
            List<Candidato> candidatos = new List<Candidato>();
            foreach (var item in candidatosDto)
            {
                candidatos.Add(MapearParaModelo(item));
            }

            return candidatos;
        }

        public static CandidatoDto MapearParaDto(this Candidato candidato)
        {
            CandidatoDto candidatoDto = new CandidatoDto()
            {
                Nome = candidato.Nome,
                NomeVice = candidato.NomeVice,
                Legenda = candidato.Legenda,
                LegendaId = candidato.LegendaId,
                
                Votos = candidato.Votos.MapearParaDto()
            };
            candidatoDto.DataDeRegistro = candidato.DataDeRegistro;

            return candidatoDto;
        }

        public static List<CandidatoDto> MapearParaDto(this List<Candidato> candidato)
        {
            List<CandidatoDto> candidatoDto = new List<CandidatoDto>();
            foreach (var item in candidato)
            {
                candidatoDto.Add(MapearParaDto(item));
            }

            return candidatoDto;
        }
    }
}
