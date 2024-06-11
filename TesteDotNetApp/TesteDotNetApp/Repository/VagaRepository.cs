using System.Data.Entity;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TesteDotNetApp.Data;
using TesteDotNetApp.Interface;
using TesteDotNetApp.Models;
using TesteDotNetApp.ViewModel;

namespace TesteDotNetApp.Repository
{
    public class VagaRepository(AppDbContext _context) : IVaga
    {
        public List<Vaga> ObterVagas()
        {
            try
            {
                var listaDeVagas = _context.Vagas.AsNoTracking().ToList();

                if (listaDeVagas == null)
                {
                    throw new Exception("Erro ao listar vagas.");
                }

                return listaDeVagas;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar vagas.", ex);
            }
        }

        public object ObterCandidatosVagaId(int id)
        {
            try
            {
                var vagaComCandidatos = _context.Vagas
                    .Include(v => v.Candidatos)
                    .Where(v => v.ID == id)
                    .Select(v => new
                    {
                        v.ID,
                        v.Titulo,
                        Candidatos = v.Candidatos.Select(c => new
                        {
                            c.ID,
                            c.Nome
                        }).ToList()
                    })
                    .FirstOrDefault();
                if (vagaComCandidatos == null)
                {
                    throw new Exception($"Vaga com o ID {id} não encontrado.");
                }

                return vagaComCandidatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar os candidatos da Vaga.");
            }
        }


        public void AdicionarVaga(Vaga vaga)
        {
            try
            {
                _context.Vagas.Add(vaga);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error ao adicionar uma nova vaga.", ex);
            }
        }


        public void AdicionarCandidatoVaga(CreateCandidatoVagaDTO model)
        {
            var vaga = _context.Vagas.Include(x => x.Candidatos).FirstOrDefault(x => x.ID == model.IdVaga);

            var candidato = _context.Candidatos.Find(model.IdCandidato);

            if (vaga == null || candidato == null)
            {
                throw new Exception("Vaga ou Candidato não encontrado.");
            }

            try
            {
                vaga.Candidatos.Add(candidato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Error ao adicionar um candidato a vaga.");
            }
        }

        public Vaga ObterVagaId(int id)
        {
            try
            {
                var vagaId = _context.Vagas.FirstOrDefault(x => x.ID == id);
                if (vagaId == null)
                {
                    throw new Exception($"Vaga com o ID {id} não encontrado.");
                }

                return vagaId;
            }


            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar uma Vaga.", ex);
            }
        }

        public void EditarVaga(Vaga vaga)
        {
            try
            {
                _context.Vagas.Update(vaga);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar um Vaga.");
            }
        }


        public void DeletarVaga(Vaga vaga)
        {
            try
            {
                _context.Vagas.Remove(vaga);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar uma Vaga.");
            }
        }
    }
}