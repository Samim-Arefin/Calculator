using CalculatorAPI.Services;
using CalculatorAPI.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnswer()
        {
            var response = await _calculatorService.GetAllAnswerAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswer(CalculatorViewModel calculator)
        {
            var response = await _calculatorService.AddAnswerAsync(calculator);
            return StatusCode(response.StatusCode, response.Message);
        }
    }
}
