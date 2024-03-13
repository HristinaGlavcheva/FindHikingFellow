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

        //KeyPoint
        public const int KeyPointNameMinLength = 3;
        public const int KeyPointNameMaxLength = 40;

        //Feature
        public const int FeatureNameMinLength = 3;
        public const int FeatureNameMaxLength = 30;

        //Adventure story
        public const int AdventureStoryTitleMinLength = 3;
        public const int AdventureStoryTitleMaxLength = 100;

        public const int AdventureStoryContentMinLength = 300;
        public const int AdventureStoryContentMaxLength = 20000;

        //Tips & tricks
        public const int TipsAndTricksContentMinLength = 10;
        public const int TipsAndTricksContentMaxLength = 1000;

        //ImageUrl
        public const int ImageUrlMinLength = 5;
        public const int ImageUrlMaxLength = 250;

    }
}
