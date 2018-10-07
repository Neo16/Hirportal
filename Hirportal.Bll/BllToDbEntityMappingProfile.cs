using AutoMapper;
using Hirportal.Bll.Models;
using Hirportal.Model;
namespace Hirportal.Bll
{
    public class BllToDbEntityMappingProfile : Profile
    {
        public BllToDbEntityMappingProfile()
        {
            CreateMap<Form, ExampleFormData>()
                .ReverseMap();
        }
    }
}
