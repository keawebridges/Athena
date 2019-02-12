using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI
{
    public class User
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string user_role { get; set; }


        public string FullInfo
        {
            get
            {
                // Format this will generate: 1 dave (davepw)
               return $"{ id } { user_name } ({ user_password }) { user_role } ";
               
            }

        }




    }
}
