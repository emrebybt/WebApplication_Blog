using AutoMapper;
using BuisnessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApplication_Blog.ViewModels;

namespace WebApplication_Blog.ViewComponents.Banner
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BannerViewComponent(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            var values = _blogService.GetAllBlogsWithCategory().OrderByDescending(x => x.BlogCreateDate).Take(6).ToList();
            return View(_mapper.Map<List<BlogViewModel>>(values));
        }
    }
}
