﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core3MVC.Data;
using Core3MVC.Models;

namespace Core3MVC.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArticlesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Articles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Article.Include(a => a.Next).Include(a => a.Previous);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Articles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .Include(a => a.Next)
                .Include(a => a.Previous)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // GET: Articles/Create
        public IActionResult Create()
        {
            ViewData["NextId"] = new SelectList(_context.Article, "Id", "Id");
            ViewData["PreviousId"] = new SelectList(_context.Article, "Id", "Id");
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,PreviousId,NextId")] Article article)
    {
        if (ModelState.IsValid)
        {
            int minArticleId = _context.Articles.Max(a => a.Id);
            var previous = await _context.Articles.Where(s => s.Id == minArticleId).FirstOrDefaultAsync();
            article.PreviousId = minArticleId;
            _context.Add(article);
            await _context.SaveChangesAsync();
            previous.NextId = article.Id;
            //var newArticle = new Article();

            //article.Next = newArticle;
            //newArticle.Previous = article;
            _context.Update(previous);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["NextId"] = new SelectList(_context.Article, "Id", "Id", article.NextId);
        ViewData["PreviousId"] = new SelectList(_context.Article, "Id", "Id", article.PreviousId);
        return View(article);
    }

        // GET: Articles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }
            ViewData["NextId"] = new SelectList(_context.Article, "Id", "Id", article.NextId);
            ViewData["PreviousId"] = new SelectList(_context.Article, "Id", "Id", article.PreviousId);
            return View(article);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PreviousId,NextId")] Article article)
        {
            if (id != article.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(article);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArticleExists(article.Id))
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
            ViewData["NextId"] = new SelectList(_context.Article, "Id", "Id", article.NextId);
            ViewData["PreviousId"] = new SelectList(_context.Article, "Id", "Id", article.PreviousId);
            return View(article);
        }

        // GET: Articles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Article
                .Include(a => a.Next)
                .Include(a => a.Previous)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (article == null)
            {
                return NotFound();
            }

            return View(article);
        }

        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var article = await _context.Article.FindAsync(id);
            _context.Article.Remove(article);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArticleExists(int id)
        {
            return _context.Article.Any(e => e.Id == id);
        }
    }
}
