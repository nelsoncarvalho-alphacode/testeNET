using Microsoft.AspNetCore.Mvc.RazorPages;
using VagasForDevs.Repositories.Interfaces;
using VagasForDevs.Models;
using Microsoft.AspNetCore.Mvc;


namespace VagasForDevs.Pages;
public class IndexModel : PageModel
{
    private readonly IUsuarioRepository _usuarioRepository;

    [BindProperty]
    public Usuario Usuario { get; set; } = new Usuario();

    public IndexModel(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public void OnGet()
    {

    }


    public void OnPost()
    {
        Usuario usuarioLogado = _usuarioRepository.GetByLogin(Usuario.Email, Usuario.Senha);

        if (usuarioLogado != null)
        {
            HttpContext.Session.SetInt32("IdLogado", usuarioLogado.Id);

            if (usuarioLogado.Id_Perfil == 1)
                Response.Redirect("/Adm/Vagas/Index");

            else if (usuarioLogado.Id_Perfil == 2)
                Response.Redirect("/Candidato/Vagas/Index");
        }

    }
}
