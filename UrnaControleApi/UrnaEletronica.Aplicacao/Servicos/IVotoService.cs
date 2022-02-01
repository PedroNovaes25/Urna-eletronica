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
        Task<bool> VotoAdd(VotoDto voto);
        Task<List<VotoDto>> VotosPorCandidatoGet(int legendaId);
        Task<bool> VotosDelete();
    }
}
