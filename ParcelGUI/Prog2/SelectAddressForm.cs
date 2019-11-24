/*
Program 3
CIS 200-01
Fall 2018
Due: 11/12/2018
By: D8649
File: SelectAddressForm.cs
This class creates the Select Address dialog box form GUI. It performs validation
and provides String properties for each combo box field.
 */
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
    public partial class SelectAddressForm : Form

    {
        private ComboBox addressComboBox; //combo box
        private Button okBttn; //ok button
        private Button cnclBttn;//cancel button
        private Label label1;
        private ErrorProvider errorProvider1;
        private IContainer components;
        private List<Address> addressList; //list of addresses

        // Precondition:  None
        // Postcondition: The form's GUI is prepared for display.
        public SelectAddressForm(List<Address> addresses)
        {

            InitializeComponent();
            addressList = addresses;//creates list of addresses
        }

        internal int AddressIndex
        {
            // Precondition:  User has selected from addressComboBox
            // Postcondition: The index of the address returned
            get
            {
                return addressComboBox.SelectedIndex;
            }
            // Precondition:  -1 <= value < addressList.Count
            // Postcondition: The specified index is selected in originAddCbo
            set
            {
                if ((value >= -1) && (value < addressList.Count))
                    addressComboBox.SelectedIndex = value;
                else
                    throw new ArgumentOutOfRangeException("AddressIndex", value,
                        "Index must be valid");
            }
        }

        // Precondition:  None
        // Postcondition: The form is loaded and the address combo box is 
        //                filled with addresses from address list
        private void SelectAddressForm_Load(object sender, EventArgs e)
        {
            foreach (Address a in addressList)
            {
                addressComboBox.Items.Add(a.Name); //address box is loaded with address names
            }
        }


        // Precondition:  OK button is cliked 
        // Postcondition: The address form is shown with the address selected from combo box loaded. The
        //                user can change the data and save it to the file, which will update the address.
        private void okBttn_Click_1(object sender, EventArgs e)
        {
            Address address = addressList[AddressIndex];    //holds index of address list 
            AddressForm addressForm = new AddressForm();    // The address dialog box form
            addressForm.AddressName = address.Name; //changes the address form name to the address chosen's address name
            addressForm.Address1 = address.Address1; //changes the address form address 1 to the address chosen's address 1
            addressForm.Address2 = address.Address2; //changes the address form address 2 to the address chosen's address 2
            addressForm.City = address.City; //changes the address form city to the address chosen's city
            addressForm.State = address.State; //changes the address form state to the address chosen's state
            addressForm.ZipText = address.Zip.ToString(); //changes the zip form name to the address chosen's zip

            DialogResult result = addressForm.ShowDialog(); // Show form as dialog and store result
            if (result == DialogResult.OK)//if the result is okay
            {
                int zip; //holds value of zip code
                address.Name = addressForm.AddressName; //changes the address object's name to name on address form
                address.Address1 = addressForm.Address1; //changes the address object's address1 to address1 on address form
                address.Address2 = addressForm.Address2; //changes the address address2 to the address form address2
                address.City = addressForm.City; //changes the address city to the address form city
                address.State = addressForm.State;//changes the address state to the address form state
                int.TryParse(addressForm.ZipText, out zip);//changes the address zip to the address form zip
                address.Zip = zip;//changes the address name to the address form name
                Close();//close address form
            }
        }


        // Precondition:  Cancel button is cliked 
        // Postcondition: The dialog box is closed
        private void cnclBttn_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) // Was it a left-click?
                this.DialogResult = DialogResult.Cancel;
        }


        

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.addressComboBox = new System.Windows.Forms.ComboBox();
            this.okBttn = new System.Windows.Forms.Button();
            this.cnclBttn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // addressComboBox
            // 
            this.addressComboBox.FormattingEnabled = true;
            this.addressComboBox.Location = new System.Drawing.Point(73, 64);
            this.addressComboBox.Name = "addressComboBox";
            this.addressComboBox.Size = new System.Drawing.Size(121, 21);
            this.addressComboBox.TabIndex = 0;
            this.addressComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.addressComboBox_Validating);
            this.addressComboBox.Validated += new System.EventHandler(this.addressComboBox_Validated);
            // 
            // okBttn
            // 
            this.okBttn.Location = new System.Drawing.Point(39, 170);
            this.okBttn.Name = "okBttn";
            this.okBttn.Size = new System.Drawing.Size(75, 23);
            this.okBttn.TabIndex = 1;
            this.okBttn.Text = "OK";
            this.okBttn.UseVisualStyleBackColor = true;
            this.okBttn.Click += new System.EventHandler(this.okBttn_Click_1);
            // 
            // cnclBttn
            // 
            this.cnclBttn.Location = new System.Drawing.Point(150, 170);
            this.cnclBttn.Name = "cnclBttn";
            this.cnclBttn.Size = new System.Drawing.Size(75, 23);
            this.cnclBttn.TabIndex = 2;
            this.cnclBttn.Text = "Cancel";
            this.cnclBttn.UseVisualStyleBackColor = true;
            this.cnclBttn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cnclBttn_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select address to change:";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SelectAddressForm
            // 
            this.AcceptButton = this.okBttn;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cnclBttn);
            this.Controls.Add(this.okBttn);
            this.Controls.Add(this.addressComboBox);
            this.Name = "SelectAddressForm";
            this.Load += new System.EventHandler(this.SelectAddressForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private void addressComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (addressComboBox.SelectedIndex == -1) // Didn't select anything from cbo
            {
                e.Cancel = true;
                errorProvider1.SetError(addressComboBox, "Must select an address!");
            }
        }
        private void addressComboBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(addressComboBox, "");
        }

    }
}




