﻿using Nghia.API.Models.Domain;

namespace Nghia.API.Models.DTO
{
    public class CreateAndUpdateWalkDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }
        public Guid DiffcultyId { get; set; }
        public Guid RegionId { get; set; }


    }
}
