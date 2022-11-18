namespace ActividadScaffold.Entities
{
    public partial class Conductor
    {
        public Conductor()
        {
            Sanciones = new HashSet<Sancione>();
        }

        public int Id { get; set; }
        public string Identificacion { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string? Direccion { get; set; }
        public string Telefono { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? FechaNacimiento { get; set; }
        public bool Activo { get; set; }
        public int? MatriculaId { get; set; }

        public virtual Matricula? Matricula { get; set; }
        public virtual ICollection<Sancione> Sanciones { get; set; }
    }
}
