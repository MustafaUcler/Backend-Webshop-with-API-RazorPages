using BackendApp1.Data;
using BackendApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendApp1.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly AccessControl _accessControl;

        public ProductDetailsModel(AppDbContext context, AccessControl accessControl)
        {
            _context = context;
            _accessControl = accessControl;
        }

        public Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            if (Product == null)
            {
                return NotFound();
            }

            return Page();
        }

        public class OrderConfirmationModel : PageModel
        {
            [BindProperty(SupportsGet = true)]
            public double TotalPrice { get; set; }

            public void OnGet()
            {
                
            }

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
