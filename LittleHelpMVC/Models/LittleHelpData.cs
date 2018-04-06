using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleHelpMVC.Models
{
    public class LittleHelpData
    {
        private static List<LittleHelp> helpers = new List<LittleHelp>();

        //GetAll
        public static List<LittleHelp> GetAll()
        {
            return helpers;
        }

        //Add
        public static void Add(LittleHelp helper)
        {
            helpers.Add(helper);
        }
        
        //Remove
        public static void Remove(int id)
        {
            LittleHelp helpToRemove = GetById(id);
            helpers.Remove(helpToRemove);
        }

        //GetById
        public static LittleHelp GetById(int id)
        {
            return helpers.Find(x => x.HelpId == id);
        }
    }
}
