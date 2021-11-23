using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoP2_Sistema_CafeteriaV1._1.Data;
using ProjetoP2_Sistema_CafeteriaV1._1.Models;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Controllers
{
    [Authorize]
    public class FuncionariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index()
        {
            return View(await _context._DBFuncionarios.ToListAsync());
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context._DBFuncionarios
                .FirstOrDefaultAsync(m => m.Id == id);
            funcionarios._ListTelefones = _context._DBTelefones.Where(t => t.FuncionarioId == funcionarios.Id).ToList();

            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            Funcionarios _Funcionario = new Funcionarios();
            _Funcionario._Telefone = new Telefones();
            return View(_Funcionario);
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cpf,Nome,Sobrenome")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionarios);
                await _context.SaveChangesAsync();

                Telefones _Telefone = new Telefones
                {
                    FuncionarioId = _context._DBFuncionarios.FirstOrDefault(f => f.Cpf == funcionarios.Cpf).Id,
                    NumTelefone = Request.Form["_Telefone.NumTelefone"].ToString(),
                    Descricao = Request.Form["_Telefone.Descricao"].ToString()
                };

                _context.Add(_Telefone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context._DBFuncionarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarios = await _context._DBFuncionarios.FindAsync(id);
            _context._DBFuncionarios.Remove(funcionarios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionariosExists(int id)
        {
            return _context._DBFuncionarios.Any(e => e.Id == id);
        }
    }
}
