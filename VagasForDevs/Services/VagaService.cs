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

    public void Delete(int id)
    {
        _repository.Delete(id);
    }

    public void DeleteAllVagas()
    {
        _repository.DeleteAllVagas();
    }

    public Vaga GetVagaById(int id)
    {
       return _repository.GetVagaById(id);
    }

    public List<Vaga> GetAllVagas()
    {
        return _repository.GetAllVagas();
    }




    






}
