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








        /*
        //get all Events (OLD)
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
        */

        //get all Events and their Sessions (NEW)
        public List<TheEvent> getEvents()
        {
            List<TheEvent> event_List = new List<TheEvent>();

            //string sql = "SELECT * FROM THEEVENTS AS A LEFT JOIN THESESSIONS AS B ON A.TE_ID = B.TE_ID LEFT JOIN RSVPS AS C ON B.TS_ID = C.TS_ID;";
           string sql = "SELECT * FROM THEEVENTS AS A LEFT JOIN THESESSIONS AS B ON A.TE_ID = B.TE_ID " +
                "LEFT JOIN RSVPS AS C ON B.TS_ID = C.TS_ID ORDER BY A.TE_Start_Date;";

            using (MySqlConnection connection = new MySqlConnection(DBpath))
            {
                var eventDictionary = new Dictionary<int, TheEvent>();
                var sessionDictionary = new Dictionary<int, TheSession>();


                event_List = connection.Query<TheEvent, TheSession, Rsvp, TheEvent>(
                    sql,
                    (cur_event, cur_session, cur_rsvp) =>
                    {
                        TheEvent eventEntry;

                        if (!eventDictionary.TryGetValue(cur_event.TE_id, out eventEntry))
                        {
                            eventEntry = cur_event;
                            eventEntry.TE_SessionsList = new List<TheSession>();
                            eventDictionary.Add(eventEntry.TE_id, eventEntry);
                        }

                        if (cur_session != null) {

                            TheSession sessionEntry;

                            if (!sessionDictionary.TryGetValue(cur_session.TS_id, out sessionEntry))
                            {
                                sessionEntry = cur_session;
                                sessionEntry.TS_RsvpsList = new List<Rsvp>();
                                sessionDictionary.Add(sessionEntry.TS_id, sessionEntry);
                                eventEntry.TE_SessionsList.Add(sessionEntry);
                            }

                            if (cur_rsvp != null)
                                sessionEntry.TS_RsvpsList.Add(cur_rsvp);
                        }
                        
                  
                        /*  Customer  Invoice LineItem
                         *      A         A        A    //new customer, invoice, and lineitem made
                         *      A         B        B    //old customer, new invoice and lineitem made
                         *      A         B        C    //old customer, reuse invoice that is in customer's list, new lineitem???
                        */

                        return eventEntry;
                    },
                    splitOn: "TS_ID, R_ID") 
                .Distinct()
                .ToList();
            }

            return event_List;
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

        //Posts the rsvp in the database
        /*
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
                    
                    SEA_User_id = s.SEA_User_id,
                    SEA_First_Name = s.SEA_First_Name,
                    SEA_Last_Name = s.SEA_Last_Name,
                    SEA_Role = s.SEA_Role,
                    TE_id = s.TE_id,
                    TE_Name = s.TE_Name,
                    ES_id = s.ES_id,
                    ES_Name = s.ES_Name
                    

                });
            }
        }
        */
        public void RSVP_Function(Rsvp r)
        {
           // System.Diagnostics.Debug.WriteLine(r.ToString());

            string sql = "INSERT INTO rsvps (E_id, TS_id) " +
                "Values (@E_id, @TS_id);";

            using (var connection = new MySqlConnection(DBpath))
            {
                var affectedRows = connection.Execute(sql, new
                {
                    E_id = r.E_id,
                    TS_id = r.TS_id
                });
            }
        }

        public List<TheSession> find_SessionsRSVPDfor_byId(string id)
        {
            List<TheSession> SessionsRSVPd_List = new List<TheSession>();

            //string sql = "SELECT * FROM rsvps WHERE E_id = @ID;";
            string sql = "SELECT * FROM THESESSIONS WHERE THESESSIONS.TS_ID IN (SELECT TS_ID FROM RSVPS WHERE E_ID = @ID); ";

            using (MySqlConnection connection = new MySqlConnection(DBpath))
            {
                SessionsRSVPd_List = connection.Query<TheSession>(sql, new { ID = id }).ToList();
            }

            return SessionsRSVPd_List;
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
