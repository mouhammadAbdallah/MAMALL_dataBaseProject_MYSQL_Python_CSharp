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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;

            dateTimePicker1.Value = DateTime.Now;
           

            string output = MaMall.execlppy("employee", "get");
           

            string[] employeeItems= output.Trim().Split(' ','\n');

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";


            for (int i = 0; i < employeeItems.Length; i=i+3)
            {
                comboBox1.Items.Add(new { Text = employeeItems[i] + " " + employeeItems[i + 1], Value = employeeItems[i + 2] });

            }

            output = MaMall.execlppy("shop", "get");
           

            string[] shopItems = output.Trim().Split(' ', '\n');

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";


            for (int i = 0; i < shopItems.Length; i = i + 2)
            {
                comboBox2.Items.Add(new { Text = shopItems[i], Value = shopItems[i + 1] });

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;

            string output = MaMall.execlppy("employee", "inf", (comboBox1.SelectedItem as dynamic).Value);
            //MessageBox.Show(output);
         
            string[] infos = output.Split('\n');
            int shopId = int.Parse(infos[0]);
            int adminId= int.Parse(infos[1]);
            string stopDate = infos[2].Trim();
           string profile = infos[3].Trim();

           pictureBox1.Image = new Bitmap("images\\employee\\" + profile + ".jpg");
           pictureBox1.Tag = profile;

            if (shopId == 0)
            {
                checkBox1.Checked = false;
                comboBox2.Text = "";
                comboBox2.Enabled = false;
            }
            else
            {
                checkBox1.Checked = true;
                comboBox2.Enabled = true;
                int Selected=0;
                int count = comboBox2.Items.Count;
                for (int i = 0; (i <= (count - 1)); i++)
                {
                    comboBox2.SelectedIndex = i;
                    //MessageBox.Show("\"" + (comboBox2.SelectedItem as dynamic).Value + "\"");
                    if (((string)((comboBox2.SelectedItem as dynamic).Value)).Trim() == shopId.ToString().Trim())
                    {
                        
                        Selected = i;
                        break;
                    }

                }
                
                comboBox2.SelectedIndex = Selected;
                comboBox2.Enabled = true;
            }


            if (adminId == 0)
            {
                checkBox2.Checked = false;
            }
            else
            {
                checkBox2.Checked = true;
            }



            if (stopDate == "0")
            {
                checkBox3.Checked = false;
                dateTimePicker1.Enabled = false;
            }
            else
            {
                checkBox3.Checked = true;
                dateTimePicker1.Enabled = true;

                dateTimePicker1.Value =DateTime.ParseExact(stopDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;

            }

            button1.Enabled = true;

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = new Bitmap(@"images\shop\" + (comboBox2.SelectedItem as dynamic).Text + ".jpg");
            }
            catch
            {
                pictureBox2.Image = new Bitmap(@"images\shop\category.jpg");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeId = (comboBox1.SelectedItem as dynamic).Value;
            string adminID = this.Tag.ToString();
            string shopID;
            if (checkBox1.Checked)
            {
                try { shopID = (comboBox2.SelectedItem as dynamic).Value; }
                catch { shopID = "0"; }
               
            }
            else shopID = "0";

            string admin;
            if (checkBox2.Checked)
            {
                admin = "1";
            }
            else admin = "0";

            string stopDate;
            if (checkBox3.Checked)
            {
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                stopDate = dateTimePicker1.Text;
                dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
            }
            else stopDate = "0";

           // MessageBox.Show(employeeId + "\n" + adminID + "\n" + shopID + "\n" + admin + "\n" + stopDate);
            string output = MaMall.execlppy("employee", "edit", employeeId,adminID,shopID,admin,stopDate);
            button1.Enabled = false;



        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox2.Enabled = true;
                pictureBox1.Visible = true;

            }
            else
            {
                comboBox2.Enabled = false;
                pictureBox1.Visible = false;
            }

            }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
                dateTimePicker1.Enabled = true;
            else dateTimePicker1.Enabled = false;

        }
    }
    
}
