using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Core.Utilitarios;
using TDSTecnologia.Site.Infrastructure.Data;

namespace TDSTecnologia.Site.Infrastructure.Repository
{
    public class CursoRespository : BasicRepository
    {
        public CursoRespository(AppContexto context) : base(context)
        {
        }

        public async Task<List<Curso>> ListarTodos()
        {
            List<Curso> cursos = await _context.CursoDao.ToListAsync();
            return cursos;
        }

        public async Task<Curso> Pegar(int? id)
        {            
            return await _context.CursoDao.FindAsync(id);
        }

        public async Task<Curso> PegarPrimeiroOuDefault(int? id)
        {
            return await _context.CursoDao.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Salvar(Curso curso, IFormFile arquivo)
        {
            curso.Banner = await UtilImagem.ConverterParaByte(arquivo);
            _context.Add(curso);
            await _context.SaveChangesAsync();
        }

        public async Task Alterar(Curso curso)
        {
            _context.Update(curso);
            _context.Entry<Curso>(curso).Property(c => c.Banner).IsModified = false;
            await _context.SaveChangesAsync();
        }
        public async Task Excluir(int id)
        {
            var curso = await _context.CursoDao.FindAsync(id);
            _context.CursoDao.Remove(curso);
            await _context.SaveChangesAsync();
        }
    }
}
