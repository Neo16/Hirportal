using Hirportal.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hirportal.Bll.Services
{
    public abstract class ServiceBase
    {
        protected readonly ApplicationDbContext context;

        public ServiceBase(ApplicationDbContext context)
        {
           this.context = context;
        }
    }
}
