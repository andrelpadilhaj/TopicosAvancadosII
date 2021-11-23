using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoP2_Sistema_CafeteriaV1._1.Data;
using ProjetoP2_Sistema_CafeteriaV1._1.Models;

namespace ProjetoP2_Sistema_CafeteriaV1._1.Controllers
{
    public class RelPedidosProdutosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelPedidosProdutosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create(int Id)
        {
            RelPedidosProdutos _RelPedidosProdutos = new RelPedidosProdutos
            {
                PedidoId = _context._DBPedidos.FirstOrDefault(p => p.Id == Id).Id,
                _SelectProduto = new List<SelectListItem>()
            };

            var produtos = _context._DBProdutos.ToList();

            foreach(var item in produtos)
            {
                _RelPedidosProdutos._SelectProduto.Add(new SelectListItem
                {
                    Text = "Nome: " + item.Nome + " | Valor: " + item.Valor,
                    Value = item.Id.ToString()
                });
            }

            return View(_RelPedidosProdutos);
        }

        // POST: RelPedidosProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,ProdutoId,Quantidade")] RelPedidosProdutos relPedidosProdutos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(relPedidosProdutos);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", "Pedidos", new { Id = relPedidosProdutos.PedidoId });
            }
            ViewData["PedidoId"] = new SelectList(_context._DBPedidos, "Id", "Id", relPedidosProdutos.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context._DBProdutos, "Id", "Id", relPedidosProdutos.ProdutoId);
            return View(relPedidosProdutos);
        }

        // GET: RelPedidosProdutos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var relPedidosProdutos = await _context._DBRelPedidosProdutos.FindAsync(id);
            _context._DBRelPedidosProdutos.Remove(relPedidosProdutos);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Pedidos", new { Id = relPedidosProdutos.PedidoId });
        }
    }
}
