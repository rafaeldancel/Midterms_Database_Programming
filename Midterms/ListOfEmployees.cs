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
using System.IO;

namespace Midterms
{
    public partial class ListOfEmployees : Form
    {
        string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
        public ListOfEmployees()
        {
            InitializeComponent();
        }

        private void ListOfEmployees_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // sending the data to the sql server
         // string connectionString = @"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter dataSql = new SqlDataAdapter("SELECT * FROM employeeList", connection);
                DataTable dataTable = new DataTable();
                dataSql.Fill(dataTable);

                //Display the table
                dataGridView1.DataSource = dataTable;
            }
        }
    }
}
