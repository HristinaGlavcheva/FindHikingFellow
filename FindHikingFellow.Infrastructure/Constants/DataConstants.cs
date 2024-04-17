namespace FindHikingFellow.Infrastructure.Constants
{
    public static class DataConstants
    {
        //Tour
        public const int TourNameMinLength = 3;
        public const int TourNameMaxLength = 80;

        public const int TourDescriptionMinLength = 20;
        public const int TourDescriptionMaxLength = 3000;

        public const int TourDurationMinLength = 5;
        public const int TourDurationMaxLength = 100;

        public const int TourMeetingPointMinLength = 5;
        public const int TourMeetingPointMaxLength = 150;

        //Destination
        public const int DestinationNameMinLength = 3;
        public const int DestinationNameMaxLength = 40;

        //Feedback
        public const int ReviewMinLength = 3;
        public const int ReviewMaxLength = 10000;

        //PersonalListNameMaxLength
        public const int PersonalListNameMinLength = 3;
        public const int PersonalListNameMaxLength = 40;

        //KeyPoint
        public const int KeyPointNameMinLength = 3;
        public const int KeyPointNameMaxLength = 40;

        //ImageUrl
        public const int ImageUrlMinLength = 5;
        public const int ImageUrlMaxLength = 250;

        //ApplicationUser
        public const int UserFirstNameMaxLength = 20;
        public const int UserFirstNameMinLength = 1;

        public const int UserLastNameMaxLength = 50;
        public const int UserLastNameMinLength = 3;
    }
}
