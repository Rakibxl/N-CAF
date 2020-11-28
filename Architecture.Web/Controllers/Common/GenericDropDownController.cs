using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Architecture.Web.Controllers.Common
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{v:apiVersion}/DropDown")]
    public class GenericDropDownController : Controller
    {
        //[HttpGet("AddressType")]
        //public async Task<IActionResult> GetAddressType()
        //{
        //    try
        //    {
        //        var basicInfoId = 2;
        //        var result = await _basicInfoService.GetById(basicInfoId);
        //        return OkResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
        //    try
        //    {
        //        var result = "";
        //        return OkResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}

        //[HttpPost("CreateOrUpdate")]
        //public async Task<IActionResult> CreateOrUpdate([FromBody] ProfBasicInfo model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return ValidationResult(ModelState);
        //    }

        //    try
        //    {
        //        var result = await _basicInfoService.AddOrUpdate(model);
        //        return OkResult(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return ExceptionResult(ex);
        //    }
        //}
    }
}
