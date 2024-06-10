using VagasAPI.Dto.Vaga;
using VagasAPI.Models;

namespace VagasAPI.Services
{
    public interface IVagaService
    {
        Task<ResponseModel<List<VagaModel>>> GetAllAsync();
        Task<ResponseModel<VagaModel>> GetByIdAsync(int id);
        Task<ResponseModel<VagaModel>> CreateAsync(VagaCriacaoDto vaga);
        Task<ResponseModel<VagaModel>> UpdateAsync(VagaEdicaoDto vaga);
        Task<ResponseModel<bool>> DeleteAsync(int id);
    }
}
