using Microsoft.EntityFrameworkCore;
using VagasAPI.Data;
using VagasAPI.Dto.Vaga;
using VagasAPI.Models;

namespace VagasAPI.Services
{
    public class VagaService : IVagaService
    {
        private readonly UserDbContext _context;
        public VagaService(UserDbContext dbContext)
        {
            _context = dbContext;

        }

        public async Task<ResponseModel<List<VagaModel>>> GetAllAsync()
        {
            ResponseModel<List<VagaModel>> resposta = new();
            try
            {
                var vagas = await _context.Vagas.ToListAsync();
                resposta.Dados = vagas;
                resposta.Mensagem = "Vagas retornadas com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {

                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<VagaModel>> GetByIdAsync(int id)
        {
            ResponseModel<VagaModel> resposta = new();
            try
            {
                var vaga = await _context.Vagas.FindAsync(id);
                if (vaga == null)
                {
                    resposta.Mensagem = "Vaga não encontrada";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = vaga;
                resposta.Mensagem = "Vaga retornada com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<VagaModel>> CreateAsync(VagaCriacaoDto vagaDto)
        {
            ResponseModel<VagaModel> resposta = new();
            try
            {
                var vaga = new VagaModel
                {
                    Titulo = vagaDto.Titulo,
                    Descricao = vagaDto.Descricao,
                    Tipo = vagaDto.Tipo,
                    StatusVaga = vagaDto.StatusVaga
                };
                _context.Vagas.Add(vaga);
                await _context.SaveChangesAsync();
                resposta.Dados = vaga;
                resposta.Mensagem = "Vaga criada com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<VagaModel>> UpdateAsync(VagaEdicaoDto vaga)
        {
            ResponseModel<VagaModel> resposta = new();
            try
            {
                var vagaExistente = await _context.Vagas.FirstOrDefaultAsync(v => v.Id == vaga.Id);
                if (vagaExistente == null)
                {
                    resposta.Mensagem = "Vaga não encontrada";
                    resposta.Status = false;
                    return resposta;
                }
                vagaExistente.Titulo = vaga.Titulo;
                vagaExistente.Descricao = vaga.Descricao;
                vagaExistente.Tipo = vaga.Tipo;
                vagaExistente.StatusVaga = vaga.StatusVaga;

                _context.Update(vagaExistente);
                await _context.SaveChangesAsync();

                resposta.Dados = vagaExistente;
                resposta.Mensagem = "Vaga atualizada com sucesso";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
        public async Task<ResponseModel<bool>> DeleteAsync(int id)
        {
            ResponseModel<bool> resposta = new();
            try
            {
                var vagaExistente = await _context.Vagas.FirstOrDefaultAsync(v => v.Id == id);
                if (vagaExistente == null)
                {
                    resposta.Mensagem = "Vaga não encontrada";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Remove(vagaExistente);
                await _context.SaveChangesAsync();
                resposta.Dados = true;
                resposta.Mensagem = "Vaga deletada com sucesso";
                resposta.Status = true;
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
