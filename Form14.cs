using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Drawing.Printing;
using Microsoft.VisualBasic;
using System.Net.Http;
using System.Net.Http.Headers;


namespace MAMall
{

    public partial class Form14 : Form
    {

        //ArrayList mycomboboxes = new ArrayList(10);
        //ArrayList mytextboxes = new ArrayList(10);
        Dictionary<string, int> dict = new Dictionary<string, int>(5);
        Dictionary<string, MaMall.Product> productdict = new Dictionary<string, MaMall.Product>(5);
        PrintDocument document = new PrintDocument();
        PrintDialog dialog = new PrintDialog();
        public Form14()
        {
            InitializeComponent();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);

        }
        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(richTextBox2.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, 20, 20);
        }
        private void button1_Click(object sender, EventArgs e)
        {

            int saved;

            string customerID;
            try
            {
                customerID = ((string)(comboBox2.SelectedItem as dynamic).Value).Trim();
                int.Parse(((string) (comboBox2.SelectedItem as dynamic).Value).Trim());
            }
            catch
            {
                customerID = "0";
            }
            customerID = customerID.Trim();

            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            string orderDate = dateTimePicker1.Text;
            dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;


            dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            string requiredDate = dateTimePicker2.Text;
            dateTimePicker2.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            string time = DateTime.Now.ToString("hh:mm:ss");

            string invoiceContents = "";
            //for(int i = 0; i < n-1; i++)
            //{
            //    invoiceContents += (((ComboBox)(mycomboboxes[i])).SelectedItem as dynamic).Value;
            //    invoiceContents += "_";
            //    invoiceContents += ((TextBox)mytextboxes[i]).Text.Trim();
            //    invoiceContents+="_";
            //}
            foreach(KeyValuePair<string,int> couple in dict)
            {
                invoiceContents += couple.Key;
                invoiceContents += "_";
                invoiceContents += couple.Value.ToString();
                invoiceContents += "_";
            }
            invoiceContents = invoiceContents.Trim();

          //  MessageBox.Show(invoiceContents);


            string userID = this.Tag.ToString();
            string output;
            if (comboBox1.Visible == false)
                output = MaMall.execlppy("invoice", "add", customerID, orderDate, requiredDate, userID, time, invoiceContents);

            else
            {
                string invoiceID = dateTimePicker1.Tag.ToString().Trim();
               // MessageBox.Show(userID);
                output = MaMall.execlppy("invoice","editinfo", customerID, orderDate, requiredDate, userID, time, invoiceContents,invoiceID);
              //  MessageBox.Show(output);

            }

            saved = int.Parse(output);

            if (saved >= 1)
            {

               
                button1.Enabled = false;
                ShowAllTheInvoicesOfTheShop(this.Tag.ToString().Trim());

                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();

                dialog.Document = document;
                 if (dialog.ShowDialog() == DialogResult.OK)
                       {
                           document.Print();
                       }
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ////MessageBox.Show(((TextBox)mytextboxes[0]).Text);
            button1.Enabled = true;
            //n = 0;
            //for (int i = 0; i < mycomboboxes.Count; i++)
            //{
            //    Controls.Remove((ComboBox)mycomboboxes[i]);
            //    Controls.Remove((TextBox)mytextboxes[i]);
            //}
            //mytextboxes.Clear();
            //mycomboboxes.Clear();

            dict.Clear();
            richTextBox2.Text = "";

            if (comboBox1.Visible == false)
            {
                richTextBox2.AppendText(string.Format("{0,-25}{1,-18}{2}\r\n", "", "MaMAll", ""));
                richTextBox2.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", "", "", ""));
                richTextBox2.AppendText(string.Format("{0,-30}{1,-18}{2}\r\n", DateTime.Now.ToString("dd   MMMM.yyyy"), "", ""));
                richTextBox2.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", DateTime.Now.ToString("hh:mm:ss"), "", ""));
                richTextBox2.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", "", "", ""));
            }

        }

        int nbProduct = 0;
        void ShowAllTheInvoicesOfTheShop(string userID)
        {
            richTextBox1.Text = String.Empty;

            Dictionary<string, MaMall.Invoice> invoicesdict = new Dictionary<string, MaMall.Invoice>(9);//id,invoice

            string output = MaMall.execlppy("invoice", "ShowAllTheInvoicesOfTheShop", userID);
            string[] invoiceItems = output.Trim().Split('\n');
            //MessageBox.Show(invoiceItems[0]);
            //MessageBox.Show(invoiceItems[1]);
            //MessageBox.Show(invoiceItems[2]);
            //MessageBox.Show(invoiceItems[3]);
            //MessageBox.Show(invoiceItems[4]);
            //MessageBox.Show(invoiceItems[5]);
            //MessageBox.Show(invoiceItems[6]);
            //MessageBox.Show(invoiceItems[7]);

            string[] properties;
            MaMall.Invoice invoice;
            MaMall.ProductInvoice prod;
            int qty;

            invoice.productdict = new Dictionary<MaMall.ProductInvoice, int>(8);
            int k = invoiceItems.Length;
            if (k == 1) k = 0;
            if (k!=0){
                foreach (string raw in invoiceItems)
                {

                    properties = raw.Trim().Split(' ');


                    if (!invoicesdict.ContainsKey(properties[0].Trim()))
                    {


                        invoice.productdict = new Dictionary<MaMall.ProductInvoice, int>(8);


                        invoice.id = properties[0].Trim();
                        invoice.order_date = properties[1].Trim();
                        invoice.time = properties[2].Trim();
                        prod.name = properties[3].Trim();
                        qty = int.Parse(properties[4].Trim());
                        prod.unitPrice = properties[5].Trim();
                        prod.discount = properties[6].Trim();
                        prod.id = properties[9].Trim();
                        invoice.productdict.Add(prod, qty);
                        invoice.userID = properties[8].Trim();
                        invoicesdict.Add(invoice.id, invoice);

                    }
                    else
                    {
                        prod.name = properties[3].Trim();
                        qty = int.Parse(properties[4].Trim());
                        prod.unitPrice = properties[5].Trim();
                        prod.discount = properties[6].Trim();
                        prod.id = properties[9].Trim();
                        invoicesdict[properties[0].Trim()].productdict.Add(prod, qty);

                    }


                } }

            foreach(KeyValuePair<string,MaMall.Invoice> couple in invoicesdict)
            {
                richTextBox1.AppendText(string.Format("{0,-25}{1,-18}{2}\r\n", "", "MaMAll", ""));
                richTextBox1.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", "", "", ""));
                richTextBox1.AppendText(string.Format("{0,-30}{1,-18}{2}\r\n", couple.Value.id, "", ""));
                richTextBox1.AppendText(string.Format("{0,-30}{1,-18}{2}\r\n", couple.Value.order_date, "", ""));
                richTextBox1.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", couple.Value.time, "", ""));
                richTextBox1.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", "", "", ""));

                double totalPrice = 0, totalPriceWithDicount = 0;
                foreach (KeyValuePair<MaMall.ProductInvoice, int> couplePro in couple.Value.productdict)
                {
                    totalPrice += double.Parse(couplePro.Key.unitPrice.Trim())*couplePro.Value;
                    double priceDouble = (double.Parse(couplePro.Key.unitPrice.Trim()) - (double.Parse(couplePro.Key.discount.Trim()) / 100) * double.Parse(couplePro.Key.unitPrice.Trim())) * couplePro.Value;
                    totalPriceWithDicount += priceDouble;
                    string price = priceDouble.ToString();
                    // MessageBox.Show(couplePro.Key.name + " " + couple.Key);
                    richTextBox1.AppendText(string.Format("• {0,-17}x {1,-18}{2}\r\n", couplePro.Key.name, couplePro.Value, couplePro.Value * priceDouble));
                }



                richTextBox1.AppendText("________________\r\n");
                richTextBox1.AppendText(string.Format("  {0,-17}{1,-17}{2,-11}  $\r\n", "", "", "-" + totalPrice + "-"));
                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.SelectionLength = 0;

                richTextBox1.SelectionColor = Color.Red;
                richTextBox1.AppendText(string.Format("  {0,-17}{1,-18}{2,-10}  $\r\n", "", "", totalPriceWithDicount));
                richTextBox1.SelectionColor = richTextBox1.ForeColor;

                richTextBox1.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", "", "", ""));

                richTextBox1.SelectionStart = richTextBox1.TextLength;
                richTextBox1.SelectionLength = 0;

                richTextBox1.SelectionColor = Color.BlueViolet;
                richTextBox1.AppendText("___________________________\r\n");
                richTextBox1.SelectionColor = richTextBox1.ForeColor;




            }






        }
        private void Form14_Load(object sender, EventArgs e)
        {
           





            ShowAllTheInvoicesOfTheShop(this.Tag.ToString().Trim());

            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();

            string userId = this.Tag.ToString().Trim();
            string output;
            string[] properties;
            output = MaMall.execlppy("product", "getdetails", userId);
            string[] productItems = output.Trim().Split('\n');
            foreach (string raw in productItems)
            {

                properties = raw.Trim().Split(' ');

                MaMall.Product prod;

                PictureBox pic = new PictureBox();
                pic.Image = new Bitmap(@"images\product\" + properties[4] + ".jpg");
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Size = new Size(150, 150);
                pic.BorderStyle = BorderStyle.Fixed3D;
                pic.Left = 30 + (pic.Width+20) * (nbProduct % 3);
                pic.Top = 40 + (pic.Height + 50) * (nbProduct / 3);
                pic.MouseClick += picMouseClick;
                
                panel1.Controls.Add(pic);
                nbProduct++;

                prod.id= properties[1];

                Label namedesc = new Label();
                namedesc.Text = properties[0]+" :"+ properties[2];
                namedesc.Left = pic.Left;
                namedesc.Top = pic.Top + pic.Height;
                panel1.Controls.Add(namedesc);

                prod.name= properties[0];
                
                prod.desc= properties[2];

                Label Price = new Label();
                

                double price = double.Parse(properties[3].Trim()) - (double.Parse(properties[5].Trim()) / 100) * double.Parse(properties[3].Trim());
                Price.Text ="$ "+ price.ToString();
                Price.Left = pic.Left;
                Price.Top = pic.Top + pic.Height + namedesc.Height ;
                panel1.Controls.Add(Price);

                prod.unitPrice= properties[3];

                

                prod.discount= properties[5];

               

                prod.discType= properties[6];

                pic.Tag = prod;
                productdict.Add(prod.id, prod);





        

            }

            if (comboBox1.Visible == false)
            {
                richTextBox2.AppendText(string.Format("{0,-25}{1,-18}{2}\r\n", "", "MaMAll", ""));
                richTextBox2.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", "", "", ""));
                richTextBox2.AppendText(string.Format("{0,-30}{1,-18}{2}\r\n", DateTime.Now.ToString("dd   MMMM.yyyy"), "", ""));
                richTextBox2.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", DateTime.Now.ToString("hh:mm:ss"), "", ""));
                richTextBox2.AppendText(string.Format("{0,-17}{1,-18}{2}\r\n", "", "", ""));

            }


            //copy load

            button3.Enabled = false;

            dateTimePicker2.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;

            //when edit invoice
             output = MaMall.execlppy("invoice","get",this.Tag.ToString());

            string[] invoiceItems = output.Trim().Split(' ', '\n');

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            int k = invoiceItems.Length;
            if (k == 1) k = 0;


            for (int i = 0; i < k; i = i + 2)
            {
                comboBox1.Items.Add(new { Text = invoiceItems[i] , Value = invoiceItems[i + 1] });

            }

            output = MaMall.execlppy("customer","get");
            //MessageBox.Show(output);
            string[] customerItems = output.Trim().Split(' ', '\n');

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";


            for (int i = 0; i < customerItems.Length; i = i + 3)
            {
                comboBox2.Items.Add(new { Text = customerItems[i]+" "+ customerItems[i+1]  , Value = customerItems[i + 2] });

            }

            //end when edit invoice 

        }
        private void mouseOverTheDiscType(object sender, EventArgs e)
        {
            toolTip1.Show(((Label)sender).Tag.ToString(),(Label)sender);
        }
        
        private void picMouseClick(object sender, MouseEventArgs e)
        {
            richTextBox2.Lines = richTextBox2.Lines.Where(line => !line.Contains("________")).ToArray();
            richTextBox2.Lines = richTextBox2.Lines.Where(line => !line.Contains("$")).ToArray();

            double priceDouble = double.Parse(((MaMall.Product)(((PictureBox)sender).Tag)).unitPrice.Trim()) - (double.Parse(((MaMall.Product)(((PictureBox)sender).Tag)).discount.Trim()) / 100) * double.Parse(((MaMall.Product)(((PictureBox)sender).Tag)).unitPrice.Trim());
            string price=priceDouble.ToString();
            // MessageBox.Show(((MaMall.Product)(((PictureBox)sender).Tag)).name);
            if (dict.ContainsKey(((MaMall.Product)(((PictureBox)sender).Tag)).id))
            {

                switch (e.Button)
                {
                    case MouseButtons.Right:
                        {
                           string qt= Interaction.InputBox("number of this product?", "Fast fill", "1");
                            try {
                                dict[((MaMall.Product)(((PictureBox)sender).Tag)).id] = int.Parse(qt.Trim());
                            }
                            catch
                            {

                            }
                        }
                        break;
                    default: dict[((MaMall.Product)(((PictureBox)sender).Tag)).id] += 1;break;

                }


                richTextBox2.Lines = richTextBox2.Lines.Where(line => !line.Contains(((MaMall.Product)(((PictureBox)sender).Tag)).name)).ToArray();
                richTextBox2.AppendText(string.Format("• {0,-17}x {1,-18}{2}\r\n", ((MaMall.Product)(((PictureBox)sender).Tag)).name,  dict[((MaMall.Product)(((PictureBox)sender).Tag)).id] , dict[((MaMall.Product)(((PictureBox)sender).Tag)).id]* priceDouble));
               // MessageBox.Show(textBox1.Lines[i]);
            }


            else
            {

                switch (e.Button)
                {
                    case MouseButtons.Right:
                        {
                            string qt = Interaction.InputBox("number of this product?", "Fast fill", "1");
                            try
                            {
                                dict.Add(((MaMall.Product)(((PictureBox)sender).Tag)).id, int.Parse(qt.Trim()));
                            }
                            catch
                            {

                            }

                        }
                        break;
                    default: dict.Add(((MaMall.Product)(((PictureBox)sender).Tag)).id, 1);
                        //MessageBox.Show(dict[((MaMall.Product)(((PictureBox)sender).Tag)).id].ToString());
                        break;

                }
                richTextBox2.AppendText(string.Format("• {0,-17}x {1,-18}{2}\r\n", ((MaMall.Product)(((PictureBox)sender).Tag)).name, dict[((MaMall.Product)(((PictureBox)sender).Tag)).id], price));
            }



            double totalPrice = 0, totalPriceWithDicount = 0;
            richTextBox2.AppendText("________________________\r\n");
            
                foreach (KeyValuePair<string, int> couple in dict)
                {
                     //MessageBox.Show(couple.Key);
                    totalPrice += double.Parse(productdict[couple.Key].unitPrice) * couple.Value;
                    totalPriceWithDicount += double.Parse(productdict[couple.Key].unitPrice) * couple.Value * (100 - double.Parse(productdict[couple.Key].discount)) / 100;
                }

            

            richTextBox2.AppendText(string.Format("  {0,-17}{1,-17}{2,-11}  $\r\n", "", "","-"+ totalPrice+"-"));
            richTextBox2.SelectionStart = richTextBox2.TextLength;
            richTextBox2.SelectionLength = 0;

            richTextBox2.SelectionColor = Color.Red;
            richTextBox2.AppendText(string.Format("  {0,-17}{1,-18}{2,-10}  $\r\n", "", "", totalPriceWithDicount));
            richTextBox2.SelectionColor = richTextBox2.ForeColor;



        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2_Click(null, null);

            string output = MaMall.execlppy("invoice","getinf", (comboBox1.SelectedItem as dynamic).Value);//invoiceID
            string[] properties = output.Trim().Split('\n');
            //MessageBox.Show("{0}", string.Join("\n", properties));
           

            dateTimePicker1.Tag = properties[0];


            dateTimePicker1.Value = DateTime.ParseExact(properties[2].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateTimePicker1.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;

          

            dateTimePicker2.Value = DateTime.ParseExact(properties[3].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture);
            dateTimePicker2.CustomFormat = "dd   MMMM    .yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;

            string customerId = properties[1];
            try
            {
               // MessageBox.Show(customerId);
                int.Parse(customerId.Trim());
                int Selected = 0;
                int count = comboBox2.Items.Count;
                for (int i = 0; i <= count - 1; i++)
                {
                    comboBox2.SelectedIndex = i;
                    if (((string)((comboBox2.SelectedItem as dynamic).Value)).Trim() == customerId.Trim())
                    {
                        Selected = i;
                        break;
                    }

                }

                comboBox2.SelectedIndex = Selected;

            }
            catch
            {
                // MessageBox.Show("noitem");
                comboBox2.SelectedIndex = -1;
            }



            string productId, qty;string[] arr;
            dict.Clear();

            for (int j = 4; j < properties.Length; j++)
            {
                arr = properties[j].Trim().Split(' ');
                productId = arr[0];
                qty = arr[1];



                dict.Add(productId.Trim(), int.Parse(qty.Trim()));
                double priceDouble = double.Parse(productdict[productId.Trim()].unitPrice.Trim()) - (double.Parse(productdict[productId.Trim()].discount.Trim()) / 100) * double.Parse(productdict[productId.Trim()].unitPrice.Trim());
                string price = priceDouble.ToString();
                richTextBox2.AppendText(string.Format("• {0,-17}x {1,-18}{2}\r\n", productdict[productId].name, qty, double.Parse(qty.Trim()) * priceDouble));
            }
                double totalPrice = 0, totalPriceWithDicount = 0;
                richTextBox2.AppendText("________________________\r\n");

                foreach (KeyValuePair<string, int> couple in dict)
                {
                    //MessageBox.Show(couple.Key);
                    totalPrice += double.Parse(productdict[couple.Key].unitPrice) * couple.Value;
                    totalPriceWithDicount += double.Parse(productdict[couple.Key].unitPrice) * couple.Value * (100 - double.Parse(productdict[couple.Key].discount)) / 100;
                }



                richTextBox2.AppendText(string.Format("  {0,-17}{1,-17}{2,-11}  $\r\n", "", "", "-" + totalPrice + "-"));
                richTextBox2.SelectionStart = richTextBox2.TextLength;
                richTextBox2.SelectionLength = 0;

                richTextBox2.SelectionColor = Color.Red;
                richTextBox2.AppendText(string.Format("  {0,-17}{1,-18}{2,-10}  $\r\n", "", "", totalPriceWithDicount));
                richTextBox2.SelectionColor = richTextBox2.ForeColor;


            

                button3.Enabled = true;


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string invoiceId = dateTimePicker1.Tag.ToString().Trim();
            
            string output = MaMall.execlppy("invoice", "delete", invoiceId);
            button3.Enabled = false;
           
            button2_Click(null, null);
        }
    }

}
