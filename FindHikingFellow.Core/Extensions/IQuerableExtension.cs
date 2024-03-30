using FindHikingFellow.Core.Models.Tour;
using FindHikingFellow.Infrastructure.Data.Models;

namespace System.Linq
{
    public static class IQuerableTourExtension
    {
        public static IQueryable<TourServiceModel> ProjectToTourServiceModel(this IQueryable<Tour> tours)
        {
            return tours.Select(t => new TourServiceModel
            {
                Id = t.Id,
                Name = t.Name,
                ImageUrl = t.ImageUrl,
                Destination = t.Destination.Name,
                MeetingTime = t.MeetingTime.Date,
                Upcoming = t.MeetingTime > DateTime.Now
            });
        }
    }
}
