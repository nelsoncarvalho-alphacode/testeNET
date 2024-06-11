namespace VagasForDevs.Models;

public class Candidatura
{
    public int Id { get; set; }
    public int Id_Usuario { get; set; }
    public int Id_Vaga { get; set; }

    //Propriedades de navegação
    public virtual Usuario usuario { get; set; } = new Usuario();
    public virtual Vaga vaga { get; set; } = new Vaga();

}
