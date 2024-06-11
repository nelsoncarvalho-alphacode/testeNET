using VagasForDevs.Models;

namespace VagasForDevs.Services.Interfaces;

public interface IUsuarioService
{
    void Create(Usuario usuario);
    void Delete(int id);
    void DeleteAllCandidatos();
    Usuario? GetByLogin(string email, string senha);
    Usuario Get(int Id);
    List<Usuario> GetAllUsers();
}
