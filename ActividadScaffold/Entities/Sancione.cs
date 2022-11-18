namespace ActividadScaffold.Entities
{
    public partial class Sancione
    {
        public int Id { get; set; }
        public DateTime FechaActual { get; set; }
        public string Sancion { get; set; } = null!;
        public string? Observacion { get; set; }
        public decimal Valor { get; set; }
        public int? ConductorId { get; set; }

        public virtual Conductor? Conductor { get; set; }
    }
}
