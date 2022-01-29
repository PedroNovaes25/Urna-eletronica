using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Aplicacao.dto;
using UrnaEletronica.Aplicacao.Servicos;

namespace UrnaControleApi.Controllers
{
    [Route("api/[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatoController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpPost]
        public async Task<IActionResult> Candidatar([FromBody] CandidatoDto candidatoDto)
        {
            try
            {
                var candidato = await _candidatoService.CandidadoAdd(candidatoDto);
                if (candidato == null) return NoContent();

                return Ok(candidato);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar candidato. Erro: {ex.Message}");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> CandidaturaRemover([FromBody] CandidatoDto candidatoDto)
        {
            try
            {
                return await _candidatoService.CandidatoDelete(candidatoDto) ? Ok(true) : throw new Exception("Ocorreu um problem não específico ao tentar remover candidatura.");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar remover candidatura. Erro: {ex.Message}");
            }
        }
        [HttpGet("{legendaCandidato}")]
        public async Task<IActionResult> Candidato(int legendaCandidato)
        {
            try
            {
                var candidato = await _candidatoService.CandidatoGet(legendaCandidato);
                if (candidato == null) return NoContent();

                return Ok(candidato);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar candidato. Erro: {ex.Message}");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Candidatos()
        {
            try
            {
                var candidato = await _candidatoService.CandidatosGet();
                if (candidato == null) return NoContent();

                return Ok(candidato);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar candidatos. Erro: {ex.Message}");
            }
        }
    }
}
