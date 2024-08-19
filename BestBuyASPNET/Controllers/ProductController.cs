using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BestBuyASPNET.Controllers;

public class ProductController : Controller
{
    private readonly IProductRepository _productRepo;

    public ProductController(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }
    
    
    // GET
    public IActionResult Index()
    {
        var products = _productRepo.GetAllProducts();
        return View(products);
    }
}