using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly MyHttpClient _myHttpClient;

        public PeopleController(MyHttpClient myHttpClient)
        {
            _myHttpClient = myHttpClient;
        }

        [HttpGet("index")]
        public ActionResult<List<PersonWithGender>> Get()
        {
            var items = new List<PersonWithGender>
            {
                new PersonWithGender {
                    Id = 1,
                    Gender = Gender.Male
                },
                new PersonWithGender {
                    Id = 2,
                    Gender = Gender.Female
                }
            };

            return Ok(items);
        }

        [HttpGet("test")]
        public async Task<ActionResult<IEnumerable<PersonWithGender>>> Test()
        {
            var items = await _myHttpClient.GetPeopleAsync();
            return items;
        }
    }
}
