using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoOperationList()
        {
            var values = await _cargoOperationService.TGetAllAsync();

            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoOperationById([FromRoute] int id)
        {
            var values = await _cargoOperationService.TGetByIdAsync(id);

            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoOperation([FromRoute] int id)
        {
            await _cargoOperationService.TDeleteAsync(id);

            return Ok("Kargo operasyon bilgisi silindi.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoOperation([FromBody] CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode=createCargoOperationDto.Barcode,
                Description=createCargoOperationDto.Description,
                OperationDate=createCargoOperationDto.OperationDate
            };

            await _cargoOperationService.TInsertAsync(cargoOperation);

            return Ok("Kargo operasyon bilgisi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoOperation([FromBody] UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate
            };

            await _cargoOperationService.TUpdateAsync(cargoOperation);

            return Ok("Kargo operasyon bilgisi eklendi.");
        }
    }
}
