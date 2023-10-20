using AutoMapper;
using BuisnessLayer.Abstract;
using EntityLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.Controllers.Admin
{
    public class AdmnCommentController : Controller
    {
        private readonly ICommentDal _commentDal;
        private readonly IMapper _mapper;

        public AdmnCommentController(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
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
        public IActionResult Edit(int id)
        {
            var comment = _commentDal.GetById(id);
            return View(_mapper.Map<CommentViewModel>(comment));
        }
    }
}
