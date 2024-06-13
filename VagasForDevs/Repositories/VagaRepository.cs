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

    //OPERAÇÃO PARA SALVAR AS MUDANÇAS NO BANCO
    public void Commit()
    {
        _context.SaveChanges();
    }

    //OPERAÇÕES CRUD
    public void Create(Vaga vaga)
    {
        _context.Vaga.Add(vaga);
        Commit();
    }

    public Vaga GetById(int id)
    {
        return _context.Vaga.First(vaga => vaga.Id == id);
    }

    public List<Vaga> GetAll()
    {
        return _context.Vaga.ToList();
    }

    public void Update(int id, Vaga vagaEdit) 
    {
        Vaga vagaToBeUpdated = GetById(id);

        if (vagaToBeUpdated != null)
        {
            vagaToBeUpdated.Descricao = vagaEdit.Descricao;
            vagaToBeUpdated.Id_Perfil = vagaEdit.Id_Perfil;
            vagaToBeUpdated.Valor = vagaEdit.Valor;
        }

        Commit();
    }

    public void Delete(int id)
    {
        Vaga vaga = GetById(id);

        _context.Vaga.Remove(vaga);
        Commit();
    }


    //OUTRAS OPERAÇÕES
    public List<Usuario> GetCandidatos(int id)
    {
        Vaga vaga = GetById(id);
        return vaga.Candidaturas.Select(candidatura => candidatura.Usuario).ToList();
    }



}
