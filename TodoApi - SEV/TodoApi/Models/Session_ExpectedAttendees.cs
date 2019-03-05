using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace TodoApi.Models
{
    public class Session_ExpectedAttendees
    {
        public string SEA_id { get; set; }
        /*
         public int SEA_id { get; set; }
        public int SEA_User_id { get; set; }
        public string SEA_First_Name { get; set; }
        public string SEA_Last_Name { get; set; }
        public string SEA_Role { get; set; }
        public int TE_id { get; set; }
        public string TE_Name { get; set; }
        public int ES_id { get; set; }
        public string ES_Name { get; set; }
        */

        public override string ToString()
        {
            return "Id: " + SEA_id + " ";
            /*    +
            "User Id: " + SEA_User_id + " " +
            "User First Name: " + SEA_First_Name + " " +
            "User Last Name: " + SEA_Last_Name + " " +
            "User Role: " + SEA_Role + " " +
            "Event Id: " + TE_id + " " +
            "Event Name: " + TE_Name + " " +
            "Session Id: " + ES_id + " " +
            "Session Name: " + ES_Name + " ";
            */
        }

    }
}