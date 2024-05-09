using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendApp1.Data;
using BackendApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BackendApp1.Pages
{
    public class ShoppingCartModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly AccessControl _accessControl;

        public ShoppingCartModel(AppDbContext context, AccessControl accessControl)
        {
            _context = context;
            _accessControl = accessControl;
        }

        public IList<Product> Products { get; set; }
        public double TotalPrice { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var shoppingCart = await _context.ShoppingCarts
                .Include(sc => sc.Products)
                .FirstOrDefaultAsync(sc => sc.UserId == _accessControl.LoggedInAccountID.ToString());

            if (shoppingCart != null)
            {
                Products = shoppingCart.Products.ToList();
                TotalPrice = Products.Sum(p => p.Price);
            }
            else
            {
                Products = new List<Product>();
                TotalPrice = 0;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostClearCartAsync()
        {
            var shoppingCart = await _context.ShoppingCarts
                .Include(sc => sc.Products)
                .FirstOrDefaultAsync(sc => sc.UserId == _accessControl.LoggedInAccountID.ToString());

            if (shoppingCart != null)
            {
                shoppingCart.Products.Clear();
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveFromCartAsync(int productId)
        {
            var shoppingCart = await _context.ShoppingCarts
                .Include(sc => sc.Products)
                .FirstOrDefaultAsync(sc => sc.UserId == _accessControl.LoggedInAccountID.ToString());

            if (shoppingCart != null)
            {
                var productToRemove = shoppingCart.Products.FirstOrDefault(p => p.ProductId == productId);
                if (productToRemove != null)
                {
                    shoppingCart.Products.Remove(productToRemove);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            var shoppingCart = await _context.ShoppingCarts
                .Include(sc => sc.Products)
                .FirstOrDefaultAsync(sc => sc.UserId == _accessControl.LoggedInAccountID.ToString());

            if (shoppingCart != null)
            {
                double totalPrice = shoppingCart.Products.Sum(p => p.Price);

                shoppingCart.Products.Clear(); 
                await _context.SaveChangesAsync();

                return RedirectToPage("/OrderConfirmation", new { totalPrice });
            }

            return RedirectToPage();
        }
    }
}
