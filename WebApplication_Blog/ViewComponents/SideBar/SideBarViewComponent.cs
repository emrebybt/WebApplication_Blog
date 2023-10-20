using AutoMapper;
using BuisnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.ViewComponents.SliderViewComponent
{
    public class SideBarViewComponent : ViewComponent
    {
        ICategoryService _categoryService;
        IMapper _mapper;
        IBlogService _blogService;

        public SideBarViewComponent(ICategoryService categoryService, IMapper mapper, IBlogService blogService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _blogService = blogService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Blogs = _blogService.GetList().Where(x=>x.BlogStatus == true).TakeLast(3).Reverse();

            var values = _categoryService.GetList().Where(x => x.CategoryStatus == true);
            return View(_mapper.Map<List<CategoryViewModel>>(values));
        }
    }
}
