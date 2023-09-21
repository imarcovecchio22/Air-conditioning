using Microsoft.AspNetCore.Identity;

public class Cita
{
    public int Id { get; set; }
    public DateTime HoraInicio { get; set; }
    public DateTime HoraFin { get; set; }
    public int TecnicoId { get; set; }
    public Tecnico Tecnico { get; set; }

    public string UsuarioId { get; set; } 
    public IdentityUser Usuario { get; set; }
}