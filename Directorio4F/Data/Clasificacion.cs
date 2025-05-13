using System.ComponentModel.DataAnnotations;

namespace Directorio4F.Data
{
    public class Clasificacion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo Nombre no puede tener más de 100 caracteres.")]
        public string? Nombre { get; set; }
        virtual public ICollection<Persona>? Personas { get; set; }
    }
}
