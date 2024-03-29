﻿using Hirportal.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hirportal.Bll.ServiceInterfaces
{
    public interface IAdminTagService
    {
        Task<IEnumerable<TagData>> Get();

        Task<Guid> Create(TagData tag);

        Task Update(TagData tag);

        Task Delete(Guid id);
    }
}
