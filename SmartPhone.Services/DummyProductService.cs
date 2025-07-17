using SmartPhone.Model;
using SmartPhone.Model.SearchObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPhone.Services
{
    public class DummyProductService : IProductService
    {
        public List<Product> Get(ProductSerachObject? search)
        {
            List<Product> products = new List<Product>();
            products.Add(new Product()
            { Id = 1, Name = "Telefon", Code = "telefon1" });

            var queryable = products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Name))
            {
                queryable = queryable.Where(x => x.Name == search.Name);  
            }

            if (!string.IsNullOrWhiteSpace(search?.NameGTE))
            {
                queryable = queryable.Where(x => x.Name.StartsWith(search.NameGTE, StringComparison.CurrentCultureIgnoreCase));
            }
            return queryable.ToList();

           
        }

        public Product GetById(int id)
        {

            return new Product() { Id = 1, Name = "Telefon", Code = "telefon1" };
        }
    }
}
