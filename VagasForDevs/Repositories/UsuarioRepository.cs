using Microsoft.EntityFrameworkCore;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;
namespace Vagas.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    public ApplicationContext _context;

    public UsuarioRepository(ApplicationContext context)
    {
        _context = context;
    }

    //OPERAÇÃO PARA SALVAR AS MUDANÇAS NO BANCO
    public void Commit()
    {
        _context.SaveChanges();
    }

    //OPERAÇÕES CRUD
    public void Create(Usuario usuario)
    {
        _context.Usuario.Add(usuario);
        Commit();
    }

    public void Update(int id, Usuario usuarioEdit)
    {
        Usuario usuarioToBeUpdated = GetById(id);

        usuarioToBeUpdated.Nome = usuarioEdit.Nome;
        usuarioToBeUpdated.CPF = usuarioEdit.CPF;
        usuarioToBeUpdated.Telefone = usuarioEdit.Telefone;
        usuarioToBeUpdated.Email = usuarioEdit.Email;

        Commit();        
    }


    public void Delete(int id)
    {
        Usuario usuario = GetById(id); 
        _context.Usuario.Remove(usuario);

        Commit();
    }
    public Usuario GetById(int Id)
    {
        List<Usuario> usuarios = GetAll();

        Usuario candidato = usuarios.FirstOrDefault(candidato => candidato.Id == Id) ?? new Usuario();
        return candidato;
    }

    public Usuario GetByLogin(string email, string senha)
    {
        return _context.Usuario.First(usuario => usuario.Email == email && usuario.Senha == senha);
    }


    public List<Usuario> GetAll()
    {
        return _context.Usuario.Include(usuario => usuario.Perfil).ToList();
    }
    public void DeleteAll()
    {
        _context.Usuario.RemoveRange(GetAll().Where(usuario => usuario.Id_Perfil == 2).ToList());

        Commit();
    }

    //OUTRA OPERAÇÕES
    public List<Vaga> GetVagas(int id)
    {
        Usuario usuario = GetById(id);

        return usuario.Candidaturas.Select(candidatura => candidatura.Vaga).ToList();
    }


}
