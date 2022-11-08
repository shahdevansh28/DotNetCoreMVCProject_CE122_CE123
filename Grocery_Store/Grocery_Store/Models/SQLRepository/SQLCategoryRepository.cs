namespace Grocery_Store.Models.SQLRepository
{
    public class SQLCategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;
        public SQLCategoryRepository(AppDbContext context)
        {
            this.context = context;
        }
        Category ICategoryRepository.Add(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category;
        }
        Category ICategoryRepository.Delete(int Id)
        {
            Category category = context.Categories.Find((long)Id);
            if (category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            return category;
        }

        IEnumerable<Category> ICategoryRepository.GetAllCategories()
        {
            return context.Categories;
        }

        Category ICategoryRepository.GetCategory(int id)
        {
            return context.Categories.FirstOrDefault(m => m.Id == id);
        }

        Category ICategoryRepository.Update(Category categoryChanges)
        {
            var category = context.Categories.Attach(categoryChanges);
            category.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return categoryChanges;
        }
    }
}
