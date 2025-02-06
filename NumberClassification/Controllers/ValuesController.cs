using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberClassification.Services;

namespace NumberClassification.Controllers
{
    [ApiController]
    [Route("api/classify-number")]
    public class NumberController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly NumberService _numberService;

        public NumberController()
        {
            _httpClient = new HttpClient();
            _numberService = new NumberService(_httpClient);
        }

        [HttpGet]
        public async Task<IActionResult> GetNumberInfo([FromQuery] string number)
        {
            if (!int.TryParse(number, out int num))
            {
                return BadRequest(new { number, error = true });
            }

            var result = _numberService.ClassifyNumber(num);
            return Ok(result);
        }
    }

}
