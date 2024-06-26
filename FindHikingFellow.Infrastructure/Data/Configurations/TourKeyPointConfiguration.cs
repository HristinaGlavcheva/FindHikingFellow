﻿using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class TourKeyPointConfiguration : IEntityTypeConfiguration<TourKeyPoint>
    {
        public void Configure(EntityTypeBuilder<TourKeyPoint> builder)
        {
            builder.HasKey(tkp => new {tkp.TourId, tkp.KeyPointId});
            builder.HasData(SeedTourKeyPoints());
        }

        private TourKeyPoint[] SeedTourKeyPoints()
        {
            ICollection<TourKeyPoint> tourKeyPoints = new HashSet<TourKeyPoint>
                {
                    new TourKeyPoint
                    {
                        TourId = 2,
                        KeyPointId= 1,
                    },
                     new TourKeyPoint
                    {
                        TourId = 2,
                        KeyPointId= 10,
                    }
                };

            return tourKeyPoints.ToArray();
        }
    }
}
