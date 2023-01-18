using Microsoft.EntityFrameworkCore;
using Persona_API_MedVision.Data;
using Persona_API_MedVision.Interfaces;
using Persona_API_MedVision.Model;

namespace Persona_API_MedVision.Repository
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly SqlDbContext_PruebaMedVisionDB mySqlDbContext;

        public PersonaRepository(SqlDbContext_PruebaMedVisionDB mySqlDbContext)
        {
            this.mySqlDbContext = mySqlDbContext;
        }

        public virtual async Task<IEnumerable<Persona>> GetAll() => await mySqlDbContext.Set<Persona>().ToListAsync();

        public virtual async Task<Persona?> GetById(string id) => await mySqlDbContext.Set<Persona>().FindAsync(keyValues: Convert.ToInt32(id));

        public virtual async Task<Persona> Insert(Persona entity)
        {
            mySqlDbContext.Set<Persona>().Add(entity);
            await mySqlDbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<Persona> Update(Persona entity)
        {
            mySqlDbContext.Set<Persona>().Update(entity);
            await mySqlDbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> Delete(string id)
        {
            var entity = await GetById(id);

            if (entity == null)
                return false;

            mySqlDbContext.Set<Persona>().Remove(entity);
            await mySqlDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> PersonaExists(int id)
            => await mySqlDbContext.persona.Where(e => e.IdPersona == id).AnyAsync();
        public async Task<bool> PersonaExistsByIdentificacion(string identificacion)
           => await mySqlDbContext.persona.Where(e => e.Identificacion == identificacion).AnyAsync();


    }
}
