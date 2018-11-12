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
    public class TagService: ServiceBase, ITagService
    {
        public TagService(ApplicationDbContext context) : base(context)
        {
        }

        public Task Add(TagData tag)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TagData>> Get()
        {
            return await context.Tags
               .ProjectTo<TagData>()
               .ToListAsync();
        }

        public Task Update(TagData tag)
        {
            throw new NotImplementedException();
        }
    }
}
