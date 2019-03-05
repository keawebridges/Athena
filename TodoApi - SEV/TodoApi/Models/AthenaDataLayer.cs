//Made by Keawe Bridges


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;



namespace TodoApi.Models
{
    public class AthenaDataLayer
    {
        string DBpath = "Server=localhost; Database=lit_db; UID=keawebridges; Password=keawebridges";

        //check if File exists
        public bool fileExists(string path)
        {
            return File.Exists(path);
        }









        //get all Events
        public List<TheEvent> getEvents()
        {
            List<TheEvent> event_List = new List<TheEvent>();

            string sql = "SELECT * FROM THEEVENTS";

            using (MySqlConnection connection = new MySqlConnection(DBpath))
            {
                event_List = connection.Query<TheEvent>(sql).ToList();
            }

            return event_List;
        }











        //read File
        public List<StuItem> fileRead()
        {
            List<StuItem> student_List = new List<StuItem>();

            string sql = "SELECT * FROM STUDENT";

            using (MySqlConnection connection = new MySqlConnection(DBpath))
            {
               student_List = connection.Query<StuItem>(sql).ToList();
            }

            return student_List;
        }








        /*
        //write File
        public void fileWrite(StuItem student)
        {
            string sql = "INSERT INTO STUDENT (STU_ID, STU_NAME, STU_GPA) Values (@STU_ID, @STU_NAME, @STU_GPA);";

            using (var connection = new MySqlConnection(DBpath))
            {
                    var affectedRows = connection.Execute(sql, new { STU_ID = student.stu_id,
                        STU_NAME = student.stu_name,
                        STU_GPA = student.stu_gpa});
            }
        }
        */

        //write File
        public void RSVP_Function(Session_ExpectedAttendees s)
        {
            System.Diagnostics.Debug.WriteLine(s.ToString());

            string sql = "INSERT INTO Session_ExpectedAttendees (SEA_User_id, SEA_First_Name, SEA_Last_Name, " +
                "SEA_Role, TE_id, TE_Name, ES_id, ES_Name) " +
                "Values (@SEA_User_id, @SEA_First_Name, @SEA_Last_Name, " +
                "@SEA_Role, @TE_id, @TE_Name, @ES_id, @ES_Name);";

            using (var connection = new MySqlConnection(DBpath))
            {
                var affectedRows = connection.Execute(sql, new
                {
                    /*
                    SEA_User_id = s.SEA_User_id,
                    SEA_First_Name = s.SEA_First_Name,
                    SEA_Last_Name = s.SEA_Last_Name,
                    SEA_Role = s.SEA_Role,
                    TE_id = s.TE_id,
                    TE_Name = s.TE_Name,
                    ES_id = s.ES_id,
                    ES_Name = s.ES_Name
                    */

                    /*
                    s.SEA_User_id, s.SEA_First_Name, s.SEA_Last_Name, s.SEA_Role,
                    s.TE_id, s.TE_Name, s.ES_id, s.ES_Name
                    */

                });
            }
        }
        public List<Session_ExpectedAttendees> find_SessionsRSVPDfor_byId(string id)
        {
            List<Session_ExpectedAttendees> SEA_List = new List<Session_ExpectedAttendees>();

            string sql = "SELECT * FROM Session_ExpectedAttendees WHERE SEA_User_id = @ID;";

            using (MySqlConnection connection = new MySqlConnection(DBpath))
            {
                SEA_List = connection.Query<Session_ExpectedAttendees>(sql, new { ID = id }).ToList();
            }

            return SEA_List;
        }









        public StuItem findId(string id)
        {
            string sql = "SELECT * FROM STUDENT WHERE STU_ID = @ID;";

            using (var connection = new MySqlConnection(DBpath))
            {
                StuItem student = connection.QuerySingle<StuItem>(sql, new { ID = id });
                return student;
            }
            
        }

        public bool  deleteId(string id)
        {
            string sql = "DELETE FROM STUDENT WHERE STU_ID = @ID;";

            using (var connection = new MySqlConnection(DBpath))
            {
                var affectedRows = connection.Execute(sql, new { ID = id });

                if (affectedRows > 0)
                    return true;
                else
                    return false;
            }
        }

        public StuItem maxGPA()
        {
            string sql = "SELECT * FROM STUDENT WHERE STU_GPA = (SELECT MAX(STU_GPA) FROM STUDENT) ; ";

            using (MySqlConnection connection = new MySqlConnection(DBpath))
            {
                StuItem maxStudent = connection.QuerySingle<StuItem>(sql);
                return maxStudent;
            }
        }

        public string minGPA()
        {
            string sql = "SELECT MIN(STU_GPA) FROM STUDENT;";

            using (MySqlConnection connection = new MySqlConnection(DBpath))
            {
                string minString = connection.Query<string>(sql).ToString();
                return minString;
            }
        }
        
    }
}
