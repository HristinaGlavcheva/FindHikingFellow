using FindHikingFellow.Core.Models.Feedback;
using FindHikingFellow.Core.Models.Tour;

namespace FindHikingFellow.Core.Contracts
{
    public interface IFeedbackService
    {
        Task<int> CreateFeedbackAsync(FeedbackFormModel input, int tourId, string userId);
    }
}
