using Grocery_Store.Models;
using Grocery_Store.Models.SQLRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Grocery_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(ILogger<HomeController> logger, IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _logger = logger;
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}