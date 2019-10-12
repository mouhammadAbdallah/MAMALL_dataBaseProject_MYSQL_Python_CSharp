using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MAMall
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int saved;

            string
                firstname = textBox1.Text.Trim(),
                lastname = textBox2.Text.Trim(),

                country = textBox4.Text.Trim(),
                city = textBox3.Text.Trim();


            string output;

            if (comboBox1.Visible == false)
                output = MaMall.execlppy("customer","add", firstname, lastname, country, city);

            else
            {
                string personId = textBox1.Tag.ToString().Trim();
               
                
                output = MaMall.execlppy("customer","editinfo", firstname, lastname, country, city, personId);
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

            if (saved >= 1)
            {

               
                button1.Enabled = false;
            }
            else
            {
                switch (saved)
                {
                    case -1: MessageBox.Show("firstname and second name are unuseful \ntry to change them"); break;
                    


                }

            }





        }

        private void Form13_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;

            
            string output = MaMall.execlppy("customer","get");

            string[] customerItems = output.Trim().Split(' ', '\n');

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";


            for (int i = 0; i < customerItems.Length; i = i + 3)
            {
                comboBox1.Items.Add(new { Text = customerItems[i] + " " + customerItems[i + 1], Value = customerItems[i + 2] });

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; 
            textBox2.Text = ""; 
            textBox3.Text = ""; 
            textBox4.Text = ""; 
            
           

            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string output = MaMall.execlppy("customer","getinf", (comboBox1.SelectedItem as dynamic).Value);//customerID
            string[] properties = output.Trim().Split('\n');
            //MessageBox.Show("{0}", string.Join("\n", properties));
            textBox1.Text = properties[0]; 
            textBox2.Text = properties[1]; 
            textBox3.Text = properties[3]; 
            textBox4.Text = properties[2]; 
          

            textBox1.Tag = properties[4];
           


            button3.Enabled = true;








        }

        private void button3_Click(object sender, EventArgs e)
        {
            string personId = textBox1.Tag.ToString().Trim();
   
            string output = MaMall.execlppy("customer","delete", personId);
            button3.Enabled = false;
      
            button2_Click(null, null);
        }
    }
}
