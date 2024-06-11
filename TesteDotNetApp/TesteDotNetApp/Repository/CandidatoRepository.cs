using Microsoft.AspNetCore.Http.HttpResults;
using System.Data.Entity;
using TesteDotNetApp.Data;
using TesteDotNetApp.Interface;
using TesteDotNetApp.Models;

namespace TesteDotNetApp.Repository
{
    public class CandidatoRepository(AppDbContext _context) : ICandidato
    {
        public List<Candidato> ObterCandidatos()
        {
            try
            {
                var listaDeCandidatos = _context.Candidatos.AsNoTracking().ToList();

                if (listaDeCandidatos == null)
                {
                    throw new Exception("Erro ao listar vagas.");
                }

                return listaDeCandidatos;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar os Candidatos.", ex);
            }
        }


        public Candidato AdicionarCandidato(Candidato candidato)
        {
            try
            {
                _context.Candidatos.Add(candidato);
                _context.SaveChanges();
                return candidato;   
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao adicionar um Candidato.");
            }
        }

        public Candidato ObterCandidatoId(int id)
        {
            try
            {
                var candidato = _context.Candidatos.FirstOrDefault(x => x.ID == id);

                if (candidato == null)
                {
                    throw new Exception($"Candidato com o ID {id} não encontrado.");
                }

                return candidato;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar um Candidato por ID.", ex);
            }
        }

        public void EditarCandidato(Candidato candidato)
        {
            try
            {
                _context.Candidatos.Update(candidato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao editar um Candidato.");
            }
        }


        public void DeletarCandidato(Candidato candidato)
        {   
            
            
            try
            {
                _context.Candidatos.Remove(candidato);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao deletar um Candidato.");
            }
        }
    }
}