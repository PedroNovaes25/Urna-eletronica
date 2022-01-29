using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrnaEletronica.Dominio;
using UrnaEletronica.Persistencia._BDContexto;
using UrnaEletronica.Persistencia.Storage;

namespace UrnaEletronica.Persistencia.Armazem
{
    public class VotoPersistencia : IVotoPersistencia
    {
        private readonly UrnaBDContext _context;

        public VotoPersistencia(UrnaBDContext context)
        {
            this._context = context;
        }
        public async Task<bool> VotoAdd(Voto voto)
        {
            await _context.AddAsync(voto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> VotosDelete()
        {
            var votos = _context.Votos.AsNoTracking().ToList();
             _context.RemoveRange(votos);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Voto>> VotosPorCandidatoGet(int candidatoId)
        {
            IQueryable<Voto> query = _context.Votos.Include(cd => cd.Candidato);

            query.AsNoTracking().Where(vt => vt.CandidatoId == candidatoId);

            query = query.AsNoTracking().Where(vt => vt.CandidatoId == candidatoId);

            return await query.ToListAsync();
            //return await query.ToListAsync();
        }
    }
}
