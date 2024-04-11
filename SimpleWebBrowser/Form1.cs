using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// The author is Robert Lute
/// getrobertajob@gmail.com
/// 719-310-0055
/// 
/// This is just a very simple browser with basic functionality.
/// </summary>
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        /// <summary>
        /// This just initializes the form
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// This fuction is called when the about me menu item is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //This just displays a popup with my info
            MessageBox.Show("This program was made by Rober Lute");
        }

        /// <summary>
        /// This fuction is called when the exit menu item is selected and closes the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// This function is called when the click argument happens
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            NavigateToPage();
        }

        /// <summary>
        /// This is the core function that will perform all navigate and post processing
        /// </summary>
        private void NavigateToPage()
        {
            //Tool tip text, disables the url text box, navigates web browser object
            toolStripStatusLabel1.Text = "Navigation has started";
            textBox1.Enabled = false;
            webBrowser1.Navigate(textBox1.Text);
        }

        /// <summary>
        /// This function will fire every single time a key is pushed and released
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Checks if the enter key was pressed and navigates the web browser object if yes
            if (e.KeyChar == (char)ConsoleKey.Enter)
            {
                NavigateToPage();
            }
        }

        /// <summary>
        /// This function is run after the web browser object has loaded the url
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //Enables the button & url text box, updates tool tip text
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation Complete";
        }

        /// <summary>
        /// This function loads the progress bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            //Calculates the amount of progress
            if( e.CurrentProgress > 0 & e.MaximumProgress > 0)
            {
                toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
