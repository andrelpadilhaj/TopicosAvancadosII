using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjAula06092021.Data;
using ProjAula06092021.Models;

namespace ProjAula06092021.Controllers
{
    public class LocacoesController : Controller
    {
        private readonly ProjAula06092021Context _context;

        public LocacoesController(ProjAula06092021Context context)
        {
            _context = context;
        }

        // GET: Locacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locacoes.Include(c => c.Carro).ToListAsync());
        }

        // GET: Locacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacoes = await _context.Locacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locacoes == null)
            {
                return NotFound();
            }

            return View(locacoes);
        }

        // GET: Locacoes/Create
        public IActionResult Create()
        {
            var l = new Locacoes();
            var carros = _context.Carros.ToList();
            l.Carros = new List<SelectListItem>();

            foreach(var c in carros)
            {
                l.Carros.Add(new SelectListItem { Text = c.Nome, Value = c.Id.ToString() });
            }
            
            return View(l);
        }

        // POST: Locacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Locacoes locacoes)
        {
            int _IdCarro = int.Parse(Request.Form["Carro"].ToString());
            var carro = _context.Carros.FirstOrDefault(c => c.Id == _IdCarro);
            locacoes.Carro = carro;

            if (ModelState.IsValid)
            {
                _context.Add(locacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(locacoes);
        }

        // GET: Locacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacao = _context.Locacoes.Include(c => c.Carro).First(l => l.Id == id);

            var carros = _context.Carros.ToList();

            locacao.Carros = new List<SelectListItem>();

            foreach (var c in carros) {
                locacao.Carros.Add(new SelectListItem { Text = c.Nome, Value = c.Id.ToString() });
            }

            if (locacao == null)
            {
                return NotFound();
            }
            return View(locacao);
        }

        // POST: Locacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Locacoes locacoes)
        {
            if (id != locacoes.Id)
            {
                return NotFound();
            }

            int _IdCarro = int.Parse(Request.Form["Carro"].ToString());
            var carro = _context.Carros.FirstOrDefault(c => c.Id == _IdCarro);
            locacoes.Carro = carro;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(locacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocacoesExists(locacoes.Id))
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
            return View(locacoes);
        }

        // GET: Locacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var locacoes = await _context.Locacoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (locacoes == null)
            {
                return NotFound();
            }

            return View(locacoes);
        }

        // POST: Locacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var locacoes = await _context.Locacoes.FindAsync(id);
            _context.Locacoes.Remove(locacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocacoesExists(int id)
        {
            return _context.Locacoes.Any(e => e.Id == id);
        }
    }
}
