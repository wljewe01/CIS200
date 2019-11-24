// Program 2
// CIS 200-01
// Fall 2018
// Due: 10/25/2018
// By: D8649
// File: AddressForm.cs
// This file allows the user to enter 
// values for the addresses that they 
// wish to use and validates the input. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog2
{

    public partial class AddressForm : Form
    {

        // Precondition:  None
        // Postcondition: The Address GUI is initialized
        public AddressForm()
        {
            InitializeComponent();
        }


        internal string NameInputValue// Accessible by other classes in same namespace
        {
            //Precondition:  None
            //Postcondition: Text in nameTextBox is returned
            get
            {
                return nameTextBox.Text;
            }
            //Precondition:  None
            //Postcondition: Text in nameTextBox is set to specified value
            set
            {
                nameTextBox.Text = value;
            }
        }



        internal string Address1InputValue // Accessible by other classes in same namespace
        {
            //Precondition: None
            //Postcondition: Text in address1TextBox is returned
            get
            {
                return address1TextBox.Text;
            }
            // Precondition:  None
            // Postcondition: Text in address1TextBox is set to specified value
            set
            {
                address1TextBox.Text = value;
            }
        }

        internal string Address2InputValue // Accessible by other classes in same namespace
        {
            //Precondition:  None
            //Postcondition: Text in address2TextBox is returned
            get
            {
                return address2TextBox.Text;
            }
            // Precondition:  None
            // Postcondition: Text in address2TextBox is set to specified value
            set
            {
                address2TextBox.Text = value;
            }
        }

        internal string CityInputValue// Accessible by other classes in same namespace
        {
            //Precondition:  None
            //Postcondition: Text in cityTextBox is returned
            get
            {
                return cityTextBox.Text;
            }
            // Precondition:  None
            // Postcondition: Text in cityTextBox is set to specified value
            set
            {
                cityTextBox.Text = value;
            }
        }

        internal string StateInputValue // Accessible by other classes in same namespace
        {
            //Precondition:  None
            //Postcondition: Text in stateComboBox is returned
            get
            {
                return stateComboBox.Text;
            }
            // Precondition:  None
            // Postcondition: Text in stateComboBox is set to specified value
            set
            {
                stateComboBox.Text = value;
            }
        }

        internal string ZipInputValue // Accessible by other classes in same namespace
        {
            //Precondition:  None
            //Postcondition: Text in zipTextBox is returned
            get
            {
                return zipTextBox.Text;
            }
            // Precondition:  None
            // Postcondition: Text in zipTextBox is set to specified value
            set
            {
                zipTextBox.Text = value;
            }
        }


        //Precondition: Attempting to change focus from nameTextBox 
        //Postcondition: If entered value is valid string, focus will change
        //                else, focus will remain and error provider message
        private void nameText_Validating(object sender, CancelEventArgs e)
        {
            string name;// Value entered into nameTextBox

            //will test if string has white space or is null
            //If true, stops focus from changing process and won't
            //proceed to validated event
            //if false, focus will change 
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))

            {
                e.Cancel = true; // Stops focus changing process
                                // Will NOT proceed to Validated event
                errorProvider1.SetError(nameTextBox, "Enter an string!");
                nameTextBox.SelectAll(); // Select all text in nameTextBox to ease correction

            }
            else { name = nameTextBox.Text; }
        }

        //Precondition: attempting to change focus from address1TextBox 
        //Postcondition: If entered value is valid string, focus will change
        //                else, focus will remain and error provider message
        private void address1Text_Validating(object sender, CancelEventArgs e)
        {
            string address1;

            if (string.IsNullOrWhiteSpace(address1TextBox.Text))

            {
                address1 = address1TextBox.Text;
                e.Cancel = true;// Stops focus changing process
                                // Will NOT proceed to Validated event
                errorProvider1.SetError(address1TextBox, "Enter an address!");
                address1TextBox.SelectAll(); // Select all text in address1TextBox to ease correction

            }
        }

        //Precondition: attempting to change focus from cityTextBox 
        //Postcondition: If entered value is valid string, focus will change
        //                else, focus will remain and error provider message
        private void cityText_Validating(object sender, CancelEventArgs e)
        {
            string city;

            if (string.IsNullOrWhiteSpace(cityTextBox.Text))

            {
                city = cityTextBox.Text;
                e.Cancel = true;
                errorProvider1.SetError(cityTextBox, "Enter an string!");
                cityTextBox.SelectAll(); // Select all text in cityTextBox to ease correction

            }
        }

        //Precondition: attempting to change focus from stateComboBox 
        //Postcondition: If entered value is valid string, focus will change
        //                else, focus will remain and error provider message
        private void stateCombo_Validating(object sender, CancelEventArgs e)
        {
             if (stateComboBox.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(stateComboBox, "Choose a state!");
                stateComboBox.SelectAll(); // Select all text in stateComboBox to ease correction

            }
        }

        //Precondition: attempting to change focus from zipTextBox 
        //Postcondition: If entered value is valid int, focus will change
        //                else, focus will remain and error provider message
        private void zipText_Validating(object sender, CancelEventArgs e)
        {
            int zip;

            // Will try to parse text as int
            // If fails, TryParse returns false
            // If succeeds, TryParse returns true and number stores parsed value
            if (!int.TryParse(zipTextBox.Text, out zip))
            {
                e.Cancel = true; // Stops focus changing process
                                 // Will NOT proceed to Validated event

                errorProvider1.SetError(zipTextBox, "Enter an integer!");
                zipTextBox.SelectAll(); // Select all text in zipTextBox to ease correction
            }

            else
            {
 
                if (zip < 0 || zip > 99999)
                {
                    e.Cancel = true; // Stops focus changing process
                                     // Will NOT proceed to Validated event

                    errorProvider1.SetError(zipTextBox, "Enter an integer between 0 and 99999"); // Set error message
                    zipTextBox.SelectAll(); // Select all text in zipTextBox to ease correction

                }
            }
            
        }

        // Precondition:  nameText_Validating succeeded
        // Postcondition: Any error message set for nameTextBox is cleared
        //                Focus is allowed to change
        private void nameText_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(nameTextBox, "");
        }

        // Precondition:  address1Text_Validating succeeded
        // Postcondition: Any error message set for adress1TextBox is cleared
        //                Focus is allowed to change
        private void address1Text_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(address1TextBox, "");
        }

        // Precondition:  cityText_Validating succeeded
        // Postcondition: Any error message set for cityTextBox is cleared
        //                Focus is allowed to change
        private void cityText_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(cityTextBox, "");
        }

        // Precondition:  stateCombo_Validating succeeded
        // Postcondition: Any error message set for stateComboBox is cleared
        //                Focus is allowed to change
        private void stateCombo_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(stateComboBox, "");
        }

        // Precondition:  zipText_Validating succeeded
        // Postcondition: Any error message set for zipTextBox is cleared
        //                Focus is allowed to change
        private void zipText_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(zipTextBox, "");
        }

        // Precondition:  User has initiated click on cancelBtn
        // Postcondition: If left-click, InputBox is dismissed with Cancel result
        private void cnclButton_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }

        // Precondition:  User has initiated click on OkBtn
        // Postcondition: If all controls on form validate, InputBox is dismissed with OK result
        private void okBttn_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }

       
    }  
}
