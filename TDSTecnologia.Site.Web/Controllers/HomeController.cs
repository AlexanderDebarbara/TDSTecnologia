using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDSTecnologia.Site.Core.Entities;
using TDSTecnologia.Site.Core.Utilitarios;
using TDSTecnologia.Site.Infrastructure.Data;
using TDSTecnologia.Site.Infrastructure.Repository;

namespace TDSTecnologia.Site.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CursoRespository _cursoRespository;

        public HomeController(AppContexto context, CursoRespository cursoRespository)
        {
            _context = context;
            _cursoRespository = cursoRespository;
        }
        public async Task<IActionResult> Index()
        {
            List<Curso> cursos = await _cursoRespository.ListarTodos();

            return View(cursos);
        }

        private readonly AppContexto _context;

        [HttpGet]
        public IActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo([Bind("Id,Nome,Descricao,QuantidadeAula,DataInicio,Turno,Modalidade, Vagas, Nivel")] Curso curso, IFormFile arquivo)
        {
            if (ModelState.IsValid)
            {
                await _cursoRespository.Salvar(curso, arquivo);
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.CursoDao.FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        public async Task<IActionResult> Alterar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.CursoDao.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Alterar(int id, [Bind("Id,Nome,Descricao,QuantidadeAula,DataInicio,Turno, Modalidade, Vagas, Nivel")] Curso curso)
        {
            if (id != curso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _cursoRespository.Alterar(curso);
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.CursoDao
                .FirstOrDefaultAsync(m => m.Id == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmarExclusao(int id)
        {
            await _cursoRespository.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}