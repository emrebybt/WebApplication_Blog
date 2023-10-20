using AutoMapper;
using BuisnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.ViewComponents.Comment
{
    public class CommentViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public CommentViewComponent(ICommentService commentService, IMapper mapper)
        {
            _commentService = commentService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke(int id) 
        {
            var values = _commentService.GetList(id).Where(x => x.CommentStatus == true);
            values.Reverse();
            return View(_mapper.Map<List<CommentViewModel>>(values)); 
        }
    }
}
