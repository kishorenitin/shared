using InsuranceClaimsApi.BusinessService;
using InsuranceClaimsApi.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClaimsController : ControllerBase
    {
        public IWebHostEnvironment HostingEnvironment;
        private InsuranceClaimService ClmService { get; set; }

        private readonly ILogger<ClaimsController> _logger;

        public ClaimsController(ILogger<ClaimsController> logger,IWebHostEnvironment environment)
        {
            _logger = logger;
            ClmService = new InsuranceClaimService(environment);
        }

        [HttpGet]
        public List<Member> Get(DateTime date)
        {
            return ClmService.GetMemberClaimsByDate(date);
        }
    }
}
