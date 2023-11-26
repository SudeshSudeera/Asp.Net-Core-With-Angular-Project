using DataService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS_Project.Controllers.Api.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [AutoValidateAntiforgeryToken]
    public class CountryController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public CountryController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCountries()
        {
            var countries = await _db.Countries.OrderBy(x => x.Name).ToListAsync();

            return Ok(countries);
        }
    }
}
