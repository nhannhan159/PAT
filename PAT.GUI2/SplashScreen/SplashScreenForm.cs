﻿using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using PAT.Common.Utility;
using PAT.GUI.Properties;

namespace PAT.GUI.SplashScreen
{
    public partial class SplashScreenForm : Form
    {

        delegate void StringParameterDelegate(string Text);
        delegate void StringParameterWithStatusDelegate(string Text, TypeOfMessage tom);
        delegate void SplashShowCloseDelegate();

        /// <summary>
        /// To ensure splash screen is closed using the API and not by keyboard or any other things
        /// </summary>
        bool CloseSplashScreenFlag = false;

        public SplashScreenForm()
        {
            InitializeComponent();
            textLabel.Parent = pictureBox;
            textLabel.BackColor = Color.Transparent;
            versionLabel.Parent = pictureBox;
            versionLabel.BackColor = Color.Transparent;
            versionLabel.Text += Common.Utility.Utilities.AssemblyVersion(Assembly.GetExecutingAssembly());

            Label_FullName.Parent = pictureBox;
            Label_FullName.BackColor = Color.Transparent;
            Label_FullName.Text = Common.Utility.Utilities.APPLICATION_FULL_NAME;
            Label_RegistrationInfo.Text = "";




            progressBar.Parent = pictureBox;
            progressBar.Show();
        }

        /// <summary>
        /// Displays the splashscreen
        /// </summary>
        public void ShowSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(ShowSplashScreen));
                return;
            }
            this.Show();
            Application.Run(this);
        }

        /// <summary>
        /// Closes the SplashScreen
        /// </summary>
        public void CloseSplashScreen()
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new SplashShowCloseDelegate(CloseSplashScreen));
                return;
            }
            CloseSplashScreenFlag = true;
            this.Close();
        }

        /// <summary>
        /// Update text in default green color of success message
        /// </summary>
        /// <param name="text">Message</param>
        public void UdpateStatusText(string text)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UdpateStatusText), new object[] { text });
                return;
            }
            // Must be on the UI thread if we've got this far
            textLabel.Text = text;
        }
        /// <summary>
        /// Update text with message color defined as green/yellow/red/ for success/warning/failure
        /// </summary>
        /// <param name="text">Message</param>
        /// <param name="tom">Type of Message</param>
        public void UdpateStatusTextWithStatus(string text, TypeOfMessage tom)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterWithStatusDelegate(UdpateStatusTextWithStatus), new object[] { text, tom });
                return;
            }
            // Must be on the UI thread if we've got this far
            switch (tom)
            {
                case TypeOfMessage.Error:
                    textLabel.ForeColor = Color.Red;
                    break;
                case TypeOfMessage.Warning:
                    textLabel.ForeColor = Color.Yellow;
                    break;
                case TypeOfMessage.Success:
                    textLabel.ForeColor = Color.Green;
                    break;
            }
            textLabel.Text = Text;
        }

        /// <summary>
        /// Prevents the closing of form other than by calling the CloseSplashScreen function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SplashForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CloseSplashScreenFlag == false)
                e.Cancel = true;
        }
    }
}
