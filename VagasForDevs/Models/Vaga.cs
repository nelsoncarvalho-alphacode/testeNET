using System.ComponentModel.DataAnnotations.Schema;

namespace VagasForDevs.Models;

public class Vaga
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int Id_Perfil { get; set; }
    public bool Ativa { get; set; } = false;
    public decimal Valor { get; set; }

    [ForeignKey("Id_Perfil")]
    public virtual PerfilVaga Perfil { get; set;} = new PerfilVaga();
}
