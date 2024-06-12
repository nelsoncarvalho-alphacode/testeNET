using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VagasForDevs.Repositories.Interfaces;
using VagasForDevs.Models;

namespace VagasForDevs.Pages.Adm.Usuarios
{
    public class CreateModel : PageModel
    {
        private readonly IUsuarioRepository _usuarioRepository;

        [BindProperty]
        public Usuario Usuario { get; set; } = new Usuario();

        public CreateModel(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            _usuarioRepository.Create(Usuario);
            Response.Redirect("Index");
        }
    }
}
