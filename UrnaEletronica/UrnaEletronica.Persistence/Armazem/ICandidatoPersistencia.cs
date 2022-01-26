using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Dominio;

namespace UrnaEletronica.Persistencia.Storage
{
    public interface ICandidatoPersistencia
    {
        Task<Candidato> CandidadoAdd(Candidato candidato);
        Task<bool> CandidatoDelete(Candidato candidato);
        Task<List<Candidato>> CandidatosGet();
    }
}
