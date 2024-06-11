using System.ComponentModel.DataAnnotations;
using TesteDotNetApp.Models;

namespace TesteDotNetApp.ViewModel
{
    public class CreateCandidatoDTO
    {
        [Required]
        public string Nome { get; set; }
        
        [Required]
        public string Email { get; set; }
    }
}
