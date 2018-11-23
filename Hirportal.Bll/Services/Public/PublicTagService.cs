using AutoMapper.QueryableExtensions;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hirportal.Bll.Services
{
    public class PublicTagService: ServiceBase, IPublicTagService
    {
        public PublicTagService(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<TagData>> Get()
        {
            return await context.Tags
               .ProjectTo<TagData>()
               .ToListAsync();
        }
    }
}
