using System;
using System.Threading.Tasks;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hirportal.Web.Controllers
{
    [Route("api/admin")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class AdminColumnsController : ControllerBase
    {
        public readonly IColumnService columnService;

        public AdminColumnsController(IColumnService columnService)
        {           
            this.columnService = columnService;
        }       

        [HttpPost]
        [Route("create-column")]      
        public async Task<IActionResult> CreateColumn([FromBody] ColumnData column)
        {            
            await columnService.Create(column);
            return Ok();
        }

        [HttpDelete]
        [Route("delete-column")]
        public async Task<IActionResult> DeleteColumn(Guid columnId)
        {
            await columnService.Delete(columnId);
            return Ok(columnId);
        }
    }    
}