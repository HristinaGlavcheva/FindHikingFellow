namespace FindHikingFellow.Core.Models.Feedback
{
    public class AllFeedbackViewModel
    {
        public int ReviewsCount { get; set; }

        public double AverageRate { get; set; }

        public IEnumerable<FeedbackFormModel> Reviews { get; set; } = new HashSet<FeedbackFormModel>();
    }
}
