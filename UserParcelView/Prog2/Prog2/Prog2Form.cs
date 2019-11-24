// Program 2
// CIS 200-01
// Fall 2018
// Due: 10/25/2018
// By: D8649

// File: Prog2Form.cs
// This file contains the code for the main GUI.
// It creates 2 diaglog boxes called LetterForm and 
// AddressForm when the user clicks "Insert Address"
// or "Insert Letter".
// This class creates an object of UserParcelView and 
// collects the data from the dialog boxes to initialize
// the UPV object with. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UPVApp
{
    public partial class Prog2Form : Form
    {
        private UserParcelView upv; //UserParcelView

        //Precondition: None
        //Postcondition: GUI form is created
        //               Creates address form and letter form
        //               if the user selects those options from
        //               the menu.
        //               Data collected from this form is sent to
        //               the UserParcelView class to be created
        //               into lists. 
        public Prog2Form()
        {
            //Precondition: None
            //Postcondition: Form is created
            InitializeComponent();

            //Creating an object of the UserParcelView
            upv = new UserParcelView();

            //Test Data: Addresses 
            upv.AddAddress("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                 "  Louisville   ", "  KY   ", 40202); // Test Address 1
            upv.AddAddress("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            upv.AddAddress("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            upv.AddAddress("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4
            upv.AddAddress("Charlotte Jones", "123 Maple St. ",
              "Clarksville", "IN", 47129); // Test Address 5
            upv.AddAddress("Kayla Kay", "989 Chipp Avenue", "Apt. 2",
              "Salem", "IN", 52143); // Test Address 6
            upv.AddAddress("Hunter Ansleigh", "554 Herrick Way",
              "Jeffersonville", "IN", 47130); // Test Address 7
            upv.AddAddress("Mckenzie Caldwell", "2201 Morgan Avenue",
              "Charlestown", "KY", 42450); // Test Address 8


            //Test Data: Letters 
            upv.AddLetter(upv.AddressAt(0), upv.AddressAt(1), 3.95M);
            upv.AddLetter(upv.AddressAt(3), upv.AddressAt(2), 2.05M);

            //Test Data: GroundPackages 
            upv.AddGroundPackage(upv.AddressAt(2), upv.AddressAt(3), 14, 10, 5, 12.5);
            upv.AddGroundPackage(upv.AddressAt(1), upv.AddressAt(5), 22, 15, 16, 28);

            //Test Data: NextDayAirPackages 
            upv.AddNextDayAirPackage(upv.AddressAt(5), upv.AddressAt(0), 25, 15, 15, 85, 7.50M);
            upv.AddNextDayAirPackage(upv.AddressAt(1), upv.AddressAt(2), 50, 20, 15, 120, 9.75M);

            //Test Data: TwoDayAirPackages 
            upv.AddTwoDayAirPackage(upv.AddressAt(3), upv.AddressAt(2), 46.5, 39.5, 28.0, 80.5, TwoDayAirPackage.Delivery.Saver);
            upv.AddTwoDayAirPackage(upv.AddressAt(7), upv.AddressAt(6), 20.75, 16.20, 20.50, 120.75, TwoDayAirPackage.Delivery.Early);
        }
       

        //Precondition:  User clicks "address" menu item
        //Postcondition: Address form is created and shown
        //               as a dialog box
        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prog2.AddressForm addressForm = new Prog2.AddressForm(); // creates address form   
            DialogResult result;                          //  Result from dialog - OK/Cancel?
            string name;                                 //   User's input for name (gather from dialog box)
            string address1;                            //   User's input for address 1 (gather from dialog box)
            string address2;                           //   User's input for address 2 (gather from dialog box)
            string city;                              //   User's input for city (gather from dialog box)
            string state;                            //   User's input for state (gather from dialog box)
            int zip;                                //   User's input for zip (gather from dialog box)

            result = addressForm.ShowDialog(); // Show dialog box form - modal, waits for OK/Cancel
                                               // Even after user dismisses, the form still exists
                                               // and can be interacted with using methods/properties


            //if the user clicks the OK button, the data will be input
            if (result == DialogResult.OK)
            {
                zip = int.Parse(addressForm.ZipInputValue);
                name = addressForm.NameInputValue;
                address1 = addressForm.Address1InputValue;
                address2 = addressForm.Address2InputValue;
                city = addressForm.CityInputValue;
                state = addressForm.StateInputValue;

                upv.AddAddress(name, address1, address2, city, state, zip);
                //adds the address input into the upv object 
               
            } 
        }


        //Precondition: User clicks "about" menu item
        //Postcondition: About form is shown as a message box
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Program 2{ Environment.NewLine}Grading ID: D8649" +
                $"{ Environment.NewLine}CIS 200{Environment.NewLine}Fall 2018", 
                "About",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Precondition: User clicks "cancel" menu item
        //Postcondition: The application is exited
        private void cancelToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }


        //Precondition: User clicks "report" menu item
        //Postcondition: The report text box is input
        //               with data from the Parcel List
        //               and the Address List
        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder result = new StringBuilder(); // Will hold result as being built
            string NL = Environment.NewLine;            // Newline shorthand

            result.Append($"--------------{Environment.NewLine}Addresses: {Environment.NewLine}--------------" +
                $"{Environment.NewLine}");
            //foreach loop outputs each parcel in the parcel list
            foreach (Address a in upv.AddressList)
                result.Append($"{Environment.NewLine}{a}{Environment.NewLine}");
            
            result.Append($"--------------{Environment.NewLine}Parcels: {Environment.NewLine}--------------" +
                $"{Environment.NewLine}");

            //foreach loop outputs each parcel in the parcel list
            foreach (Parcel p in upv.ParcelList)
                result.Append($"{p}{Environment.NewLine}-------------------{Environment.NewLine}-------------------" +
                    $"{Environment.NewLine}");

          

            reportTextBox.Text = result.ToString();//adds the strings created
                                                   //into the text box
        }

        //Precondition: User clicks "letter" menu item
        //Postcondition: A letter form is created and is sent the
        //               addresses from the upv object
        private void letterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prog2.LetterForm letterForm = new Prog2.LetterForm(upv.addresses);
            DialogResult result; //Result from dialog - OK / Cancel ?
            result = letterForm.ShowDialog(); // Show dialog box form - modal, waits for OK/Cancel
                                              // Even after user dismisses, the form still exists
                                              // and can be interacted with using me
        }

    }
}
