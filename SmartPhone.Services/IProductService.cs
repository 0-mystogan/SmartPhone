using SmartPhone.Model;
using SmartPhone.Model.SearchObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPhone.Services
{
    public interface IProductService
    {
        public List<Product> Get(ProductSerachObject? search);
        public Product GetById(int id);
    }
}
