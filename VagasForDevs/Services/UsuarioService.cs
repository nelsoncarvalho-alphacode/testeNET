using Vagas.Repositories;
using VagasForDevs.Models;
using VagasForDevs.Repositories.Interfaces;
using VagasForDevs.Services.Interfaces;

namespace VagasForDevs.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }


    public void Create(Usuario usuario)
    {
        _usuarioRepository.Create(usuario);
    }

    public void Delete(int id)
    {
        _usuarioRepository.Delete(id);
    }

    public void DeleteAllCandidatos()
    {
        _usuarioRepository.DeleteAllCandidatos();
    }

    public Usuario? GetByLogin(string email, string senha)
    {
        return _usuarioRepository.GetAllUsers().FirstOrDefault(candidato => candidato.Email == email && candidato.Senha == senha);
    }

    public Usuario Get(int id)
    {
        return _usuarioRepository.Get(id);
    }

    public List<Usuario> GetAllUsers()
    {
        return _usuarioRepository.GetAllUsers();
    }




}







