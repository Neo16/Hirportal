using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hirportal.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        public readonly IColumnService columnService;

        public ColumnsController(IColumnService columnService)
        {           
            this.columnService = columnService;
        }

        /// <summary>
        /// Az összes rovat nevét adja vissza
        /// </summary>   
        [HttpGet("columns")]
        public async Task<ActionResult> ListColumns()
        {
            IEnumerable<ColumnData> columns = await columnService.Get();
            return Ok(columns);
        }
    }    
}