using Microsoft.AspNetCore.Mvc;
using SmartPhone.Model;
using SmartPhone.Model.SearchObject;
using SmartPhone.Services;

namespace SmartPhone_WEB_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        protected readonly IProductService _productService;
        public ProductController(IProductService service) { 
            _productService = service;
        }
        [HttpGet()]
        public IEnumerable<Product> Get([FromQuery]ProductSerachObject? search)
        {
          
            return _productService.Get(search);
        }


        [HttpGet("{id}")]
        public Product Get(int id)
        {

            return _productService.GetById(id);
        }
    }
}
