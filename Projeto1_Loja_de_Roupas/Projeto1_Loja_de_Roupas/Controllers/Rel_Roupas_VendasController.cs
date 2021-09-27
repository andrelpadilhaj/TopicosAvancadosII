using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto1_Loja_de_Roupas.Data;
using Projeto1_Loja_de_Roupas.Models;

namespace Projeto1_Loja_de_Roupas.Controllers
{
    public class Rel_Roupas_VendasController : Controller
    {
        private readonly Projeto1_Loja_de_RoupasContext _context;

        public Rel_Roupas_VendasController(Projeto1_Loja_de_RoupasContext context)
        {
            _context = context;
        }

        // GET: Rel_Roupas_Vendas
        public async Task<IActionResult> Index()
        {
            var projeto1_Loja_de_RoupasContext = _context.Rel_Roupas_Vendas.Include(r => r.Roupa).Include(r => r.Venda);
            return View(await projeto1_Loja_de_RoupasContext.ToListAsync());
        }

        // GET: Rel_Roupas_Vendas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rel_Roupas_Vendas = await _context.Rel_Roupas_Vendas
                .Include(r => r.Roupa)
                .Include(r => r.Venda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rel_Roupas_Vendas == null)
            {
                return NotFound();
            }

            return View(rel_Roupas_Vendas);
        }

        // GET: Rel_Roupas_Vendas/Create
        public IActionResult Create()
        {
            ViewData["RoupaId"] = new SelectList(_context.Roupas, "Id", "Id");
            ViewData["VendaId"] = new SelectList(_context.Set<Vendas>(), "Id", "Id");
            return View();
        }

        // POST: Rel_Roupas_Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoupaId,VendaId,Quantidade")] Rel_Roupas_Vendas rel_Roupas_Vendas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rel_Roupas_Vendas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoupaId"] = new SelectList(_context.Roupas, "Id", "Id", rel_Roupas_Vendas.RoupaId);
            ViewData["VendaId"] = new SelectList(_context.Set<Vendas>(), "Id", "Id", rel_Roupas_Vendas.VendaId);
            return View(rel_Roupas_Vendas);
        }

        // GET: Rel_Roupas_Vendas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rel_Roupas_Vendas = await _context.Rel_Roupas_Vendas.FindAsync(id);
            if (rel_Roupas_Vendas == null)
            {
                return NotFound();
            }
            ViewData["RoupaId"] = new SelectList(_context.Roupas, "Id", "Id", rel_Roupas_Vendas.RoupaId);
            ViewData["VendaId"] = new SelectList(_context.Set<Vendas>(), "Id", "Id", rel_Roupas_Vendas.VendaId);
            return View(rel_Roupas_Vendas);
        }

        // POST: Rel_Roupas_Vendas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoupaId,VendaId,Quantidade")] Rel_Roupas_Vendas rel_Roupas_Vendas)
        {
            if (id != rel_Roupas_Vendas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rel_Roupas_Vendas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Rel_Roupas_VendasExists(rel_Roupas_Vendas.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoupaId"] = new SelectList(_context.Roupas, "Id", "Id", rel_Roupas_Vendas.RoupaId);
            ViewData["VendaId"] = new SelectList(_context.Set<Vendas>(), "Id", "Id", rel_Roupas_Vendas.VendaId);
            return View(rel_Roupas_Vendas);
        }

        // GET: Rel_Roupas_Vendas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rel_Roupas_Vendas = await _context.Rel_Roupas_Vendas
                .Include(r => r.Roupa)
                .Include(r => r.Venda)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rel_Roupas_Vendas == null)
            {
                return NotFound();
            }

            return View(rel_Roupas_Vendas);
        }

        // POST: Rel_Roupas_Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rel_Roupas_Vendas = await _context.Rel_Roupas_Vendas.FindAsync(id);
            _context.Rel_Roupas_Vendas.Remove(rel_Roupas_Vendas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Rel_Roupas_VendasExists(int id)
        {
            return _context.Rel_Roupas_Vendas.Any(e => e.Id == id);
        }
    }
}
