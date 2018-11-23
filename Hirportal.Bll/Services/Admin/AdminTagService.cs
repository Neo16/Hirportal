using AutoMapper.QueryableExtensions;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.ServiceInterfaces;
using Hirportal.Dal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hirportal.Bll.Exceptions;
using Hirportal.Model;

namespace Hirportal.Bll.Services
{
    public class AdminTagService: ServiceBase, IPublicTagService
    {
        public AdminTagService(ApplicationDbContext context) : base(context)
        {
        }


        public async Task Delete(Guid id)
        {

            bool tagHasArticles = await context.ArticleTags
                .AnyAsync(e => e.TagId == id);
            if (tagHasArticles)
            {
                throw new BusinessLogicException("A címke nem törölhető, mert cikkek tartoznak hozzá.") { ErrorCode = ErrorCode.InvalidArgument };
            }

            var tagEntity = await context.Tags
              .FirstOrDefaultAsync(e => e.Id == id);

            if (tagEntity != null)
            {
                context.Tags.Remove(tagEntity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<Guid> Create(TagData tag)
        {
            var tagObj = AutoMapper.Mapper.Map<Tag>(tag);
            context.Tags.Add(tagObj);
            await context.SaveChangesAsync();
            return tagObj.Id;
        }

        public async Task Update(TagData tag)
        {
            var tagEntity = await context.Tags
              .FirstOrDefaultAsync(e => e.Id == tag.TagId);

            if (tagEntity != null)
            {
                tagEntity.Value= tag.Name;
                await context.SaveChangesAsync();
            }
            else
            {
                throw new BusinessLogicException("A keresett címke nem található.") { ErrorCode = ErrorCode.InvalidArgument };
            }
        }
        public async Task<IEnumerable<TagData>> Get()
        {
            return await context.Tags
               .ProjectTo<TagData>()
               .ToListAsync();
        }
    }
}
