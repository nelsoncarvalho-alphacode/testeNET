using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TesteDotNetApp.Interface;
using TesteDotNetApp.Models;
using TesteDotNetApp.ViewModel;

namespace TesteDotNetApp.Controllers
{
    [ApiController]
    [Route("candidato")]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidato _candidato;

        public CandidatoController(ICandidato candidato)
        {
            _candidato = candidato ?? throw new ArgumentNullException(nameof(candidato));
        }

        [HttpGet]
        [Route("obtercandidatos")]
        public IActionResult ObterCandidatos([FromQuery] string ordenarId = null, string ordenarNome = null,
           int pagina = 1)
        {
            try
            {
                var listaDeCandidatos = _candidato.ObterCandidatos();
                
                const int pageSize = 20;
                var candidatosDaPagina = listaDeCandidatos.Skip((pagina - 1) * pageSize).Take(pageSize).ToList();

               
                if (!string.IsNullOrEmpty(ordenarId))
                {
                    if (ordenarId == "asc")
                    {
                        candidatosDaPagina = candidatosDaPagina.OrderBy(v => v.ID).ToList();
                    }
                    else if (ordenarId == "desc")
                    {
                        candidatosDaPagina = candidatosDaPagina.OrderByDescending(v => v.ID).ToList();
                    }
                }

                if (!string.IsNullOrEmpty(ordenarNome))
                {
                    if (ordenarNome == "asc")
                    {
                        candidatosDaPagina = candidatosDaPagina.OrderBy(v => v.Nome).ToList();
                    }
                    else if (ordenarNome == "desc")
                    {
                        candidatosDaPagina = candidatosDaPagina.OrderByDescending(v => v.Nome).ToList();
                    }
                }

               

               
                int totalCandidatos = listaDeCandidatos.Count;
                int totalPaginas = (int)Math.Ceiling((double)totalCandidatos / pageSize);

             
                return Ok(new { Candidatos = candidatosDaPagina, TotalPaginas = totalPaginas });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao listar os Candidatos.");
            }
        }


        [HttpPost]
        [Route("adicionarcandidato")]
        public ActionResult AdicionarCandidato([FromBody] CreateCandidatoDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var novoCandidato = new Candidato()
            {
                Nome = model.Nome,
                Email = model.Email,
            };

             Candidato candidatoJaCadastrado = _candidato.AdicionarCandidato(novoCandidato);

            try
            {
                return Ok(new { novoCandidato = candidatoJaCadastrado, text = "Candidato cadastrado com sucessso!" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao cadastrar um Candidato.");
            }
        }


        [HttpPut]
        [Route("{id}")]
        public IActionResult ObterCandidatoId([FromBody] CreateCandidatoDTO model, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var candidatoId = _candidato.ObterCandidatoId(id);

            if (candidatoId == null)
            {
                return NotFound("Não foi encontrado um candidato com esse ID.");
            }


            try
            {
                candidatoId.Nome = model.Nome;
                candidatoId.Email = model.Email;

                _candidato.EditarCandidato(candidatoId);

                return Ok("Candidato editado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao editar um Candidato.");
            }
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeletarCandidato([FromRoute] int id)
        {
            var candidato = _candidato.ObterCandidatoId(id);

            if (candidato == null)
            {
                return NotFound("Não encontrado um candidato com esse ID.");
            }

            try
            {
                _candidato.DeletarCandidato(candidato);
                return Ok("Deletado com sucesso!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro ao deletar uma Vaga.");
            }
        }
    }
}