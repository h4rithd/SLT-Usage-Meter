using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mshtml;
using System.Threading;
using System;



namespace SLT_Usage_Meter
{
    public partial class Form1 : Form
    {
             
        public Form1()
        {
            InitializeComponent();
            Clipboard.Clear();
            this.Size = new Size(310, 10);
            
            webBrowser1.Navigate("https://www.internetvas.slt.lk/SLTVasPortal-war/application/login.nable");
            webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_DocumentCompleted);
            
        }

        public void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.Size = new Size(312, 392);
           
            CopyClip();
            getClip();


        }


        private void getClip() {

            Image cImage = Clipboard.GetImage();
            pictureBox1.Image = (Image)cImage;
            
        }

        public void CopyClip() {

            try
            {
                string image_name = "temp.bmp";
                IHTMLDocument2 document = (IHTMLDocument2)webBrowser1.Document.DomDocument;
                IHTMLControlRange imgRange = (IHTMLControlRange)((HTMLBody)document.body).createControlRange();
                Clipboard.Clear();
                imgRange.add(document.all.item("loginfrm:j_idt11"));
                imgRange.execCommand("Copy");
                using (Bitmap bmp = (Bitmap)Clipboard.GetDataObject().GetData(DataFormats.Bitmap))
                {
                    bmp.Save(image_name);
                }
               
            }
            catch (Exception x) {
               
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            
            String userName = txtUser.Text;
            String passWord = txtPass.Text;
            String vCode = txtVCode.Text;

            webBrowser1.Document.GetElementById("loginfrm:chngusername").SetAttribute("Value", userName);
            webBrowser1.Document.GetElementById("loginfrm:chngpassword").SetAttribute("Value", passWord);
            webBrowser1.Document.GetElementById("loginfrm:chngcaptchs").SetAttribute("Value", vCode);

            webBrowser1.Document.GetElementById("loginfrm:logbtn").InvokeMember("Click");

            MessageBox.Show("Click Get Result Button ! :)");
            geReseut();
            final();

        }


        public void geReseut() {

           
            webBrowser1.Navigate("https://www.internetvas.slt.lk/SLTVasPortal-war/application/usage.nable");
                       
        }

        public void final() {

            HtmlElementCollection theElementCollection = default(HtmlElementCollection);
            theElementCollection = webBrowser1.Document.GetElementsByTagName("div");

            foreach (HtmlElement curElement in theElementCollection)
            {
                if (curElement.GetAttribute("className").ToString() == "i_detail_peak")
                {
                    lblTotal.Text = curElement.GetAttribute("InnerText");

                }

            }
            foreach (HtmlElement curElement in theElementCollection)
            {
                if (curElement.GetAttribute("className").ToString() == "i_detail")
                {
                    label10.Text = curElement.GetAttribute("InnerText");

                }

            }

        }




        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
                      
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            
                    }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            HtmlElementCollection theElementCollection = default(HtmlElementCollection);
            theElementCollection = webBrowser1.Document.GetElementsByTagName("div");

            foreach (HtmlElement curElement in theElementCollection)
            {
                if (curElement.GetAttribute("className").ToString() == "i_detail_peak")
                {
                    //ssageBox.Show(curElement.GetAttribute("InnerText"));
                    lblTotal.Text = curElement.GetAttribute("InnerText");
                    // Do something you want

                }

            }
            foreach (HtmlElement curElement in theElementCollection)
            {
                if (curElement.GetAttribute("className").ToString() == "i_detail")
                {
                    //ssageBox.Show(curElement.GetAttribute("InnerText"));
                    label10.Text = curElement.GetAttribute("InnerText");
                    // Do something you want

                }

            }
        }
    }

}
