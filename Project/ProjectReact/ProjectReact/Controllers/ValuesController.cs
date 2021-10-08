using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectReact.Controllers.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectReact.Controllers
{
    [Route("values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       

        [HttpPost]
        public IActionResult Create([FromBody] Data data)
        {
            
            if (data.Inr < 0)
            {
                return CreatedAtAction(nameof(Create), "wrong!");

            }
            else
            {
                return CreatedAtAction(nameof(Create), "Hello world" + data.Inr);
            }

        }

        [HttpGet]
        public int Get()
        {
            int x = 2;
            return x;
        }

    }
}
