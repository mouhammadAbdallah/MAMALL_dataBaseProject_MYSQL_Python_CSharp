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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        string profile;
        private void button1_Click(object sender, EventArgs e)
        {


            int saved;

            string
                supplierName = textBox1.Text.Trim(),
                fax = textBox2.Text.Trim(),

                country = textBox4.Text.Trim(),
                city = textBox3.Text.Trim();

            string webPage = textBox5.Text.Trim(),
                    street = textBox7.Text.Trim(),
                    building = textBox8.Text.Trim(),
                    floor = textBox9.Text.Trim(),
                    doorId = textBox10.Text.Trim(),
                    postalCode = textBox11.Text.Trim(),
                    phoneNumber = textBox12.Text.Trim();

            string output;
            if (profile != "supplier")
            {
                profile = supplierName;
            }
            if (comboBox1.Visible == false)
                output = MaMall.execlppy("supplier","add", supplierName, fax, country, city, profile, webPage, street, building, floor, doorId, postalCode, phoneNumber);

            else
            {

                string supplierID = textBox1.Tag.ToString().Trim();
                string fulladdID = textBox7.Tag.ToString().Trim();
                output = MaMall.execlppy("supplier","editinfo", supplierName, fax, country, city, profile, webPage, street, building, floor, doorId, postalCode, phoneNumber, supplierID, fulladdID);
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

            if (saved >= 1)//in this case saved=supplierId
            {

                if (profile != "supplier")
                {
                    try { File.Delete("images\\supplier\\" + profile + ".jpg"); 
                    File.Copy(pictureBox1.Tag.ToString(), "images\\supplier\\" + profile + ".jpg");
                    }
                    catch { }
                }
                button1.Enabled = false;
            }
            else
            {
                switch (saved)
                {
                    case -2: MessageBox.Show("phonenumber and address details are unuseful \ntry to change them"); break;
                    case -3: MessageBox.Show("supplier name  and some details are unuseful \ntry to change them"); break;


                }

            }




        }

        private void Form7_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;

            string output = MaMall.execlppy("supplier","get");
            string[] supplierItems = output.Trim().Split(' ', '\n');
            //MessageBox.Show(supplierItems[0]);

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";


            for (int i = 0; i < supplierItems.Length; i = i + 2)
            {
                comboBox1.Items.Add(new { Text = supplierItems[i], Value = supplierItems[i + 1] });

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
                profile = "takeitfromsupplierName";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; ; textBox11.Text = "";
            textBox2.Text = ""; textBox7.Text = ""; textBox12.Text = "";
            textBox3.Text = ""; textBox8.Text = ""; 
            textBox4.Text = ""; textBox9.Text = ""; 
            textBox5.Text = ""; textBox10.Text = "";
            pictureBox1.Image = new Bitmap("images\\supplier\\supplier.jpg");
            pictureBox1.Tag = "supplier";

            button1.Enabled = true;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string output = MaMall.execlppy("supplier","getinf", (comboBox1.SelectedItem as dynamic).Value);//supplierID
            string[] properties = output.Trim().Split('\n');
            //MessageBox.Show("{0}", string.Join("\n", properties));
            textBox1.Text = properties[1]; textBox7.Text = properties[7]; textBox12.Text = properties[12];
            textBox2.Text = properties[2]; textBox8.Text = properties[8]; 
            textBox3.Text = properties[4]; textBox9.Text = properties[9]; 
            textBox4.Text = properties[3]; textBox10.Text = properties[10];
            textBox5.Text = properties[6]; textBox11.Text = properties[11];
           

            textBox1.Tag = properties[0];
            textBox7.Tag = properties[13];
 

            pictureBox1.Image = new Bitmap("images\\supplier\\" + properties[5].Trim() + ".jpg");
            pictureBox1.Tag = properties[5].Trim();

            button3.Enabled = true;










        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string supplierID = textBox1.Tag.ToString().Trim();
            string fulladdID = textBox7.Tag.ToString().Trim();
            string output = MaMall.execlppy("supplier","delete", supplierID, fulladdID);
            button3.Enabled = false;
            try
            {
                File.Delete("images\\supplier\\" + textBox1.Text.Trim() + ".jpg");
            }
            catch { }
            button2_Click(null, null);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
