using System.Runtime.InteropServices;
using VagasForDevs.Models;

namespace VagasForDevs.Repositories.Interfaces;

public interface IVagaRepository
{
    public void Commit();
    void Create(Vaga vaga);
    void Delete(int id);
    void Update(int id, Vaga vagaEdit);
    void DeleteAllVagas();
    Vaga GetVagaById(int id);
    List<Vaga> GetAllVagas();
}
