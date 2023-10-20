using EntityLayer.Concrete;

namespace WebApplication_Blog.ViewModels
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public string BlogTags { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
