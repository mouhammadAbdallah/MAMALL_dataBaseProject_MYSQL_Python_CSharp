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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        string profile;
        private void button1_Click(object sender, EventArgs e)
        {
            int saved;
            string adminId = this.Tag.ToString();
            string
                shopname = textBox1.Text.Trim(),
                description = textBox2.Text.Trim().Replace(" ","_"),
                floor = textBox3.Text.Trim(),
                categoryId;
            try { categoryId = (comboBox2.SelectedItem as dynamic).Value; }
            catch { categoryId = "0"; }


            if (profile != "shop")
            {
                profile = shopname;
            }

            string output;

            if (comboBox1.Visible == false)
                output = MaMall.execlppy("shop","add", shopname, description, floor,profile, adminId,categoryId);

            else
            {
                string shopId = (comboBox1.SelectedItem as dynamic).Value;
                output = MaMall.execlppy("shop","editinfo", shopname, description, floor, profile, adminId, categoryId,shopId);
                //string output1 = Form6.execlppy("getshop");

                //string[] shopItems = output1.Trim().Split(' ', '\n');

                //comboBox1.DisplayMember = "Text";
                //comboBox1.ValueMember = "Value";


                //for (int i = 0; i < shopItems.Length; i = i + 2)
                //{
                //    comboBox1.Items.Add(new { Text = shopItems[i], Value = shopItems[i + 1] });

                //}
            }
            //  MessageBox.Show(output);
            saved = int.Parse(output);

            if (saved >= 1)
            {

                if (profile != "category")
                {

                    try { File.Delete("images\\shop\\" + profile + ".jpg"); }
                    catch { }
                    try
                    {
                        File.Copy(pictureBox1.Tag.ToString(), "images\\shop\\" + profile + ".jpg");
                    }
                    catch { }
                }
                button1.Enabled = false;
            }
            else
            {
                switch (saved)
                {
                    case -1: MessageBox.Show("shop name or category are unuseful \ntry to change them"); break;


                }

            }



        }

        private void Form10_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button3.Enabled = false;
            string output = MaMall.execlppy("shop","get");

            string[] shopItems = output.Trim().Split(' ', '\n');

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";


            for (int i = 0; i < shopItems.Length; i = i + 2)
            {
                comboBox1.Items.Add(new { Text = shopItems[i], Value = shopItems[i + 1] });

            }

            string output1 = MaMall.execlppy("category","get");

            string[] categoryItems = output1.Trim().Split(' ', '\n');

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";


            for (int i = 0; i < categoryItems.Length; i = i + 2)
            {
                comboBox2.Items.Add(new { Text = categoryItems[i], Value = categoryItems[i + 1] });

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
                profile = "takeitfromshopname";




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

            pictureBox1.Image = new Bitmap("images\\shop\\shop.jpg");
            pictureBox1.Tag = "shop";

            comboBox2.Text = "";
            button1.Enabled = true;

            pictureBox2.Image = new Bitmap("images\\category\\category.jpg");
            pictureBox2.Tag = "category";


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string output = MaMall.execlppy("shop","getinf", (comboBox1.SelectedItem as dynamic).Value);//shopID
            string[] properties = output.Trim().Split('\n');
            //MessageBox.Show(output);

            textBox1.Text = properties[0];
            textBox2.Text = properties[1];
            textBox3.Text = properties[4];
            string categoryID = properties[5].Trim();
            textBox1.Tag = properties[6];



            pictureBox1.Image = new Bitmap("images\\shop\\" + properties[2].Trim() + ".jpg");
            pictureBox1.Tag = properties[2].Trim();

            int Selected = 0;
            int count = comboBox2.Items.Count;
            for (int i = 0; (i <= (count - 1)); i++)
            {
                comboBox2.SelectedIndex = i;
                

                    if (    ((string)((comboBox2.SelectedItem as dynamic).Value)).Trim() == categoryID)
                {
                    Selected = i;
                    break;
                }

            }

            comboBox2.SelectedIndex = Selected;
            button3.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string shopId = textBox1.Tag.ToString().Trim();

            string output = MaMall.execlppy("shop","delete", shopId);
            button3.Enabled = false;
            try
            {
                File.Delete("images\\shop\\" + textBox1.Text.Trim() + ".jpg");
            }
            catch { }
            button2_Click(null, null);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = new Bitmap(@"images\category\" + (comboBox2.SelectedItem as dynamic).Text + ".jpg");
            }
            catch
            {
                pictureBox2.Image = new Bitmap(@"images\category\category.jpg");
            }
        }
    }
}
