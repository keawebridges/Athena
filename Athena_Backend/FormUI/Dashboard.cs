using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class Dashboard : Form
    {
        List<User> people = new List<User>();

        public void UpdateBinding()
        {
            PeopleFound_Listbox.DataSource = people;
            PeopleFound_Listbox.DisplayMember = "FullInfo";
        }

        public Dashboard()
        {
            InitializeComponent();

            NoMatchFound_label.Visible = false;

            UpdateBinding();
        }


        private void Search_Button_Click(object sender, EventArgs e)
        {
            DataAccess db = new DataAccess();

            people = db.GetPeople(Username_text.Text, Password_text.Text);

            if (people.Count() == 0)
            {
                Console.WriteLine("LIST IS EMPTY!");
                NoMatchFound_label.Visible = true;
            }
            else
            NoMatchFound_label.Visible = false;

            UpdateBinding();


        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
