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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        string profile="category" ;
        private void button1_Click(object sender, EventArgs e)
        {
            int saved;
            string adminId = this.Tag.ToString();
            string
                categoryname = textBox1.Text.Trim(),
                description = textBox2.Text.Trim().Replace(" ","_");
            if (profile != "category")
            {
                profile = categoryname;
            }

                string output;

            if (comboBox1.Visible == false)
                output = MaMall.execlppy("category", "add", categoryname, description,  profile,adminId);

            else
            {
                string categoryId = (comboBox1.SelectedItem as dynamic).Value;
                output = MaMall.execlppy("category","editinfo", categoryname, description, profile, categoryId);
                //string output1 = Form6.execlppy("getcategory");

                //string[] categoryItems = output1.Trim().Split(' ', '\n');

                //comboBox1.DisplayMember = "Text";
                //comboBox1.ValueMember = "Value";


                //for (int i = 0; i < categoryItems.Length; i = i + 2)
                //{
                //    comboBox1.Items.Add(new { Text = categoryItems[i] , Value = categoryItems[i + 1] });

                //}
            }
          //  MessageBox.Show(output);
            saved = int.Parse(output);

            if (saved >= 1)
            {

                if (profile != "category")
                {
                    try
                    {
                        File.Delete("images\\category\\" + profile + ".jpg");
                    }
                    catch { }
                    try { File.Copy(pictureBox1.Tag.ToString(), "images\\category\\" + profile + ".jpg"); }
                    catch { }
                }
                button1.Enabled = false;
            }
            else
            {
                switch (saved)
                {
                    case -1: MessageBox.Show("category name  is unuseful \ntry to change it"); break;


                }

            }





        }

        private void Form8_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;

            string output = MaMall.execlppy("category", "get");

            string[] categoryItems = output.Trim().Split(' ', '\n');

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";


            for (int i = 0; i < categoryItems.Length; i = i + 2)
            {
                comboBox1.Items.Add(new { Text = categoryItems[i] , Value = categoryItems[i +1] });

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
                profile = "takeitfromcategoryname";




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
            
            pictureBox1.Image = new Bitmap("images\\category\\category.jpg");
            pictureBox1.Tag = "category";

            button1.Enabled = true;








        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string output = MaMall.execlppy("category","getinf", (comboBox1.SelectedItem as dynamic).Value);//categoryID
            string[] properties = output.Trim().Split('\n');
            //MessageBox.Show("{0}", string.Join("\n", properties));

            textBox1.Text = properties[0];
            textBox2.Text = properties[1];
                                                                             

            textBox1.Tag = properties[4];
           


            pictureBox1.Image = new Bitmap("images\\category\\" + properties[2].Trim() + ".jpg");
            pictureBox1.Tag = properties[2].Trim();


            button3.Enabled = true;








        }

        private void button3_Click(object sender, EventArgs e)
        {
            string categoryId = textBox1.Tag.ToString().Trim();
            
            string output = MaMall.execlppy("category", "delete", categoryId);
            button3.Enabled = false;
            try
            {
                File.Delete("images\\category\\" + textBox1.Text.Trim() + ".jpg");
            }
            catch { }
            button2_Click(null, null);
        }
    }
}
