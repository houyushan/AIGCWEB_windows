using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace MyWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var webView2 = new WebView2
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(webView2);
            webView2.Source = new Uri("http://101.133.229.203/");
        }
    }
}
