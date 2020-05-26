using System;
namespace Menu_Test.Models
{
    public class DestinationViewModel
    {
        public PlaceVisited placeVisited { get; set; }

        public DestinationViewModel()
        {
        }

        public void SetDestination(string destination)
        {
            placeVisited = new PlaceVisited(destination);
            
            User.Destination = destination;
            User.Visited.Add(placeVisited);
            App.Database.SaveItemAsync(placeVisited);
        }
    }
}
