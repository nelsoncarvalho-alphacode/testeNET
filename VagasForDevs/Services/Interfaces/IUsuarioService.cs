using VagasForDevs.Models;

namespace VagasForDevs.Services.Interfaces;

public interface IUsuarioService
{
    void Create(Usuario usuario);
    Usuario GetById(int Id);
    Usuario GetByLogin(string email, string senha);
    List<Usuario> GetAll();
    void Update(int id, Usuario usuario);
    void Delete(int id);
    void DeleteAll();
}
