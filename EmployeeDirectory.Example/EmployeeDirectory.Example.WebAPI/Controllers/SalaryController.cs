using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmployeeDirectory.Example.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private ILogger<SalaryController> Logger { get; }
        private IMapper Mapper { get; }
        
        public SalaryController(ILogger<SalaryController> logger, IMapper mapper)
        {
            this.Logger = logger;
            this.Mapper = mapper;
        }

        
    }
}