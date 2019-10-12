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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string shopId;
        private void Form4_Load(object sender, EventArgs e)
        {
            string userId = this.Tag.ToString().Trim();
            string output = MaMall.execlppy("employee", "user", userId);
            //MessageBox.Show(output);
            string[] properties = output.Trim().Split('\n');

            label1.Text = properties[7];
            //MessageBox.Show(properties[7]); MessageBox.Show(properties[6]);

            pictureBox2.Image = new Bitmap("images\\employee\\" + properties[6].Trim() + ".jpg");
            pictureBox2.Tag = properties[6].Trim();

            string output1 = MaMall.execlppy("shop", "specificshop", userId);
            //MessageBox.Show(output1);
            string[] properties1 = output1.Trim().Split('\n');

            label2.Text = properties1[0];
            //MessageBox.Show(properties[7]); MessageBox.Show(properties[6]);

            pictureBox1.Image = new Bitmap("images\\shop\\" + properties1[0].Trim() + ".jpg");
            pictureBox1.Tag = properties1[0].Trim();

            shopId = properties1[3];
        }

        private void addGoodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.label19.Visible = false;
            f7.comboBox1.Visible = false;
            f7.button3.Visible = false;
            f7.ShowDialog();
        }

        private void changePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            f7.label19.Visible = true;
            f7.comboBox1.Visible = true;
            f7.button3.Visible = true;
            f7.ShowDialog();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Tag = this.Tag.ToString();//userId
            f11.label19.Visible = false;
            f11.comboBox1.Visible = false;
            f11.button3.Visible = false;
            f11.ShowDialog();
        }

        private void changePropertiesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Tag = this.Tag.ToString();//userId
            f11.label19.Visible = true;
            f11.comboBox1.Visible = true;
            f11.button3.Visible = true;
            f11.ShowDialog();
        }

        private void addGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Tag = this.Tag.ToString();//userId
            f12.label19.Visible = false;
            f12.comboBox1.Visible = false;
            f12.button3.Visible = false;
            f12.ShowDialog();
        }

        private void changePropertiesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Tag = this.Tag.ToString();//userId
            f12.label19.Visible = true;
            f12.comboBox1.Visible = true;
            f12.button3.Visible = true;
            f12.ShowDialog();
        }


        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Tag = this.Tag.ToString();//userId
            f13.label19.Visible = false;
            f13.comboBox1.Visible = false;
            f13.button3.Visible = false;
            f13.ShowDialog();
        }

        private void changePropertiesToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13();
            f13.Tag = this.Tag.ToString();//userId
            f13.label19.Visible = true;
            f13.comboBox1.Visible = true;
            f13.button3.Visible = true;
            f13.ShowDialog();
        }

        private void addInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Tag = this.Tag.ToString();//userId
            f14.label19.Visible = false;
            f14.comboBox1.Visible = false;
            f14.button3.Visible = false;
            f14.ShowDialog();
        }

        private void changePropertiesToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Form14 f14 = new Form14();
            f14.Tag = this.Tag.ToString();//userId
            f14.label19.Visible = true;
            f14.comboBox1.Visible = true;
            f14.button3.Visible = true;
            f14.ShowDialog();
        }

        private void addOfferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Tag = this.Tag.ToString();//userId
            f15.label19.Visible = false;
            f15.comboBox1.Visible = false;
            f15.button3.Visible = false;
            f15.ShowDialog();
        }

        private void changePropertiesToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Form15 f15 = new Form15();
            f15.Tag = this.Tag.ToString();//userId
            f15.label19.Visible = true;
            f15.comboBox1.Visible = true;
            f15.button3.Visible = true;
            f15.ShowDialog();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaMall.execlppy("shop", "shop_supplier", "plot", shopId);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MaMall.execlppy("shop", "shop_supplier", "export", shopId);
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                // ...
                File.Copy("temp.csv", folderPath + @"\data.csv");
            }
        }

        private void viewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MaMall.execlppy("supplier", "supplier_products", "plot", shopId);

        }

        private void exportToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            MaMall.execlppy("supplier", "supplier_products", "export", shopId);
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                // ...
                File.Copy("temp.csv", folderPath + @"\data.csv");
            }
        }

        private void viewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MaMall.execlppy("product", "product_groups", "plot", shopId);

        }

        private void exportToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            MaMall.execlppy("product", "product_groups", "export", shopId);
            OpenFileDialog folderBrowser = new OpenFileDialog();
            // Set validate names and check file exists to false otherwise windows will
            // not let you select "Folder Selection."
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            // Always default to Folder Selection.
            folderBrowser.FileName = "Folder Selection.";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string folderPath = Path.GetDirectoryName(folderBrowser.FileName);
                // ...
                File.Copy("temp.csv", folderPath + @"\data.csv");
            }
        }

        private void myShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void salesVolumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void salariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "salaries.shop";
            f16.dataGridView1.Tag = this.Tag ;
            f16.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void usersToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void volumeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "sales.volume.shop";
            f16.dataGridView1.Tag = this.Tag.ToString();
            f16.ShowDialog();
        }

        private void operationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "operations";
            f16.dataGridView1.Tag = this.Tag.ToString();
            f16.ShowDialog();
        }

        private void customerByHourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "avgCustByHoursInAShop";
            f16.dataGridView1.Tag = this.Tag.ToString();
            f16.ShowDialog();
        }

        private void customerByWeekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "customerInShopInWeek";
            f16.dataGridView1.Tag = this.Tag.ToString();
            f16.ShowDialog();
        }

        private void showAllGroupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.Tag = this.Tag.ToString();//userId
            f17.panel1.Tag = "ShopGroup";
            f17.ShowDialog();
        }

        private void availableProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.Tag = this.Tag.ToString();//userId
            f17.panel1.Tag = "ProductInStock";
            f17.ShowDialog();
        }

        private void usersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            f16.Tag = "emplinf";
            f16.dataGridView1.Tag = this.Tag;
            f16.ShowDialog();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            f17.Tag = this.Tag.ToString();//userId
            f17.panel1.Tag = "productInThisShop";
            f17.ShowDialog();
        }
    }
}
