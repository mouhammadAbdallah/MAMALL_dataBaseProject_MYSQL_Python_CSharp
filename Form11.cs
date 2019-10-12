using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MAMall
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        string profile;

        private void button1_Click(object sender, EventArgs e)
        {

            int saved;

            string
                productName = textBox1.Text.Trim(),
                pPrice = textBox2.Text.Trim(),

                unitPrice = textBox4.Text.Trim();


            string qtyPerUnit = textBox5.Text.Trim(),
                    description = textBox7.Text.Trim();

            string supplierId = (comboBox2.SelectedItem as dynamic).Value;
            string userId = this.Tag.ToString();


            string output;
            if (profile != "product")
            {
                profile = productName;
            }
            if (comboBox1.Visible == false)
                output = MaMall.execlppy("product","add", productName, pPrice, unitPrice, qtyPerUnit, description, supplierId,userId,profile);

            else
            {

                string productID = textBox1.Tag.ToString().Trim();
                output = MaMall.execlppy("product","editinfo", productName, pPrice, unitPrice, qtyPerUnit, description, supplierId, userId, profile,productID);
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

                if (profile != "product")
                {
                    try
                    {
                        File.Delete("images\\product\\" + profile + ".jpg");
                        File.Copy(pictureBox1.Tag.ToString(), "images\\product\\" + profile + ".jpg");
                    }
                    catch { }
                }
                button1.Enabled = false;
            }
            else
            {
                switch (saved)
                {
                    case -1: MessageBox.Show("product name is unuseful \ntry to change it"); break;


                }

            }



        }

        private void Form11_Load(object sender, EventArgs e)
        {
            string userId = this.Tag.ToString().Trim();
            button1.Enabled = false;
            button3.Enabled = false;
            string output = MaMall.execlppy("product","get",userId);

            string[] productItems = output.Trim().Split(' ', '\n');

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            int k = productItems.Length;
            if(k == 1) k = 0;
            
            for (int i = 0; i < k; i = i + 2)
            {
                comboBox1.Items.Add(new { Text = productItems[i].Trim(), Value = productItems[i + 1].Trim() });

            }
            string output1 = MaMall.execlppy("supplier","get");
            //MessageBox.Show(output1);
            string[] supplierItems = output1.Trim().Split(' ', '\n');
            //MessageBox.Show(supplierItems[0]);

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";


            for (int i = 0; i < supplierItems.Length; i = i + 2)
            {
                comboBox2.Items.Add(new { Text = supplierItems[i], Value = supplierItems[i + 1] });

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
                profile = "takeitfromproductNAme";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; ; 
            textBox2.Text = ""; textBox7.Text = ""; 
            
            textBox4.Text = ""; 
            textBox5.Text = ""; 
            pictureBox1.Image = new Bitmap("images\\product\\product.jpg");
            pictureBox1.Tag = "product";

            pictureBox2.Image = new Bitmap("images\\supplier\\supplier.jpg");
            pictureBox2.Tag = "supplier";

            button1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string output = MaMall.execlppy("product","getinf", (comboBox1.SelectedItem as dynamic).Value);//productID
            //MessageBox.Show(output);
            string[] properties = output.Trim().Split('\n');
            //MessageBox.Show("{0}", string.Join("\n", properties));
            textBox1.Text = properties[2].Trim(); textBox7.Text = properties[8].Trim(); 
            textBox2.Text = properties[3].Trim(); 
             
            textBox4.Text = properties[4].Trim(); 
            textBox5.Text = properties[7].Trim(); 


            textBox1.Tag = properties[0].Trim();

            string supplierId = properties[6].Trim();
            //for(int i=0;i<properties.Length;i++)
            //     MessageBox.Show("\""+properties[i].Trim()+"\"");
            pictureBox1.Image = new Bitmap("images\\product\\" + properties[5].Trim() + ".jpg");
            pictureBox1.Tag = properties[5].Trim();

            //MessageBox.Show("\"" + supplierId + "\"");
            int Selected = 0;
            int count = comboBox2.Items.Count;
            for (int i = 0; i <= count - 1; i++)
            {
                comboBox2.SelectedIndex = i;
                //MessageBox.Show("\"" + (string)(comboBox2.SelectedValue) + "\"");
                if (((string)((comboBox2.SelectedItem as dynamic).Value)).Trim()== supplierId.Trim())
                {

                    Selected = i;
                    break;
                }

            }
            //MessageBox.Show(Selected.ToString());
            comboBox2.SelectedIndex = Selected;

            button3.Enabled = true;





        }

        private void button3_Click(object sender, EventArgs e)
        {
            string productID = textBox1.Tag.ToString().Trim();
            string output = MaMall.execlppy("product", "delete", productID);
            button3.Enabled = false;
            try
            {
                File.Delete("images\\product\\" + textBox1.Text.Trim() + ".jpg");
            }
            catch { }
            button2_Click(null, null);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = new Bitmap(@"images\supplier\" + (comboBox2.SelectedItem as dynamic).Text + ".jpg");
            }
            catch
            {
                pictureBox2.Image = new Bitmap(@"images\supplier\supplier.jpg");
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
