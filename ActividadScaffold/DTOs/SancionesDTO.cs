using ActividadScaffold.Entities;

namespace ActividadScaffold.DTOs
{
    public class SancionesDTO
    {
        public string Sancion { get; set; } = null!;
        public decimal Valor { get; set; }
        public int? ConductorId { get; set; }

    }
}
