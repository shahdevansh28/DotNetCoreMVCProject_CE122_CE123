using Grocery_Store.Models;
using Grocery_Store.Models.SQLRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Grocery_Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(AppDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;

        }
        public IActionResult Index()
        {
            ViewData["Products"] = _productRepository.GetAllProducts();
            ViewData["Categories"] = _categoryRepository.GetAllCategories();
            var products = _productRepository.GetAllProducts();
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Categories"] = _categoryRepository.GetAllCategories();
            //ViewBag.Category = _categoryRepository.GetAllCategories();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            //ViewBag.Categories = new SelectList(_categoryRepository.GetAllCategories(), "Id", "Name", product.CategoryId);
            ViewData["Categories"] = _categoryRepository.GetAllCategories();
                Product newProduct = new Product
                {
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Image = " ",
                    CategoryId = product.CategoryId
                };
                _productRepository.Add(newProduct);
                TempData["Success"] = "The product has been created!";
                return RedirectToAction("index");
        }

        public IActionResult Edit(long id)
        {
            Product product = _productRepository.GetProduct((int)id);
            //ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            //ViewBag.Product = product;
            ViewData["Categories"] = _categoryRepository.GetAllCategories();
            return View(product);
        }
        //[HttpGet]
        /*public ViewResult Edit(int id)
        {
            Product product = _productRepository.GetProduct(id);
            return View(product);
        }*/
        [HttpPost]
        public IActionResult Edit(Product model)
        {
            //ViewBag.Categories = new SelectList(_context.Categories, "Id", "Name", model.CategoryId);
            ViewData["Categories"] = _categoryRepository.GetAllCategories();
            
                Product product = _productRepository.GetProduct((int)model.Id);
                // Update the Category object with the data in the model object
                product.Name = model.Name;
                product.Description = model.Description;
                product.Price = model.Price;
                product.CategoryId = model.CategoryId;
                // Call update method on the repository service passing it the
                // Category object to update the data in the database table
                Product updatedProduct = _productRepository.Update(product);

                return RedirectToAction("index");
        }
        public ViewResult Details(int id)
        {
            ViewData["Categories"] = _categoryRepository.GetAllCategories();
            Product product = _productRepository.GetProduct(id);
            if (product == null)
            {
                Response.StatusCode = 404;
                return View("Product NotFound", id);
            }
            return View(product);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Product product = _productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _productRepository.GetProduct(id);
            _productRepository.Delete((int)product.Id);
            return RedirectToAction("index");
        }
    }
}
