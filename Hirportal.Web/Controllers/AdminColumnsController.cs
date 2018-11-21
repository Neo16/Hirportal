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
        public readonly IAdminColumnService columnService;

        public AdminColumnsController(IAdminColumnService columnService)
        {           
            this.columnService = columnService;
        }       

        [HttpPost]
        [Route("create-column")]      
        public async Task<IActionResult> CreateColumn([FromBody] ColumnData column)
        {            
            Guid createdColumnId = await columnService.Create(column);
            return Ok(createdColumnId);
        }

        [HttpDelete]
        [Route("delete-column")]
        public async Task<IActionResult> DeleteColumn(Guid columnId)
        {
            await columnService.Delete(columnId);
            return Ok(columnId);
        }

        [HttpPut]
        [Route("update-column")]
        public async Task<IActionResult> UpdateColumn([FromBody] ColumnData column)
        {            
            await columnService.Update(column);
            return Ok(column);
        }
    }    
}