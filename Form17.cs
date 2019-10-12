using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace MAMall
{
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        int nbProduct = 0, nbempend=0, nbGroup = 0, nbPro=0, nbSupp=0, nbProductma=0, nbshopma=0, nbcatma=0, nbemp=0;
        private void Form17_Load(object sender, EventArgs e)
        {







            string userId = this.Tag.ToString().Trim();

            switch (panel1.Tag.ToString())
            {
                case "endEmployee":
                    {
                        string output;
                        string[] properties;
                        output = MaMall.execlppy("employee", "endEmployee");
                        string[] empendItems = output.Trim().Split('\n');
                        foreach (string raw in empendItems)
                        {
                            properties = raw.Trim().Split(' ');

                            PictureBox pic = new PictureBox();
                            pic.Image = new Bitmap(@"images\employee\" + properties[2] + ".jpg");
                            pic.Tag = properties[2];
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Size = new Size(240, 200);
                            pic.BorderStyle = BorderStyle.Fixed3D;
                            pic.Left = 40 + (pic.Width + 40) * (nbempend % 3);
                            pic.Top = 40 + (pic.Height + 120) * (nbempend / 3);
                            panel1.Controls.Add(pic);
                            nbempend++;



                            Label name = new Label();
                            name.Width = pic.Width;
                            name.Text = properties[0] + " " + properties[1];
                            name.Left = pic.Left;
                            name.Top = pic.Top + pic.Height;
                            panel1.Controls.Add(name);


                            Label desc = new Label();
                            desc.Width = pic.Width;
                            desc.Text = properties[3];
                            desc.Left = pic.Left;
                            desc.Top = pic.Top + pic.Height + name.Height;
                            panel1.Controls.Add(desc);


                            Label unitPrice = new Label();
                            unitPrice.Width = pic.Width;

                            unitPrice.Text = properties[4].Trim();
                            unitPrice.Left = pic.Left;
                            unitPrice.Top = pic.Top + pic.Height + name.Height + desc.Height;
                            panel1.Controls.Add(unitPrice);


                            Label discount = new Label();//discount means here the price after the discount
                            discount.Text = properties[5];
                            discount.Width = pic.Width;

                            discount.Left = pic.Left;
                            discount.Top = pic.Top + pic.Height + name.Height + desc.Height + unitPrice.Height;
                            panel1.Controls.Add(discount);





                        }

                        break;
                    }
                case "allEmp":
                    {

                        string output;
                        string[] properties;
                        output = MaMall.execlppy("employee", "allEmp");
                        string[] empItems = output.Trim().Split('\n');
                        foreach (string raw in empItems)
                        {
                            properties = raw.Trim().Split(' ');

                            PictureBox pic = new PictureBox();
                            pic.Image = new Bitmap(@"images\employee\" + properties[2] + ".jpg");
                            pic.Tag = properties[2];
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Size = new Size(240, 200);
                            pic.BorderStyle = BorderStyle.Fixed3D;
                            pic.Left = 90 + (pic.Width + 40) * (nbemp % 3);
                            pic.Top = 40 + (pic.Height + 120) * (nbemp / 3);
                            panel1.Controls.Add(pic);
                            nbemp++;



                            Label name = new Label();
                            name.Width = pic.Width;
                            name.Text = properties[0]+" " +properties[1];
                            name.Left = pic.Left;
                            name.Top = pic.Top + pic.Height;
                            panel1.Controls.Add(name);


                            Label desc = new Label();
                            desc.Width = pic.Width;
                            desc.Text = properties[3];
                            desc.Left = pic.Left;
                            desc.Top = pic.Top + pic.Height + name.Height;
                            panel1.Controls.Add(desc);


                            Label unitPrice = new Label();
                            unitPrice.Width = pic.Width;

                            unitPrice.Text = properties[4].Trim();
                            unitPrice.Left = pic.Left;
                            unitPrice.Top = pic.Top + pic.Height + name.Height + desc.Height;
                            panel1.Controls.Add(unitPrice);


                            Label discount = new Label();//discount means here the price after the discount
                            discount.Text = properties[5];
                            discount.Width = pic.Width;

                            discount.Left = pic.Left;
                            discount.Top = pic.Top + pic.Height + name.Height + desc.Height + unitPrice.Height;
                            panel1.Controls.Add(discount);


                          


                        }

                        break;
                    }
                case "allCategory":
                    {
                        string output;
                        string[] properties;
                        output = MaMall.execlppy("category", "allCategory");
                        string[] catItems = output.Trim().Split('\n');
                        foreach (string raw in catItems)
                        {
                            properties = raw.Trim().Split(' ');

                            PictureBox pic = new PictureBox();
                            pic.Image = new Bitmap(@"images\category\" + properties[1].Trim() + ".jpg");
                            pic.Tag = properties[1];
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Size = new Size(160, 160);
                            pic.BorderStyle = BorderStyle.Fixed3D;
                            pic.Left = 40 + (pic.Width + 80) * (nbcatma % 4);
                            pic.Top = 40 + (pic.Height + 50) * (nbcatma / 4);
                            panel1.Controls.Add(pic);
                            nbcatma++;



                            Label name = new Label();
                            name.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);
                            name.Width = pic.Width;

                            name.Text =" "+ properties[0];
                            name.Left = pic.Left;
                            name.Top = pic.Top + pic.Height;
                            panel1.Controls.Add(name);


                          



                        }
                        break;
                    }
                case "allShop":
                    {
                        string output;
                        string[] properties;
                        output = MaMall.execlppy("shop", "allShop");
                        string[] shopItems = output.Trim().Split('\n');
                        foreach (string raw in shopItems)
                        {
                            properties = raw.Trim().Split(' ');

                            PictureBox pic = new PictureBox();
                            pic.Image = new Bitmap(@"images\shop\" + properties[1] + ".jpg");
                            pic.Tag = properties[1];
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Size = new Size(160, 160);
                            pic.BorderStyle = BorderStyle.Fixed3D;
                            pic.Left = 40 + (pic.Width + 80) * (nbshopma % 4);
                            pic.Top = 40 + (pic.Height + 80) * (nbshopma / 4);
                            panel1.Controls.Add(pic);
                            nbshopma++;



                            Label name = new Label();
                            name.Text = properties[0];
                            name.Left = pic.Left;
                            name.Top = pic.Top + pic.Height;
                            name.Width = pic.Width;
                            panel1.Controls.Add(name);


                            Label desc = new Label();
                            desc.Width = pic.Width;

                            desc.Text = properties[2];
                            desc.Left = pic.Left;
                            desc.Top = pic.Top + pic.Height + name.Height;
                            panel1.Controls.Add(desc);



                        }

                        break;

                    }
                case "productinthemall":
                    {

                        string output;
                        string[] properties;
                        output = MaMall.execlppy("product", "productinthemall", userId);
                        string[] productItems = output.Trim().Split('\n');
                        foreach (string raw in productItems)
                        {
                            properties = raw.Trim().Split(' ');

                            PictureBox pic = new PictureBox();
                            pic.Image = new Bitmap(@"images\product\" + properties[4] + ".jpg");
                            pic.Tag = properties[1];
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Size = new Size(200, 200);
                            pic.BorderStyle = BorderStyle.Fixed3D;
                            pic.Left = 40 + (pic.Width + 30) * (nbProductma % 4);
                            pic.Top = 40 + (pic.Height + 120) * (nbProductma / 4);
                            panel1.Controls.Add(pic);
                            nbProductma++;



                            Label name = new Label();
                            name.Width = pic.Width;
                            name.Text = properties[0];
                            name.Left = pic.Left;
                            name.Top = pic.Top + pic.Height;
                            panel1.Controls.Add(name);


                            Label desc = new Label();
                            desc.Width = pic.Width;
                            desc.Text = "desc: "+properties[2];
                            desc.Left = pic.Left;
                            desc.Top = pic.Top + pic.Height + name.Height;
                            panel1.Controls.Add(desc);


                            Label unitPrice = new Label();
                            unitPrice.Width = pic.Width;
                            if (double.Parse(properties[5].Trim()) != 0)
                                unitPrice.Text = properties[3];
                            else unitPrice.Text = "-";
                            unitPrice.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Strikeout | FontStyle.Italic);
                            unitPrice.Left = pic.Left;
                            unitPrice.Top = pic.Top + pic.Height + name.Height + desc.Height;
                            panel1.Controls.Add(unitPrice);


                            Label discount = new Label();//discount means here the price after the discount
                            discount.Width = pic.Width;
                            double price = double.Parse(properties[3].Trim()) - (double.Parse(properties[5].Trim()) / 100) * double.Parse(properties[3].Trim());
                            discount.Text = price.ToString();
                            discount.Left = pic.Left;
                            discount.Top = pic.Top + pic.Height + name.Height + desc.Height + unitPrice.Height;
                            panel1.Controls.Add(discount);


                            Label discType = new Label();
                            discType.Width = pic.Width;
                            if (properties[6] != "None")
                                discType.Text ="offerDesc: "+ properties[6];
                            else discType.Text = "-";
                            discType.Tag = properties[6];
                            discType.Left = pic.Left;
                            discType.Top = pic.Top + pic.Height + name.Height + desc.Height + unitPrice.Height + discount.Height;
                            discType.MouseHover += new System.EventHandler(mouseOverTheDiscType);
                            panel1.Controls.Add(discType);


                        }

                        break;
                    }
                case "AllSupplier":
                    {
                        string output;
                        string[] properties;
                        output = MaMall.execlppy("supplier", "AllSupplier");
                        string[] SuppItems = output.Trim().Split('\n');
                        foreach (string raw in SuppItems)
                        {
                            properties = raw.Trim().Split(' ');

                            PictureBox pic = new PictureBox();
                            pic.Image = new Bitmap(@"images\supplier\" + properties[1] + ".jpg");
                            pic.Tag = properties[1];
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Size = new Size(200, 200);
                            pic.BorderStyle = BorderStyle.Fixed3D;
                            pic.Left = 30 + (pic.Width + 40) * (nbSupp % 4);
                            pic.Top = 40 + (pic.Height + 90) * (nbSupp / 4);
                            panel1.Controls.Add(pic);
                            nbSupp++;



                            Label name = new Label();
                            name.Text = properties[0];
                            name.Width = pic.Width;
                            name.Left = pic.Left;
                            name.Top = pic.Top + pic.Height;
                            panel1.Controls.Add(name);


                            Label desc = new Label();
                            desc.Width = pic.Width;

                            desc.Text = properties[2];
                            desc.Left = pic.Left;
                            desc.Top = pic.Top + pic.Height + name.Height;
                            panel1.Controls.Add(desc);

                        }

                        break;
                    }
                case "ProductInStock":
                    {
                        string output;
                        string[] properties;
                        output = MaMall.execlppy("product", "ProductInStock", userId);
                        string[] productItems = output.Trim().Split('\n');
                        foreach (string raw in productItems)
                        {
                            properties = raw.Trim().Split(' ');

                            PictureBox pic = new PictureBox();
                            pic.Image = new Bitmap(@"images\product\" + properties[1] + ".jpg");
                            pic.Tag = properties[1];
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Size = new Size(200, 200);
                            pic.BorderStyle = BorderStyle.Fixed3D;
                            pic.Left = 150 + (pic.Width + 40) * (nbPro % 3);
                            pic.Top = 40 + (pic.Height + 60) * (nbPro / 3);
                            panel1.Controls.Add(pic);
                            nbPro++;



                            Label name = new Label();
                            name.Text = properties[0];
                            name.Left = pic.Left;
                            name.Top = pic.Top + pic.Height;
                            panel1.Controls.Add(name);


                            Label desc = new Label();
                            desc.Width = pic.Width;
                            desc.Text = properties[2]+" units in stock";
                            desc.Left = pic.Left;
                            desc.Top = pic.Top + pic.Height + name.Height;
                            panel1.Controls.Add(desc);

                        }

                        break;
                    }
                case "productInThisShop":
                    {

                        string output;
                        string[] properties;
                        output = MaMall.execlppy("product", "getdetails", userId);
                        string[] productItems = output.Trim().Split('\n');
                        foreach (string raw in productItems)
                        {
                            properties = raw.Trim().Split(' ');

                            PictureBox pic = new PictureBox();
                            pic.Image = new Bitmap(@"images\product\" + properties[4] + ".jpg");
                            pic.Tag = properties[1];
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Size = new Size(200, 200);
                            pic.BorderStyle = BorderStyle.Fixed3D;
                            pic.Left = 150 + (pic.Width + 40) * (nbProduct % 3);
                            pic.Top = 40 + (pic.Height + 120) * (nbProduct / 3);
                            panel1.Controls.Add(pic);
                            nbProduct++;



                            Label name = new Label();
                            name.Text = properties[0];
                            name.Left = pic.Left;
                            name.Top = pic.Top + pic.Height;
                            panel1.Controls.Add(name);


                            Label desc = new Label();
                            desc.Text = properties[2];
                            desc.Left = pic.Left;
                            desc.Top = pic.Top + pic.Height + name.Height;
                            panel1.Controls.Add(desc);


                            Label unitPrice = new Label();
                            if (double.Parse(properties[5].Trim()) != 0)
                                unitPrice.Text = properties[3];
                            else unitPrice.Text = "-";
                            unitPrice.Font = new Font(this.Font.FontFamily, this.Font.Size, FontStyle.Strikeout | FontStyle.Italic);
                            unitPrice.Left = pic.Left;
                            unitPrice.Top = pic.Top + pic.Height + name.Height + desc.Height;
                            panel1.Controls.Add(unitPrice);


                            Label discount = new Label();//discount means here the price after the discount
                            double price = double.Parse(properties[3].Trim()) - (double.Parse(properties[5].Trim()) / 100) * double.Parse(properties[3].Trim());
                            discount.Text = price.ToString();
                            discount.Left = pic.Left;
                            discount.Top = pic.Top + pic.Height + name.Height + desc.Height + unitPrice.Height;
                            panel1.Controls.Add(discount);


                            Label discType = new Label();
                            if (properties[6] != "None")
                                discType.Text = properties[6];
                            else discType.Text = "-";
                            discType.Tag = properties[6];
                            discType.Left = pic.Left;
                            discType.Top = pic.Top + pic.Height + name.Height + desc.Height + unitPrice.Height + discount.Height;
                            discType.MouseHover += new System.EventHandler(mouseOverTheDiscType);
                            panel1.Controls.Add(discType);


                        }

                        break;
                    }
                case "ShopGroup":
                    {
                        string output;
                        string[] properties;
                        output = MaMall.execlppy("group", "ShopGroup", userId);
                        string[] groupItems = output.Trim().Split('\n');
                        foreach (string raw in groupItems)
                        {
                            properties = raw.Trim().Split(' ');

                            PictureBox pic = new PictureBox();
                            pic.Image = new Bitmap(@"images\product\" + properties[5] + ".jpg");
                            pic.Tag = properties[0];
                            pic.SizeMode = PictureBoxSizeMode.StretchImage;
                            pic.Size = new Size(200, 200);
                            pic.BorderStyle = BorderStyle.Fixed3D;
                            pic.Left = 150 + (pic.Width + 40) * (nbGroup % 3);
                            pic.Top = 40 + (pic.Height + 120) * (nbGroup / 3);
                            panel1.Controls.Add(pic);
                            nbGroup++;



                            Label groupId = new Label();
                            groupId.Text = "id: "+properties[0];
                            groupId.Left = pic.Left;
                            groupId.Top = pic.Top + pic.Height;
                            panel1.Controls.Add(groupId);


                            Label prodName = new Label();
                            prodName.Text = properties[1];
                            prodName.Left = pic.Left;
                            prodName.Top = pic.Top + pic.Height + groupId.Height;
                            panel1.Controls.Add(prodName);


                            Label qty = new Label();
                            qty.Text ="qty: "+  properties[2];
                            qty.Left = pic.Left;
                            qty.Top = pic.Top + pic.Height + groupId.Height + prodName.Height;
                            panel1.Controls.Add(qty);


                            Label dateBuy = new Label();//discount means here the price after the discount
                            dateBuy.Text = properties[3];
                            dateBuy.Left = pic.Left;
                            dateBuy.Top = pic.Top + pic.Height + groupId.Height + prodName.Height + qty.Height;
                            panel1.Controls.Add(dateBuy);


                            Label dateExp = new Label();

                            dateExp.Text ="exp:"+ properties[4];
                            dateExp.Left = pic.Left;
                            dateExp.Top = pic.Top + pic.Height+ groupId.Height + prodName.Height + qty.Height + dateBuy.Height;
                            panel1.Controls.Add(dateExp);

                        }
                        break;

                    }


            }
        }
        private void mouseOverTheDiscType(object sender, EventArgs e)
        {
            toolTip1.Show(((Label)sender).Tag.ToString(), (Label)sender);
        }
    }
}
