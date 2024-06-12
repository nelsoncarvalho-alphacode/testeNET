using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VagasForDevs.Repositories.Interfaces;
using VagasForDevs.Models;

namespace VagasForDevs.Pages.Candidato.Vagas
{
    public class IndexModel : PageModel
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public Usuario UsuarioLogado { get; set; } = new Usuario();
        public List<Vaga> Vagas { get; set; } = new List<Vaga>();

        public IndexModel(IVagaRepository vagaRepository, IUsuarioRepository usuarioRepository)
        {
            _vagaRepository = vagaRepository;
            _usuarioRepository = usuarioRepository;
        }

        public void OnGet()
        {
            int id = HttpContext.Session.GetInt32("IdLogado") ?? 0;
            UsuarioLogado = _usuarioRepository.GetById(id);
            Vagas = _vagaRepository.GetAll();
        }
    }
}
