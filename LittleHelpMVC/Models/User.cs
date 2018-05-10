using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LittleHelpMVC.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Screenname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ID { get; set; }
    }
}
