using BuisnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_Blog.ViewComponents.Reply
{
    public class ReplyViewComponent : ViewComponent
    {
        private readonly ICommentReplyService _commentReplyService;

        public ReplyViewComponent(ICommentReplyService commentReplyService)
        {
            _commentReplyService = commentReplyService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var value = _commentReplyService.GetReplyList(id);
            return View(value);
        }
    }
}
