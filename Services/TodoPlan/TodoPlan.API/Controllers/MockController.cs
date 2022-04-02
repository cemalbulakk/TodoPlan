using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBases;
using Shared.Dtos;
using TodoPlan.API.Services.Interfaces;
using TodoPlan.Core.Models;

namespace TodoPlan.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MockController : CustomBaseController
    {
        private readonly IBusinessTaskMockService _businessTaskMockService;
        private readonly IITTaskMockService _itTaskMockService;


        public MockController(IBusinessTaskMockService businessTaskMockService, IITTaskMockService itTaskMockService)
        {
            _businessTaskMockService = businessTaskMockService;
            _itTaskMockService = itTaskMockService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBusinessTask()
        {
            var result = await _businessTaskMockService.Get();
            return CreateActionResultInstance(Response<List<BusinessTask>>.Success(result, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetITTask()
        {
            var itTasks = await _itTaskMockService.Get();

            var addDbItTasks = await _itTaskMockService.AddItTaskMock(itTasks);

            return CreateActionResultInstance(addDbItTasks
                ? Response<NoContent>.Success(204)
                : Response<NoContent>.Fail("IT Tasks is not added.",
                    400));
        }
    }
}
