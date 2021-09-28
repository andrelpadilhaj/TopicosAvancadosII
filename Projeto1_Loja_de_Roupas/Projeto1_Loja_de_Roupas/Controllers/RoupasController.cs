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
    public class RoupasController : Controller
    {
        private readonly Projeto1_Loja_de_RoupasContext _context;

        public RoupasController(Projeto1_Loja_de_RoupasContext context)
        {
            _context = context;
        }

        // GET: Roupas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roupas.Include(t => t.Tipo).ToListAsync());
        }

        // GET: Roupas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roupas = await _context.Roupas
                .Include(t => t.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roupas == null)
            {
                return NotFound();
            }

            return View(roupas);
        }

        // GET: Roupas/Create
        public IActionResult Create()
        {
            var r = new Roupas();
            var tipos = _context.Tipos.ToList();

            r.Tipos = new List<SelectListItem>();

            foreach (var t in tipos)
            {
                r.Tipos.Add(new SelectListItem { Text = t.Descricao, Value = t.Id.ToString() });
            }

            return View(r);
        }

        // POST: Roupas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Cor,Quantidade")] Roupas roupas)
        {
            int _tipoId = int.Parse(Request.Form["Tipo"].ToString());
            var tipo = _context.Tipos.FirstOrDefault(t => t.Id == _tipoId);
            roupas.Tipo = tipo;

            var roupa = _context.Roupas.FirstOrDefault(r => r.Cor == roupas.Cor && r.TipoId == roupas.Tipo.Id) ;

            if (ModelState.IsValid)
            {
                if (roupa == null)
                {
                    _context.Add(roupas);
                } else
                {
                    roupa.Quantidade = roupas.Quantidade + roupa.Quantidade;
                    _context.Update(roupa);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(roupas);
        }

        // GET: Roupas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roupa = _context.Roupas.Include(t => t.Tipo).First(r => r.Id == id);
            var tipos = _context.Tipos.ToList();
            roupa.Tipos = new List<SelectListItem>();

            foreach(var t in tipos)
            {
                roupa.Tipos.Add(new SelectListItem { Text = t.Descricao, Value = t.Valor.ToString() });
            }

            var roupas = await _context.Roupas.FindAsync(id);
            if (roupas == null)
            {
                return NotFound();
            }

            return View(roupas);
        }

        // POST: Roupas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Cor,Quantidade")] Roupas roupas)
        {
            if (id != roupas.Id)
            {
                return NotFound();
            }

            int _tipoId = int.Parse(Request.Form["Tipo"].ToString());
            var tipo = _context.Tipos.FirstOrDefault(t => t.Id == _tipoId);
            roupas.Tipo = tipo;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roupas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoupasExists(roupas.Id))
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
            return View(roupas);
        }

        // GET: Roupas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roupas = await _context.Roupas
                .Include(t => t.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (roupas == null)
            {
                return NotFound();
            }

            return View(roupas);
        }

        // POST: Roupas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roupas = await _context.Roupas.FindAsync(id);
            _context.Roupas.Remove(roupas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoupasExists(int id)
        {
            return _context.Roupas.Any(e => e.Id == id);
        }
    }
}
