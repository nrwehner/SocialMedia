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
    public class LikeService
    {
        public bool CreateLike(LikeCreate model)
        {
            var entity = new Like()
            {
                Liker = model.Liker
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LikeListItem> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Likes
                    //.Where(e=>e.Author==_userId)
                    .Select(
                        e =>
                            new LikeListItem
                            {
                                Liker = e.Liker
                            }
                        );
                return query.ToArray();
            }
        }
    }
}
