using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleHelpMVC.Models
{
    public class LittleHelp
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public int HelpId { get; set; }
        public string Comment { get; set; }
        public static int nextId = 1;

        public LittleHelp()
        {
            HelpId = nextId;
            nextId++;
        }
    }
}
