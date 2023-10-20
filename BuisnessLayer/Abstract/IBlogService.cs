using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Abstract
{
    public interface IBlogService : IGenericService<Blog>
    {
        List<Blog> GetAllBlogsWithCategory();
        Blog GetBlogsWithCategory(int id);
        List<Blog> GetBlogsWithCategory();
        List<Blog> GetAllBlogsByCategoryId(int? id);
        List<Blog> GetListWithSearch(string search);
        int GetBlogCountByCategory(int categoryId);
    }
}
