using KursusGuru.Data_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursusGuru.Logic_Layer
{
    static class LogicController
    {
        private static User currentUser;

        public static object GetBookData(User user)
        {
            throw new NotImplementedException();
        }

        public static object GetCalenderData(User user)
        {
            throw new NotImplementedException();
        }

        public static object GetCourseData(User user)
        {
            throw new NotImplementedException();
        }

        public static User GetUserData(int id)
        {
            throw new NotImplementedException();
        }

        public static void SaveUser(User user)
        {
            throw new NotImplementedException();
        }

        // Hjælpe metode til hurtigt at hente data fra den bruger der allerede er logget ind
        public static User CurrentUser()
        {
            return currentUser;
        }

        public static void SetCurrentUser(User user)
        {
            currentUser = user;
        }
    }
}
