using ClassLibraryModel;
using Microsoft.Reporting.WinForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodePrinter
{
    public partial class Barcode : Form
    {
        public Barcode()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = ZoomMode.FullPage;
            this.reportViewer1.ZoomPercent = 100;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                btnGenerate.Enabled = false;
                btnGenerate.Text = "Generating, Please wait......";
                List<vmProductDetails> _objData = new List<vmProductDetails>();
                var _objProduct = GetProduc();
                foreach (var sitem in _objProduct)
                {
                    this.Text = sitem.detailsid.ToString();

                    //Encode
                    Image img = barcode.Encode(BarcodeLib.TYPE.CODE128, sitem.detailsid, Color.Black, Color.Transparent, 635, 105);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, ImageFormat.Png);
                        _objData.Add(new vmProductDetails
                        {
                            detailsid = sitem.detailsid,
                            sizename = sitem.sizename,
                            offerprice = sitem.offerprice,
                            codeimage = ms.ToArray()
                        });

                        //Save Generated Image
                        string tempfolder = @"C:\barcode\";
                        if (!Directory.Exists(tempfolder))
                            Directory.CreateDirectory(tempfolder);
                        string filepath = tempfolder + sitem.detailsid + ".png";
                        img.Save(filepath, ImageFormat.Png);

                        //Display Generated Image
                        barcodeImagePanel.BackgroundImageLayout = ImageLayout.Center;
                        var _img = resizeImage(img, new Size(235, 39));
                        barcodeImagePanel.BackgroundImage = _img;
                    }

                    Application.DoEvents();
                }

                this.reportViewer1.LocalReport.ReportPath = "barcode.rdlc";
                ReportDataSource rds = new ReportDataSource("DataSetBarcode", _objData);
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
                btnGenerate.Enabled = true;
                btnGenerate.Text = "Generate Barcode";
                this.Text = "Barcode Generator";
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public List<vmProductDetails> GetProduc()
        {
            List<vmProductDetails> objProductDetails = null;
            try
            {
                objProductDetails = new List<vmProductDetails>()
                {
                    new vmProductDetails(){ id = 1, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XXL" },
                    new vmProductDetails(){ id = 2, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 3, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "S" },
                    new vmProductDetails(){ id = 4, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 5, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 6, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 7, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 8, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 9, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 10, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 11, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 12, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 13, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 14, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 15, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 16, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 17, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XXL" },
                    new vmProductDetails(){ id = 18, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 19, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "S" },
                    new vmProductDetails(){ id = 20, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 21, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 22, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 23, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 24, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 25, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 26, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 27, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 28, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 29, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 30, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 31, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 32, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 33, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 34, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 35, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 36, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 37, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 38, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 39, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 40, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 41, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 42, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 43, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" },
                    new vmProductDetails(){ id = 44, detailsid = GenerateRandomNumber(6).ToString(), offerprice = GenerateRandomNumber(2), sizename = "XL" }
                };
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return objProductDetails;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public static Int64 GenerateRandomNumber(int size)
        {
            Random random = new Random((int)DateTime.Now.Ticks);
            StringBuilder builder = new StringBuilder();
            string s;
            for (int i = 0; i < size; i++)
            {
                s = Convert.ToString(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(s);
            }

            return Convert.ToInt64((builder.ToString()));
        }
    }
}
