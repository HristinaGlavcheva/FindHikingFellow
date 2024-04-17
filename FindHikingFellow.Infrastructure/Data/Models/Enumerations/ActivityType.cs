using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Infrastructure.Data.Models.Enumerations
{
    public enum ActivityType
    {
        Hiking = 1,
        [Display(Name = "Mountain Biking")]
        MountainBiking = 2,
        Running = 3,
        Backpacking = 4,
        Walking = 5,
        [Display(Name = "Road Biking")]
        RoadBiking = 6,
        [Display(Name = "Rock Climbing")]
        RockClimbing = 7,
        [Display(Name = "Via Ferrata")]
        ViaFerrata = 8,
        [Display(Name = "Snow Shoeing")]
        SnowShoeing = 9,
        Skiing = 10
    }
}
