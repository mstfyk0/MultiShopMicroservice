using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {

        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompanyController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoCompanyList()
        {
            var values = await _cargoCompanyService.TGetAllAsync();
            return Ok(values);  
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany([FromBody] CreateCompanyDto createCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyName=createCompanyDto.CargoCompanyName,
            };
            await _cargoCompanyService.TInsertAsync(cargoCompany);
            return Ok("Kargo şirketi oluşturuldu.");
        }
        
        [HttpPut]
        public async Task<IActionResult> UpdateCargoCompany([FromBody] UpdateCargoCompanyDto updateCargoCompanyDto )
        {
            CargoCompany cargoCompany = new CargoCompany()
            {
                CargoCompanyId = updateCargoCompanyDto.CargoCompanyId,
                CargoCompanyName = updateCargoCompanyDto.CargoCompanyName

            };

            await _cargoCompanyService.TUpdateAsync(cargoCompany);
            return Ok("Kargo şirketi güncellendi.");
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCargoCompany([FromRoute] int id)
        {
            await _cargoCompanyService.TDeleteAsync(id);
            return Ok("Kargo şirketi silindi.");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoCompanyById([FromRoute] int id)
        {
            var values = await  _cargoCompanyService.TGetByIdAsync(id);
            return Ok("Kargo şirketi silindi.");
        }
    }
}
