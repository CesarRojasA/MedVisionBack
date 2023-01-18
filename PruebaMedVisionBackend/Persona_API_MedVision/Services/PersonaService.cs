using AutoMapper;
using Persona_API_MedVision.DTOs;
using Persona_API_MedVision.Interfaces;
using Persona_API_MedVision.Model;

namespace Persona_API_MedVision.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository personaRepository;
        public readonly IMapper mapper;

        public PersonaService(IPersonaRepository personaRepository, IMapper mapper)
        {
            this.personaRepository = personaRepository;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<PersonaDto>> GetAll()
            => (await personaRepository.GetAll()).Select(x => mapper.Map<PersonaDto>(x));

        public async Task<PersonaDto?> GetById(string id)
            => mapper.Map<PersonaDto>(await personaRepository.GetById(id));

        public async Task<PersonaDto> Insert(PersonaDto personaDto)
            => mapper.Map<PersonaDto>(await personaRepository.Insert(mapper.Map<Persona>(personaDto)));

        public async Task<PersonaDto> Update(PersonaDto personaDto)
            => mapper.Map<PersonaDto>(await personaRepository.Update(mapper.Map<Persona>(personaDto)));

        public async Task<bool> Delete(string id)
        {
            var persona = await personaRepository.GetById(id);
            if (persona == null)
                throw new Exception("Persona No Encontrada");
            var result = await personaRepository.Delete(id);
            return (result);
        }

        public async Task<bool> PersonaExists(int id)
            => await personaRepository.PersonaExists(id);

        public async Task<bool> PersonaExistsByIdentificacion(string identificacion)
            => await personaRepository.PersonaExistsByIdentificacion(identificacion);
    }
}
