//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using LittleHelpMVC.ViewModels;

//namespace LittleHelpMVC.Models
//{
//    public class UserData
//    {
//        static List<User> Users = new List<User>();

//        public static List<User> GetAll()
//        {
//            return Users;
//        }

//        public static void Add(User user)
//        {
//            Users.Add(user);
//        }

//        public static User GetById(int id)
//        {
//            var thisUser = Users.Find(c => c.UserId == id);
//            return thisUser;
//        }

//        public static User FindUser(SignInViewModel signInViewModel)
//        {
//            var thisUser = Users.Find(c => c.Username == signInViewModel.Username);
//            return thisUser;
//        }

//        public static bool ExistingUser(User user)
//        {
//            return Users.Contains(user);
//        }

//    }
//}
