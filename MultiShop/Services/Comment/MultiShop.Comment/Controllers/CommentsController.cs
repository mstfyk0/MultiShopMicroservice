using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCommentList()
        {
            var values = _context.UserCommnets.ToList();
            return Ok(values);
        }

        [HttpGet("GetOneCommentById/{id}")]
        public IActionResult GetOneCommentById(int id)
        {
            var values = _context.UserCommnets.Find(id);
            return Ok(values);
        }


        [HttpPost]
        public IActionResult CreateCommand([FromBody]UserComment userComment)
        {
            _context.UserCommnets.Add(userComment); 
            _context.SaveChanges();
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpPut]
        public IActionResult UpdateCommand([FromBody] UserComment userComment)
        {
            _context.UserCommnets.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla güncellendi");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteCommand(int id)
        {
            var value = _context.UserCommnets.Find(id);
            _context.UserCommnets.Remove(value);
            _context.SaveChanges();
            return Ok("Yorum başarıyla silindi");
        }

    }
}
