using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Midterms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListOfEmployees aForm = new ListOfEmployees();
            aForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegionalOffice aForm = new RegionalOffice();
            aForm.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditEmployees aForm = new EditEmployees();
            aForm.Show(); 
        }

        private void addAnEmployeeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEmployeecs aForm = new AddEmployeecs();
            aForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SectorsAndSubSectors aForm = new SectorsAndSubSectors();
            aForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Department aForm = new Department();
            aForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            JobList aForm = new JobList();
            aForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void editAnEmployeeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowseEmployees aForm  = new BrowseEmployees();
            aForm.Show();
        }

        private void browseAnEmployeeRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteEmployees aForm = new DeleteEmployees();
            aForm.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
