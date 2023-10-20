using AutoMapper;
using BuisnessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.Controllers.Admin
{
    public class AdmnCategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IBlogService _blogService;

        public AdmnCategoryController(ICategoryService categoryService, IMapper mapper, IBlogService blogService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetList();
            var mappedList = _mapper.Map<List<CategoryViewModel>>(categories);
            foreach (var item in mappedList)
            {
                item.BlogCount = _blogService.GetBlogCountByCategory(item.CategoryId);
            }
            return View(mappedList);
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel model)
        {
            model.CategoryStatus = true;
            _categoryService.Add(_mapper.Map<Category>(model));
            return RedirectToAction("Index");
        }
        public IActionResult CategoryStatus(int id)
        {
            var category = _categoryService.GetById(id);
            if (category.CategoryStatus == true)
            {
                category.CategoryStatus = false;
            }
            else
            {
                category.CategoryStatus = true;
            }
            _categoryService.Update(category);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetById(id);
            return View(_mapper.Map<CategoryViewModel>(category));
        }
        [HttpPost]
        public IActionResult Edit(CategoryViewModel model)
        {
            _categoryService.Update(_mapper.Map<Category>(model));
            return RedirectToAction("Index");
        }
    }
}
