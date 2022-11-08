namespace Grocery_Store.Models.SQLRepository
{
    public class SQLProductRepository:IProductRepository
    {
        private readonly AppDbContext context;
        public SQLProductRepository(AppDbContext context)
        {
            this.context = context;
        }
        Product IProductRepository.Add(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }
        Product IProductRepository.Delete(int Id)
        {
            Product product = context.Products.Find((long)Id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }

        IEnumerable<Product> IProductRepository.GetAllProducts()
        {
            return context.Products;
        }

        Product IProductRepository.GetProduct(int id)
        {
            return context.Products.FirstOrDefault(m => m.Id == id);
        }

        Product IProductRepository.Update(Product productChanges)
        {
            var product = context.Products.Attach(productChanges);
            product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return productChanges;
        }
    }
}
