using System.Collections.Generic;

namespace EFCore.WebAPi.Models.Loja
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
