﻿ using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CommentReply
    {
        [Key]
        public int ReplyCommentId { get; set; }
        public string CommentUserName { get; set; }
        public string CommentEmail { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        public int BlogId { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
