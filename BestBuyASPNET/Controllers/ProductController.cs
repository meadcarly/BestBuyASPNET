using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestBuyASPNET.Models;
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

    public IActionResult ViewProduct(int id)
    {
        var product = _productRepo.GetProduct(id);
        return View(product);
    }

    public IActionResult UpdateProduct(int id)
    {
        Product prod = _productRepo.GetProduct(id);
        if(prod == null)
        {
            return View("Error", new ErrorViewModel());
        }

        return View(prod);
    }

    public IActionResult UpdateProductToDatabase(Product product)
    {
        _productRepo.UpdateProduct(product);

        return RedirectToAction("ViewProduct", new { id = product.ProductID });
    }
}