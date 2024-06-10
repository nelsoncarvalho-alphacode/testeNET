using Microsoft.AspNetCore.Identity;

namespace VagasAPI.Models
{
    public class InscricaoModel
    {
        public int Id { get; set; }
        public int VagaId { get; set; }
        public string UserId { get; set; }
        public VagaModel Vaga { get; set; }
        public IdentityUser User { get; set; }
    }
}