using DataAccessLayer.Data;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        private readonly BlogContext _context;
        public EfBlogRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogs()
        {
            return _context.Blogs.OrderByDescending(x=>x.BlogCreateDate).ToList();
        }

        public List<Blog> GetAllBlogsByCategoryId(int? id)
        {
            return _context.Blogs.Include(b=>b.Category).Where(x=>x.CategoryId == id).ToList();
        }

        public List<Blog> GetAllBlogsWithCategory()
        {
            return _context.Blogs.Include(b => b.Category).Where(x => x.BlogStatus == true && x.Category.CategoryStatus == true).ToList();
        }

        public Blog GetBlogsWithCategory(int id)
        {
            return _context.Blogs.Include(b => b.Category).Where(x => x.BlogId == id).FirstOrDefault();
        }
        public List<Blog> GetBlogsWithCategory()
        {
            return _context.Blogs.Include(b => b.Category).ToList();
        }
    }
}
