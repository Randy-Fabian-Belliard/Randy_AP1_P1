using System.ComponentModel.DataAnnotations;

public class Aportes
{
    [Key]
    public int AportesId { get; set; }

    [Required(ErrorMessage = "Este campo es requerido")]
    public DateTime Fecha { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Este campo es requerido")]
    public string? Persona { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public string? Observacion { get; set; }
    [Required(ErrorMessage = "Este campo es requerido")]
    public int Monto { get; set; }
    public int Conteo {get; set;} = 1;
}