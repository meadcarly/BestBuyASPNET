using System;
using System.Collections.Generic;

using BestBuyASPNET.Models;


namespace BestBuyASPNET;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();

    public Product GetProduct(int productId);

    public void UpdateProduct(Product product);

    //Create
    public int InsertProduct(Product productToInsert);

    //Get ALL
    public IEnumerable<Category> GetCategories();
    
    //Assign category to product
    public Product AssignCategory();
}

//SELECT LAST_INSERT_ID();