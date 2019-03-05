//Made by Keawe Bridges
//9/21/2018
/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text;


namespace TodoApi.Models
{
    public class StuDataLayer
    {
        //check if File exists
        public bool fileExists(string path)
        {
            return File.Exists(path);
        }
        //read File
        public List<StuItem> fileRead(string path)
        {
            List<StuItem> student_List = new List<StuItem>();

            string[] lines = File.ReadAllLines(path);
            bool columnHeaders = true;

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                if (!columnHeaders)
                {
                    //convert gpa from a string to a float
                    string stringVal = values[2];
                    float fval = float.Parse(stringVal);

                    //add a new item to the student_List
                    StuItem student = new StuItem { Id = values[0], Name = values[1], Gpa = fval };
                    student_List.Add(student);
                }
                else
                {
                    //we are now past the column headers, so set it to false
                    columnHeaders = false;
                }
            }

            return student_List;
        }
        //write File
        public void fileWrite(StuItem SIstudent, string path)
        {
         ////make incoming strStudent fit proper format
         //   string[] values = strStudent.Split(',');

         //   //convert gpa from a string to a float
         //   string stringVal = values[2];
         //   float fval = float.Parse(stringVal);
            
         //   StuItem SIstudent = new StuItem { Id = values[0], Name = values[1], Gpa = fval };
          
            
         //Add incoming strStudent to the List
            List<StuItem> student_List = fileRead(path);
            student_List.Add(SIstudent);

         //Write list to the "database" (Excel File)

            //arrays are a fixed size
            int size = student_List.Count() + 1;
            string[] lines = new string[size];
            lines[0] = "STU_ID, " + "STU_NAME, " + "STU_GPA, ";

            int index = 1;
            foreach (StuItem student in student_List)
            {
                lines[index] = student.Id + ", " + student.Name + ", " + student.Gpa;

                index++;
            }
            student_List.Clear();

            File.WriteAllLines(path, lines);
        }

        public string findId(string id, List<StuItem> student_List)
        {
            StuItem student = student_List.Find(x => x.Id.Contains(id));
            if (student == null)
            {
                string emptyString = "";
                return emptyString;
            }
            else
            return student.ToString();
        }

        public bool  deleteId(string id, List<StuItem> student_List, string path)
        {
         //Find and Delete the particular student that has this id from the List
            StuItem particular_student = student_List.Find(x => x.Id.Contains(id));
            if (particular_student == null)
            {
                //show that a StuItem does not exist
                return false;
            }
            else
            {
                student_List.Remove(particular_student);

                //Write List to the "database" (Excel File)

                //arrays are a fixed size
                int size = student_List.Count() + 1;
                string[] lines = new string[size];
                lines[0] = "STU_ID, " + "STU_NAME, " + "STU_GPA, ";

                int index = 1;
                foreach (StuItem student in student_List)
                {
                    lines[index] = student.Id + ", " + student.Name + ", " + student.Gpa;

                    index++;
                }
                student_List.Clear();

                File.WriteAllLines(path, lines);

                //show that a StuItem was deleted
                return true;
            }
            
        }

        public string maxGPA(List<StuItem> student_List)
        {
            float max = student_List.Max(x => x.Gpa);
            return max.ToString();
        }

        public string minGPA(List<StuItem> student_List)
        {
            float min = student_List.Min(x => x.Gpa);
            return min.ToString();
        }
        
    }
}
*/
