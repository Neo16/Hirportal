using Hirportal.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface ITagService
    {
        Task<IEnumerable<TagData>> Get();

        Task Add(TagData tag);

        Task Update(TagData tag);

        Task Delete(Guid id);
    }
}
