using System.ComponentModel.DataAnnotations;

namespace Directorio4F.Data
{
    public class Persona
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo Nombre no puede tener más de 100 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido.")]
        [StringLength(100, ErrorMessage = "El campo Correo no puede tener más de 100 caracteres.")]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es obligatorio.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El campo Teléfono debe contener exactamente 10 dígitos.")]
        [StringLength(10, ErrorMessage = "El campo Teléfono no puede tener más de 10 caracteres.")]
        public string? Telefono { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "El campo Clasificación es obligatorio.")]
        public int ClasificacionId { get; set; }
        virtual public Clasificacion? Clasificacion { get; set; }
        public ICollection<Habito>? Habitos { get; set; }
    }
}
