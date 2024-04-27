using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCargoDetailList()
        {
            var values = await _cargoDetailService.TGetAllAsync();

            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCargoDetailById([FromRoute] int id)
        {
            var values = await _cargoDetailService.TGetByIdAsync(id);

            return Ok(values);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCargoDetail([FromRoute] int id)
        {
            await _cargoDetailService.TDeleteAsync(id);

            return Ok("Kargo detay bilgisi silindi.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoDetail([FromBody] CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailDto.Barcode,
                SenderCustomer = createCargoDetailDto.SenderCustomer,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                CargoCompanyId= createCargoDetailDto.CargoCompanyId
                
            };
            await _cargoDetailService.TInsertAsync(cargoDetail);
            
            return Ok("Kargo detay bilgisi eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCargoDetail([FromBody] UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                SenderCustomer = updateCargoDetailDto.SenderCustomer,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId
            };

            await _cargoDetailService.TUpdateAsync(cargoDetail);

            return Ok("Kargo detay bilgisi güncellendi.");
        }
    }
}
