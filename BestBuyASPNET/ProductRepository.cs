using System.Data;
using BestBuyASPNET.Models;
using Dapper;

namespace BestBuyASPNET;

public class ProductRepository : IProductRepository
{
    //Field(Class level variable): Make it private/readonly because you don't ever want it to change outside of this class
    //readonly can only get a value inside a constructor or object initializer
    private readonly IDbConnection _conn;

    //Constructor gives the readonly variable a value
    public ProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }
    public IEnumerable<Product> GetAllProducts()
    {
        //Connect to database and run the SQL
        return _conn.Query<Product>("SELECT * FROM products");
    }

    public Product GetProduct(int productId)
    {
        var product = _conn.QuerySingle<Product>("SELECT * FROM products WHERE ProductID = @productId", new { productId = productId });
        
        return product;
    }

    public void UpdateProduct(Product product)
    {
        //Execute update command to the database
        _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
            new { name = product.Name, price = product.Price, id = product.ProductID });
    }

    public void InsertProduct(Product productToInsert)
    {
        _conn.Execute(
            "INSERT INTO PRODUCTS (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryId)",
            new
            {
                name = productToInsert.Name, price = productToInsert.Price, categoryId = productToInsert.CategoryID
            });
    }

    public IEnumerable<Category> GetCategories()
    { 
       return _conn.Query<Category>("SELECT * FROM categories");
    }

    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product();
        product.Categories = categoryList;
        return product;
    }
}