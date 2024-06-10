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
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentsController(CommentContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
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

        [HttpGet("GetCommentListByProductId/{id}")]
        public async Task<IActionResult> GetCommentListByProductId(string id)
        {
            var value = _context.UserCommnets.Where(x=>x.ProductId==id).ToList();

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7047/api/products/GetProductById/"+id);


            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadAsStringAsync();
            }
            return Ok(value);   
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
            if (value is not null)
            {
                _context.UserCommnets.Remove(value);
                _context.SaveChanges();
                return Ok("Yorum başarıyla silindi");
            }
            return Ok(null);
        }

    }
}
