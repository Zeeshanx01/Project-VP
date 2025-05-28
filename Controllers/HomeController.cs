using Microsoft.AspNetCore.Mvc;
using Project_VP.Models; // Make sure this matches your namespace
using System.Collections.Generic;
using System.Linq;

namespace Project_VP.Controllers
{
    public class HomeController : Controller
    {
        // Static list of products to act like a mini database
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 450.00m },
            new Product { Id = 2, Name = "Mouse", Price = 15.99m },
            new Product { Id = 3, Name = "Keyboard", Price = 29.50m },
            new Product { Id = 4, Name = "Monitor", Price = 120.00m }
        };

        // Cart to store selected items
        private static List<Product> cart = new List<Product>();

        // Show products
        public IActionResult Index()
        {
            return View(products);
        }

        // Add to cart
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                cart.Add(product);
            }
            return RedirectToAction("Index");
        }

        // View cart
        public IActionResult Cart()
        {
            return View(cart);
        }

        // Checkout
        public IActionResult Checkout()
        {
            cart.Clear();
            ViewBag.Message = "Thanks for your purchase!";
            return View();
        }
    }
}
