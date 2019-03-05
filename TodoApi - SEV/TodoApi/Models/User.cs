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
    public class User
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public string user_role { get; set; }
        

        public override string ToString()
        {
            /*
            return "Id: " + TE_id + " " +
            "Name: " + TE_Name + " " +
             "Start Date: " + TE_Start_Date.ToString() + " " +
              "End Date: " + TE_End_Date.ToString() + " " +
               "Time: " + TE_Time.ToString() + " " +
                "Location: " + TE_Location + " ";
                */

            return "";
        }

    }
}

