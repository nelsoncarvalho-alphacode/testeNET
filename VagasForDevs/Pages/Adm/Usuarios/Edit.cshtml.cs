using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;

namespace VagasForDevs.Pages.Adm.Usuarios
{
    public class EditModel : PageModel
    {
        private readonly IUsuarioRepository _usuarioRepository;

        [BindProperty]
        public Usuario Usuario { get; set; } = new Usuario();

        public EditModel(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Query["Id"]);
            Usuario = _usuarioRepository.GetById(id);
        }

        public void OnPost()
        {
            int id = int.Parse(Request.Query["Id"]);
            _usuarioRepository.Update(id, Usuario);

            Response.Redirect("Index");

        }


    }
}
