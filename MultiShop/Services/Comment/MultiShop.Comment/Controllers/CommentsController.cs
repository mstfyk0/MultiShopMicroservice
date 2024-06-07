using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _context;

        public CommentsController(CommentContext context)
        {
            _context = context;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var values = _context.UserCommnets.ToList();
            return Ok(values);
        }

        [HttpGet("GetCommentById/{id}")]
        public IActionResult GetCommentById(int id)
        {
            var values = _context.UserCommnets.Find(id);
            return Ok(values);
        }


        [HttpPost("Create")]
        public IActionResult Create([FromBody] UserComment userComment)
        {
            _context.UserCommnets.Add(userComment); 
            _context.SaveChanges();
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] UserComment userComment)
        {
            _context.UserCommnets.Update(userComment);
            _context.SaveChanges();
            return Ok("Yorum başarıyla güncellendi");
        }


        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var value = _context.UserCommnets.Find(id);
            _context.UserCommnets.Remove(value);
            _context.SaveChanges();
            return Ok("Yorum başarıyla silindi");
        }

    }
}
