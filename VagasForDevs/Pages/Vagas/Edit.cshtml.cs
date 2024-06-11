using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;
using VagasForDevs.Services.Interfaces;

namespace VagasForDevs.Pages.Vagas
{
    public class EditModel : PageModel
    {
        private readonly IVagaService _vagaService;
        private readonly IVagaRepository _vagaRepository;


        public string mensagemErro { get; set; } = "";
        public string mensagemSucesso { get; set; } = "";


        [BindProperty]
        public Vaga vaga { get; set; } = new Vaga();

        public EditModel(IVagaService vagaService, IVagaRepository vagaRepository)
        {
            _vagaService = vagaService;
            _vagaRepository = vagaRepository;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Query["Id"]);
            vaga = _vagaService.GetVagaById(id);
        }


        public void OnPost()
        {
            _vagaService.Update(vaga.Id, vaga);
            Response.Redirect("Index");
        }
    }
}
