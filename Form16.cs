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
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
namespace MAMall
{
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "untitled";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {

                File.Copy("temp.xlsx", folderBrowser.FileName + ".xlsx");
            }

            string fileExcel;
            fileExcel = folderBrowser.FileName + ".xlsx";
            Excel.Application xlapp;
            Excel.Workbook xlworkbook;
            xlapp = new Excel.Application();

            xlworkbook = xlapp.Workbooks.Open(fileExcel, 0, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

            xlapp.Visible = true;
        }

        private void Form16_Load(object sender, EventArgs e)
        {

            switch (this.Tag.ToString().Trim())
            {
                case "customerInShopInWeek":
                    {
                        MaMall.execlppy("invoice", "customerInShopInWeek", "view", dataGridView1.Tag.ToString());

                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();
                        break;
                    }
                case "avgCustByHoursInAShop":
                    {
                        MaMall.execlppy("invoice", "avgCustByHoursInAShop", "view", dataGridView1.Tag.ToString());

                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();
                        break;

                    }
                case "operations":
                    {
                        MaMall.execlppy("invoice", "operation", "view", dataGridView1.Tag.ToString());

                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();
                        button1.Visible = false;

                        break;

                    }
                case "emplinf":
                    {
                        MaMall.execlppy("employee", "emplinf", "view",dataGridView1.Tag.ToString());

                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();
                        button1.Visible = false;
                        break;
                    }
                case "shop.shop_user":
                    {
                        MaMall.execlppy("shop", "shop_user", "view");

                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();

                        break;

                    }
                case "category.category_shop":
                    {
                        MaMall.execlppy("category", "category_shop", "view","0");

                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;

                        con.Close();
                        comboBox1.Visible = true;
                        string output = MaMall.execlppy("category", "get");

                        string[] categoryItems = output.Trim().Split(' ', '\n');

                        comboBox1.DisplayMember = "Text";
                        comboBox1.ValueMember = "Value";


                        for (int i = 0; i < categoryItems.Length; i = i + 2)
                        {
                            comboBox1.Items.Add(new { Text = categoryItems[i], Value = categoryItems[i + 1] });

                        }
                        break;

                    }
                case "sales.volume":
                    {
                        MaMall.execlppy("shop", "shop_prices", "view");
                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();
                        break;
                    }
                case "sales.volume.shop":
                    {
                        MaMall.execlppy("product", "product_prices", "view", dataGridView1.Tag.ToString());//userId
                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();
                        break;
                    }
                case "shop.supplier.product":
                    {
                        MaMall.execlppy("shop", "shopSupplierProduct", "0");//all shop
                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();
                        comboBox1.Visible = true;button1.Visible = false;
                        string output = MaMall.execlppy("shop", "get");

                        string[] shopItems = output.Trim().Split(' ', '\n');

                        comboBox1.DisplayMember = "Text";
                        comboBox1.ValueMember = "Value";


                        for (int i = 0; i < shopItems.Length; i = i + 2)
                        {
                            comboBox1.Items.Add(new { Text = shopItems[i], Value = shopItems[i + 1] });

                        }
                        break;
                    }
                case "salaries.shop":
                    {
                        MaMall.execlppy("shop", "salaries_shop", "0",this.dataGridView1.Tag.ToString());//all shop or userId
                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();
                        if (this.dataGridView1.Tag.ToString() == "0")
                        {
                            comboBox1.Visible = true;
                        }
                        button1.Visible = false;
                        string output = MaMall.execlppy("shop", "get");

                        string[] shopItems = output.Trim().Split(' ', '\n');

                        comboBox1.DisplayMember = "Text";
                        comboBox1.ValueMember = "Value";


                        for (int i = 0; i < shopItems.Length; i = i + 2)
                        {
                            comboBox1.Items.Add(new { Text = shopItems[i], Value = shopItems[i + 1] });

                        }
                        break;
                    }
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (this.Tag.ToString().Trim())
            {
                case "shop.shop_user":
                    MaMall.execlppy("shop", "shop_user", "plot");
                    break;
                case "category.category_shop":
                    MaMall.execlppy("category", "category_shop", "plot");
                    break;
                case "sales.volume":
                    MaMall.execlppy("shop", "shop_prices", "plot");
                    break;
                case "sales.volume.shop":
                    MaMall.execlppy("product", "product_prices", "plot", dataGridView1.Tag.ToString());//userId
                    break;
                case "avgCustByHoursInAShop":
                    MaMall.execlppy("invoice", "avgCustByHoursInAShop", "plot", dataGridView1.Tag.ToString());//userId
                    break;
                case "customerInShopInWeek":
                    MaMall.execlppy("invoice", "customerInShopInWeek", "plot", dataGridView1.Tag.ToString());//userId
                    break;
            }



        }

        private void Form16_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.Delete("temp.xlsx");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (this.Tag.ToString().Trim())
            {

                case "shop.supplier.product":
                    {
                        MaMall.execlppy("shop", "shopSupplierProduct", (comboBox1.SelectedItem as dynamic).Value);//shopID
                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;
                        con.Close();
                        comboBox1.Visible = true;
                        comboBox1.Items.Clear();
                        string output = MaMall.execlppy("shop", "get");

                        string[] shopItems = output.Trim().Split(' ', '\n');

                        comboBox1.DisplayMember = "Text";
                        comboBox1.ValueMember = "Value";


                        for (int i = 0; i < shopItems.Length; i = i + 2)
                        {
                            comboBox1.Items.Add(new { Text = shopItems[i], Value = shopItems[i + 1] });

                        }
                        break;
                    }
                case "category.category_shop":
                    {
                        button1.Visible = false;
                        MaMall.execlppy("category", "category_shop", "view", (comboBox1.SelectedItem as dynamic).Value);//categoryID

                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;

                        con.Close();
                        comboBox1.Visible = true;
                        string output = MaMall.execlppy("category", "get");

                        string[] categoryItems = output.Trim().Split(' ', '\n');

                        comboBox1.DisplayMember = "Text";
                        comboBox1.ValueMember = "Value";


                        for (int i = 0; i < categoryItems.Length; i = i + 2)
                        {
                            comboBox1.Items.Add(new { Text = categoryItems[i], Value = categoryItems[i + 1] });

                        }
                        break;

                    }
                case "salaries.shop":
                    {
                        MaMall.execlppy("shop", "salaries_shop", (comboBox1.SelectedItem as dynamic).Value,"0");//shopId

                        string file = "temp.xlsx";

                        String name = "Sheet1";
                        String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                        file +
                                        ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                        OleDbConnection con = new OleDbConnection(constr);
                        OleDbCommand oconn = new OleDbCommand("Select * From [" + name + "$]", con);
                        con.Open();

                        OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                        DataTable data = new DataTable();
                        sda.Fill(data);
                        dataGridView1.DataSource = data;

                        con.Close();
                        string output = MaMall.execlppy("shop", "get");

                        string[] shopItems = output.Trim().Split(' ', '\n');

                        comboBox1.DisplayMember = "Text";
                        comboBox1.ValueMember = "Value";


                        for (int i = 0; i < shopItems.Length; i = i + 2)
                        {
                            comboBox1.Items.Add(new { Text = shopItems[i], Value = shopItems[i + 1] });

                        }
                        break;

                    }
            }
        }
    }
}
