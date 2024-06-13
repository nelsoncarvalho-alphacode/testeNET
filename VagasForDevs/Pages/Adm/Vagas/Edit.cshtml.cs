using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;

namespace VagasForDevs.Pages.Vagas
{
    public class EditModel : PageModel
    {
        private readonly IVagaRepository _vagaRepository;


        public string mensagemErro { get; set; } = "";
        public string mensagemSucesso { get; set; } = "";


        [BindProperty]
        public Vaga vaga { get; set; } = new Vaga();

        public EditModel(IVagaRepository vagaRepository)
        {
            _vagaRepository = vagaRepository;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Query["Id"]);
            vaga = _vagaRepository.GetById(id);
        }


        public void OnPost()
        {
            _vagaRepository.Update(vaga.Id, vaga);
            Response.Redirect("Index");
        }
    }
}
