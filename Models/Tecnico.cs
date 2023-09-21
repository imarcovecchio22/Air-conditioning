public class Tecnico{
    public int Id { get; set; }
    public string Nombre{get;set;}
    public string Apellido { get; set; }
    public int Edad { get; set; }
    public GeneroType Genero { get; set; } 

    public string Especializacion { get; set; }

    public string Ubicacion { get; set; }

    public List<FranjaHoraria> Disponibilidad { get; set; }

    public List<Cita> CitasProgramadas { get; set; }
}