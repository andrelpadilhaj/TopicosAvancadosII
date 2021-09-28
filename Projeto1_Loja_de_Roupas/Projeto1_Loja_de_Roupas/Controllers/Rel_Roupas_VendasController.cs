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
            return View(await _context.Rel_Roupas_Vendas
                .Include(r => r.Roupa)
                .Include(t => t.Roupa.Tipo)
                .Include(r => r.Venda)
                .ToListAsync());
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
                .Include(t => t.Roupa.Tipo)
                .Include(r => r.Venda)
                .Include(c => c.Venda.Cliente)
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
            var rel_roupas_venda = new Rel_Roupas_Vendas();
            rel_roupas_venda.Roupas = new List<SelectListItem>();
            rel_roupas_venda.Venda = new Vendas();
            rel_roupas_venda.Venda.Clientes = new List<SelectListItem>();

            var roupas = _context.Roupas.Include(t => t.Tipo).ToList();
            var clientes = _context.Clientes.ToList();

            foreach (var r in roupas)
            {
                rel_roupas_venda.Roupas.Add(new SelectListItem { Text = "Cor: " + r.Cor + " | Descricao: " + r.Tipo.Descricao + " | Valor: " + r.Tipo.Valor.ToString(), Value = r.Id.ToString() });
            }

            foreach (var c in clientes)
            {
                rel_roupas_venda.Venda.Clientes.Add( new SelectListItem { Text = "Nome: " + c.Nome + " | Telefone: " + c.Telefone, Value = c.Id.ToString() });
            }

            return View(rel_roupas_venda);
        }

        // POST: Rel_Roupas_Vendas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoupaId,VendaId,Quantidade")] Rel_Roupas_Vendas rel_Roupas_Vendas)
        {
            rel_Roupas_Vendas.Venda = new Vendas();
            int _clientId = int.Parse(Request.Form["Venda.Cliente"].ToString());
            rel_Roupas_Vendas.Venda.Cliente = _context.Clientes.FirstOrDefault(c => c.Id == _clientId);
            rel_Roupas_Vendas.Venda.Data = System.DateTime.Now;

            var roupa = _context.Roupas.Include(t => t.Tipo).FirstOrDefault(r => r.Id == rel_Roupas_Vendas.RoupaId);

            rel_Roupas_Vendas.Venda.Valor = rel_Roupas_Vendas.Quantidade * roupa.Tipo.Valor;

            roupa.Quantidade = roupa.Quantidade - rel_Roupas_Vendas.Quantidade;


            if (ModelState.IsValid)
            {
                _context.Add(rel_Roupas_Vendas.Venda);
                _context.Add(rel_Roupas_Vendas);
                _context.Update(roupa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
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
