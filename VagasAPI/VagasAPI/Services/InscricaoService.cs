using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using VagasAPI.Data;
using VagasAPI.Dto.Inscricao;
using VagasAPI.Models;

namespace VagasAPI.Services
{
    public class InscricaoService : IInscricaoService
    {
        private readonly UserDbContext _context;

        public InscricaoService(UserDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<ResponseModel<List<InscricaoModel>>> GetAllAsync()
        {
            ResponseModel<List<InscricaoModel>> resposta = new();
            try
            {
                var inscricao = await _context.Inscricoes.ToListAsync();
                resposta.Dados = inscricao;
                resposta.Mensagem = "Inscrições retornadas com sucesso";
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
        public async Task<ResponseModel<InscricaoModel>> GetByIdAsync(int id)
        {
            ResponseModel<InscricaoModel> resposta = new();
            try
            {
                var inscricao = await _context.Inscricoes.FirstOrDefaultAsync(x => x.Id == id);
                if (inscricao == null)
                {
                    resposta.Mensagem = "Inscrição não encontrada";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = inscricao;
                resposta.Mensagem = "Inscrição retornada com sucesso";
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
        public async Task<ResponseModel<List<InscricaoModel>>> GetAllByIdVagaAsync(int id)
        {
            ResponseModel<List<InscricaoModel>> resposta = new();
            try
            {
                var inscricao = await _context.Inscricoes.Where(i => i.VagaId == id).ToListAsync();
                if (inscricao == null)
                {
                    resposta.Mensagem = "Inscrições não encontradas";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = inscricao;
                resposta.Mensagem = "Inscrições retornadas com sucesso";
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
        public async Task<ResponseModel<List<InscricaoModel>>> GetAllByIdUserAsync(string id)
        {
            ResponseModel<List<InscricaoModel>> resposta = new();
            try
            {
                var inscricao = await _context.Inscricoes.Where(i => i.UserId == id).ToListAsync();
                if (inscricao == null)
                {
                    resposta.Mensagem = "Inscrições não encontradas";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = inscricao;
                resposta.Mensagem = "Inscrições retornadas com sucesso";
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
        public async Task<ResponseModel<InscricaoModel>> CreateAsync(InscricaoCriacaoDto inscricao)
        {
            ResponseModel<InscricaoModel> resposta = new();
            try
            {
                var vaga = await _context.Vagas.FirstOrDefaultAsync(x => x.Id == inscricao.Vaga.Id);
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == inscricao.User.Id);
                if (vaga == null)
                {
                    resposta.Mensagem = "Vaga não encontrados";
                    resposta.Status = false;
                    return resposta;
                } else if (user == null)
                {
                    resposta.Mensagem = "Usuário não encontrado";
                    resposta.Status = false;
                    return resposta;
                }
                InscricaoModel novaInscricao = new()
                {
                    VagaId = inscricao.Vaga.Id,
                    UserId = inscricao.User.Id
                };
                _context.Inscricoes.Add(novaInscricao);
                await _context.SaveChangesAsync();
                resposta.Dados = novaInscricao;
                resposta.Mensagem = "Inscrição criada com sucesso";
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
                var inscricao = await _context.Inscricoes
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (inscricao == null)
                {
                    resposta.Mensagem = "Inscrição não encontrada";
                    resposta.Status = false;
                    return resposta;
                }
                _context.Inscricoes.Remove(inscricao);
                await _context.SaveChangesAsync();
                resposta.Dados = true;
                resposta.Mensagem = "Inscrição deletada com sucesso";
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
