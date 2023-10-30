using BuisnessLayer.Abstract;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;


        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Add(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Delete(Blog t)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAllBlogsByCategoryId(int? id)
        {
            return _blogDal.GetAllBlogsByCategoryId(id);
        }

        public List<Blog> GetAllBlogsWithCategory()
        {
            return _blogDal.GetAllBlogsWithCategory();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }
        public List<Blog> GetListWithSearch(string search)
        {
            return _blogDal.GetListAll().Where(b => b.BlogContent.ToLower().Contains(search)).ToList();
        }

        public Blog GetBlogsWithCategory(int id)
        {
            return _blogDal.GetBlogsWithCategory(id);
        }
        public List<Blog> GetBlogsWithCategory()
        {
            return _blogDal.GetBlogsWithCategory();
        }

        public int GetBlogCountByCategory(int categoryId)
        {
            var list = _blogDal.GetAllBlogsByCategoryId(categoryId);
            return list.Count();
        }
    }
}
