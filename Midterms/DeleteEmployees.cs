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
    public partial class DeleteEmployees : Form
    {
        public DeleteEmployees()
        {
            InitializeComponent();
        }

        private void DeleteEmployees_Load(object sender, EventArgs e)
        {
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryString = "SELECT EmployeeID FROM employeeList ORDER BY EmployeeID;";
            var command = new SqlCommand(queryString, connection);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                string employeeID = reader["EmployeeID"].ToString();
                comboBox1.Items.Add(employeeID);
            }
            reader.Close();
            connection.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string employeeID = comboBox1.Text;
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryString = "SELECT LastName, FirstName, MiddleInitial FROM employeeList WHERE EmployeeID = @EmployeeID;";
           
            SqlParameter param1 = new SqlParameter("@EmployeeID", employeeID);
            var command = new SqlCommand(queryString, connection);
            command.Parameters.Add(param1);
            var reader = command.ExecuteReader();
            reader.Read();
            string lastNameString = reader["LastName"].ToString();
            string firstNameString = reader["FirstName"].ToString();
            string middleInitialString = reader["MiddleInitial"].ToString();
            reader.Close();
            connection.Close();

            string fullNameString = lastNameString + ", " + firstNameString + ", " + middleInitialString;
            DialogResult response = new DialogResult();
            response = MessageBox.Show("Are you sure you want to delete the records of " + fullNameString + "?", "CONFIRM DELETION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(response == DialogResult.Yes)
            {
                connection.Open();
                queryString = "DELETE FROM employeeList WHERE EmployeeID = @EmployeeID;";
                param1 = new SqlParameter("@EmployeeID", employeeID);
                command = new SqlCommand(queryString, connection);
                command.Parameters.Add(param1);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("The records of Employee Number " + employeeID + " has now been REMOVED.");
            }
            if(response == DialogResult.No)
            {
                //Exits the messageBox
                //cancels the deletion of the employee
            }
        }
    }
}
