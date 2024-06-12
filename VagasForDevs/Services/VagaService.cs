using VagasForDevs.Repositories.Interfaces;
using VagasForDevs.Models;
using VagasForDevs.Services.Interfaces;

namespace VagasForDevs.Services;

public class VagaService : IVagaService
{
    private readonly IVagaRepository _repository;  

    public VagaService(IVagaRepository repository)
    {
        _repository = repository;
    }


    public void Create(Vaga vaga)
    {
        _repository.Create(vaga);
    }

    public void Update(int id, Vaga vagaEdit)
    {
        _repository.Update(id, vagaEdit);
    }

    public void SwitchStatus(int id)
    {
        Vaga vaga = GetVagaById(id);

        if (vaga.Ativa)
            vaga.Ativa = false;

        else if (!vaga.Ativa)
            vaga.Ativa = true;

        Update(id, vaga);
    }

    public void Delete(int id)
    {
        _repository.Delete(id);
    }
    public Vaga GetById(int id)
    {
       return _repository.GetVagaById(id);
    }

    public List<Vaga> GetAll()
    {
        return _repository.GetAllVagas();
    }

    public List<Usuario> GetCandidatos(int id)
    {
        Vaga vaga = GetById(id);
        return vaga.Candidaturas.Select(candidatura => candidatura.Usuario).ToList();
    }










}
