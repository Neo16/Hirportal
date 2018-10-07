using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hirportal.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper mapper;
        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
    }
}
