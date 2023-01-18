using AutoMapper;
using Persona_API_MedVision.DTOs;
using Persona_API_MedVision.Model;

namespace Persona_API_MedVision.Common
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Persona, PersonaDto>();
            CreateMap<PersonaDto, Persona>();
        }
    }
}
