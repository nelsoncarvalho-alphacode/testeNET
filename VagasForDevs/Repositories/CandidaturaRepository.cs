using Vagas.Repositories;
using VagasForDevs.Repositories.Interfaces;
using VagasForDevs.Models;

namespace VagasForDevs.Repositories;

public class CandidaturaRepository : ICandidaturaRepository
{
    private readonly ApplicationContext _context;

    public CandidaturaRepository(ApplicationContext context)
    {
        _context = context;
    }

    //OPERAÇÃO PARA SALVAR AS MUDANÇAS NO BANCO
    public void Commit()
    {
        _context.SaveChanges();
    }

    //OPERAÇÕES CRUD
    public void Create(Candidatura candidatura)
    {
        _context.Candidatura.Add(candidatura);
        Commit();
    }
    public Candidatura GetById(int id)
    {
        return _context.Candidatura.Find(id) ?? throw new Exception("A Candidatura não foi encontrada");
    }

    public Candidatura GetByUsuarioVaga(int idUsuario, int idVaga)
    {
        return _context.Candidatura.First(candidatura => candidatura.Id_Usuario == idUsuario && candidatura.Id_Vaga == idVaga);
    }




    public void Delete(int id)
    {
        try
        {
            Candidatura candidatura = GetById(id);
            _context.Candidatura.Remove(candidatura);
            Commit();

        } catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


}
