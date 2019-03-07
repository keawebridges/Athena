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
    public class Employee
    {
       public int E_id { get; set; }
       public string E_First_Name { get; set; }
       public string E_Last_Name { get; set; }
       public string E_User_Name { get; set; }
       public string E_Pass_Word { get; set; }

    }
}

