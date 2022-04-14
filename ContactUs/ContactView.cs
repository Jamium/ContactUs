﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ContactUs
{
    public partial class ContactView : Form
    {
        bool IsNewContact = true;
        
        public ContactView()
        {
            InitializeComponent();
            CenterToScreen();
        }

        private void lbFName_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pbSendMail_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start($"mailto:{rtxtEmailAddresses.Text}");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //MessageBoxButtons.YesNo
            //MessageBox.Show();
            DialogResult dialogResult = MessageBox.Show("If you have unsaved progress, click No below to return & save it.\r\n Any unsaved data will be lost.\r\nDo you want to continue exiting?", "Are you sure you want to exit?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //this.Hide();
                System.Windows.Forms.Application.Exit();
            }
            else if (dialogResult == DialogResult.No)
            {
                //Hide();
            }
        }

        private void ContactView_Load(object sender, EventArgs e)
        {

        }

        private void btnChangeContactImage_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            var inDir = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = inDir + "\\Pictures";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    pbContactPicture.Image = new Bitmap(openFileDialog.FileName);

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    //using (StreamReader reader = new StreamReader(fileStream))
                    //{
                    //    fileContent = reader.ReadToEnd();
                    //}
                }
            }

            //MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
            //pbContactPicture.Image = fileContent;
        }

        private void txtFName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFName.Text))
            {
                txtFName.Text = txtFName.Text.Trim();
                txtFName.Text = (char.ToUpper(txtFName.Text[0]) + txtFName.Text.Substring(1));
            }

            titleUpdater();
            
        }

        private void txtLName_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtLName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtFName.Text))
            {
                txtLName.Text = txtLName.Text.Trim();
                txtLName.Text = (char.ToUpper(txtLName.Text[0]) + txtLName.Text.Substring(1));
            }

            titleUpdater();
            
        }

        private void rtxtEmailAddresses_Leave(object sender, EventArgs e)
        {
            if (!rtxtEmailAddresses.Text.Contains("@"))
            {
                MessageBox.Show("The email you have entered is invalid, you can still continue if you like.", "Warning: Invalid Email");
            }
        }

        private void rtxtPhoneNumbers_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtPhoneNumbers_Leave(object sender, EventArgs e)
        {
            //if (!rtxtEmailAddresses.Text.Contains("@"))
            //{
            //    MessageBox.Show("The email you have entered is invalid, you can still continue if you like.", "Warning: Invalid Email");
            //}
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void titleUpdater()
        {
            lbTitle.Text = ($"{txtFName.Text} {txtLName.Text}");
        }

        private void Saver(int currentContactLineNumber)
        {
            if (IsNewContact == true)
            {
                //Add new line
            }
            else
            {
                //Edit current line
                lineChanger("", "", currentContactLineNumber);
            }
        }

        static void lineChanger(string newText, string fileName, int line_to_edit) //Changes a certain line of a certain text file (used for changing the user's password in txtUsers.txt).
        {
            string[] arrLine = File.ReadAllLines(fileName);
            //arrLine[line_to_edit - 1] = newText;
            arrLine[line_to_edit] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Hide();
            new Login().Show();
        }
    }
}
