using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registration_ZhanzhouTa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //click button reset to clear all the informations
        private void btnReset_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            using (Form2 frm2 = new Form2())
            {
                this.Hide();
                //get the table information string
                string sendInformation = "First Name: " + textFirstName.Text +
                    "\r\nLast Name: " + textLastName.Text + "\r\nEmail: " + textEmail.Text +
                    "\r\nAddress: " + textAddress.Text + "\r\nCity: " + textCity.Text +
                    "\r\nPostal Code: " + textPostalCode.Text + "\r\nCountry: " + textCountry.Text +
                    "\r\nPhone: " + textPhone.Text;
                //send to form2
                frm2.DataToTransferForm2 = sendInformation;
                //save to file
                StreamWriter sw = File.AppendText(@"C:\Users\6151957\source\repos\Registration_ZhanzhouTa\\Registration.txt");
                sw.Write("\r\n***\r\n" + sendInformation);
                sw.Flush();
                sw.Close();
                //display by form2
                frm2.ShowDialog();
                //clear the table informations
                clearAll();
            }
            this.Show();
        }


        private void textFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textFirstName.Text))
            {
                e.Cancel = true;
                textFirstName.Focus();
                errorProvider1.SetError(textFirstName, "Please enter First Name.");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(textFirstName, null);
            }
        }

        private void textLastName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textLastName.Text))
            {
                e.Cancel = true;
                textLastName.Focus();
                errorProvider2.SetError(textLastName, "Please enter Last Name.");
            }
            else
            {
                e.Cancel = false;
                errorProvider2.SetError(textLastName, null);
            }
        }

        private void textEmail_Validating(object sender, CancelEventArgs e)
        {
            //check if the email is empty
            if (string.IsNullOrEmpty(textEmail.Text))
            {
                e.Cancel = true;
                textEmail.Focus();
                errorProvider3.SetError(textEmail, "Please enter Email.");
            }
            //check if the email is correct
            else if (!validEmail(textEmail.Text))
            {
                e.Cancel = true;
                textEmail.Focus();
                errorProvider3.SetError(textEmail, "Invalid Email");
            }
            else
            {
                e.Cancel = false;
                errorProvider3.SetError(textEmail, null);
            }
        }

        private void textPostalCode_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textPostalCode.Text))
            {
                e.Cancel = false;
                errorProvider4.SetError(textPostalCode, null);
            }
            else if (!validPostalCode(textPostalCode.Text))
            {
                e.Cancel = true;
                textPostalCode.Focus();
                errorProvider4.SetError(textEmail, "Invalid Postal Code");
            }
            else
            {
                e.Cancel = false;
                errorProvider4.SetError(textPostalCode, null);
            }
        }

        private void textPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textPhone.Text))
            {
                e.Cancel = false;
                errorProvider5.SetError(textPhone, null);
            }
            else if (!validPhoneNumber(textPhone.Text))
            {
                e.Cancel = true;
                textPhone.Focus();
                errorProvider5.SetError(textPhone, "Invalid Phone Number");
            }
            else
            {
                e.Cancel = false;
                errorProvider5.SetError(textPostalCode, null);
            }
        }  

        //method to check the email format
        private bool validEmail(string emailAddress)
        {
            if (emailAddress.IndexOf("@") > -1)
            {
                if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                {
                    return true;
                }
            }
            return false;
        }
        //method to check the postal code format
        private bool validPostalCode(string postalCode)
        {
            return Regex.IsMatch(postalCode ?? string.Empty, @"[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]");
        }
        //method to check the phone number format
        private bool validPhoneNumber(string phoneNumber)
        {
            var r = new Regex(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");
            return r.IsMatch(phoneNumber);
        }

        //method to clear the information of form1
        private void clearAll()
        {
            textFirstName.Clear();
            textLastName.Clear();
            textEmail.Clear();
            textAddress.Clear();
            textCity.Clear();
            textPostalCode.Clear();
            textCountry.Clear();
            textPhone.Clear();
        }
    }
}
