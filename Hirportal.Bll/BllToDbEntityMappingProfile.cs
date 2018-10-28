using AutoMapper;
using Hirportal.Bll.Dtos;
using Hirportal.Bll.Dtos.MainPage;
using Hirportal.Model;
using Hirportal.Model.MainPage;
using System.Linq;

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
                .ForMember(e => e.PublishDate, f => f.MapFrom(k => k.PublishDate))
                .ForMember(e => e.Column, f => f.MapFrom(k => k.Column))
                .ForMember(e => e.Tags, f => f.MapFrom(k => k.ArticleTags))
                .ForMember(e => e.AuthorName, f => f.MapFrom(k => k.Author.UserName));

            CreateMap<Article, ArticleEditCreateData>()
                .ForMember(e => e.Title, f => f.MapFrom(k => k.Title))
                .ForMember(e => e.ThumbnailContent, f => f.MapFrom(k => k.ThumbnailContent))
                .ForMember(e => e.HtmlContent, f => f.MapFrom(k => k.HtmlContent))
                .ForMember(e => e.CoverImageUrl, f => f.MapFrom(k => k.CoverImageUrl))
                .ForMember(e => e.PublishDate, f => f.MapFrom(k => k.PublishDate))
                .ForMember(e => e.ArchiveDate, f => f.MapFrom(k => k.ArchiveDate))
                .ForMember(e => e.Column, f => f.MapFrom(k => k.Column))
                .ForMember(e => e.Tags, f => f.MapFrom(k => k.ArticleTags))
                .ForMember(e => e.AuthorId, f => f.MapFrom(k => k.Author))
                .ReverseMap();

            CreateMap<ArticleTag, TagData>()
                .ForMember(e => e.TagId, f => f.MapFrom(k => k.TagId))
                .ForMember(e => e.Name, f => f.MapFrom(k => k.Tag.Value))
                .ReverseMap();

            CreateMap<Column, ColumnData>()
                .ForMember(e => e.ColumnId, f => f.MapFrom(k => k.Id))
                .ForMember(e => e.Name, f => f.MapFrom(k => k.Name))
                .ReverseMap();

            CreateMap<ApplicationUser, AuthorData>()
                .ForMember(e => e.AuthorId, f => f.MapFrom(k => k.Id))
                .ForMember(e => e.Name, f => f.MapFrom(k => k.UserName))
                .ReverseMap();

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
