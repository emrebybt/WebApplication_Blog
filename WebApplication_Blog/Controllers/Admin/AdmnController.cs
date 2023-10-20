using AutoMapper;
using BuisnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.Controllers.Admin
{
    public class AdmnController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;

        public AdmnController(IBlogService blogService, IMapper mapper, ICommentService commentService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _mapper = mapper;
            _commentService = commentService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _blogService.GetAllBlogsWithCategory();
            ViewBag.Blogs = _mapper.Map<List<BlogViewModel>>(values).Count();
            values.Reverse();
            ViewBag.Comments = _mapper.Map<List<CommentViewModel>>(_commentService.GetList()).Count();
            return View(_mapper.Map<List<BlogViewModel>>(values).Take(3).ToList());
        }
        public IActionResult AllBlogs()
        {
            var blogs = _blogService.GetBlogsWithCategory();
            blogs.Reverse();
            return View(_mapper.Map<List<BlogViewModel>>(blogs));
        }
        public IActionResult BlogStatus(int id)
        {
            var blog = _blogService.GetById(id);
            if (blog.BlogStatus == true)
            {
                blog.BlogStatus = false;
            }
            else
            {
                blog.BlogStatus = true;
            }
            _blogService.Update(blog);
            return RedirectToAction("AllBlogs");
        }
        public IActionResult Edit(int id)
        {
            var blog = _blogService.GetById(id);
            ViewBag.Categories = new SelectList(_categoryService.GetList(), "CategoryId", "CategoryName");
            return View(_mapper.Map<BlogViewModel>(blog));
        }
        public IActionResult CreateBlog()
        {
            ViewBag.Categories = new SelectList(_categoryService.GetList(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult CreateBlog(BlogViewModel blog, IFormFile formFile1, IFormFile formFile2)
        {
            //Thumbnail Image
            var path1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", formFile1.FileName);
            //Content Image
            var path2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", formFile2.FileName);
            var stream1 = new FileStream(path1, FileMode.Create);
            var stream2 = new FileStream(path2, FileMode.Create);
            formFile1.CopyTo(stream1);
            formFile2.CopyTo(stream2);
            blog.BlogThumbnailImage = "/images/" + formFile1.FileName;
            blog.BlogImage = "/images/" + formFile2.FileName;
            blog.BlogCreateDate = DateTime.Now;
            _blogService.Add(_mapper.Map<Blog>(blog));

            ViewBag.Categories = new SelectList(_categoryService.GetList(), "CategoryId", "CategoryName");
            return View();
        }
    }
}
