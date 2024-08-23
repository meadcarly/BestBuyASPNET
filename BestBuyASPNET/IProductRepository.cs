using System;
using System.Collections.Generic;
using BestBuyASPNET.Models;


namespace BestBuyASPNET;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();

    public Product GetProduct(int productId);

    public void UpdateProduct(Product product);

    public void InsertProduct(Product productToInsert);

    public IEnumerable<Category> GetCategories();

    public Product AssignCategory();
}

//SELECT LAST_INSERT_ID();