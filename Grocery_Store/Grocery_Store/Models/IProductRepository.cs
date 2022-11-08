﻿namespace Grocery_Store.Models
{
    public interface IProductRepository
    {
        Product GetProduct(int Id);
        IEnumerable<Product> GetAllProducts();
        Product Add(Product Product);
        Product Update(Product ProductChanges);
        Product Delete(int Id);
    }
}
