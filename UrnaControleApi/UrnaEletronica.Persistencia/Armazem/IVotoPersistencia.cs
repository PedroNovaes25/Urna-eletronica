using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Dominio;

namespace UrnaEletronica.Persistencia.Storage
{
    public interface IVotoPersistencia
    {
        Task<bool> VotoAdd(Voto voto);
        Task<List<Voto>> VotosPorCandidatoGet(int candidatoId);
        Task<bool> VotosDelete();
    }
}
