using VagasAPI.Dto.Inscricao;
using VagasAPI.Models;

namespace VagasAPI.Services
{
    public interface IInscricaoService
    {
        Task<ResponseModel<List<InscricaoModel>>> GetAllAsync();
        Task<ResponseModel<List<InscricaoModel>>> GetAllByIdVagaAsync(int id);
        Task<ResponseModel<List<InscricaoModel>>> GetAllByIdUserAsync(string id);
        Task<ResponseModel<InscricaoModel>> GetByIdAsync(int id);
        Task<ResponseModel<InscricaoModel>> CreateAsync(InscricaoCriacaoDto vaga);
        Task<ResponseModel<bool>> DeleteAsync(int id);
    }
}
