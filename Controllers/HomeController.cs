using Microsoft.AspNetCore.Mvc;
using Project_VP.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Project_VP.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        // Inject AppDbContext
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        // Show products from database
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // Cart - keep as it is for now (if you want to make it dynamic, we can modify later)
        private static List<Product> cart = new List<Product>();

        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            // For now, get product from DB synchronously for simplicity
            var product = _context.Products.Find(id);
            if (product != null)
            {
                cart.Add(product);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Cart()
        {
            return View(cart);
        }

        public IActionResult Checkout()
        {
            cart.Clear();
            ViewBag.Message = "Thanks for your purchase!";
            return View();
        }
    }
}
