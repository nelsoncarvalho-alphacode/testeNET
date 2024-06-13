using System.ComponentModel.DataAnnotations.Schema;

namespace VagasForDevs.Models;

[Table("Perfil_Usuario")]
public class PerfilUsuario
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
}
