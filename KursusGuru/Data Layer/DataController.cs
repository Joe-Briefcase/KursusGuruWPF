using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursusGuru.Data_Layer
{
    static class DataController
    {
        /* 
         * Liste med brugere.
         * I et dictionary indekseres brugeren vha. studienummer (user id).
         */
        private static Dictionary<int, User> userList = new Dictionary<int, User>();

        /*
         * Henter bruger ud fra deres studienummer.
         */
        public static User LoadUserData(int id)
        {
            User user = userList.ElementAt(id);
            return user;
        }

        /*
         * Gemmer en bruger.
         */
        public static void SaveUserData(User user)
        {
            userList.Add(user);
        }
    }
}
