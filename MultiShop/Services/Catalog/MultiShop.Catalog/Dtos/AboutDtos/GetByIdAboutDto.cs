﻿namespace MultiShop.Catalog.Dtos.AboutDtos
{
    public record GetByIdAboutDto
    {
        public string AboutId { get; init; }
        public string AboutDescription { get; init; }
        public string AboutAddress { get; init; }
        public string AboutEmail { get; init; }
        public string AboutPhone { get; init; }
    }
}
