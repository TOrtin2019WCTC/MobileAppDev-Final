using System;
namespace Menu_Test.Models
{
    public class DestinationViewModel
    {
        public string City { get; set; }

        public DestinationViewModel()
        {
        }

        public void SetDestination(string destination)
        {
            City = destination;
            User.Destination = City;
            User.Visited.Add(new PlaceVisited(City));
        }
    }
}
