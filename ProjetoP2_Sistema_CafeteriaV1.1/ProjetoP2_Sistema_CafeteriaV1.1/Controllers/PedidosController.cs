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
    public class PedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context._DBPedidos.Include(p => p._Funcionario).Include(p => p._Mesa);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedidos = await _context._DBPedidos
                .Include(p => p._Funcionario)
                .Include(p => p._Mesa)
                .FirstOrDefaultAsync(m => m.Id == id);
            pedidos._ListPedidosProdutos = _context._DBRelPedidosProdutos.Where(rpp => rpp.PedidoId == pedidos.Id).ToList();

            foreach (var item in pedidos._ListPedidosProdutos)
            {
                item._Produto = _context._DBProdutos.Find(item.ProdutoId);
            }

            if (pedidos == null)
            {
                return NotFound();
            }

            return View(pedidos);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            Pedidos _Pedido = new Pedidos
            {
                _SelectFuncionario = new List<SelectListItem>(),
                _SelectMesa = new List<SelectListItem>()
            };

            var _Funcionarios = _context._DBFuncionarios.ToList();
            var _Mesas = _context._DBMesas.ToList();

            foreach (var item in _Funcionarios)
            {
                _Pedido._SelectFuncionario.Add(new SelectListItem { Text = "Nome: " + item.Sobrenome + ", " + item.Nome, Value = item.Id.ToString() });
            }

            foreach(var item in _Mesas)
            {
                if (item.StatusId == _context._DBStatus.FirstOrDefault(s => s.Descricao == "Disponível").Id)
                {
                    _Pedido._SelectMesa.Add(new SelectListItem { Text = "Mesa: " + item.Id.ToString() + " | " + item.NumCadeiras + " lugares.", Value = item.Id.ToString() });
                }
            }

            return View(_Pedido);
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MesaId,FuncionarioId,DataHoraAbertura,DataHoraFechamento,Total")] Pedidos pedidos)
        {
            if (ModelState.IsValid)
            {
                pedidos.DataHoraAbertura = System.DateTime.Now;
                pedidos.DataHoraFechamento = null;
                pedidos.Total = 0f;
                pedidos._Mesa = _context._DBMesas.FirstOrDefault(m => m.Id == pedidos.MesaId);
                pedidos._Mesa.StatusId = _context._DBStatus.FirstOrDefault(s => s.Descricao == "Ocupada").Id;
                _context.Add(pedidos);
                _context.Update(pedidos._Mesa);
                await _context.SaveChangesAsync();
                var _pedidos = _context._DBPedidos.FirstOrDefault(p => p.FuncionarioId == pedidos.FuncionarioId && p.MesaId == pedidos.MesaId && p.DataHoraAbertura == pedidos.DataHoraAbertura);
                return RedirectToAction("Details", "Pedidos", new { Id = pedidos.Id });
            }
            ViewData["FuncionarioId"] = new SelectList(_context._DBFuncionarios, "Id", "Id", pedidos.FuncionarioId);
            ViewData["MesaId"] = new SelectList(_context._DBMesas, "Id", "Id", pedidos.MesaId);
            return View(pedidos);
        }

        public async Task<IActionResult> Close(int Id)
        {
            var pedido = _context._DBPedidos.FirstOrDefault(p => p.Id == Id);

            if (pedido == null)
            {
                return NotFound();
            }

            pedido._Mesa = _context._DBMesas.Find(pedido.MesaId);
            pedido._Mesa._Status = _context._DBStatus.FirstOrDefault(s => s.Descricao == "Disponível");

            pedido.DataHoraFechamento = System.DateTime.Now;

            pedido._ListPedidosProdutos = _context._DBRelPedidosProdutos.Where(pp => pp.PedidoId == pedido.Id).ToList();

            foreach (var item in pedido._ListPedidosProdutos)
            {
                pedido.Total += _context._DBProdutos.Find(item.ProdutoId).Valor * item.Quantidade;
            }

            _context.Update(pedido);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Pedidos", new { Id = pedido.Id });
        }
    }
}
