using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNetCoreWebApplication.Data;
using ASPNetCoreWebApplication.Models;
using ASPNetCoreWebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPNetCoreWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //ProductsDbContext productsDbContext = new ProductsDbContext();
        private IProduct productRepository;

        public ProductsController(IProduct aProductsDbContext)
        {
            productRepository = aProductsDbContext;
        }

        // GET: api/Products
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productRepository.GetProducts();
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetProduct(id);

            return product == null ? NotFound("Record Not Found") : (IActionResult)Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult Post([FromBody] Product aProduct)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            productRepository.AddProduct(aProduct);

            return StatusCode(StatusCodes.Status200OK);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product aproduct)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != aproduct.ProductId)
            {
                return BadRequest();
            }

            try
            {
                productRepository.UpdateProduct(aproduct);
                return Ok("Product updated...");
            }
            catch(DbUpdateException e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = productRepository.GetProduct(id);           

            productRepository.DeleteProduct(id);
            return Ok(StatusCodes.Status200OK);
        }
    }
}
