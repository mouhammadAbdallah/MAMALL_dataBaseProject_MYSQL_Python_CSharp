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


namespace MAMall
{
    public partial class Form5 : Form
    {
       
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String employee=this.Tag.ToString(), username = textBox1.Text, password = textBox2.Text;
            int employeeId;



            string output = MaMall.execlppy("checkAccount", employee, username, password);
            employeeId = int.Parse( output);//adminId or userId
     

            if (employeeId!=-1)
            {
                if (employee == "admin")
                {
                    Form3 f3 = new Form3();
                    f3.Tag = employeeId;
                    f3.ShowDialog();
                    this.Close();
                }
                else
                {
                    Form4 f4 = new Form4();
                    f4.Tag = employeeId;
                    f4.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("invalid username or password");
            }
         


        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // Set to no text.  
            textBox2.Text = "";
            // The password character is an asterisk.  
            textBox2.PasswordChar = '•';
            // The control will allow no more than 14 characters.  
            textBox2.MaxLength = 20;

            if (this.Tag.ToString() == "admin")
            {
                textBox1.Text = "BaderNAjiha";//delete
                textBox2.Text = "6548aw6e6";//delete
            }
            else
            {
                textBox1.Text = "AlaaAbdallah";//delete
                textBox2.Text = "56a4da684wd";//delete
            }
            if (textBox1.Text == "") button1.Enabled = false;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
