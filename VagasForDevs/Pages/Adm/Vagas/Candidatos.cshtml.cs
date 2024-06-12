using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;

namespace VagasForDevs.Pages.Adm.Vagas
{
    public class CandidatosModel : PageModel
    {
        
        private readonly IVagaRepository _vagaRepository;
        
        public Vaga Vaga { get; set; } = new Vaga();
        public List<Usuario> Candidatos { get; set; } = new List<Usuario>();


        public CandidatosModel(IVagaRepository vagaRepository)
        {
            _vagaRepository = vagaRepository;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Query["Id"]);

            Vaga = _vagaRepository.GetById(id);
            Candidatos = Vaga.Candidaturas.Select(candidatura => candidatura.Usuario).ToList();
        }
        
    }
}
