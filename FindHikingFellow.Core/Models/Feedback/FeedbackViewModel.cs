namespace FindHikingFellow.Core.Models.Feedback
{
    public class FeedbackViewModel
    {
        public string Author { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }

        public double Rating { get; set; }

        public string Review { get; set; } = string.Empty;
    }
}
