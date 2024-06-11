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


    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Create(Usuario usuario)
    {
        _context.Usuario.Add(usuario);
        Commit();
    }

    public void Delete(int id)
    {
        Usuario usuario = Get(id); 
        _context.Usuario.Remove(usuario);

        Commit();
    }
    public void DeleteAllCandidatos()
    {
        _context.Usuario.RemoveRange(GetAllUsers().Where(usuario => usuario.Id_Perfil == 2).ToList());

        Commit();
    }

    public Usuario Get(int Id)
    {
        List<Usuario> usuarios = GetAllUsers();

        Usuario candidato = usuarios.FirstOrDefault(candidato => candidato.Id == Id) ?? new Usuario();
        return candidato;
    }

    public List<Usuario> GetAllUsers()
    {
        return _context.Usuario.ToList();
    }

}
