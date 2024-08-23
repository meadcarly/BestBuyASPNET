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

    public int InsertProduct(Product productToInsert)
    {
       var lastCreatedId = _conn.QuerySingleOrDefault<int>("INSERT INTO PRODUCTS (Name, Price, CategoryID) VALUES (@newName, @newPrice, @categoryId); SELECT LAST_INSERT_ID();", new
        {newName = productToInsert.Name, newPrice = productToInsert.Price, categoryId = productToInsert.CategoryID});

       return lastCreatedId;
    }

    public IEnumerable<Category> GetCategories()
    {
        var categories = _conn.Query<Category>("SELECT * FROM categories");
        return categories;
    }

    public Product AssignCategory()
    {
        var categoriesList = GetCategories();
        var product = new Product();
        product.Categories = categoriesList;
        return product;
    }

    public void DeleteProduct(Product productToDelete)
    {
        _conn.Execute("DELETE FROM REVIEWS WHERE PRODUCTID = @productId",
            new { productId = productToDelete.ProductID });
        _conn.Execute("DELETE FROM SALES WHERE PRODUCTID = @productId", new { productId = productToDelete.ProductID });
        _conn.Execute("DELETE FROM PRODUCTS WHERE PRODUCTID = @productId",
            new { productId = productToDelete.ProductID });
    }
}