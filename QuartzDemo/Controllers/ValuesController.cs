using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NLog;
using QuartzDemo.Core;

namespace QuartzDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

          private ILogger<ValuesController> _logger;
          private ILogger<ValuesController> _GeneralEnginelogger;
        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
            _logger.LogInformation("构造方法获取的对象日志");
            _GeneralEnginelogger = EnginContext.Current.Resolve<ILogger<ValuesController>>();
            _GeneralEnginelogger.LogInformation("EnginContext方法获取的对象日志");
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {


            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
