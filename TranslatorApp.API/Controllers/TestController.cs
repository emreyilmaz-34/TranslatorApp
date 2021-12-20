using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TranslatorApp.Core.Models;
using TranslatorApp.Core.Service;

namespace TranslatorApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        readonly IService<TestModel> _testService;
        readonly IMapper _mapper;

        public TestController(IService<TestModel> service, IMapper mapper)
        {
            _testService = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var testModels = await _testService.GetAllAsync();
            return Ok(testModels);
        }

        [HttpPost]
        public async Task<IActionResult> Save(TestModel testModel)
        {
            var newTestModel = await _testService.AddAsync(testModel);
            return Ok(newTestModel);
        }
    }
}
