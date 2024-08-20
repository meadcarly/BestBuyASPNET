using System.Data;
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
}