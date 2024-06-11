using VagasForDevs.Models;

namespace VagasForDevs.Repositories.Interfaces;

public interface IUsuarioRepository
{
    void Create(Usuario usuario);
    void Delete(int id);
    void DeleteAllCandidatos();
    Usuario Get(int Id);
    List<Usuario> GetAllUsers();

}
