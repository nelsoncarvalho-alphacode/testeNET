using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;

namespace VagasForDevs.Pages.Adm.Usuarios
{
    public class IndexModel : PageModel
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public List<Usuario> Usuarios { get; set; } = new List<Usuario>();


        public IndexModel(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void OnGet()
        {
            Usuarios = _usuarioRepository.GetAll();
        }
    }
}
