using EFCore.WebAPi.Models.Loja;
using EFCore.WebAPi.Repositories;
using EFCore.WebAPi.ViewModel.ProductViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EFCore.WebAPi.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductRepository _repository;

        public ProductController(ProductRepository repository)
        {
            _repository = repository;
        }

        [Route("v1/products")]
        [HttpGet]
        public IEnumerable<ListProductViewModel> Get()
        {
            return _repository.Get();
        }

        [Route("v1/products/{id}")]
        [HttpGet]
        public Product Get(int id)
        {
            return _repository.Get(id);
        }

        [Route("v1/products")]
        [HttpPost]
        public IActionResult Post([FromBody] EditorProductViewModel model)
        {

            var product = new Product();

            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.CreateDate = DateTime.Now;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now;
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repository.Save(product);

            return Ok(product);
        }

        [Route("v2/products")]
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            _repository.Save(product);

            var products = new Product();

            return Ok(product);
        }

        [Route("v1/products")]
        [HttpPut]
        public IActionResult Put([FromBody] EditorProductViewModel model)
        {
            var product = _repository.Get(model.Id);
            product.Title = model.Title;
            product.CategoryId = model.CategoryId;
            product.Description = model.Description;
            product.Image = model.Image;
            product.LastUpdateDate = DateTime.Now; 
            product.Price = model.Price;
            product.Quantity = model.Quantity;

            _repository.Update(product);

            return Ok(product);
        }

        [Route("v1/categories/{id}/products")]
        [HttpGet]
        [ResponseCache(Duration = 30)]
        public IActionResult GetProductsPorCategoria(int id)
        {
            var products = _repository.GetProdutoPorCategoria(id);
            return Ok(products);           
        }
    }
}
