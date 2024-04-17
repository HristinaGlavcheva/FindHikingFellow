using Microsoft.EntityFrameworkCore;
using FindHikingFellow.Core.Contracts;
using FindHikingFellow.Core.Models.Feedback;
using FindHikingFellow.Infrastructure.Data.Common;
using FindHikingFellow.Infrastructure.Data.Models;

namespace FindHikingFellow.Core.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository feedbackRepository;
        private readonly IRepository tourRepository;

        public FeedbackService(IRepository _feedbackRepository, IRepository _tourRepository)
        {
            feedbackRepository = _feedbackRepository;
            tourRepository = _tourRepository;
        }

        public async Task<int> CreateFeedbackAsync(FeedbackFormModel input, int id, string userId)
        {
            var tour = await tourRepository
                .AllAsNoTracking<Tour>()
                 .FirstAsync(t => t.Id == id);

            var newFeedback = new FeedBack
            {
                TourId = id,
                AuthorId = userId,
                Review = input.Review,
                Rate = input.Rate,
                CreatedOn = input.CompletedOn,
                ActivityType = input.ActivityType
            };

            if (tour != null && !tour.IsDeleted)
            {
                tour.FeedBacks.Add(newFeedback);
            }

            await feedbackRepository.AddAsync(newFeedback);
            await feedbackRepository.SaveChangesAsync();
            await tourRepository.SaveChangesAsync();

            return newFeedback.Id;
        }
    }
}
