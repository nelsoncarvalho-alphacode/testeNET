using VagasForDevs.Models;

namespace VagasForDevs.Repositories.Interfaces;

public interface ICandidaturaRepository
{
    void Commit();
    void Create(Candidatura candidatura);
    void Delete(int id);
    Candidatura GetById(int id);
    Candidatura GetByUsuarioVaga(int idUsuario, int idVaga);
}
