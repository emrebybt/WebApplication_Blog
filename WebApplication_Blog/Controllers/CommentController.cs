using AutoMapper;
using BuisnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly ICommentReplyService _commentReplyService;

        public CommentController(ICommentService commentService, IMapper mapper, ICommentReplyService commentReplyService)
        {
            _commentService = commentService;
            _mapper = mapper;
            _commentReplyService = commentReplyService;
        }

        [HttpPost]
        public IActionResult AddComment(CommentViewModel comment)
        {
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = false;
            _commentService.Add(_mapper.Map<Comment>(comment));
            return RedirectToAction("BlogDetails", "Blog", new { id = comment.BlogId });
        }
        [HttpPost]
        public IActionResult AddReplyComment(ReplyCommentViewModel replyComment)
        {
            replyComment.CommentDate = DateTime.Now;
            replyComment.CommentStatus = false;
            _commentReplyService.Add(_mapper.Map<CommentReply>(replyComment));
            return RedirectToAction("BlogDetails", "Blog", new { id = replyComment.BlogId });
        }
    }
}
