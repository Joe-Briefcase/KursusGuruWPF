using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KursusGuru.Data_Layer;

namespace KursusGuru.Logic_Layer
{
    interface ILogicController
    {
        /*
       * Access data.
       */
        Object GetCalenderData(User user);
        Object GetCourseData(User user);
        User GetUserData(int id);
        Object GetBookData(User user);

        /*
         * Save data.
         */
        void SaveUser(User user);
    }
}
