using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoCustomerList()
        {
            var values = await _cargoCustomerService.TGetAllAsync();

            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCustomerById([FromRoute]int id )
        {
            var values = await _cargoCustomerService.TGetByIdAsync(id);

            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoCustomer ([FromRoute] int id)
        {
            await _cargoCustomerService.TDeleteAsync(id);

            return Ok("Kargo müşteri bilgisi silindi.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCustomer([FromBody] CreateCargoCustomerDto createCargoCustomerDto )
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Address = createCargoCustomerDto.Address,
                City = createCargoCustomerDto.City,
                District= createCargoCustomerDto.District,
                Email = createCargoCustomerDto.Email,
                Name = createCargoCustomerDto.Name,
                Phone = createCargoCustomerDto.Phone,
                SurName= createCargoCustomerDto.SurName
            };

            await _cargoCustomerService.TInsertAsync(cargoCustomer);

            return Ok("Kargo müşteri bilgisi eklendi.");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCustomer([FromBody] UpdateCargoCustomerDto updateCargoCustomerDto )
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Address = updateCargoCustomerDto.Address,
                City = updateCargoCustomerDto.City,
                District= updateCargoCustomerDto.District,
                Email = updateCargoCustomerDto.Email,
                Name = updateCargoCustomerDto.Name,
                Phone = updateCargoCustomerDto.Phone,
                SurName= updateCargoCustomerDto.SurName
            };

            await _cargoCustomerService.TUpdateAsync(cargoCustomer);

            return Ok("Kargo müşteri bilgisi güncellendi.");
        }
    }
}
