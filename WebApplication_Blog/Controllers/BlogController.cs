using AutoMapper;
using BuisnessLayer.Abstract;
using BuisnessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _blogService.GetAllBlogsWithCategory();
            values.Reverse();
            return View(_mapper.Map<List<BlogViewModel>>(values));
        }
        public IActionResult Blogs(int? id, string search)
        {
            var values = _blogService.GetAllBlogsWithCategory();
            values.Reverse();
            if (id != null)
            {
                values = _blogService.GetAllBlogsByCategoryId(id);
                values.Reverse();
            }
            if (search != null)
            {
                values = _blogService.GetListWithSearch(search);
            }
            
            
            return View(_mapper.Map<List<BlogViewModel>>(values));
        }
        
        public IActionResult BlogDetails(int id)
        {
            var values = _blogService.GetBlogsWithCategory(id);
            return View(_mapper.Map<BlogViewModel>(values));
        }
    }
}
