namespace MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos
{
    public record UpdateCargoOperationDto
    {
        public int CargoOperationId { get; init; }
        public string Barcode { get; init; }
        public string Description { get; init; }
        public DateTime OperationDate { get; init; }
    }
}
