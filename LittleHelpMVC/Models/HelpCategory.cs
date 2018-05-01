using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleHelpMVC.Models
{
    public class HelpCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public List<LittleHelp> Helpers { get; set; }
    }

    //public enum HelpCategory
    //{
    //    Electrical,
    //    Handyman,
    //    HeatingAndAC,
    //    HouseCleaning,
    //    Landscaping, 
    //    Lawnmower,
    //    Plumbing,
    //    Snowplower,
    //    TreeService
    //}
}
