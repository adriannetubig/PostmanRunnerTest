using System;
using System.Linq;
using System.Net;
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

        [HttpPut]
        public IActionResult Create([FromBody]ETest eTest)
        {
            try
            {
                using (var context = new Context(_dbContextOptions))
                {
                    eTest.Description = "Modified Description";
                    context.ETests.Add(eTest);
                    context.ETests.Add(eTest);
                    context.SaveChanges();

                    return new ObjectResult(eTest)
                    {
                        StatusCode = (int)HttpStatusCode.Created
                    };
                }
            }
            catch (Exception e)
            {
                return new ObjectResult(e)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpGet]
        public IActionResult Read()
        {
            try
            {
                using (var context = new Context(_dbContextOptions))
                    return Ok(context.ETests.ToList());
            }
            catch (Exception e)
            {
                return new ObjectResult(e)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpPost]
        public IActionResult Update([FromBody]ETest eTest)
        {
            try
            {
                using (var context = new Context(_dbContextOptions))
                {
                    context.ETests.Update(eTest);
                    context.SaveChanges();
                    return Ok(eTest);
                }
            }
            catch (Exception e)
            {

                return new ObjectResult(e)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }

        [HttpDelete("{TestId}")]
        public IActionResult Delete(int testId)
        {
            try
            {
                using (var context = new Context(_dbContextOptions))
                {
                    var eTest = context.ETests.FirstOrDefault(a => a.TestId == testId);
                    context.Remove(eTest);
                    context.SaveChanges();

                    return NoContent();
                }
            }
            catch (Exception e)
            {

                return new ObjectResult(e)
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError
                };
            }
        }
    }
}
