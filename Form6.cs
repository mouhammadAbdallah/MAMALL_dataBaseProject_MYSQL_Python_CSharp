using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Globalization;

namespace MAMall
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        
        string profile="employee";
        private void button1_Click(object sender, EventArgs e)//save
        {
           
            int saved ;

            string
                firstname = textBox1.Text.Trim(),
                lastname = textBox2.Text.Trim(),

                country = textBox4.Text.Trim(),
                city = textBox3.Text.Trim();

            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            string birthdate = dateTimePicker1.Text;
            dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            
         

            string username = textBox5.Text.Trim(),
                    password = textBox6.Text.Trim(),
                    street = textBox7.Text.Trim(),
                    building = textBox8.Text.Trim(),
                    floor = textBox9.Text.Trim(),
                    doorId = textBox10.Text.Trim(),
                    postalCode = textBox11.Text.Trim(),
                    phoneNumber = textBox12.Text.Trim();

            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            string hireDate = dateTimePicker2.Text;
            dateTimePicker2.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            string fixSalary = textBox13.Text.Trim();

            int married = (checkBox1.Checked == true) ? 1 : 0;
            string nbChildren = textBox14.Text.Trim();
            string email = textBox15.Text.Trim();
            string output;

            if (profile != "employee")
            {
                profile = firstname + lastname;
            }
            if (comboBox1.Visible == false)
                output = MaMall.execlppy("employee", "add", firstname, lastname, country, city, birthdate, profile, username, password, street, building, floor, doorId, postalCode, phoneNumber, hireDate, fixSalary, married.ToString(), nbChildren, email);

            else
            {
                string personId = textBox1.Tag.ToString().Trim();
                string employeeID= textBox5.Tag.ToString().Trim();
                string fulladdID= textBox7.Tag.ToString().Trim();
                output = MaMall.execlppy("employee","editinfo", firstname, lastname, country, city, birthdate, profile, username, password, street, building, floor, doorId, postalCode, phoneNumber, hireDate, fixSalary, married.ToString(), nbChildren, email,personId,employeeID,fulladdID);
                //string output1 = execlppy("getemployee");

                //string[] employeeItems = output1.Trim().Split(' ', '\n');

                //comboBox1.DisplayMember = "Text";
                //comboBox1.ValueMember = "Value";


                //for (int i = 0; i < employeeItems.Length; i = i + 3)
                //{
                //    comboBox1.Items.Add(new { Text = employeeItems[i] + " " + employeeItems[i + 1], Value = employeeItems[i + 2] });

                //}
            }

            saved = int.Parse(output);

            if (saved >= 1)//in this case saved=employeeId
            {

                if (profile != "employee")
                {
                    try { 
                    File.Delete("images\\employee\\" + profile + ".jpg");
                    File.Copy(pictureBox1.Tag.ToString(), "images\\employee\\" + profile + ".jpg");
                    }
                    catch { }
                }
                button1.Enabled = false;
            }
            else
            {
                switch (saved)
                {
                    case -1: MessageBox.Show("firstname and second name are unuseful \ntry to change them"); break;
                    case -2: MessageBox.Show("phonenumber and address details are unuseful \ntry to change them"); break;
                    case -3: MessageBox.Show("username and password and email are unuseful \ntry to change them"); break;


                }

            }


           



        }

        private void Form6_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;

            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
            string output = MaMall.execlppy("employee","get");
      
            string[] employeeItems = output.Trim().Split(' ', '\n');

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";


            for (int i = 0; i < employeeItems.Length; i = i + 3)
            {
                comboBox1.Items.Add(new { Text = employeeItems[i] + " " + employeeItems[i + 1], Value = employeeItems[i + 2] });

            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string picture = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(picture);
                pictureBox1.Tag = picture;
                profile = "takeitfromfirstlastname";




            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
          textBox1.Text=""; textBox6.Text="";    textBox11.Text="";
          textBox2.Text=""; textBox7.Text="";    textBox12.Text="";
          textBox3.Text=""; textBox8.Text="";    textBox13.Text="";
          textBox4.Text=""; textBox9.Text="";    textBox14.Text="";
          textBox5.Text=""; textBox10.Text = ""; textBox15.Text = "";
            pictureBox1.Image = new Bitmap("images\\employee\\employee.jpg");
            pictureBox1.Tag = "employee";

            button1.Enabled = true;

            checkBox1.Checked = false;







        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string output = MaMall.execlppy("employee","getinf", (comboBox1.SelectedItem as dynamic).Value);//employeeID
            string[] properties = output.Trim().Split('\n');
            //MessageBox.Show("{0}", string.Join("\n", properties));
            textBox1.Text = properties[1];textBox7.Text = properties[9]; textBox12.Text = properties[14];
            textBox2.Text = properties[2];textBox8.Text = properties[10]; textBox13.Text = properties[16];
            textBox3.Text = properties[4];textBox9.Text = properties[11]; textBox14.Text = properties[18];
            textBox4.Text = properties[3];textBox10.Text = properties[12]; textBox15.Text = properties[19];
            textBox5.Text = properties[7]; textBox11.Text = properties[13];
            textBox6.Text = properties[8];

            textBox1.Tag =properties[20];
            textBox5.Tag = properties[0];
            textBox7.Tag = properties[21];

        dateTimePicker1.Value = DateTime.ParseExact(properties[5].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

            pictureBox1.Image = new Bitmap("images\\employee\\" + properties[6].Trim() + ".jpg");
            pictureBox1.Tag = properties[6].Trim();

            dateTimePicker2.Value = DateTime.ParseExact(properties[15].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateTimePicker2.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            if (properties[17].Trim() == "0") checkBox1.Checked = false;
            else checkBox1.Checked = true;

            button3.Enabled = true;













        }

        private void button3_Click(object sender, EventArgs e)
        {
            string personId = textBox1.Tag.ToString().Trim();
            string employeeID = textBox5.Tag.ToString().Trim();
            string fulladdID = textBox7.Tag.ToString().Trim();
            string output = MaMall.execlppy("employee", "delete", personId,employeeID,fulladdID);
            button3.Enabled = false;
            try
            {
                File.Delete("images\\employee\\" + textBox1.Text.Trim() + textBox2.Text.Trim() + ".jpg");
            }
            catch { }
            button2_Click(null, null);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
