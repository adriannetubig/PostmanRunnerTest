using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostmanRunnerTestWeb.Entities;

namespace PostmanRunnerTestWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        private readonly DbContextOptions<Context> _dbContextOptions;
        public TestsController()
        {
            _dbContextOptions = new DbContextOptionsBuilder<Context>()
                   .UseInMemoryDatabase(databaseName: "InMemoryDb")
                   .Options;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (var context = new Context(_dbContextOptions))
            {
                context.ETests.Add(
                    new ETest
                    {
                        Description = "description",
                        Name = "name"
                    });

                context.SaveChanges();

                var test = context.ETests.FirstOrDefault();
            }
            return new string[] { "value1", "value2" };
        }
    }
}
