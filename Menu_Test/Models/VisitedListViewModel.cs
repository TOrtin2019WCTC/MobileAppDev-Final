using System;
using System.Collections.Generic;

namespace Menu_Test.Models
{
    public class VisitedListViewModel
    {
        
       static List<PlaceVisited> Visited { get; set; }

       static VisitedListViewModel()
        {
            Visited = User.Visited;
        }
    }
}
