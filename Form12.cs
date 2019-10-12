using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace MAMall
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int saved;

            string
                qty = textBox1.Text.Trim();
              

            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            string dateOfBuy = dateTimePicker1.Text;
            dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;



            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            string expirationDAte = dateTimePicker2.Text;
            dateTimePicker2.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

       string productId= (comboBox2.SelectedItem as dynamic).Value;
            string output;
            if (comboBox1.Visible == false)
                output = MaMall.execlppy("group","add", qty, productId, dateOfBuy, expirationDAte);

            else
            {
                string groupId = textBox1.Tag.ToString().Trim();
                
                output = MaMall.execlppy("group","editinfo", qty, productId, dateOfBuy, expirationDAte,groupId);
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
                    case -1: MessageBox.Show("details are unuseful \ntry to change them"); break;
                   


                }

            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;

            dateTimePicker1.Value = DateTime.Now;

            string output = MaMall.execlppy("group","get",this.Tag.ToString());

            string[] groupItems = output.Trim().Split(' ', '\n');

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            try
            {
                for (int i = 0; i < groupItems.Length; i = i + 2)
                {
                    comboBox1.Items.Add(new { Text = groupItems[i + 1], Value = groupItems[i] });

                }
            }
            catch { }
            string output1 = MaMall.execlppy("product","get",this.Tag.ToString().Trim());//userId

            string[] productItems = output1.Trim().Split(' ', '\n');

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";


            for (int i = 0; i < productItems.Length; i = i + 2)
            {
                comboBox2.Items.Add(new { Text = productItems[i].Trim(), Value = productItems[i + 1].Trim() });

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            pictureBox2.Image = new Bitmap("images\\product\\product.jpg");
            pictureBox2.Tag = "product";

            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(@"\"+(comboBox1.SelectedItem as dynamic).Value+@"\");
            string output = MaMall.execlppy("group", "getinf", ((string)(comboBox1.SelectedItem as dynamic).Value)).Trim();//groupID

            string[] properties = output.Trim().Split('\n');
           // MessageBox.Show(output);
            textBox1.Text = properties[2];

            textBox1.Tag = properties[0];
           

            dateTimePicker1.Value = DateTime.ParseExact(properties[3].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;


            dateTimePicker2.Value = DateTime.ParseExact(properties[4].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateTimePicker2.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            string productId = properties[1].Trim();
            int Selected = 0;
            int count = comboBox2.Items.Count;
            for (int i = 0; (i <= (count - 1)); i++)
            {
                comboBox2.SelectedIndex = i;
              //  MessageBox.Show("//" + ((string)(comboBox2.SelectedItem as dynamic).Value).Trim() + "//" + productId.Trim() + "//");

                if (((string)(comboBox2.SelectedItem as dynamic).Value).Trim() == productId.Trim())
                {
                    Selected = i;
                    break;
                }

            }
          //  MessageBox.Show("5elsou");
            comboBox2.SelectedIndex = Selected;


            button3.Enabled = true;











        }

        private void button3_Click(object sender, EventArgs e)
        {
            string groupId = textBox1.Tag.ToString().Trim();
         
            string output = MaMall.execlppy("group","delete", groupId);
            button3.Enabled = false;
        
            button2_Click(null, null);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = new Bitmap(@"images\product\" + (comboBox2.SelectedItem as dynamic).Text + ".jpg");
            }
            catch
            {
                pictureBox2.Image = new Bitmap(@"images\product\product.jpg");
            }
        }
    }
}
