using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MulitShop.Order.Application.Features.Meditor.Queries.OrderingQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        [HttpGet] 
        public async Task<IActionResult> GetAllOrderingList()
        {
            //Handle tipindeki sınıflara ulaşmak için send kullanılıyor.
            //send içinde Irequesti miras alan sınıfları çağırıcaz
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllOrderingById([FromRoute] int id)
        {
            //Handle tipindeki sınıflara ulaşmak için send kullanılıyor.
            //send içinde Irequesti miras alan sınıfları çağırıcaz
            var values = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(values);
        }
    }
}
