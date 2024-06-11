using TesteDotNetApp.Models;

namespace TesteDotNetApp.Interface
{
    public interface ICandidato
    {
        List<Candidato> ObterCandidatos();

        Candidato AdicionarCandidato(Candidato candidato);
        Candidato ObterCandidatoId(int id);
        void EditarCandidato(Candidato candidato);

        void DeletarCandidato(Candidato candidato);
       
    
      
    }
}
