using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;

namespace VagasForDevs.Pages.Vagas
{
    public class IndexModel : PageModel
    {
        public IVagaRepository _vagaRepository;
        public List<Vaga> vagas = new List<Vaga>();


        public IndexModel(IVagaRepository vagaRepository) 
        {
            _vagaRepository = vagaRepository;
        }

        public void OnGet()
        {
            vagas = _vagaRepository.GetAll();
        }


    }
}
