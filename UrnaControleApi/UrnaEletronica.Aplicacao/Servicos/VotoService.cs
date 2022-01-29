using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Aplicacao.dto;
using UrnaEletronica.Dominio;
using UrnaEletronica.Persistencia.Storage;

namespace UrnaEletronica.Aplicacao.Servicos
{
    public class VotoService : IVotoService
    {
        private readonly IVotoPersistencia _votoPersistencia;
        private readonly ICandidatoPersistencia _candidatoPersistencia;

        public VotoService(IVotoPersistencia votoPersistencia, ICandidatoPersistencia candidatoPersistencia)
        {
            _votoPersistencia = votoPersistencia;
            _candidatoPersistencia = candidatoPersistencia;
        }

        public async Task<bool> VotoAdd(VotoDto votoDto)
        {
            try
            {
                var candidatoExiste = await _candidatoPersistencia.CandidatoGet(votoDto.CandidatoId)!=null;
                if (!candidatoExiste)
                    return false;
                var voto = votoDto.MapearParaModelo();
                voto.DataDeVoto = DateTime.Now;
                return await _votoPersistencia.VotoAdd(voto);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> VotosDelete()
        {
            return await _votoPersistencia.VotosDelete();
        }

        public async Task<List<VotoDto>> VotosPorCandidatoGet(int lengendaCandidato)
        {
            try
            {
                var votosDoCandidato = await _votoPersistencia.VotosPorCandidatoGet(lengendaCandidato);
                if (votosDoCandidato.Count == 0)
                    throw new Exception($"Não foi encontrado votos para o candidado da legenda {lengendaCandidato}");
                return votosDoCandidato.MapearParaDto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
