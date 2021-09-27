﻿using System;
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
    public class TiposController : Controller
    {
        private readonly Projeto1_Loja_de_RoupasContext _context;

        public TiposController(Projeto1_Loja_de_RoupasContext context)
        {
            _context = context;
        }

        // GET: Tipos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipos.ToListAsync());
        }

        // GET: Tipos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos = await _context.Tipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipos == null)
            {
                return NotFound();
            }

            return View(tipos);
        }

        // GET: Tipos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Valor")] Tipos tipos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipos);
        }

        // GET: Tipos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos = await _context.Tipos.FindAsync(id);
            if (tipos == null)
            {
                return NotFound();
            }
            return View(tipos);
        }

        // POST: Tipos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Valor")] Tipos tipos)
        {
            if (id != tipos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposExists(tipos.Id))
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
            return View(tipos);
        }

        // GET: Tipos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos = await _context.Tipos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipos == null)
            {
                return NotFound();
            }

            return View(tipos);
        }

        // POST: Tipos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipos = await _context.Tipos.FindAsync(id);
            _context.Tipos.Remove(tipos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposExists(int id)
        {
            return _context.Tipos.Any(e => e.Id == id);
        }
    }
}
