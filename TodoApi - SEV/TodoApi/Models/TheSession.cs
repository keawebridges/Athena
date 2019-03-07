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
    public class TheSession
    {
        public int TS_id { get; set; }
        public string TS_Name { get; set; }
        public DateTime TS_Start_Date { get; set; }
        public DateTime TS_End_Date { get; set; }
        public TimeSpan TS_Time { get; set; }
        public string TS_Location { get; set; }

        public List<Rsvp> TS_RsvpsList { get; set; }
        public int TE_id { get; set; }


        public override string ToString()
        {
            return "Id: " + TS_id + " " +
            "Name: " + TS_Name + " " +
             "Start Date: " + TS_Start_Date.ToString() + " " +
              "End Date: " + TS_End_Date.ToString() + " " +
               "Time: " + TS_Time.ToString() + " " +
                "Location: " + TS_Location + " " +
                "TE_id: " + TE_id + " ";
        }

    }
}
