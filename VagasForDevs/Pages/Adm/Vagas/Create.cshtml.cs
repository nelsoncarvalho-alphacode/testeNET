using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;

namespace VagasForDevs.Pages.Vagas
{
    public class CreateModel : PageModel
    {
        private readonly IVagaRepository _vagaRepository;
        private readonly IPerfilVagaRepository _perfilVagaRepository;

        [BindProperty]
        public Vaga vaga { get; set; } = new Vaga();
        public string mensagemErro { get; set; } = "";
        public string mensagemSucesso { get; set; } = "";

        public CreateModel(IVagaRepository vagaRepository, IPerfilVagaRepository perfilVagaRepository) 
        {
            _vagaRepository = vagaRepository;
            _perfilVagaRepository = perfilVagaRepository;
        }


        public void OnGet()
        {

        }


        public void OnPost() 
        {
            vaga.Ativa = true;
            vaga.Perfil = _perfilVagaRepository.GetById(vaga.Id_Perfil);
            _vagaRepository.Create(vaga);

            vaga = new Vaga();

            Response.Redirect("Index");
        }



    }
}
