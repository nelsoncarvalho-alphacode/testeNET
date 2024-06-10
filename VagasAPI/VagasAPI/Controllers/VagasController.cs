using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VagasAPI.Dto.Vaga;
using VagasAPI.Models;
using VagasAPI.Services;

namespace VagasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagasController : ControllerBase
    {
        private readonly IVagaService _vagaService;

        public VagasController(IVagaService vagaService)
        {
            _vagaService = vagaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _vagaService.GetAllAsync();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _vagaService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(VagaCriacaoDto vaga)
        {
            var criarVaga = await _vagaService.CreateAsync(vaga);
            return Ok(criarVaga);
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(VagaEdicaoDto vaga)
        {
            var editarVaga = await _vagaService.UpdateAsync(vaga);
            return Ok(editarVaga);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _vagaService.DeleteAsync(id);
            return Ok(response);
        }
    }
}
