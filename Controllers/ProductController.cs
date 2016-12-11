using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using workshop.Models;

namespace workshop.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public IProductRepository _productrepo;

        public ProductController(IProductRepository productRepo)
        {
            this._productrepo = productRepo;
        }

        [HttpGet]
        
        public IEnumerable<ProductDto> Get()
        {
            return this._productrepo.GetAll();
        }

        [HttpPost]
        [ProducesResponseTypeAttribute(typeof(ProductDto), 200)]

        public IActionResult Post([FromBody] ProductDto product)
        {
            ProductDto productResultDTO = this._productrepo.Add(product);
            return new OkObjectResult(productResultDTO);
        }
    }
}
