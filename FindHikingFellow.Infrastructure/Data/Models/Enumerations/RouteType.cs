using System.ComponentModel.DataAnnotations;

namespace FindHikingFellow.Infrastructure.Data.Models.Enumerations
{
    public enum RouteType
    {
        Loop = 1,
        [Display(Name = "Out and Back")]
        OutAndBack = 2,
        [Display(Name = "Point to Point")]
        PointToPoint = 3
    }
}
