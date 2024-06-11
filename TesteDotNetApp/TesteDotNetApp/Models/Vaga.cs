using System.ComponentModel.DataAnnotations;
using TesteDotNetApp.ViewModel;

namespace TesteDotNetApp.Models

{
    public class Vaga
    {   

       
        [Key]
        public int ID { get; set; }

        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public string Tipo { get; set; }

        public string Setor { get; set; }

        public bool Ativa { get; set; } = true;
        
        public DateTime Data { get; set; } = DateTime.Now;

        public List<Candidato> Candidatos { get; set; } = new ();
    

    }
}
