using BuisnessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Concrete
{
    public class CommentReplyManager : ICommentReplyService
    {
        private readonly ICommentReplyDal _commentReplyDal;

        public CommentReplyManager(ICommentReplyDal commentReplyDal)
        {
            _commentReplyDal = commentReplyDal;
        }

        public void Add(CommentReply t)
        {
            _commentReplyDal.Insert(t);
        }

        public void Delete(CommentReply t)
        {
            _commentReplyDal.Delete(t);
        }

        public CommentReply GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CommentReply> GetList()
        {
            return _commentReplyDal.GetListAll();
        }

        public List<CommentReply> GetReplyList(int id)
        {
            return _commentReplyDal.GetReplyList(id);
        }

        public void Update(CommentReply t)
        {
            throw new NotImplementedException();
        }
    }
}
