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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int saved;

            string
                rate = textBox1.Text.Trim(),
                desc = textBox2.Text.Trim();

            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            string startDate = dateTimePicker1.Text;
            dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;




            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            string endDAte = dateTimePicker2.Text;
            dateTimePicker2.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            string prductID= (comboBox2.SelectedItem as dynamic).Value;

            string output;

            if (comboBox1.Visible == false)
                output = MaMall.execlppy("offer", "add", prductID, rate, desc, startDate, endDAte);


            else
            {
                string offerId = textBox1.Tag.ToString().Trim();
            
                output = MaMall.execlppy("offer","editinfo", prductID, rate, desc, startDate, endDAte,offerId);
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
                MessageBox.Show("error");

            }




        }

        private void Form15_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;

            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
            string output = MaMall.execlppy("offer","get",this.Tag.ToString());

            string[] offerItems = output.Trim().Split(' ', '\n');

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            try
            {
                for (int i = 0; i < offerItems.Length; i = i + 2)
                {
                    comboBox1.Items.Add(new { Text = offerItems[i] + " " + offerItems[i + 1], Value = offerItems[i + 1] });

                }
            }
            catch { }
            string output1 = MaMall.execlppy("product", "get",this.Tag.ToString().Trim());//userid

            string[] productItems = output1.Trim().Split(' ', '\n');

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";


            for (int i = 0; i < productItems.Length; i = i + 2)
            {
                comboBox2.Items.Add(new { Text = productItems[i], Value = productItems[i + 1] });

            }

        }

        private void Form15_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; 
            textBox2.Text = "";
            pictureBox2.Image = new Bitmap("images\\product\\product.jpg");
            pictureBox2.Tag = "product";


            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string output = MaMall.execlppy("offer","getinf", (comboBox1.SelectedItem as dynamic).Value);//offerID
            string[] properties = output.Trim().Split('\n');
           // MessageBox.Show(output);
            textBox1.Text = properties[2];
            textBox2.Text = properties[3];

            string productId = properties[1].Trim();
            
           

            
            int Selected = 0;
            int count = comboBox2.Items.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                comboBox2.SelectedIndex = i;
               // MessageBox.Show("\"" + (string)(comboBox2.SelectedValue) + "\"");
                if (((string)(comboBox2.SelectedItem as dynamic).Value).Trim() == productId)
                {

                    Selected = i;
                    break;
                }

            }
            //MessageBox.Show(Selected.ToString());
            comboBox2.SelectedIndex = Selected;

            textBox1.Tag = properties[0];
            

            dateTimePicker1.Value = DateTime.ParseExact(properties[4].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

          
            dateTimePicker2.Value = DateTime.ParseExact(properties[5].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateTimePicker2.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

        

            button3.Enabled = true;












        }

        private void button3_Click(object sender, EventArgs e)
        {
            string offerId = textBox1.Tag.ToString().Trim();
          
            string output = MaMall.execlppy("offer", "delete", offerId);
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
