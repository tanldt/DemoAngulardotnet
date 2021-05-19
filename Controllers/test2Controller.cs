using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAngulardotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class test2Controller : ControllerBase
    {
        [HttpGet]
        public string saytesting() {
            return "a testing";
        }
    }
    
}
