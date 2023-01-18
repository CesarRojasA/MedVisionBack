using Persona_API_MedVision.DTOs;

namespace Persona_API_MedVision.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<PersonaDto>> GetAll();
        Task<PersonaDto?> GetById(string id);
        Task<PersonaDto> Insert(PersonaDto personaDto);
        Task<PersonaDto> Update(PersonaDto personaDto);
        Task<bool> Delete(string id);
        Task<bool> PersonaExists(int id);
        Task<bool> PersonaExistsByIdentificacion(string identificacion);
    }
}
