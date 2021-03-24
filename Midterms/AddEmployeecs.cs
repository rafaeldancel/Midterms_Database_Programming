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
    public partial class AddEmployeecs : Form
    {
        public string imgLoc = string.Empty;
        public AddEmployeecs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // SUBMIT Button
            string employeeIdString = textBox1.Text;
            string lastNameString = textBox2.Text;
            string firstNameString = textBox3.Text;
            string middleInitialString = textBox9.Text;
            string genderString = comboBox1.Text;
            string addressString = textBox4.Text;
            string birthDateString = dateTimePicker1.Text;
            string departmentString = textBox5.Text;
            string phoneNumberString = textBox6.Text;
            string emailString = textBox7.Text;
            string salaryString = textBox8.Text;
            string hireDateString = dateTimePicker2.Text;

            bool allPopulatedBool = employeeIdString != String.Empty &&
                lastNameString != string.Empty && firstNameString != string.Empty 
                && middleInitialString != string.Empty && genderString != string.Empty 
                && addressString != string.Empty && birthDateString != string.Empty 
                && departmentString != string.Empty && phoneNumberString != string.Empty 
                && emailString != string.Empty && salaryString != string.Empty 
                && hireDateString != string.Empty && imgLoc != string.Empty;

            if(allPopulatedBool)
            {
                //To send the data to the database
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);

                //Setup the connection to the database
                string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                string queryString = "INSERT INTO employeeList VALUES(@EmployeeID, @LastName, @FirstName, @MiddleInitial, @Gender, @Address, @BirthDate, @Department, @PhoneNumber, @Email, @Salary, @HireDate, @Picture)";

                SqlParameter param1 = new SqlParameter();
                param1.ParameterName = "@EmployeeID";
                param1.Value = employeeIdString;

                SqlParameter param2 = new SqlParameter();
                param2.ParameterName = "@LastName";
                param2.Value = lastNameString;

                SqlParameter param3 = new SqlParameter();
                param3.ParameterName = "@FirstName";
                param3.Value = firstNameString;

                SqlParameter param4 = new SqlParameter();
                param4.ParameterName = "@MiddleInitial";
                param4.Value = middleInitialString;

                SqlParameter param5 = new SqlParameter();
                param5.ParameterName = "@Gender";
                char genderChar = ' ';
                if (genderString == "M") genderChar = 'M';
                if (genderString == "F") genderChar = 'F';
                param5.Value = genderChar;

                SqlParameter param6 = new SqlParameter();
                param6.ParameterName = "@Address";
                param6.Value = addressString;

                SqlParameter param7 = new SqlParameter();
                param7.ParameterName = "@BirthDate";
                param7.Value = DateTime.Parse(birthDateString);


                SqlParameter param8 = new SqlParameter();
                param8.ParameterName = "@Department";
                param8.Value = departmentString;

                SqlParameter param9 = new SqlParameter();
                param9.ParameterName = "@PhoneNumber";
                param9.Value = phoneNumberString;

                SqlParameter param10 = new SqlParameter();
                param10.ParameterName = "@Email";
                param10.Value = emailString;

                SqlParameter param11 = new SqlParameter();
                param11.ParameterName = "@Salary";
                param11.Value = salaryString;

                SqlParameter param12 = new SqlParameter();
                param12.ParameterName = "@HireDate";
                param12.Value = DateTime.Parse(hireDateString);

                SqlParameter param13 = new SqlParameter();
                param13.ParameterName = "@Picture";
                param13.Value = img;

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.Add(param1);
                command.Parameters.Add(param2);
                command.Parameters.Add(param3);
                command.Parameters.Add(param4);
                command.Parameters.Add(param5);
                command.Parameters.Add(param6);
                command.Parameters.Add(param7);
                command.Parameters.Add(param8);
                command.Parameters.Add(param9);
                command.Parameters.Add(param10);
                command.Parameters.Add(param11);
                command.Parameters.Add(param12);
                command.Parameters.Add(param13);

                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Employee has been registered succesfully.", "New Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;
                textBox3.Text = string.Empty;
                textBox9.Text = string.Empty;
                comboBox1.Text = string.Empty;
                textBox4.Text = string.Empty; 
                dateTimePicker1.Text = string.Empty; 
                textBox5.Text = string.Empty;
                textBox6.Text = string.Empty;
                textBox7.Text = string.Empty;
                textBox8.Text = string.Empty;
                dateTimePicker2.Text = string.Empty;
                pictureBox1.ImageLocation = null;
                textBox1.Focus();
            }
            if(!allPopulatedBool)
            {
                //The isntance when not all controls are populated
                MessageBox.Show("Please fill out all information.", "Incomplete Entry", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //BROWSE Button
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Choose a file";
            if(dlg.ShowDialog()==DialogResult.OK)
            {
                imgLoc = dlg.FileName.ToString();
                pictureBox1.ImageLocation = imgLoc;
            }
        }
    }
}
