using BusinessTask.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBases;
using Shared.Dtos;

namespace BusinessTask.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockController : CustomBaseController
    {
        private readonly IMockService _mockService;

        public MockController(IMockService mockService)
        {
            _mockService = mockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAndAdd()
        {
            var result = await _mockService.GetBusinessTask();
            return CreateActionResultInstance(Response<string>.Success(result, 200));
        }
    }
}
