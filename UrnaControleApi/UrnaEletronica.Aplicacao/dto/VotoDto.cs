using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Dominio;

namespace UrnaEletronica.Aplicacao.dto
{
    public class VotoDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int CandidatoId { get; set; }
    }


    public static class ConverterVotoParaModelo
    {

        public static Voto MapearParaModelo(this VotoDto votoDto) 
        {
            Voto voto = new Voto()
            {
                CandidatoId = votoDto.CandidatoId,
            };

            return voto;
        }

        public static List<Voto> MapearParaModelo(this List<VotoDto> votoDto)
        {
            List<Voto> Votos = new List<Voto>();
            if (votoDto == null)
                return null;

            foreach (var item in votoDto)
            {
                Votos.Add(MapearParaModelo(item));
            }

            return Votos;
        }

        public static VotoDto MapearParaDto(this Voto voto)
        {
            VotoDto votoDto = new VotoDto()
            {
                CandidatoId = voto.CandidatoId,
            };

            return votoDto;
        }

        public static List<VotoDto> MapearParaDto(this List<Voto> voto)
        {
            List<VotoDto> VotosDto = new List<VotoDto>();
            foreach (var item in voto)
            {
                VotosDto.Add(MapearParaDto(item));
            }

            return VotosDto;
        }
    }
}
