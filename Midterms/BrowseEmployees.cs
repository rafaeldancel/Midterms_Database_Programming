using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Midterms
{
    public partial class BrowseEmployees : Form
    {
        public BrowseEmployees()
        {
            InitializeComponent();
        }

        private void BrowseEmployees_Load(object sender, EventArgs e)
        {
            //Setup the connection to the database
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryString = "SELECT EmployeeID, LastName, FirstName, MiddleInitial, Gender, Address, BirthDate, Department, PhoneNumber, Email, Salary, HireDate FROM employeeList ORDER BY LastName;";
            SqlCommand command = new SqlCommand(queryString, connection);
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                string employeeID = reader["EmployeeID"].ToString();
                string lastName = reader["LastName"].ToString();
                string firstName = reader["FirstName"].ToString();
                string middleInitial = reader["MiddleInitial"].ToString();
                string gender = reader["Gender"].ToString();
                string address = reader["Address"].ToString();
                DateTime birthDate = DateTime.Parse(reader["BirthDate"].ToString());
                string department = reader["Department"].ToString();
                string phoneNumber = reader["PhoneNumber"].ToString();
                string email = reader["Email"].ToString();
                string salary = reader["Salary"].ToString();
                DateTime hireDate = DateTime.Parse(reader["hireDate"].ToString());

                ListViewItem lvi = new ListViewItem(employeeID);
                lvi.SubItems.Add(lastName);
                lvi.SubItems.Add(firstName);
                lvi.SubItems.Add(middleInitial);
                lvi.SubItems.Add(gender);
                lvi.SubItems.Add(address);
                lvi.SubItems.Add(birthDate.ToString());
                lvi.SubItems.Add(department);
                lvi.SubItems.Add(phoneNumber);
                lvi.SubItems.Add(email);
                lvi.SubItems.Add(salary);
                lvi.SubItems.Add(hireDate.ToString());

                listView1.Items.Add(lvi);
            }
            reader.Close();
            connection.Close();
            for(int i = 0; i < listView1.Items.Count; i++)
            {
                if(listView1.Items[i].Index % 2 == 0)
                {
                    listView1.Items[i].BackColor = Color.Yellow;
                }
                else
                {
                    listView1.Items[i].BackColor = Color.White;
                }
            }
        }
    }
}
