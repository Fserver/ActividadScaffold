using ActividadScaffold.Entities;

namespace ActividadScaffold.DTOs
{
    public class SancionesDTO
    {
        public DateTime FechaActual { get; set; }
        public string Sancion { get; set; } = null!;
        public decimal Valor { get; set; }

    }
}
