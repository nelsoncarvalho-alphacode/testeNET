using VagasForDevs.Models;

namespace VagasForDevs.Repositories.Interfaces;

public interface IPerfilVagaRepository
{
    PerfilVaga GetById(int id);
}
