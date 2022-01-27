using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Aplicacao.dto;

namespace UrnaEletronica.Aplicacao.Servicos
{
    public interface IVotoService
    {
        Task VotoAdd(VotoDto voto);
        Task<List<VotoDto>> VotosPorCandidatoGet(int candidatoId);
        Task<bool> VotosDelete();
    }
}
