using Microsoft.AspNetCore.Mvc;
using Movies.Data;
using Movies.Extensions;
using Movies.Models;

namespace Movies.Controllers
{
    public class CartController : Controller
    {
        public const string SessionKeyName = "_cart";
        
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> cart=HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionKeyName);
            if (cart == null ) cart = new List<CartItem>();
            decimal total = 0;
            foreach (CartItem item in cart)
            {
                total += item.getTotal();
            }
            ViewBag.CartTotal = total;
            return View();
        }
    }
}
