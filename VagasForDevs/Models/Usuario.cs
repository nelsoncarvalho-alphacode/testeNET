using System.ComponentModel.DataAnnotations.Schema;

namespace VagasForDevs.Models;
public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public int Id_Perfil { get; set; }

    //propriedade de navegação 
    [ForeignKey("Id_Perfil")]
    public virtual PerfilUsuario Perfil { get; set; } = new PerfilUsuario();

}
