using AutoMapper;
using EntityLayer.Concrete;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() 
        {
            CreateMap<Blog, BlogViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<CommentReply, ReplyCommentViewModel>().ReverseMap();
        }
    }
}
