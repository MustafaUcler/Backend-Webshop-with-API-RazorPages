using System;
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
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _context;
        private readonly AccessControl _accessControl;

        public IndexModel(AppDbContext context, AccessControl accessControl)
        {
            _context = context;
            _accessControl = accessControl;
        }

        public IList<Product> Products { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            const int pageSize = 10;
            PageIndex = pageIndex ?? 0;

            var totalItems = await _context.Products.CountAsync();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            HasPreviousPage = PageIndex > 0;
            HasNextPage = PageIndex < totalPages - 1;

            if (totalItems > 0)
            {
                Products = await _context.Products
                    .OrderBy(p => p.ProductId)
                    .Skip(PageIndex * pageSize)
                    .Take(pageSize)
                    .ToListAsync();
            }
            else
            {
                Products = new List<Product>();
            }
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            var shoppingCart = await _context.ShoppingCarts
                .Include(sc => sc.Products)
                .FirstOrDefaultAsync(sc => sc.UserId == _accessControl.LoggedInAccountID.ToString());

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart { UserId = _accessControl.LoggedInAccountID.ToString() };
                _context.ShoppingCarts.Add(shoppingCart);
            }

            shoppingCart.Products ??= new List<Product>();
            shoppingCart.Products.Add(product);

            await _context.SaveChangesAsync();

            return RedirectToPage("/ShoppingCart");
        }
    }
}
