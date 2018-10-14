using AutoMapper;
using Hirportal.Bll.Dtos;
using Hirportal.Model;
namespace Hirportal.Bll
{
    public class BllToDbEntityMappingProfile : Profile
    {
        public BllToDbEntityMappingProfile()
        {
            CreateMap<Form, ExampleFormData>()
                .ReverseMap();

            CreateMap<Article, ArticleHeaderData>()
                .ForMember(e => e.Id, f => f.MapFrom(k => k.Id))
                .ForMember(e => e.Title, f => f.MapFrom(k => k.Title))
                .ForMember(e => e.CoverImageUrl, f => f.MapFrom(k => k.CoverImageUrl))
                .ForMember(e => e.ThumbnailContent, f => f.MapFrom(k => k.ThumbnailContent));

            CreateMap<Article, ArticleDisplayData>()
               .IncludeBase<Article, ArticleHeaderData>()
               .ForMember(e => e.HtmlContent, f => f.MapFrom(k => k.HtmlContent))
               .ForMember(e => e.AuthorName, f => f.MapFrom(k => k.Author.UserName));              
        }
    }
}
