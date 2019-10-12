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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.label19.Visible = false;
            f6.comboBox1.Visible = false;
            f6.button3.Visible = false;
            f6.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Tag = this.Tag.ToString();
            f9.ShowDialog();
        }

        private void changePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.label19.Visible = true;
            f6.comboBox1.Visible = true;
            f6.button3.Visible = true;
            f6.ShowDialog();
           
        }

        private void addCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Tag = this.Tag.ToString();
            f8.label19.Visible = false;
            f8.comboBox1.Visible = false;
            f8.button3.Visible = false;
            f8.ShowDialog();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changePropertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.label19.Visible = true;
            f8.comboBox1.Visible = true;
            f8.button3.Visible = true;
            f8.ShowDialog();
        }

     

        private void addShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Tag = this.Tag.ToString();
            f10.label19.Visible = false;
            f10.comboBox1.Visible = false;
            f10.button3.Visible = false;
            f10.ShowDialog();
        }

        private void changePropertiesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Tag = this.Tag.ToString();
            f10.label19.Visible = true;
            f10.comboBox1.Visible = true;
            f10.button3.Visible = true;
            f10.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
          
        }



        private void Form3_Load(object sender, EventArgs e)
        {
            string adminId = this.Tag.ToString().Trim();
            string output = MaMall.execlppy("employee", "admin", adminId);
            //MessageBox.Show(output);
            string[] properties = output.Trim().Split('\n');
      
            label1.Text = properties[7];
            //MessageBox.Show(properties[7]); MessageBox.Show(properties[6]);



            pictureBox2.Image = new Bitmap("images\\employee\\" + properties[6].Trim() + ".jpg");
            pictureBox2.Tag = properties[6].Trim();

        }



 

        private void shopsAndUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "shop.shop_user";
            f16.ShowDialog();
        }

        private void categoriesAndShopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "category.category_shop";
            f16.ShowDialog();
        }

        private void salesVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "sales.volume";
            f16.ShowDialog();
        }

        private void shopsupplierproductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "shop.supplier.product";
            f16.ShowDialog();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.Delete("temp.csv");
            }
            catch { }

        }

        private void salariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "salaries.shop";
            f16.dataGridView1.Tag = "0";
            f16.ShowDialog();
        }

        private void employeeInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "emplinf";
            f16.dataGridView1.Tag = 0;
            
            f16.ShowDialog();
        }

        private void shopSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.panel1.Tag = "AllSupplier";
            f17.Tag = this.Tag.ToString();//userId
            f17.ShowDialog();
        }

        private void allProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.panel1.Tag = "productinthemall";
            f17.Tag = this.Tag.ToString();//userId
            f17.ShowDialog();
        }

        private void allShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.panel1.Tag = "allShop";
            f17.Tag = this.Tag.ToString();//userId
            f17.ShowDialog();
        }

        private void allCAtegoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.panel1.Tag = "allCategory";
            f17.Tag = this.Tag.ToString();//userId
            f17.ShowDialog();
        }

        private void allEmplolyeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.panel1.Tag = "allEmp";
            f17.Tag = this.Tag.ToString();//userId
            f17.ShowDialog();
        }

        private void endEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.panel1.Tag = "endEmployee";
            f17.Tag = this.Tag.ToString();//userId
            f17.ShowDialog();
        }
    }
    }

