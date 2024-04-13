using FindHikingFellow.Core.Contracts;
using System.Text.RegularExpressions;

namespace FindHikingFellow.Core.Extensions
{
    public static class ModelExtensions
    {
        public static string GetInformation(this ITourModel tour) 
        {
            string info = tour.Name.Replace(" ", "-") + "-" + GetDescription(tour.Description);

            info = Regex.Replace(info, @"[^a-zA-Z0-9]\-", string.Empty);

            return info;
        }

        private static string GetDescription(string description)
        {
            description = string.Join("-", description.Split(" ").Take(3));

            return description;
        }
    }
}
