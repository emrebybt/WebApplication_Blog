using DataAccessLayer.Abstract;
using DataAccessLayer.Data;
using EntityLayer.Concrete;
using EntityLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCommentReplyRepository : GenericRepository<CommentReply>, ICommentReplyDal
    {
        private readonly BlogContext _blogContext;
        public EfCommentReplyRepository(BlogContext context) : base(context)
        {
            _blogContext = context;
        }

        public List<CommentReply> GetReplyList(int id)
        {
            return _blogContext.CommentsReply.Where(x => x.CommentId == id).ToList();
        }
    }
}
