using Data;
using Models;
using SocialMedia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CommentService
    {
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Text = model.Text,
                    Author = model.Author,
                    CommentPost = model.CommentPost
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentListItem> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            Text = e.Text,
                            Author = e.Author,
                            CommentPost = e.CommentPost
                        }
                   );
                return query.ToArray();
            }
        }
    }
}

