using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core31MVC.Data;
using Core31MVC.Models;

namespace Core31MVC.Controllers
{
    public class CreateProductViewModel
    {
        public IEnumerable<SelectListItem> State { get; set; }
        public IEnumerable<ParentCategory> ParentCategories { get; set; }
        public IEnumerable<ProductSubcategory> ProductSubcategories { get; set; }
        public Product Product { get; set; }
    }
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var movie = new Movie()
            {
                Name = "Test"
            };
            _context.Set<Movie>().Add(movie);
           await  _context.SaveChangesAsync();
            var applicationDbContext = _context.Products.Include(p => p.ProductSubcategory);
            return View(await applicationDbContext.ToListAsync());
        }


        [HttpGet]
        public async Task<IActionResult> GetProductsDetail(string id)
        {
            var product = await _context.Products
                .Include(p => p.ProductSubcategory)
                .FirstOrDefaultAsync(m => m.ProductID.ToString() == id);
            return RedirectToAction("Details", new { name = product.ProductName });
            //return view(product);
        }
        // GET: Products/Details/5
        [Route("Products/Details/{name}")]
        public async Task<IActionResult> Details(string name)
        {
            ViewBag.Name = name;
            //if (id == null)
            //{
            //    return NotFound();
            //}

            var product = await _context.Products
                .Include(p => p.ProductSubcategory)
                .FirstOrDefaultAsync(m => m.ProductName == name);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            var parentCategories = _context.ParentCategories.ToList();
            var productSubcategories = _context.ProductSubcategories.ToList();
            var viewModel = new CreateProductViewModel
            {
                ParentCategories = parentCategories,
                ProductSubcategories = productSubcategories
            };
            viewModel.State = new List<SelectListItem>(){
              new SelectListItem(){ Text = "Test", Value = "Test" }
           };
            return View(viewModel);
            //ViewData["ProductSubcategoryID"] = new SelectList(_context.ProductSubcategories, "ProductSubcategoryID", "ProductSubcategoryDescription");
            //return View();
        }
        [HttpGet]
        public JsonResult GetSubCategoryList(int ParentCategoryId)
        {
            var subCategoryList = _context.ProductSubcategories.Where(c => c.ParentCategoryID == ParentCategoryId).ToList();
            return Json(subCategoryList);

        }
        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,ProductName,ProductSubcategoryID")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductSubcategoryID"] = new SelectList(_context.ProductSubcategories, "ProductSubcategoryID", "ProductSubcategoryDescription", product.ProductSubcategoryID);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductSubcategoryID"] = new SelectList(_context.ProductSubcategories, "ProductSubcategoryID", "ProductSubcategoryDescription", product.ProductSubcategoryID);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductName,ProductSubcategoryID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["ProductSubcategoryID"] = new SelectList(_context.ProductSubcategories, "ProductSubcategoryID", "ProductSubcategoryDescription", product.ProductSubcategoryID);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.ProductSubcategory)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductID == id);
        }
    }
}
