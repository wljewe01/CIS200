﻿// Program 3
// CIS 200-01
// Fall 2018
// Due: 11/18/2018
// By: D8649
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        private UserParcelView upv; // The UserParcelView
        private BinaryFormatter formatter = new BinaryFormatter(); // the Binary Formatter to format object
        private BinaryFormatter reader = new BinaryFormatter(); // the Binary Formatter to read object
        private FileStream output; //writes data to file
        private FileStream input; //reads data from file
   
     

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display.=
        public Prog2Form()
        {
            InitializeComponent();
            upv = new UserParcelView();
        }

        // Precondition:  File, About menu item activated
        // Postcondition: Information about author displayed in dialog box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string NL = Environment.NewLine; // Newline shorthand
            MessageBox.Show($"Program 3{NL}By: D8649{NL}CIS 200{NL}Fall 2018",
                "About Program 3");
        }


        // Precondition:  File, Exit menu item activated
        // Postcondition: The application is exited
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // Precondition:  Insert, Address menu item activated
        // Postcondition: The Address dialog box is displayed. If data entered
        //                are OK, an Address is created and added to the list
        //                of addresses
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            int zip; // Address zip code

            if (result == DialogResult.OK) // Only add if OK
            {
                if (int.TryParse(addressForm.ZipText, out zip))
                {
                    upv.AddAddress(addressForm.AddressName, addressForm.Address1,
                        addressForm.Address2, addressForm.City, addressForm.State,
                        zip); // Use form's properties to create address
                }
                else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Address Validation!", "Validation Error");
                }
            }

            addressForm.Dispose(); // Best practice for dialog boxes
                                   // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Addresses menu item activated
        // Postcondition: The list of addresses is displayed in the addressResultsTxt
        //                text box
        private void listAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Addresses:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Address a in upv.AddressList)
            {
                result.Append(a.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
            }

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Insert, Letter menu item activated
        // Postcondition: The Letter dialog box is displayed. If data entered
        //                are OK, a Letter is created and added to the list
        //                of parcels
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LetterForm letterForm; // The letter dialog box form
            DialogResult result;   // The result of showing form as dialog
            decimal fixedCost;     // The letter's cost

            if (upv.AddressCount < LetterForm.MIN_ADDRESSES) // Make sure we have enough addresses
            {
                MessageBox.Show("Need " + LetterForm.MIN_ADDRESSES + " addresses to create letter!",
                    "Addresses Error");
                return; // Exit now since can't create valid letter
            }

            letterForm = new LetterForm(upv.AddressList); // Send list of addresses
            result = letterForm.ShowDialog();

            if (result == DialogResult.OK) // Only add if OK
            {
                if (decimal.TryParse(letterForm.FixedCostText, out fixedCost))
                {
                    // For this to work, LetterForm's combo boxes need to be in same
                    // order as upv's AddressList
                    upv.AddLetter(upv.AddressAt(letterForm.OriginAddressIndex),
                        upv.AddressAt(letterForm.DestinationAddressIndex),
                        fixedCost); // Letter to be inserted
                }
               else // This should never happen if form validation works!
                {
                    MessageBox.Show("Problem with Letter Validation!", "Validation Error");
                }
            }

            letterForm.Dispose(); // Best practice for dialog boxes
                                  // Alternatively, use with using clause as in Ch. 17
        }

        // Precondition:  Report, List Parcels menu item activated
        // Postcondition: The list of parcels is displayed in the parcelResultsTxt
        //                text box
        private void listParcelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Holds text as report being built
                                                        // StringBuilder more efficient than String
            decimal totalCost = 0;                      // Running total of parcel shipping costs
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append("Parcels:");
            result.Append(NL); // Remember, \n doesn't always work in GUIs
            result.Append(NL);

            foreach (Parcel p in upv.ParcelList)
            {
                result.Append(p.ToString());
                result.Append(NL);
                result.Append("------------------------------");
                result.Append(NL);
                totalCost += p.CalcCost();
            }

            result.Append(NL);
            result.Append($"Total Cost: {totalCost:C}");

            reportTxt.Text = result.ToString();

            // Put cursor at start of report
            reportTxt.Focus();
            reportTxt.SelectionStart = 0;
            reportTxt.SelectionLength = 0;
        }

        // Precondition:  Edit menu item is activated
        // Postcondition: The address form is displayed. Data from the address list can be edited.
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            SelectAddressForm selectAddressForm = new SelectAddressForm(upv.AddressList);    // The select address dialog box form
            DialogResult result1 = selectAddressForm.ShowDialog(); // Show form as dialog and store result
          
            int addressIndex; //holds the value of the combo box index selected
            
            if (result1 == DialogResult.OK) // Only add if OK
            {
                addressIndex = selectAddressForm.AddressIndex;
                AddressForm af = new AddressForm(); //address form dialog box form 
                DialogResult result2 = af.ShowDialog();    // shows form as dialog and store result
            }
                selectAddressForm.Dispose(); // Best practice for dialog boxes
                                             // Alternatively, use with using clause as in Ch. 17
            }


        // Precondition:  Open menu item is activated
        // Postcondition: The file chooser is displayed as a dialog box
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result; // shows form as dialog and stores result
            string fileName; // hold value of file chosen

            using (OpenFileDialog fileChooser = new OpenFileDialog())
            {
                result = fileChooser.ShowDialog(); //file chooser dialog result
                fileName = fileChooser.FileName; //file chosen value
              
                if (result == DialogResult.OK) //opens file if OK
                {
                    if (string.IsNullOrEmpty(fileName))//if file is null, error is displayed
                    {
                        MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        input = new FileStream(fileName, FileMode.Open, FileAccess.Read); //file is opened
                    }
                    try
                    {
                            var addressRecords = (List<Address>)formatter.Deserialize(input); //variable record holds input
                            foreach (Address a in addressRecords)
                            {
                                upv.AddressList.Add(a);//add object into address list
                            }

                        var parcelRecords = (List<Parcel>)formatter.Deserialize(input);
                        foreach(Parcel p in parcelRecords)
                        {
                            upv.ParcelList.Add(p);
                        }
                    }
                    catch(IOException)//catches any exceptions
                    {
                        MessageBox.Show("Error opening file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//error displayed
                    }
                    try
                    {
                        input?.Close(); // close FileStream
                    }
                    catch (IOException)//catches any exceptions
                    {
                        MessageBox.Show("Cannot close file", "Error",
                           MessageBoxButtons.OK, MessageBoxIcon.Error);//error displayed
                    }
                }
            }
        }

        // Precondition:  Save as menu item is activated
        // Postcondition: The file chooser is displayed as a dialog box
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result; //shows form as dialog and stores result
            string fileName; //string holds file name value

           
            using (SaveFileDialog fileChooser = new SaveFileDialog())
            {
                fileChooser.CheckFileExists = false;

                result = fileChooser.ShowDialog(); //holds result of file chooser
                fileName = fileChooser.FileName; //holds name of file chosen
            }

            if(result ==DialogResult.OK) //if OK
            {
                if(string.IsNullOrEmpty(fileName)) //if file name is empty
                {
                    MessageBox.Show("Invalid File Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//error is shown
                }
                else
                {
                    try
                    {
                        output = new FileStream(fileName, FileMode.Create, FileAccess.Write); //create file

                        formatter.Serialize(output, upv.AddressList);
                        formatter.Serialize(output, upv.ParcelList);
                    }
                    catch(IOException ex)//catches exceptions
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);//displays errors
                    }  
                }
            }
            try
            {
                output?.Close(); // close FileStream
            }
            catch (IOException)//catches exceptions
            {
                MessageBox.Show("Cannot close file", "Error",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);//display error
            }
        }
    } 
}