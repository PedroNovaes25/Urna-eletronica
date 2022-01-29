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
    public class CandidatoPersistencia : ICandidatoPersistencia
    {
        private readonly UrnaBDContext _context;
        public CandidatoPersistencia(UrnaBDContext context)
        {
            this._context = context;
        }

        public async Task<bool> CandidadoAdd(Candidato candidato)
        {
            await _context.AddAsync(candidato);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CandidatoDelete(Candidato candidato)
        {
            _context.Remove(candidato);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Candidato> CandidatoGet(int legendaCandidato)
        {
            IQueryable<Candidato> query = _context.Candidatos
            .Include(v => v.Votos);
            query = query.AsNoTracking().Where(vt => vt.Legenda == legendaCandidato);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Candidato>> CandidatosGet()
        {
            IQueryable<Candidato> query = _context.Candidatos
                .Include(v => v.Votos);
            query = query.AsNoTracking().OrderByDescending(x => x.Votos.Count());

            return await query.ToListAsync();
        }
    }
}
