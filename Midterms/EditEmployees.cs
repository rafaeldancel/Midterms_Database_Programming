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
    public partial class EditEmployees : Form
    {
        public string imgLoc = string.Empty;
        public bool changePictureBool = false;

        public EditEmployees()
        {
            InitializeComponent();
        }

        private void EditEmployees_Load(object sender, EventArgs e)
        {
            //Upon loading of the form, comboBox1 will be automatically populated from employeeList tables
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryString = "SELECT EmployeeID FROM employeeList ORDER BY EmployeeID;";
            var command = new SqlCommand(queryString, connection);
            var reader = command.ExecuteReader();
            while(reader.Read())
            {
                string employeeID = reader["EmployeeID"].ToString();
                comboBox1.Items.Add(employeeID);
            }
            reader.Close();
            connection.Close();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //To extract all data of the employee whose employeeID is in comboBox1
            string employeeID = comboBox1.Text;
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string queryString = "SELECT * FROM employeeList WHERE EmployeeID = @EmployeeID;";
            SqlParameter param1 = new SqlParameter("@EmployeeID", employeeID);
            var command = new SqlCommand(queryString, connection);
            command.Parameters.Add(param1);
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
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
                byte[] img = (byte[])(reader["Picture"]);
                MemoryStream ms = new MemoryStream(img);
                pictureBox1.Image = Image.FromStream(ms);

                textBox2.Text = lastName;
                textBox3.Text = firstName;
                textBox9.Text = middleInitial;
                if (gender == "M") comboBox2.Text = "M";
                if (gender == "F") comboBox2.Text = "F";
                textBox4.Text = address;
                dateTimePicker1.Text = birthDate.ToString();
                textBox5.Text = department;
                textBox6.Text = phoneNumber;
                textBox7.Text = email;
                textBox8.Text = salary;
                dateTimePicker2.Text = hireDate.ToString();
            }
            reader.Close();
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BROWSE Button
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Choose a file";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                imgLoc = dlg.FileName.ToString();
                pictureBox1.ImageLocation = imgLoc;
                changePictureBool = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SUBMIT Button
            string employeeID = comboBox1.Text;
            string connectionString = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = BSP; Integrated Security = True;";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            if (changePictureBool)
            {
                string queryString = "UPDATE employeeList SET LastName = @LastName, FirstName = @FirstName, MiddleInitial = @MiddleInitial, Gender = @Gender, Address = @Address, BirthDate = @BirthDate, Department = @Department, PhoneNumber = @PhoneNumber, Email = @Email, Salary = @Salary, HireDate = @HireDate, Picture = @Picture WHERE EmployeeID = @EmployeeID;";
                SqlParameter param1 = new SqlParameter("@LastName", textBox2.Text);
                SqlParameter param2 = new SqlParameter("@FirstName", textBox3.Text);
                SqlParameter param3 = new SqlParameter("@MiddleInitial", textBox9.Text);
                string genderString = comboBox2.Text;
                char genderChar = ' ';
                if (genderString == "M")
                {
                    genderChar = 'M';
                }
                else
                {
                    genderChar = 'F';
                }
                SqlParameter param4 = new SqlParameter("@Gender", genderChar);
                SqlParameter param5 = new SqlParameter("@Address", textBox4.Text);
                SqlParameter param6 = new SqlParameter("@BirthDate", DateTime.Parse(dateTimePicker1.Text));
                SqlParameter param7 = new SqlParameter("@Department", textBox5.Text);
                SqlParameter param8 = new SqlParameter("@PhoneNumber", textBox6.Text);
                SqlParameter param9 = new SqlParameter("@Email", textBox7.Text);
                SqlParameter param10 = new SqlParameter("@Salary", textBox8.Text);
                SqlParameter param11 = new SqlParameter("@HireDate", DateTime.Parse(dateTimePicker2.Text));
                byte[] img = null;
                FileStream fs = new FileStream(imgLoc, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                SqlParameter param12 = new SqlParameter("@Picture", img);
                SqlParameter param13 = new SqlParameter("@EmployeeID", employeeID);

                var command = new SqlCommand(queryString, connection);
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
            }

            if(!changePictureBool)
            {
                string queryString = "UPDATE employeeList SET LastName = @LastName, FirstName = @FirstName, MiddleInitial = @MiddleInitial, Gender = @Gender, Address = @Address, BirthDate = @BirthDate, Department = @Department, PhoneNumber = @PhoneNumber, Email = @Email, Salary = @Salary, HireDate = @HireDate WHERE EmployeeID = @EmployeeID;";
                SqlParameter param1 = new SqlParameter("@LastName", textBox2.Text);
                SqlParameter param2 = new SqlParameter("@FirstName", textBox3.Text);
                SqlParameter param3 = new SqlParameter("@MiddleInitial", textBox9.Text);
                string genderString = comboBox2.Text;
                char genderChar = ' ';
                if (genderString == "M")
                {
                    genderChar = 'M';
                }
                else
                {
                    genderChar = 'F';
                }
                SqlParameter param4 = new SqlParameter("@Gender", genderChar);
                SqlParameter param5 = new SqlParameter("@Address", textBox4.Text);
                SqlParameter param6 = new SqlParameter("@BirthDate", DateTime.Parse(dateTimePicker1.Text));
                SqlParameter param7 = new SqlParameter("@Department", textBox5.Text);
                SqlParameter param8 = new SqlParameter("@PhoneNumber", textBox6.Text);
                SqlParameter param9 = new SqlParameter("@Email", textBox7.Text);
                SqlParameter param10 = new SqlParameter("@Salary", textBox8.Text);
                SqlParameter param11 = new SqlParameter("@HireDate", DateTime.Parse(dateTimePicker2.Text));
                SqlParameter param12 = new SqlParameter("@EmployeeID", employeeID);

                var command = new SqlCommand(queryString, connection);
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
                command.ExecuteNonQuery();
            }
            connection.Close();
            MessageBox.Show("The employee's record has now been UPDATED", "Successfully Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
