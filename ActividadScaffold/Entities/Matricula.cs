namespace ActividadScaffold.Entities
{
    public partial class Matricula
    {
        public Matricula()
        {
            Conductors = new HashSet<Conductor>();
        }

        public int Id { get; set; }
        public string Numero { get; set; } = null!;
        public DateTime FechaExpedicion { get; set; }
        public DateTime ValidaHasta { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<Conductor> Conductors { get; set; }
    }
}
