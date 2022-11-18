using ActividadScaffold.Entities;

namespace ActividadScaffold.DTOs
{
    public class ConductorDTO
    {
        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Direccion { get; set; }
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Activo { get; set; }
        public int? MatriculaId { get; set; }

    }
}
