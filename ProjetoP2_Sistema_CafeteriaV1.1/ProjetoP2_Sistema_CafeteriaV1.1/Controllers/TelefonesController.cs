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
    public class TelefonesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TelefonesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Telefones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context._DBTelefones.Include(t => t.Funcionario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Telefones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefones = await _context._DBTelefones
                .Include(t => t.Funcionario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (telefones == null)
            {
                return NotFound();
            }

            return View(telefones);
        }

        // GET: Telefones/Create/Id
        public IActionResult Create(int? Id)
        {
            Telefones _Telefone = new Telefones
            {
                FuncionarioId = _context._DBFuncionarios.FirstOrDefault(f => f.Id == Id).Id
            };
            return View(_Telefone);
        }

        // POST: Telefones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,NumTelefone,Descricao")] Telefones telefones)
        {
            if (ModelState.IsValid)
            {
                _context.Add(telefones);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Funcionarios", new { Id = telefones.FuncionarioId });
            }
            ViewData["FuncionarioId"] = new SelectList(_context._DBFuncionarios, "Id", "Id", telefones.FuncionarioId);
            return View(telefones);
        }

        // GET: Telefones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var telefones = await _context._DBTelefones.FindAsync(id);
            if (telefones == null)
            {
                return NotFound();
            }
            ViewData["FuncionarioId"] = new SelectList(_context._DBFuncionarios, "Id", "Id", telefones.FuncionarioId);
            return View(telefones);
        }

        // POST: Telefones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FuncionarioId,NumTelefone,Descricao")] Telefones telefones)
        {
            if (id != telefones.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(telefones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TelefonesExists(telefones.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Details", "Funcionarios", new { Id = telefones.FuncionarioId });
            }
            ViewData["FuncionarioId"] = new SelectList(_context._DBFuncionarios, "Id", "Id", telefones.FuncionarioId);
            return View(telefones);
        }

        // GET: Telefones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var telefones = await _context._DBTelefones.FindAsync(id);
            _context._DBTelefones.Remove(telefones);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Funcionarios", new { Id = telefones.FuncionarioId });
        }

        private bool TelefonesExists(int id)
        {
            return _context._DBTelefones.Any(e => e.Id == id);
        }
    }
}
