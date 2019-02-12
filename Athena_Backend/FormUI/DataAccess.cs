using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;

namespace FormUI
{
   
    public class DataAccess
    {
        
        public List<User> GetPeople(string userName, string passWord)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("lit_db")))
            {
                var output = connection.Query<User>($"select * from Users where user_name = '{ userName }' and user_password = '{ passWord }'").ToList();
               
                //var output = connection.Query<Person>("Users_GetByUserName2 @user_name", new { user_name = userName }).ToList();
                /*if(output.Count() == 0)
                {
                    Console.WriteLine("LIST IS EMPTY!");
                }
                used to see the username that was found in the db:
                Console.WriteLine(output.First<Person>().user_name);
                */
                return output;
            }
        }
    }
}
