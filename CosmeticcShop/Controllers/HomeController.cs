using CosmeticcShop.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;
using CosmeticcShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace CosmeticcShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly CosmeticcShopContext _context;

        public HomeController(CosmeticcShopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList(); 
            return View(products);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
            public async Task<IActionResult> DetailsProduct(int? id)
            {
                if (id != null)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                    if (product != null)
                        return View(product);
                }
                return NotFound();
            }
            public async Task<IActionResult> Edit(int? id)
            {
                if (id != null)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                    if (product != null)
                        return View(product);
                }
                return NotFound();
            }
            [HttpPost]
            public async Task<IActionResult> Edit(Product product)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            [HttpGet]
            [ActionName("Delete")]
            public async Task<IActionResult> ConfirmDelete(int? id)
            {
                if (id != null)
                {
                    Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                    if (product != null)
                        return View(product);
                }
                return NotFound();
            }
            [HttpPost]
            [HttpPost]
            public async Task<IActionResult> Delete(int id)
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound();
                }

                _context.Products.Remove(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
        }
    }
