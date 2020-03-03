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
    public class PostService
    {
        private readonly Guid _userId;
        public PostService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    Title = model.Title,
                    Text = model.Text,
                    UserId = model.UserId,
                    CreatedUtc = DateTimeOffset.Now
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    //.Where(e=>e.Author==_userId)
                    .Select(
                        e =>
                            new PostListItem
                            {
                                //Id = e.Id,
                                Title = e.Title,
                                Text=e.Text,
                                UserId=e.UserId,
                                CreatedUtc=e.CreatedUtc
                            }
                        );
                return query.ToArray();
            }
        }

        //public PostDetail GetPostByComment(Guid userId)//       pretty sure this doesn't work
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Posts
        //                .Single(e => e.UserId == userId);
        //        return
        //            new PostDetail
        //            {
        //                Id = entity.Id,
        //                Title = entity.Title,
        //                Text = entity.Text,
        //                UserId = entity.UserId,
        //                CreatedUtc = entity.CreatedUtc
        //            };
        //    }
        //}
    }
}
