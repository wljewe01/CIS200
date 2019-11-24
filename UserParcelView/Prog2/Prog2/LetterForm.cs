// Program 2
// CIS 200-01
// Fall 2018
// Due: 10/25/2018
// By: D8649

// File: LetterForm.cs
// This file allows the user to select the addresses that
//in the address form to create a letter and enter
// a cost value. It also validates the user's inputs. 

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
    public partial class LetterForm : Form
    {
        //Precondition: None
        //Postcondition: Letter GI is initialized and
        //               values from address list are
        //               placed into combo boxes
        public LetterForm(List<Address> addresses)
        {
            //Precondition: None
            //Postcondition: Form is created
            InitializeComponent();

            //foreach loop adds each address from
            //the address list and places them 
            //in the first combo box
            foreach (Address a in addresses)
                comboBox1.Items.Add(a.Name);
            

            //foreach loop adds each address from
            //the address list and places them 
            //in the second combo box
            foreach (Address b in addresses)
                comboBox2.Items.Add(b.Name);
        }



        internal string OriginAddress // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in comboBox1 is returned
            get
            {
                return comboBox1.Text;
            }
            // Precondition:  None
            // Postcondition: Text in comboBox1 is set to specified value
            set
            {
                comboBox1.Text = value;
            }
        }

        internal string DestAddress // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in comboBox2 is returned
            get
            {
                return comboBox2.Text;
            }
            // Precondition:  None
            // Postcondition: Text in comboBox2 is set to specified value
            set
            {
                comboBox2.Text = value;
            }
        }

        internal string CostInputValue // Can be accessed by other classes in same namespace
        {
            // Precondition:  None
            // Postcondition: Text in costTxtBox is returned
            get
            {
                return costTxtBox.Text;
            }
            // Precondition:  None
            // Postcondition: Text in costTxtBox is set to specified value
            set
            {
                costTxtBox.Text = value;
            }
        }


        // Precondition:  Attempting to submit form without selecting an option
        // Postcondition: If user doesn't select an option, an error will display
        private void originAddressCombo_Validating(object sender, CancelEventArgs e)
        {
            //if the user doesn't select an option, an error is set
            if (comboBox1.SelectedIndex == -1)
            {
                e.Cancel = true;
                errorProvider1.SetError(comboBox1, "Choose an origin address!");
                comboBox1.SelectAll(); // Select all text in inputTxt to ease correction

            }
        }



        // Precondition:  Attempting to submit form without selecting an option
        // Postcondition: If user doesn't select an option, an error will display
        //                If user tries to select the same address for destination 
        //                and origin address, an error will display
        private void destAddressCombo_Validating(object sender, CancelEventArgs e)
        {
            //if the user doesn't select an option, an error is set
            if (comboBox2.SelectedIndex == -1)
            {
                e.Cancel = true;// Stops focus changing process
                                // Will NOT proceed to Validated event
                errorProvider1.SetError(comboBox2, "Choose a destination address!");
                comboBox1.SelectAll(); // Select all text in inputTxt to ease correction

            }

            else
            {
                //if the user selects the same address for both combo boxes,
                //an error is set
                if (comboBox1.SelectedIndex == comboBox2.SelectedIndex)
                {
                    e.Cancel = true; // Stops focus changing process
                                     // Will NOT proceed to Validated event

                    errorProvider1.SetError(comboBox2, "Choose a different address than origin address"); // Set error message
                    comboBox2.SelectAll(); // Select all text in inputTxt to ease correction

                }

            }


        }



        // Precondition:  Attempting to submit form without entering a cost
        // Postcondition: If entered value is a double and is > 0, the user 
        //                can continue
        private void costText_Validating(object sender, CancelEventArgs e)
        {
            double cost; //value entered into costText

            // Will try to parse text as double
            // If fails, TryParse returns false
            // If succeeds, TryParse returns true and number stores parsed value
            if (!double.TryParse(costTxtBox.Text, out cost))
            {
                e.Cancel = true; // Stops focus changing process
                                 // Will NOT proceed to Validated event

                errorProvider1.SetError(costTxtBox, "Enter an double!");
                costTxtBox.SelectAll(); // Select all text in inputTxt to ease correction


            }

            else
            {
                //If user enters a value less than 0, an error will be set
                if (cost < 0)
                {
                    e.Cancel = true; // Stops focus changing process
                                     // Will NOT proceed to Validated event

                    errorProvider1.SetError(costTxtBox, "Enter a positive double"); // Set error message
                    costTxtBox.SelectAll(); // Select all text in inputTxt to ease correction

                }

            }

        }

        // Precondition:  originAddress_Validating succeeded
        // Postcondition: Any error message set for comboBox1 is cleared
        //                Focus is allowed to change
        private void originAddress_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1, "");
        }

        // Precondition:  destAddress_Validating succeeded
        // Postcondition: Any error message set for comboBox2 is cleared
        //                Focus is allowed to change
        private void destAddress_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox2, "");
        }

        // Precondition:  costText_Validating succeeded
        // Postcondition: Any error message set for costText is cleared
        //                Focus is allowed to change
        private void costText_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(costTxtBox, "");
        }



        // Precondition:  User has initiated click on OkBtn
        // Postcondition: If all controls on form validate, InputBox is dismissed with OK result
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (this.ValidateChildren())
                this.DialogResult = DialogResult.OK;
        }


        // Precondition:  User has initiated click on cancelBtn
        // Postcondition: If left-click, InputBox is dismissed with Cancel result
        private void CancelButton_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }

    }
}
