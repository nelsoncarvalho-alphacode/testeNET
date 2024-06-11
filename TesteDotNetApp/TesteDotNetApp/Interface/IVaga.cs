using Microsoft.AspNetCore.Mvc;
using TesteDotNetApp.Models;
using TesteDotNetApp.ViewModel;

namespace TesteDotNetApp.Interface
{
    public interface IVaga
    {



        List<Vaga> ObterVagas();
        object ObterCandidatosVagaId(int id);
        void AdicionarVaga(Vaga vaga );


        void AdicionarCandidatoVaga( CreateCandidatoVagaDTO model);


        Vaga ObterVagaId(int id);
        void EditarVaga(Vaga vaga);

        void DeletarVaga(Vaga vaga);

     

    }
}
