using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SerTerraQueijaria.Data;
using SerTerraQueijaria.Models;

namespace SerTerraQueijaria.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TiposProdutosController : Controller
    {
        private readonly SerTerraContext _context;

        public TiposProdutosController(SerTerraContext context)
        {
            _context = context;
        }

        // GET: TiposProdutos
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposProd.ToListAsync());
        }

        // GET: TiposProdutos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposProdutos = await _context.TiposProd
                .FirstOrDefaultAsync(m => m.TiposProdutosId == id);
            if (tiposProdutos == null)
            {
                return NotFound();
            }

            return View(tiposProdutos);
        }

        // GET: TiposProdutos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TiposProdutosId,TipoProduto")] TiposProdutos tiposProdutos)
        {
            if (ModelState.IsValid)
            {
                tiposProdutos.TiposProdutosId = Guid.NewGuid();
                _context.Add(tiposProdutos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposProdutos);
        }

        // GET: TiposProdutos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposProdutos = await _context.TiposProd.FindAsync(id);
            if (tiposProdutos == null)
            {
                return NotFound();
            }
            return View(tiposProdutos);
        }

        // POST: TiposProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TiposProdutosId,TipoProduto")] TiposProdutos tiposProdutos)
        {
            if (id != tiposProdutos.TiposProdutosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposProdutos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposProdutosExists(tiposProdutos.TiposProdutosId))
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
            return View(tiposProdutos);
        }

        // GET: TiposProdutos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposProdutos = await _context.TiposProd
                .FirstOrDefaultAsync(m => m.TiposProdutosId == id);
            if (tiposProdutos == null)
            {
                return NotFound();
            }

            return View(tiposProdutos);
        }

        // POST: TiposProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tiposProdutos = await _context.TiposProd.FindAsync(id);
            if (tiposProdutos != null)
            {
                _context.TiposProd.Remove(tiposProdutos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposProdutosExists(Guid id)
        {
            return _context.TiposProd.Any(e => e.TiposProdutosId == id);
        }
    }
}
