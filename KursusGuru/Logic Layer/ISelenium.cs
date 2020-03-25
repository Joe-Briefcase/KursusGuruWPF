using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursusGuru.Logic_Layer
{
    interface ISelenium
    {
        /*
         * Selenium logic.
         */
        void SeleniumLoginInside(String username, String password);
        void SeleniumLoginLearn(String username, String password);
        void SeleniumLoginDiplomPortal(String username, String password);
    }
}
