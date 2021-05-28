using EFCore.WebAPi.Data;
using EFCore.WebAPi.Models.Loja;
using EFCore.WebAPi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.WebAPi.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Contexto _context;

        public CategoryController(Contexto context)
        {
            _context = context;
        }

        [Route("v1/categories")]
        [HttpPost]
        public IActionResult Post([FromBody] CategoryViewModel category)
        {
            var categoria = new Category()
            {
                Title = category.Title
            };

            _context.Categories.Add(categoria);
            _context.SaveChanges();

            return Ok();
        }

        [Route("v1/categories")]
        [HttpGet]
        [ResponseCache(Duration = 3600)]
        public IEnumerable<Category> Get()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        [Route("v1/categories/{id}")]
        [HttpGet]
        public Category Get(int id)
        {
            return _context.Categories.AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
        }

        [Route("v1/categories/{id}")]
        [HttpPut]
        public Category Put([FromBody] Category category)
        {
            _context.Entry<Category>(category).State = EntityState.Modified;
            _context.SaveChanges();

            return category;
        }

        [Route("v1/categories")]
        [HttpDelete]
        public Category Delete([FromBody] Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();

            return category;
        }
    }
}
