﻿using System;
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
            return View(await _context.TiposProduto.ToListAsync());
        }

        // GET: TiposProdutos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposProduto = await _context.TiposProduto
                .FirstOrDefaultAsync(m => m.TiposProdutoId == id);
            if (tiposProduto == null)
            {
                return NotFound();
            }

            return View(tiposProduto);
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
        public async Task<IActionResult> Create([Bind("TiposProdutoId,TipoProduto")] TiposProduto tiposProduto)
        {
            if (ModelState.IsValid)
            {
                tiposProduto.TiposProdutoId = Guid.NewGuid();
                _context.Add(tiposProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposProduto);
        }

        // GET: TiposProdutos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposProduto = await _context.TiposProduto.FindAsync(id);
            if (tiposProduto == null)
            {
                return NotFound();
            }
            return View(tiposProduto);
        }

        // POST: TiposProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("TiposProdutoId,TipoProduto")] TiposProduto tiposProduto)
        {
            if (id != tiposProduto.TiposProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposProdutoExists(tiposProduto.TiposProdutoId))
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
            return View(tiposProduto);
        }

        // GET: TiposProdutos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tiposProduto = await _context.TiposProduto
                .FirstOrDefaultAsync(m => m.TiposProdutoId == id);
            if (tiposProduto == null)
            {
                return NotFound();
            }

            return View(tiposProduto);
        }

        // POST: TiposProdutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tiposProduto = await _context.TiposProduto.FindAsync(id);
            if (tiposProduto != null)
            {
                _context.TiposProduto.Remove(tiposProduto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposProdutoExists(Guid id)
        {
            return _context.TiposProduto.Any(e => e.TiposProdutoId == id);
        }
    }
}
