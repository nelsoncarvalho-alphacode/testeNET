using System.ComponentModel.DataAnnotations;
using TesteDotNetApp.Models;

namespace TesteDotNetApp.ViewModel
{
    public class CreateVagaDTO 
    {

        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Setor { get; set; }

        [Required]
        public bool Ativa { get; set; } 
    }
}
