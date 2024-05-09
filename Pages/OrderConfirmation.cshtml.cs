using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendApp1.Pages
{
    public class OrderConfirmationModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public double TotalPrice { get; set; }

        public void OnGet()
        {
            
        }
    }
}