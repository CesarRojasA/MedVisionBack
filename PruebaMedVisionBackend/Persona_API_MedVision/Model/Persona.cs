using System.ComponentModel.DataAnnotations;

namespace Persona_API_MedVision.Model
{
    public partial class Persona
    {
        [Key]
        [Display(Name = "id_persona")]
        public int IdPersona { get; set; }
        [Required]
        [Display(Name = "nombre")]
        public string? Nombre { get; set; }
        [Required]
        [Display(Name = "apellido")]
        public string? Apellido { get; set; }
        [Required]
        [Display(Name = "identificacion")]
        public string Identificacion { get; set; } = string.Empty;
        [Required]
        [Display(Name = "edad")]
        public int Edad { get; set; }

    }
}
