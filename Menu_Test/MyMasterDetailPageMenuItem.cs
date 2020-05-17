using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Menu_Test.Models;

namespace Menu_Test
{
    public class MyMasterDetailPageMenuItem
    {
        public MyMasterDetailPageMenuItem()
        {
            TargetType = typeof(MyMasterDetailPageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
      
     
        public Type TargetType { get; set; }
    }
}
