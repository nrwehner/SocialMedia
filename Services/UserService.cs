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
    public class UserService
    {
        private readonly Guid _userId;
        public UserService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateUser(UserCreate model)
        {
            var entity =
                new User()
                {
                    //Id = model.Id,
                    Name = model.Name,
                    Email = model.Email
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Users.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<UserListItem> GetUser()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Users
                    .Select(
                        e =>
                        new UserListItem
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Email = e.Email
                        }
                   );
                return query.ToArray();
            }
        }
    }
}
