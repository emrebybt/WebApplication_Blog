using AutoMapper;
using BuisnessLayer.Abstract;
using EntityLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.Controllers.Admin
{
    [Authorize]
    public class AdmnCommentController : Controller
    {
        private readonly ICommentDal _commentDal;
        private readonly IMapper _mapper;
        private readonly ICommentReplyService _replyService;

        public AdmnCommentController(ICommentDal commentDal, IMapper mapper, ICommentReplyService replyService)
        {
            _commentDal = commentDal;
            _mapper = mapper;
            _replyService = replyService;
        }

        public IActionResult Index()
        {
            var comments = _commentDal.GetListAll();
            return View(_mapper.Map<List<CommentViewModel>>(comments));
        }
        public IActionResult CommentStatus(int id)
        {
            var comment = _commentDal.GetById(id);
            if (comment.CommentStatus == true)
            {
                comment.CommentStatus = false;
            }
            else
            {
                comment.CommentStatus = true;
            }
            _commentDal.Update(comment);
            return RedirectToAction("Index");
        }
        public IActionResult ReplyCommentStatus(int id)
        {
            var replycomment = _replyService.GetById(id);
            if (replycomment.CommentStatus == true)
            {
                replycomment.CommentStatus = false;
            }
            else
            {
                replycomment.CommentStatus = true;
            }
            _replyService.Update(replycomment);
            return RedirectToAction("Edit", new {id= replycomment.CommentId});
        }
        public IActionResult Edit(int id)
        {
            var comment = _commentDal.GetById(id);
            return View(_mapper.Map<CommentViewModel>(comment));
        }
    }
}
