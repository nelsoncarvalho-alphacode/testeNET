using System.ComponentModel.DataAnnotations;

namespace TesteDotNetApp.Models
{
    
       public class Candidato
       {
      

        [Key]
        public int ID { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }       

        public DateTime Data { get; set; } = DateTime.Now;  
        
   


     
       }
}
