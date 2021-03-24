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
    public partial class RegionalOffice : Form
    {
        string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
        public RegionalOffice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter dataSql = new SqlDataAdapter("SELECT * FROM regionalOffice", connection);
                DataTable dataTable = new DataTable();
                dataSql.Fill(dataTable);

                //Display the Table
                dataGridView1.DataSource = dataTable;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
             
        }

        private void RegionalOffice_Load(object sender, EventArgs e)
        {

        }
    }
}
