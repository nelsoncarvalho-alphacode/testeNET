using System.ComponentModel.DataAnnotations.Schema;

namespace VagasForDevs.Models;

[Table("Candidaturas")]
public class Candidatura
{
    public int Id { get; set; }
    public int Id_Usuario { get; set; }
    public int Id_Vaga { get; set; }

    //Propriedades de navegação
    public virtual Usuario Usuario { get; set; }
    public virtual Vaga Vaga { get; set; } 

}
