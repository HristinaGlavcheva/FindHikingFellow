using FindHikingFellow.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FindHikingFellow.Infrastructure.Data.Configurations
{
    internal class DestinationConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasData(SeedDestinations());
        }

        private Destination[] SeedDestinations()
        {
            ICollection<Destination> destinations = new HashSet<Destination>();

            Destination destination = null!;

            destination = new Destination
            {
                Id = 1,
                Name = "Pirin",
                ImageUrl = "https://webnews.bg/uploads/images/84/8784/228784/768x432.jpg?_=1460885734"
            };
            destinations.Add(destination);

            destination = new Destination
            {
                Id = 2,
                Name = "Rila",
                ImageUrl = "https://novavarna.net/wp-content/uploads/2020/06/rila_maliovica-1280x720.jpg"
            };
            destinations.Add(destination);

            destination = new Destination
            {
                Id = 3,
                Name = "Balkan Mauntains",
                ImageUrl = "https://trud.bg/public/images/articles/2020-11/mountain-landscape-beautiful-hd-wallpaper-1024x640_1509577115668281610_original.jpg"
            };
            destinations.Add(destination);

            destination = new Destination
            {
                Id = 4,
                Name = "Rodopi",
                ImageUrl = "https://bulgariawalking.com/wp-content/uploads/2016/10/rhodopes-and-rila-2.jpg"
            };
            destinations.Add(destination);

            destination = new Destination 
            { 
                Id = 5,
                Name = "Vithosha",
                ImageUrl = "https://media-cdn.tripadvisor.com/media/photo-s/1a/d2/6c/b8/caption.jpg"
            };
            destinations.Add(destination);

            return destinations.ToArray();
        } 
    }
}
