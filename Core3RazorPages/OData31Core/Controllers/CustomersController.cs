using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OData31Core.Controllers
{
    public  class CustomerDto
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
        {
            return Ok();
        }
    }
}