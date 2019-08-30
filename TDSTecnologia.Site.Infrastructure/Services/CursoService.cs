using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;

namespace TDSTecnologia.Site.Infrastructure.Services
{
    public class CursoService : BasicService
    {
        private readonly CursoRespository _cursoRepository;
        public CursoService(AppContexto context) : base(context)
        {
            _cursoRepository = new CursoRespository(context);
        }

        public async Task<List<Curso>> ListarTodos()
        {
            return await _cursoRepository.ListarTodos();
        }

        public async Task<Curso> Pegar(int? id)
        {
            return await _cursoRepository.Pegar(id);
        }

        public async Task<Curso> PegarPrimeiroOuDefault(int? id)
        {
            return await _cursoRepository.PegarPrimeiroOuDefault(id);
        }

        public async Task Salvar(Curso curso)
        {
            await _cursoRepository.Salvar(curso);
        }

        public async Task Alterar(Curso curso)
        {
            await _cursoRepository.Alterar(curso);
        }

        public async Task Excluir(int id)
        {
            await _cursoRepository.Excluir(id);
        }
    }
}
