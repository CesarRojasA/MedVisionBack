using System.ComponentModel.DataAnnotations;

namespace Persona_API_MedVision.DTOs
{
    public class PersonaDto
    {
        public int? IdPersona { get; set; }

        [Required(ErrorMessage = "El campo  Nombre es requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo  Apellido es requerido")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El campo  Identificacion es requerido")]
        public string Identificacion { get; set; } = String.Empty;

        [Required(ErrorMessage = "El campo  Edad es requerido")]
        public int Edad { get; set; }

    }
}
