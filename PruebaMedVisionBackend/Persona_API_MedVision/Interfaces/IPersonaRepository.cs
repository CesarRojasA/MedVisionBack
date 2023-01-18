using Persona_API_MedVision.Model;

namespace Persona_API_MedVision.Interfaces
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> GetAll();
        Task<Persona?> GetById(string id);
        Task<Persona> Insert(Persona entity);
        Task<Persona> Update(Persona entity);
        Task<bool> Delete(string id);
        Task<bool> PersonaExists(int id);
        Task<bool> PersonaExistsByIdentificacion(string identificacion);

    }
}
