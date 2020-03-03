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
    public class ReplyService
    {

        private readonly Guid _userId;
        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Text = model.Text,
                    Author = model.Author,
                    CommentPost = model.CommentPost,
                    ReplyComment = model.ReplyComment
                };
            using (var ctx =new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    //.Where(e=>e.Author==_userId)
                    .Select(
                        e =>
                            new ReplyListItem
                            {
                                Text = e.Text,
                                Name = e.Name,
                                Author = e.Author,
                                ReplyComment = e.ReplyComment
                            }
                        );
                return query.ToArray();
            }
        }

    }
}
