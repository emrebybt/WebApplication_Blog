using BuisnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Blog.ViewComponents.CommentCount
{
    public class CommentCountViewComponent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentCountViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.GetList(id).Where(x=> x.CommentStatus == true).Count();
            return View(values);
        }
    }
}
