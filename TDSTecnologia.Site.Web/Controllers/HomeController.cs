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
using TDSTecnologia.Site.Infrastructure.Services;

namespace TDSTecnologia.Site.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly CursoService _cursoService;

        public HomeController(AppContexto context, CursoService cursoService)
        {
            _context = context;
            _cursoService = cursoService;
        }
        public async Task<IActionResult> Index()
        {
            List<Curso> cursos = await _cursoService.ListarTodos();

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
                curso.Banner = await UtilImagem.ConverterParaByte(arquivo);
                await _cursoService.Salvar(curso);
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

            var curso = await _cursoService.PegarPrimeiroOuDefault(id);
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

            var curso = await _cursoService.Pegar(id);

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
                await _cursoService.Alterar(curso);
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

            var curso = await _cursoService.PegarPrimeiroOuDefault(id);
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
            await _cursoService.Excluir(id);
            return RedirectToAction(nameof(Index));
        }
    }
}