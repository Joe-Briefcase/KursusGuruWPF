using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursusGuru.Data_Layer
{
    interface IDataController
    {
        /*
         * Save and load user to/from 'database'.
         */
        void SaveUserData(User user);
        User LoadUserData(int id);
    }
}
