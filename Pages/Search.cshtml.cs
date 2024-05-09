using BackendApp1.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BackendApp1.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BackendApp1.Pages
{
    public class SearchModel : PageModel
    {
        private readonly AppDbContext _context;

        public SearchModel(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; }
        public string SearchString { get; set; }
        public string Category { get; set; }
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }

        public void OnGet(string searchString, string category, int pageIndex = 0)
        {
            const int pageSize = 10;
            PageIndex = pageIndex;
            SearchString = searchString;
            Category = category;

            IQueryable<Product> query = _context.Products;

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.Name.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(category))
            {
                query = query.Where(p => p.Category == category);
            }

            TotalPages = (int)Math.Ceiling(query.Count() / (double)pageSize);
            HasPreviousPage = PageIndex > 0;
            HasNextPage = PageIndex < TotalPages - 1;

            Products = query.Skip(PageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
