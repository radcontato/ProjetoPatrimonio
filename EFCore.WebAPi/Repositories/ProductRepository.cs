using EFCore.WebAPi.Data;
using EFCore.WebAPi.Models.Loja;
using EFCore.WebAPi.ViewModel.ProductViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EFCore.WebAPi.Repositories
{
    public class ProductRepository
    {
        private readonly Contexto _context;
        public ProductRepository(Contexto context)
        {
            _context = context;
        }

        public IEnumerable<ListProductViewModel> Get()
        {
            return _context
                .Products
                .Include(x => x.Category)
                .Select(x => new ListProductViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Price = x.Price,
                    Category = x.Category.Title,
                    CategoryId = x.Category.Id
                })
                .AsNoTracking()
                .ToList();
        }
        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }


        public IEnumerable<Product> GetProdutoPorCategoria(int id)
        {
            return _context.Products.AsNoTracking().Where(x => x.CategoryId == id).ToList();
        }



        public void Save(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }
        public void Update(Product product)
        {
            _context.Entry<Product>(product).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
