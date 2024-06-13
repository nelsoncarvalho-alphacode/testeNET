using System.Runtime.InteropServices;
using VagasForDevs.Models;

namespace VagasForDevs.Repositories.Interfaces;

public interface IVagaRepository
{
    //MÉTODO QUE VAI SALVAR AS ALTERAÇÕES
    public void Commit();

    //OPERAÇÕES CRUD
    void Create(Vaga vaga);
    Vaga GetById(int id);
    List<Vaga> GetAll();
    void Update(int id, Vaga vagaEdit);
    void Delete(int id);

    //OUTRA OPERAÇÕES
    List<Usuario> GetCandidatos(int id);
}
