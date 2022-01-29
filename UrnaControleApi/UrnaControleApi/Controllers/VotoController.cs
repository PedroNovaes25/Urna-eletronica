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
    [ApiController]
    [Route("api/[controller]")]
    public class VotoController : ControllerBase
    {
        private readonly IVotoService _votoService;

        public VotoController(IVotoService votoService)
        {
            _votoService = votoService;
        }

        [HttpPost]
        public async Task<IActionResult> Votar([FromBody] VotoDto votoDto) 
        {
            try
            {
                var votoCriado = await _votoService.VotoAdd(votoDto);
                if (!votoCriado)
                    throw new Exception("Ocorreu um problem não específico ao tentar votar."); 

                return Ok(votoCriado);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar votar. Erro: {ex.Message}");
            }
        }

        [HttpGet("{legendaCandidato}")]
        public async Task<IActionResult> Votos(int legendaCandidato)
        {
            try
            {
                var votos = await _votoService.VotosPorCandidatoGet(legendaCandidato);
                if (votos == null) return NoContent();

                return Ok(votos);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar votos. Erro: {ex.Message}");
            }
        }

        [HttpDelete("reiniciar")]
        public async Task<IActionResult> ReiniciarVotacao()
        {
            try
            {
                return await _votoService.VotosDelete() ? Ok(true) : throw new Exception("Ocorreu um problem não específico ao tentar reiniciar votos."); 
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar recuperar votos. Erro: {ex.Message}");
            }
        }
    }
}
