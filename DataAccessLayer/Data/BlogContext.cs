using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    public class BlogContext : DbContext
    {
        //Database bağlantısı
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReply> CommentsReply { get; set; } 
        public DbSet<Contact> Contacts { get; set; }

    }
}
