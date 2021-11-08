using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Counter.Controllers
{
    [ApiController]
    
    public class CounterController : ControllerBase
    {
        
        private readonly ILogger<CounterController> _logger;

        public CounterController(ILogger<CounterController> logger)
        {
            _logger = logger;
        }
        [Route("")]
        [HttpGet]
        [Route("count")]
        public int Get()
        {
            return CounterServer.GetCount();
        }
        // POST value        
        [Route("count/{value}")]
        public void Post(int value) 
        { 
            CounterServer.AddToCount(value);
        }



    }
}
