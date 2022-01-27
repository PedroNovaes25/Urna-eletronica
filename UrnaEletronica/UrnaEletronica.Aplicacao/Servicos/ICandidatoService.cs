using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Aplicacao.dto;

namespace UrnaEletronica.Aplicacao.Servicos
{
    public interface ICandidatoService
    {
        Task<CandidatoDto> CandidadoAdd(CandidatoDto candidato);
        Task<bool> CandidatoDelete(CandidatoDto candidato);
        Task<List<CandidatoDto>> CandidatosGet();
        Task<CandidatoDto> CandidatoGet(int legendaCandidato);
    }
}
