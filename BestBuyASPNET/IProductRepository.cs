using System;
using System.Collections.Generic;


namespace BestBuyASPNET;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProducts();

    public Product GetProduct(int productId);

    public void UpdateProduct(Product product);
}