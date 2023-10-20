using DataAccessLayer.Data;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCategoryRepository : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryRepository(BlogContext context) : base(context)
        {
        }
    }
}
