using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Rsvp
    {
        //the id for rsvp
        public int R_id { get; set; }

        //the employee's id
        public int E_id { get; set; }

        //the session's id
        public int TS_id { get; set; }

        public override string ToString()
        {
            return "Id: " + R_id + " " +
            "Employee Id: " + E_id + " " +
             "The Session Id: " + TS_id;
        }
    }
}
