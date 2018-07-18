using CakeCrude.DbEntities;
using CakeCrude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeCrude.Controllers
{
    public class ProductController : Controller
    {
        private CakeCrudContext _context;

        public ProductController(CakeCrudContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<ProductViewModel> model = _context.Set<Product>().ToList().Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Date = p.Date,
                CategoryId = p.CategoryId

            });


            return View("Index", model);
        }

        [HttpGet]
        public IActionResult AddEditProduct(long? id)
        {
            ProductViewModel model = new ProductViewModel();
            if (id.HasValue)
            {
                Product product = _context.Set<Product>().SingleOrDefault(c => c.Id == id.Value);

               
                if (product != null)
                {
                    model.Id = product.Id;
                    model.Name = product.Name;
                    model.Description = product.Description;
                    model.Price = product.Price;
                    model.Date = product.Date;
                    model.CategoryId = product.CategoryId;
                }
            }

            var caterogies = _context.Set<Category>().ToList();
            var categoriesViewModel = new List<CategoryViewModel>();
            foreach (var category in caterogies)
                categoriesViewModel.Add(new CategoryViewModel { Id = category.Id, Name = category.Name });
            model.Categories = categoriesViewModel;

            return PartialView("~/Views/Product/_AddEditProduct.cshtml", model);
        }

        [HttpPost]
        public IActionResult AddEditProduct(long? id, ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool isNew = !id.HasValue;
                    Product product = isNew ? new Product
                    {
                        AddedDate = DateTime.UtcNow
                    } : _context.Set<Product>().SingleOrDefault(s => s.Id == id.Value);

                    product.Id = model.Id;
                    product.Name = model.Name;
                    product.Description = model.Description;
                    product.Price = model.Price;
                    product.Date = DateTime.Now;
                    product.ModifiedDate = DateTime.Now;
                    product.CategoryId = model.CategoryId;
                    if (isNew)
                    {
                        _context.Add(product);
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult DeleteProduct(long id)
        {
            Product product = _context.Set<Product>().SingleOrDefault(c => c.Id == id);
            string productName = product.Name;
            return PartialView("~/Views/Product/_DeleteProduct.cshtml", model: productName);
        }
        [HttpPost]
        public IActionResult DeleteProduct(long id, IFormCollection form)
        {
            Product product = _context.Set<Product>().SingleOrDefault(c => c.Id == id);
            _context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}
