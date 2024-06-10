using System.Text.Json.Serialization;

namespace VagasAPI.Models
{
    public class VagaModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public TipoVaga Tipo { get; set; }
        public bool StatusVaga { get; set; }

    }
    public enum TipoVaga
    {
        CLT,
        PJ,
        Freelancer
    }
}
