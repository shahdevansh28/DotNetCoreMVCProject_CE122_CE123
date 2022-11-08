using Grocery_Store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Grocery_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var model = _categoryRepository.GetAllCategories();
            return View(model);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                Category newCategory = new Category
                {
                    Name = category.Name,
                    Description = category.Description,
                };
                _categoryRepository.Add(newCategory);
                return RedirectToAction("details", new { id = newCategory.Id });
            }
            return View();
        }


        public ViewResult Details(int id)
        {
            Category category = _categoryRepository.GetCategory(id);
            if (category == null)
            {
                Response.StatusCode = 404;
                return View("Category NotFound", id);
            }
            return View(category);
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Category category = _categoryRepository.GetCategory(id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category model)
        {
            // Check if the provided data is valid, if not rerender the edit view
            // so the user can correct and resubmit the edit form
            if (ModelState.IsValid)
            {
                // Retrieve the Category being edited from the database
                Category category = _categoryRepository.GetCategory((int)model.Id);
                // Update the Category object with the data in the model object
                category.Name = model.Name;
                category.Description= model.Description;
                // Call update method on the repository service passing it the
                // Category object to update the data in the database table
                Category updatedCategory = _categoryRepository.Update(category);

                return RedirectToAction("index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            _categoryRepository.Delete((int)category.Id);

            return RedirectToAction("index");
        }
    }
}
