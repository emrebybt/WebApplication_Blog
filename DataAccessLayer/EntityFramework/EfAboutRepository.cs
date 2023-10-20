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
    public class EfAboutRepository : GenericRepository<About>, IAboutDal
    {
        public EfAboutRepository(BlogContext context) : base(context)
        {
        }
    }
}
