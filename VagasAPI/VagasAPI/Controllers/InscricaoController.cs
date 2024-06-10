using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VagasAPI.Dto.Inscricao;
using VagasAPI.Services;

namespace VagasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly IInscricaoService _inscricaoService;
        public InscricaoController(IInscricaoService inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }

        [HttpGet("ListarInscricoes")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _inscricaoService.GetAllAsync();
            return Ok(response);
        }
        [HttpGet("BuscarInscricaoPorId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _inscricaoService.GetByIdAsync(id);
            return Ok(response);
        }
        [HttpGet("BuscarInscricoesPorVagaId/{vagaId}")]
        public async Task<IActionResult> GetByVagaId(int vagaId)
        {
            var response = await _inscricaoService.GetAllByIdVagaAsync(vagaId);
            return Ok(response);
        }
        [HttpGet("BuscarInscricoesPorUserId/{userId}")]
        public async Task<IActionResult> GetByUserId(string userId)
        {
            var response = await _inscricaoService.GetAllByIdUserAsync(userId);
            return Ok(response);
        }
        [HttpPost("CriarInscricao")]
        public async Task<IActionResult> Create(InscricaoCriacaoDto inscricao)
        {
            var criarInscricao = await _inscricaoService.CreateAsync(inscricao);
            return Ok(criarInscricao);
        }
        [HttpDelete("ExcluirInscricao/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _inscricaoService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
