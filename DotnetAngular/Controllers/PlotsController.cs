using DotnetAngular.Dtos;
using DotnetAngular.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DotnetAngular.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PlotsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var stream = FileUtility.GetStream("wwwroot/Plots.xlsx");
            var dataTable = ExcelUtility.Read(stream);
            var result= DataTableUtility.ConvertToModel<AddressDto>(dataTable);
            return this.Ok(result);
        }
    }
}
