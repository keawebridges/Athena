//Made by Keawe Bridges

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
    public class StuItem
    {
        public string stu_id { get; set; }
        public string stu_name { get; set; }
        public float stu_gpa { get; set; } 

        public override string ToString()
        {
            return "Id: " + stu_id + " " + "Name: " + stu_name + " " + "GPA: " + stu_gpa + " ";
        }
    }

}

