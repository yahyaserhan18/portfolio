using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core.Entities;
using Infrastructure.Data;
using Web.ViewModels;
using Core.Interfaces;

namespace Web.Controllers
{
    public class PortfolioItemsController : Controller
    {
        private readonly IUnitOfWork<PortfolioItem> _portfolioItem;
        private readonly IWebHostEnvironment _hosting;

        public PortfolioItemsController(IUnitOfWork<PortfolioItem> portfolioItem,IWebHostEnvironment hosting)
        {
            _portfolioItem = portfolioItem;
            _hosting = hosting;
        }

        // GET: PortfolioItems
        public async Task<IActionResult> Index()
        {
            //return View(await _context.PortfolioItems.ToListAsync());
            return View(await _portfolioItem.Entity.GetAllAsync());
        }

        // GET: PortfolioItems/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var portfolioItem = await _context.PortfolioItems
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var portfolioItem = await _portfolioItem.Entity.GetByIdAsync(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // GET: PortfolioItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioItemViewModel model)
        {
            if (ModelState.IsValid)
            {
                string fileName=string.Empty;
                if (model.File != null && model.File.Length > 0)
                {
                    string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                     fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.File.FileName);
                    string fullPath = Path.Combine(uploads, fileName);

                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await model.File.CopyToAsync(fileStream);
                    }
                }
                PortfolioItem portfolioItem = new PortfolioItem
                {
                    ProjectName = model.ProjectName,
                    Description = model.Description,
                    ImageUrl = model.File != null ? fileName : null
                };
                //_context.Add(portfolioItem);
                 _portfolioItem.Entity.Insert(portfolioItem);
                //await _context.SaveChangesAsync();
                await _portfolioItem.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PortfolioItems/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var portfolioItem = await _context.PortfolioItems.FindAsync(id);
            var portfolioItem = await _portfolioItem.Entity.GetByIdAsync(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }
            PortfolioItemViewModel portfolioItemView = new PortfolioItemViewModel
            {
                Id = portfolioItem.Id,
                ProjectName = portfolioItem.ProjectName,
                Description = portfolioItem.Description,
                ImageUrl = portfolioItem.ImageUrl
            };
            return View(portfolioItemView);
        }

        // POST: PortfolioItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Edit(Guid id, PortfolioItemViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = string.Empty;
                    if (model.File != null && model.File.Length > 0)
                    {
                        string uploads = Path.Combine(_hosting.WebRootPath, @"img\portfolio");
                        fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.File.FileName);
                        string fullPath = Path.Combine(uploads, fileName);

                        using (var fileStream = new FileStream(fullPath, FileMode.Create))
                        {
                            await model.File.CopyToAsync(fileStream);
                        }
                    }
                    PortfolioItem portfolioItem = new PortfolioItem
                    {
                        Id = model.Id,
                        ProjectName = model.ProjectName,
                        Description = model.Description,
                        ImageUrl = model.File != null ? fileName : null
                    };
                    //_context.Update(portfolioItem);
                    _portfolioItem.Entity.Update(portfolioItem);
                    //await _context.SaveChangesAsync();
                    await _portfolioItem.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await PortfolioItemExists(model.Id))
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
            return View(model);
        }

        // GET: PortfolioItems/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var portfolioItem = await _portfolioItem.Entity
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var portfolioItem = await _portfolioItem.Entity.GetByIdAsync(id);
            if (portfolioItem == null)
            {
                return NotFound();
            }

            return View(portfolioItem);
        }

        // POST: PortfolioItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //var portfolioItem = await _context.PortfolioItems.FindAsync(id);
            var portfolioItem = await _portfolioItem.Entity.GetByIdAsync(id);
            if (portfolioItem != null)
            {
                //_context.PortfolioItems.Remove(portfolioItem);
               await _portfolioItem.Entity.DeleteAsync(portfolioItem.Id);
            }

            //await _context.SaveChangesAsync();
            await _portfolioItem.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PortfolioItemExists(Guid id)
        {
            //return _context.PortfolioItems.Any(e => e.Id == id);
            return (await _portfolioItem.Entity.GetAllAsync()).Any(e => e.Id == id);
        }
    }
}
