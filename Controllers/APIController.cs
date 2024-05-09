using BackendApp1.Data;
using BackendApp1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendApp1.Controllers
{
    [Route("api")]
    [ApiController]
    public class APIController : ControllerBase
    {
        private readonly AppDbContext _database;

        public APIController(AppDbContext database)
        {
            _database = database;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string? Name = null, string? Category = null, int page = 1)
        {
            const int pageSize = 30;
            IQueryable<Product> query = _database.Products;

            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(p => p.Name.Contains(Name));
            }

            if (!string.IsNullOrEmpty(Category))
            {
                query = query.Where(p => p.Category == Category);
            }

            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var products = await query.Select(p => new Product
            {
                Name = p.Name,
                ImageUrl = $"{Request.Scheme}://{Request.Host}{p.ImageUrl}",
                Price = p.Price,
                Category = p.Category,
                Description = p.Description
            }).ToListAsync();

            var result = new
            {
                TotalCount = totalCount,
                TotalPages = totalPages,
                Products = products
            };

            return Ok(result);
        }
    }
}
