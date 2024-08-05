using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using Microsoft.Web.WebView2.Core;

namespace MyWinFormsApp
{
    public partial class Form1 : Form
    {
        private WebView2 webView2;
        private ToolStrip toolBar;
        private ToolStripButton backButton;
        private ToolStripButton forwardButton;
        private ToolStripButton refreshButton;
        private ToolStripButton homeButton;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // Initialize toolbar
            toolBar = new ToolStrip();
            backButton = new ToolStripButton("后退", null, BackButton_Click) { DisplayStyle = ToolStripItemDisplayStyle.Text };
            forwardButton = new ToolStripButton("前进", null, ForwardButton_Click) { DisplayStyle = ToolStripItemDisplayStyle.Text };
            refreshButton = new ToolStripButton("刷新", null, RefreshButton_Click) { DisplayStyle = ToolStripItemDisplayStyle.Text };
            homeButton = new ToolStripButton("回到导航系统", null, HomeButton_Click) { DisplayStyle = ToolStripItemDisplayStyle.Text };

            toolBar.Items.Add(backButton);
            toolBar.Items.Add(forwardButton);
            toolBar.Items.Add(refreshButton);
            toolBar.Items.Add(homeButton);

            // Initialize WebView2
            webView2 = new WebView2
            {
                Dock = DockStyle.Fill
            };
            webView2.NavigationCompleted += WebView2_NavigationCompleted;
            webView2.CoreWebView2InitializationCompleted += WebView2_CoreWebView2InitializationCompleted;
            webView2.Source = new Uri("http://101.133.229.203/");

            // Add controls to the form
            Controls.Add(webView2);
            Controls.Add(toolBar);

            // Set form properties
            Text = "多用户网址导航系统";
            WindowState = FormWindowState.Maximized;
        }

        private void BackButton_Click(object? sender, EventArgs e)
        {
            if (webView2.CanGoBack)
            {
                webView2.GoBack();
            }
        }

        private void ForwardButton_Click(object? sender, EventArgs e)
        {
            if (webView2.CanGoForward)
            {
                webView2.GoForward();
            }
        }

        private void RefreshButton_Click(object? sender, EventArgs e)
        {
            webView2.Reload();
        }

        private void HomeButton_Click(object? sender, EventArgs e)
        {
            webView2.Source = new Uri("http://101.133.229.203/");
        }

        private void WebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            // Optional: You can update the form title or other UI elements here.
        }

        private void WebView2_CoreWebView2InitializationCompleted(object? sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            webView2.CoreWebView2.NewWindowRequested += CoreWebView2_NewWindowRequested;
        }

        private void CoreWebView2_NewWindowRequested(object? sender, CoreWebView2NewWindowRequestedEventArgs e)
        {
            e.Handled = true;
            webView2.CoreWebView2.Navigate(e.Uri);
        }
    }
}
