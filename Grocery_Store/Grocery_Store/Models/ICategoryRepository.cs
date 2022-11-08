namespace Grocery_Store.Models
{
    public interface ICategoryRepository
    {
        Category GetCategory(int id);
        IEnumerable<Category> GetAllCategories();
        Category Add(Category Category);
        Category Update(Category CategoryChanges);
        Category Delete(int Id);
    }
}
