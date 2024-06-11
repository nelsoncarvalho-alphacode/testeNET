using Vagas.Repositories;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;

namespace VagasForDevs.Repositories;

public class PerfilVagaRepository : IPerfilVagaRepository
{
    private ApplicationContext _context;

    public PerfilVagaRepository(ApplicationContext context)
    {
        _context = context;
    }

    public PerfilVaga GetById(int id)
    {
        return _context.PerfilVaga.First(perfil => perfil.Id == id);
    }

}
