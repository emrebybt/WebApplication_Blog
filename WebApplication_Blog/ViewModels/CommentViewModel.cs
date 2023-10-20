﻿namespace WebApplication_Blog.ViewModels
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public string CommentUserName { get; set; }
        public string CommentEmail { get; set; }
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        public int BlogId { get; set; }
    }
}
