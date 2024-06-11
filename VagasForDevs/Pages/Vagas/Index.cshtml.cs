using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VagasForDevs.Models;
using VagasForDevs.Services.Interfaces;

namespace VagasForDevs.Pages.Vagas
{
    public class IndexModel : PageModel
    {
        public IVagaService _vagaService;
        public List<Vaga> vagas = new List<Vaga>();


        public IndexModel(IVagaService vagaService) 
        {
            _vagaService = vagaService;
        }

        public void OnGet()
        {
            vagas = _vagaService.GetAllVagas();
        }


    }
}
