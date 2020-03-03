using Microsoft.AspNet.Identity;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMediaAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        //GET ALL
        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComment();
            return Ok(comments);
        }
        //POST METHOD
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userId);
            return commentService;
        }


        //UPDATE METHOD- WOULD REQUIRE CHANGES TO THE COMMENTSERVICE CLASS
        //public IHttpActionResult Put(CommentEdit comment)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);
        //    var service = CreateCommentService();

        //    if (!service.UpdateComment(comment))
        //        return InternalServerError();
        //    return Ok();
        //}
    }
}
