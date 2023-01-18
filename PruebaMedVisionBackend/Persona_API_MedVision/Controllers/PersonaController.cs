using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persona_API_MedVision.DTOs;
using Persona_API_MedVision.Interfaces;
using System.Data;

namespace Persona_API_MedVision.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService personaService;
        public PersonaController(IPersonaService personaService)
        {
            this.personaService = personaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonaDto>>> GetAll()
        {
            try { return new OkObjectResult(await personaService.GetAll()); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDto>> GetById(string id)
        {
            try { return new OkObjectResult(await personaService.GetById(id)); }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(string id)
        {
            try
            {
                var result = await personaService.Delete(id);
                return new OkObjectResult(result);
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPost]
        public async Task<ActionResult<PersonaDto>> Post(PersonaDto personaDto)
        {
            try
            {
                if (await personaService.PersonaExistsByIdentificacion(personaDto.Identificacion))
                    return BadRequest(string.Format("Por favor validar la identificacion {0}", personaDto.Identificacion));
                return new OkObjectResult(await personaService.Insert(personaDto));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonaDto>> Put(PersonaDto personaDto, int id)
        {
            try
            {
                if (personaDto.IdPersona != id)
                    return BadRequest("Por favor validar id");
                if (!await personaService.PersonaExists(id))
                    return NotFound(string.Format("La persona {0} no existe", id));

                return new OkObjectResult(await personaService.Update(personaDto));
            }
            catch (Exception ex) { return StatusCode(500, ex.Message); }
        }
    }
}