using AutoMapper;
using BuisnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.ViewComponents.AdminReplyComment
{
    public class AdminReplyCommentViewComponent : ViewComponent
    {
        private readonly ICommentReplyService _commentReplyService;
        private readonly IMapper _mapper;

        public AdminReplyCommentViewComponent(IMapper mapper, ICommentReplyService commentReplyService)
        {

            _mapper = mapper;
            _commentReplyService = commentReplyService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var replycomments = _commentReplyService.GetReplyList(id);
            return View(_mapper.Map<List<ReplyCommentViewModel>>(replycomments));
        }
    }
}
