using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.Abstract
{
    public interface ICommentReplyService : IGenericService<CommentReply>
    {
        List<CommentReply> GetReplyList(int id);
    }
}
