using VagasForDevs.Models;

namespace VagasForDevs.Repositories.Interfaces;

public interface IUsuarioRepository
{
    //OPERAÇÕES CRUD DO USUARIO
    void Create(Usuario usuario);
    Usuario GetById(int Id);
    Usuario GetByLogin(string email, string senha);
    List<Usuario> GetAll();
    void Update(int id, Usuario usuario);
    void Delete(int id);
    void DeleteAll();

    //OPERAÇÕES ADICIONAIS
    List<Vaga> GetVagas(int id);
    

}
