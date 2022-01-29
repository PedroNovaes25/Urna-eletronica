using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Aplicacao.dto;
using UrnaEletronica.Persistencia.Storage;

namespace UrnaEletronica.Aplicacao.Servicos
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoPersistencia _candidatoPersistencia;

        public CandidatoService(ICandidatoPersistencia candidatoPersistencia)
        {
            this._candidatoPersistencia = candidatoPersistencia;
        }

        public async Task<CandidatoDto> CandidadoAdd(CandidatoDto candidatoDto)
        {
            try
            {
                var candidato = candidatoDto.MapearParaModelo();
                candidato.DataDeRegistro = DateTime.Now;

                var foiCriado = await _candidatoPersistencia.CandidadoAdd(candidato);
                if (!foiCriado)
                    throw new Exception($"Não foi possível registrar candidato {candidatoDto.Nome}");
                
                var retornoCadidato = await _candidatoPersistencia.CandidatoGet(candidato.Legenda);

                return retornoCadidato.MapearParaDto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CandidatoDelete(CandidatoDto candidatoDto)
        {
            try
            {
                var candidato = await _candidatoPersistencia.CandidatoGet(candidatoDto.Legenda);
                if (candidato == null)
                    throw new Exception($"Não foi possível encontrar candidato com a legenda {candidatoDto.Legenda}");

                return await _candidatoPersistencia.CandidatoDelete(candidato);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<CandidatoDto> CandidatoGet(int legendaCandidato)
        {
            try
            {
                var candidatos = await _candidatoPersistencia.CandidatoGet(legendaCandidato);
                if (candidatos == null)
                    throw new Exception($"Não foi possível encontrar candidato com a legenda {legendaCandidato}");
                return candidatos.MapearParaDto();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<List<CandidatoDto>> CandidatosGet()
        {
            try
            {
                var candidatos = await _candidatoPersistencia.CandidatosGet();
                if (candidatos.Count == 0)
                    throw new Exception($"Não há candidatos registrados");

                return candidatos.MapearParaDto();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
