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
    public class TheEvent
    {
        public int TE_id { get; set; }
        public string TE_Name { get; set; }
        public DateTime TE_Start_Date { get; set; }
        public DateTime TE_End_Date { get; set; }
        public TimeSpan TE_Time { get; set; }
        public string TE_Location { get; set; }
        public List<TheSession> TE_SessionsList { get; set; }

        public override string ToString()
            {
                return "Id: " + TE_id + " " +
                "Name: " + TE_Name + " " +
                 "Start Date: " + TE_Start_Date.ToString() + " " +
                  "End Date: " + TE_End_Date.ToString() + " " +
                   "Time: " + TE_Time.ToString() + " " +
                    "Location: " + TE_Location + " ";
            }
        
    }
}
