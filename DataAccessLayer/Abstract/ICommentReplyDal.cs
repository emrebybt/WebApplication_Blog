using EntityLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICommentReplyDal : IGenericDal<CommentReply>
    {
        List<CommentReply> GetReplyList(int id);
    }
}
