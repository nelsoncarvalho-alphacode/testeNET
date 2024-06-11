using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TesteDotNetApp.DTOs;
using TesteDotNetApp.Interface;
using TesteDotNetApp.Models;
using TesteDotNetApp.ViewModel;

namespace TesteDotNetApp.Controllers
{
    [ApiController]
    [Route("vaga")]
    public class VagaController : ControllerBase
    {
        public readonly IVaga _vaga;

        public readonly ICandidato _candidato;


        public VagaController(IVaga vaga, ICandidato candidato)
        {
            _vaga = vaga ?? throw new ArgumentNullException(nameof(vaga));
            _candidato = candidato ?? throw new ArgumentNullException(nameof(candidato));
        }




        [HttpGet]
        [Route("obtervagas")]
        public IActionResult ObterVagas([FromQuery] string setor = null, string tipo = null, bool ativa = true, string ordenarNome = null, int pagina = 1)
        {
            try
            {
                var listaDevagas = _vaga.ObterVagas();

                // Aplicar os filtros antes da paginação
                if (!string.IsNullOrEmpty(tipo))
                {
                    listaDevagas = listaDevagas.Where(v => v.Tipo == tipo).ToList();
                }

                if (ativa || !ativa)
                {
                    listaDevagas = listaDevagas.Where(v => v.Ativa == ativa).ToList();
                }

                if (!string.IsNullOrEmpty(setor))
                {
                    listaDevagas = listaDevagas.Where(v => v.Setor == setor).ToList();
                }

                if (!string.IsNullOrEmpty(ordenarNome))
                {
                    if (ordenarNome == "asc")
                    {
                        listaDevagas = listaDevagas.OrderBy(v => v.Titulo).ToList();
                    }
                    else if (ordenarNome == "desc")
                    {
                        listaDevagas = listaDevagas.OrderByDescending(v => v.Titulo).ToList();
                    }
                }    
                // Aplicar paginação após aplicar os filtros
                const int pageSize = 20;

                // Calcular o número total de páginas após aplicar os filtros
                int totalVagas = listaDevagas.Count;
                int totalPaginas = (int)Math.Ceiling((double)totalVagas / pageSize);


                var vagasDaPagina = listaDevagas.Skip((pagina - 1) * pageSize).Take(pageSize).ToList();

                return Ok(new { Vagas = vagasDaPagina, TotalPaginas = totalPaginas });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao listar as Vagas.");
            }
        }



        [HttpGet]
        [Route("obtercandidatosvaga/{id}")]
        public IActionResult ObterCandidatosVagaId( int id ) 
        {
            try
            {
                var vaga = _vaga.ObterCandidatosVagaId(id);
                return Ok(vaga);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao listar as Vagas.");
            }
        }


        [HttpPost]
        [Route("adicionarvaga")]
        public IActionResult AdicionarVaga([FromBody] CreateVagaDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Preencha todos os campos");
            }

            var novaVaga = new Vaga()
            {
                Titulo = model.Titulo,
                Descricao = model.Descricao,
                Tipo = model.Tipo,
                Setor = model.Setor,
            };


            _vaga.AdicionarVaga(novaVaga);

            try
            {
                return Ok("Vaga cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao adicionar uma Vaga.");
            }
        }


        [HttpPost]
        [Route("cadastrarcandidato")]
        public IActionResult AdicionarCandidatoVaga([FromBody] CreateCandidatoVagaDTO model)
        {
            try
            {
                _vaga.AdicionarCandidatoVaga(model);
                return Ok("Candidato cadastrado na vaga com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Usuario já cadastrado na vaga.");
            }
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult EditarVaga([FromBody] CreateVagaDTO model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Preencha todos os campos");
            }

            var vagaId = _vaga.ObterVagaId(id);

            if (vagaId == null)
            {
                return NotFound("Não encontrada uma Vaga com esse ID.");
            }


            try
            {
                vagaId.Titulo = model.Titulo;
                vagaId.Descricao = model.Descricao;
                vagaId.Tipo = model.Tipo;
                vagaId.Setor = model.Setor;
                vagaId.Ativa = model.Ativa;

                _vaga.EditarVaga(vagaId);

                return Ok("Vaga editada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao editar uma Vaga.");
            }
        }



        [HttpPut]
        [Route("desativarvaga/{id}")]
        public IActionResult DesativarVaga([FromBody] CreateAtivarVagaDTO ativo, [FromRoute] int id)
        {

            var vagaId = _vaga.ObterVagaId(id);

            if (vagaId == null)
            {
                return NotFound("Não encontrada uma Vaga com esse ID.");
            }

            try
            {


                vagaId.Ativa = ativo.Ativar;

                _vaga.EditarVaga(vagaId);



                return !ativo.Ativar ? Ok("Vaga desativada com sucesso!") : Ok("Vaga ativada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao tentar desativar ou ativar uma vaga");
            }
        }




        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCandidato([FromRoute] int id)
        {
            var vagaId = _vaga.ObterVagaId(id);

            if (vagaId == null)
            {
                return NotFound("Não encontrada uma Vaga com esse ID.");
            }

            try
            {
                _vaga.DeletarVaga(vagaId);
                return Ok("Vaga deletada com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao deletar Vaga.");
            }
        }
    }
}