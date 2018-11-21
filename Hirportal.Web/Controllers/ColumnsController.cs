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
       
        public readonly IPublicColumnService publiColumnService;

        public ColumnsController(IPublicColumnService publiColumnService)
        {
            this.publiColumnService = publiColumnService;       
        }

        /// <summary>
        /// Az összes rovat nevét adja vissza
        /// </summary>   
        [HttpGet("columns")]
        public async Task<ActionResult> ListColumns()
        {
            IEnumerable<ColumnData> columns = await publiColumnService.Get();
            return Ok(columns);
        }
    }    
}