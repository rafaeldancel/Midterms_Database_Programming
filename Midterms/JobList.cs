using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midterms
{
    public partial class JobList : Form
    {
        string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
        public JobList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter dataSql = new SqlDataAdapter("SELECT * FROM Jobs", connection);
                DataTable dataTable = new DataTable();
                dataSql.Fill(dataTable);

                //Display the Table
                dataGridView1.DataSource = dataTable;
            }

        }

        private void JobList_Load(object sender, EventArgs e)
        {

        }
    }
    }
    

