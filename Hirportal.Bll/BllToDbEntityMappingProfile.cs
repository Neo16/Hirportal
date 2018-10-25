using AutoMapper;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.Dtos.MainPage;
using Hirportal.Model;
using Hirportal.Model.MainPage;

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

            CreateMap<MainPageBlock, MainPageBlockData>()
               .ForMember(e => e.Name, f => f.MapFrom(k => k.Name))
               .ForMember(e => e.IsLeadBlock, f => f.MapFrom(k => k.IsLeadBlock))
               .ForMember(e => e.Cells, f => f.MapFrom(k => k.MainPageCells));

            CreateMap<MainPageCell, MainPageCellData>()
              .ForMember(e => e.Article, f => f.MapFrom(k => k.Article))
              .ForMember(e => e.CellSize, f => f.MapFrom(k => k.CellSize))
              .ForMember(e => e.DisplayIndex, f => f.MapFrom(k => k.DisplayId));
        }
    }
}
