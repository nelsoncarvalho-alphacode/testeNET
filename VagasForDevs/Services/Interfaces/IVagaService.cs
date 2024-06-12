using VagasForDevs.Models;
namespace VagasForDevs.Services.Interfaces;

public interface IVagaService
{
    void Create(Vaga vaga);
    void Delete(int id);
    void Update(int id, Vaga vaga);
    void SwitchStatus(int id);
    Vaga GetVagaById(int id);
    List<Vaga> GetAll();
    List<Usuario> GetCandidatos(int id);
}
