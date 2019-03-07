//Made by Keawe Bridges

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using TodoApi.Models;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Dapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.DependencyInjection;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // ***uncommented to meet Dapper assignment format***
    //[EnableCors("AllowAllOrigins")] ***commented to meet Dapper assignment format***
    public class AthenaController : ControllerBase
    {
        private readonly TodoContext _context;

        public AthenaController(TodoContext context)
        {
            //_context = context;

            //if (_context.TodoItems.Count() == 0)
            //{
            //    // Create a new TodoItem if collection is empty,
            //    // which means you can't delete all TodoItems.
            //    _context.TodoItems.Add(new TodoItem { Name = "Item1" });
            //    _context.SaveChanges();
            //}
        }



        [HttpGet("events")]
        public ActionResult<List<TheEvent>> GetAllEvents()
        {
            AthenaDataLayer data = new AthenaDataLayer();

            return data.getEvents();

        }











        /*
        [HttpGet("{id}", Name = "GetStu")]
        public ActionResult<StuItem> GetById(string id)
        {
                StuDataLayer data = new StuDataLayer();
                StuItem particular_student = data.findId(id);

                return particular_student;
        }
        */
        [HttpGet("{id}/{name}", Name = "GetStu")]
        public ActionResult<StuItem> GetById(string id, string name)
        {

            AthenaDataLayer data = new AthenaDataLayer();
            StuItem particular_student = data.findId(id);
            if(particular_student==null)
            {
                return NotFound();
            }
            if(particular_student.stu_name!=name)
            {
                return NotFound();
            }
            return particular_student;
        }
        [HttpGet("max")]
        public ActionResult<StuItem> GetMax()
        {

            AthenaDataLayer data = new AthenaDataLayer();
                StuItem max = data.maxGPA();

                return max;
        }






        //[HttpGet("{range}", Name = "GetStu2")]
        //public ActionResult<string> GetRange(string requestType)
        //{
        //    if (requestType == "range")
        //    {

        //        StuDataLayer data = new StuDataLayer();
        //        string path = "STUDENT DATABASE1.csv";
        //        if (data.fileExists(path))
        //        {
        //            List<StuItem> student_List = data.fileRead(path);
        //            string min, max;

        //            min = data.minGPA(student_List);
        //            max = data.maxGPA(student_List);

        //            if (!string.IsNullOrEmpty(min) && !string.IsNullOrEmpty(max))
        //            {
        //                string range = "{ Min GPA: " + min + ", Max GPA: " + max + " }";
        //                return range;
        //            }
        //            else
        //                return NotFound();
        //        }

        //        else
        //            return NotFound();
        //    }
        //    else
        //        return NotFound();

        //}

        /*
        [HttpPost]
        public IActionResult Create(StuItem item)
        {
            AthenaDataLayer data = new AthenaDataLayer();
 
            data.fileWrite(item);

            return CreatedAtRoute("GetStu", new { id = item.stu_id }, item);
        }
        */ 

        /*
        [HttpPost]
        public IActionResult Create(Session_ExpectedAttendees rsvp)
        {
            AthenaDataLayer data = new AthenaDataLayer();

            //The data is null here too, so the issue must be that the data is being lost during its sending from Postman***********************************************
            System.Diagnostics.Debug.WriteLine(rsvp.ToString());

            data.RSVP_Function(rsvp);

            return CreatedAtRoute("GetSEA", new { id = rsvp.SEA_id }, rsvp);
        }
        */

        // POST: api/Todo
        [HttpPost]
        public ActionResult<Rsvp> Create(Rsvp r)
        {
            AthenaDataLayer data = new AthenaDataLayer();
            
            System.Diagnostics.Debug.WriteLine(r.ToString());

            data.RSVP_Function(r);
            
            return CreatedAtAction(nameof(GetRSVPS_ById), new { id = r.R_id }, r);
        }


        [HttpGet("rsvps/{id}", Name = "GetRSVPS")]
        public ActionResult <List<TheSession>> GetRSVPS_ById(string id)
        {
                AthenaDataLayer data = new AthenaDataLayer();

                return data.find_SessionsRSVPDfor_byId(id);
        }
        





        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            AthenaDataLayer data = new AthenaDataLayer();
            
                bool StuItemWasDeleted = data.deleteId(id);

                if (StuItemWasDeleted)
                    return NoContent();
                else
                    return NotFound();
            
        }

        
    } //end of public class AthenaController : ControllerBase

}