using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPNetCoreWebApplication.Models;

namespace ASPNetCoreWebApplication.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        List<Customer> customers = new List<Customer>
        {
            new Customer{Id = 0, Name = "Andre", Email = "andre@gmail.com" , Phone = "555"},
            new Customer{Id = 0, Name = "Andre1", Email = "andre1@gmail.com" , Phone = "555"}
        };

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Customer aCustomer)
        {
            if(ModelState.IsValid)
            {
                customers.Add(aCustomer);
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }

    
}