using DotnetAngular.Dtos;
using DotnetAngular.Models;
using DotnetAngular.Services;
using DotnetAngular.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DotnetAngular.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PlotsController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PlotsController(IEmailService emailService, UserManager<ApplicationUser> userManager)
        {
            _emailService = emailService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stream = FileUtility.GetStream("wwwroot/Plots.xlsx");
            var dataTable = ExcelUtility.Read(stream);
            var result = DataTableUtility.ConvertToModel<AddressDto>(dataTable);
            return this.Ok(result);
        }

        [HttpPost("requestEmail")]
        public async Task<IActionResult> RequestEmail([FromBody] AddressDto address, CancellationToken cancellationToken = default)
        {
            var userId = this.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await this._userManager.FindByIdAsync(userId);
            var sucess = _emailService.SendEmail(new EmailData
            {
                EmailBody = $@"name: {user?.UserName}\n {user?.Email} is Requesting Quote for {address?.ToString()}",
                EmailSubject = "Request plot",
                EmailToId = "bharathprotem@gmail.com",
                EmailToName = "Bharath"
            });
            return this.Ok(sucess);
        }
    }
}
