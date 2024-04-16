namespace FindHikingFellow.Core.Models.Admin
{
    public class JoinedServiceModel
    {
        public string TourName { get; set; } = string.Empty;

        public string TourImageUrl { get; set; } = string.Empty;

        public string OrganiserFullName { get; set; } = string.Empty;

        public string OrganiserEmail { get; set; } = string.Empty;

        public IEnumerable<ParticipantServiceModel> Participants { get; set; } = new HashSet<ParticipantServiceModel>();
    }
}
