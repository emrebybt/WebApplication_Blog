using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetAllBlogsWithCategory();
        Blog GetBlogsWithCategory(int id);
        List<Blog> GetBlogsWithCategory();
        List<Blog> GetAllBlogs();
        List<Blog> GetAllBlogsByCategoryId(int? id);
    }
}
