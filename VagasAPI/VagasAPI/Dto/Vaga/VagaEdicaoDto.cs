using VagasAPI.Models;

namespace VagasAPI.Dto.Vaga
{
    public class VagaEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; internal set; }
        public TipoVaga Tipo { get; set; }
    }
}
