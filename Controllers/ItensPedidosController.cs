using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerTerraQueijaria.Data;
using SerTerraQueijaria.Models;

namespace SerTerraQueijaria.Controllers
{
    public class ItensPedidosController : Controller
    {
        private readonly SerTerraContext _context;

        public ItensPedidosController(SerTerraContext context)
        {
            _context = context;
        }

        // GET: ItensPedidos
        public async Task<IActionResult> Index()
        {
            var serTerraContext = _context.ItensPedido.Include(i => i.Pedido).Include(i => i.Produto);
            return View(await serTerraContext.ToListAsync());
        }

        // GET: ItensPedidos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido
                .Include(i => i.Pedido)
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.ItensPedidoId == id);
            if (itensPedido == null)
            {
                return NotFound();
            }

            return View(itensPedido);
        }

        // GET: ItensPedidos/Create
        public IActionResult Create()
        {
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Descricao");
            return View();
        }

        // POST: ItensPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItensPedidoId,PedidoId,ProdutoId,Quantidade,ValorUnitario")] ItensPedido itensPedido)
        {
            if (ModelState.IsValid)
            {
                itensPedido.ItensPedidoId = Guid.NewGuid();
                _context.Add(itensPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", itensPedido.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Descricao", itensPedido.ProdutoId);
            return View(itensPedido);
        }

        // GET: ItensPedidos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido.FindAsync(id);
            if (itensPedido == null)
            {
                return NotFound();
            }
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", itensPedido.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Descricao", itensPedido.ProdutoId);
            return View(itensPedido);
        }

        // POST: ItensPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ItensPedidoId,PedidoId,ProdutoId,Quantidade,ValorUnitario")] ItensPedido itensPedido)
        {
            if (id != itensPedido.ItensPedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itensPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItensPedidoExists(itensPedido.ItensPedidoId))
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
            ViewData["PedidoId"] = new SelectList(_context.Pedidos, "PedidoId", "PedidoId", itensPedido.PedidoId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "ProdutoId", "Descricao", itensPedido.ProdutoId);
            return View(itensPedido);
        }

        // GET: ItensPedidos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itensPedido = await _context.ItensPedido
                .Include(i => i.Pedido)
                .Include(i => i.Produto)
                .FirstOrDefaultAsync(m => m.ItensPedidoId == id);
            if (itensPedido == null)
            {
                return NotFound();
            }

            return View(itensPedido);
        }

        // POST: ItensPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var itensPedido = await _context.ItensPedido.FindAsync(id);
            if (itensPedido != null)
            {
                _context.ItensPedido.Remove(itensPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItensPedidoExists(Guid id)
        {
            return _context.ItensPedido.Any(e => e.ItensPedidoId == id);
        }
    }
}
