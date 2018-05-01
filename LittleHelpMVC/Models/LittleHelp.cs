using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleHelpMVC.Models
{
    public class LittleHelp
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public HelpCategory Category { get; set; }

    }
}
