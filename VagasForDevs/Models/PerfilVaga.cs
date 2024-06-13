using System.ComponentModel.DataAnnotations.Schema;

namespace VagasForDevs.Models;

[Table("Perfil_Vaga")]
public class PerfilVaga
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
}
