using Vagas.Repositories;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;

namespace VagasForDevs.Repositories;

public class VagaRepository : IVagaRepository
{
    public ApplicationContext _context;

    public VagaRepository(ApplicationContext context)
    {
        _context = context;
    }


    public void Commit()
    {
        _context.SaveChanges();
    }


    public void Create(Vaga vaga)
    {
        _context.Vaga.Add(vaga);
        Commit();
    }

    public void Delete(int id)
    {
        Vaga vaga = GetVagaById(id);

        _context.Vaga.Remove(vaga);
        Commit();
    }


    public void Update(int id, Vaga vagaEdit) 
    {
        Vaga? vagaToBeUpdated = _context.Vaga.Find(id);

        if (vagaToBeUpdated != null)
        {
            vagaToBeUpdated.Descricao = vagaEdit.Descricao;
            vagaToBeUpdated.Id_Perfil = vagaEdit.Id_Perfil;
            vagaToBeUpdated.Valor = vagaEdit.Valor;
        }

        Commit();
    }



    public void DeleteAllVagas()
    {
        List<Vaga> vagas = GetAllVagas();

        _context.Vaga.RemoveRange(vagas);
        Commit();

    }


    public Vaga GetVagaById(int id)
    {
        return _context.Vaga.First(vaga => vaga.Id == id);
    }

    public List<Vaga> GetAllVagas()
    {
        return _context.Vaga.ToList();
    }

}
