using BestBuyASPNET.Models;

namespace BestBuyASPNET;

public class Product
{
    public int ProductID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int CategoryID { get; set; }
    public bool OnSale { get; set; }
    public int StockLevel { get; set; }
    
    public IEnumerable<Category> Categories { get; set; } 
}