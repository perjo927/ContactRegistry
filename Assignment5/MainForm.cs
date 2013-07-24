// Programming Using C# @MAH
// Assignment 5
// Author: Per Jonsson
// Version 1
// Created: 2013-07-11
// Project: CustomerRegistry
// Class: MainForm.cs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactRegistry
{
    /// <summary>
    /// The Interactive GUI Class
    /// </summary>
    public partial class MainForm : Form
    {
        #region Fields
        private ContactManager contacts;
        private Contact contact;
        #endregion


        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            // Default
            InitializeComponent();

            // Create an instance of the contact registry
            this.contacts = new ContactManager();
            // Initialize user interface 
            InitializeGUI();
        }


        #region Methods
        /// <summary>
        /// Provide the relevant info at app startup
        /// </summary>
        private void InitializeGUI()
        {
            // Set focus on the first field
            txtFirstName.Select();
            // No. of registered users
            lblCount.Text = contacts.Count.ToString(); 
            // Fill the ComboBox with the valeus from the Countries enum
            cmbCountry.Items.AddRange(Enum.GetNames(typeof(Countries)));
            //Set an option as the default option 
            cmbCountry.SelectedIndex = (int)Countries.Sverige;
        }

        /// <summary>
        /// This method is called when textual information needs to be refreshed
        /// </summary>
        private void UpdateGUI()
        {
            lstResults.Items.Clear();
            lstResults.Items.AddRange(this.contacts.GetContactsInfo());
            lblCount.Text = lstResults.Items.Count.ToString();
        }

        /// <summary>
        /// Fill the input boxes with information for the highlighted contacts in the ListBox
        /// </summary>
        private void UpdateContactInfoFromRegistry()
        {
            Contact contact = this.contacts.GetContact(GetSelectedIndex()); 

            if (contact != null)
            {
                cmbCountry.SelectedIndex = (int)contact.AddressData.Country;
                txtFirstName.Text = contact.FirstName;
                txtLastName.Text = contact.LastName;
                txtCity.Text = contact.AddressData.City;
                txtStreet.Text = contact.AddressData.Street;
                txtZip.Text = contact.AddressData.Zip;
            }
        }

        /// <summary>
        /// Reads names and address information and saves it
        /// </summary>
        /// <returns>True or false</returns>
        private bool ReadInput()
        {
            // User input 
            string firstName, lastName;
            Address address;
            // MessageBox info
            string message = String.Empty;
            string caption = "Input Error";

            if (!(ReadName(out firstName, out lastName)))
            {
                // Assemble messagebox info depending on which error
                message = "Name must contain at least one character, and may not consist of only empty spaces";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!(ReadAddress(out address)))
            {
                message = "Address fields must contain at least one character, and may not consist of only empty spaces";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Save info
            this.contact = new Contact(firstName, lastName, address);
         
            return true;
        }

        /// <summary>
        /// Reads and validates first and last name
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns>True/false</returns>
        private bool ReadName(out string firstName, out string lastName)
        {
            // Fetch values
            firstName = txtFirstName.Text;
            lastName = txtLastName.Text;
            // Check Validity
            return (InputUtility.ValidateString(firstName) && InputUtility.ValidateString(lastName));
        }

        /// <summary>
        /// Reads and validates Address information
        /// </summary>
        /// <returns>True/false</returns>
        private bool ReadAddress(out Address address)
        {
            // Fetch values
            string street = txtStreet.Text;
            string city = txtCity.Text;
            string zip = txtZip.Text; 
            Countries country = (Countries)cmbCountry.SelectedIndex;

            // Check Validity
            if (InputUtility.ValidateString(street)
                && InputUtility.ValidateString(city) && InputUtility.ValidateString(zip))
            {
                address = new Address(street, city, zip, country);
                return true;
            }
            address = null;
            return false;
        }
        #endregion


        #region Events
        /// <summary>
        /// This method will be automatically called when the user highlights 
        /// an entry in the ListBox (clicks on a row in the ListBox). 
        /// 
        /// It takes the information related to the entry from the registry and
        /// fill the input boxes with the data to make it easier for the user to edit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateContactInfoFromRegistry();
        }

        /// <summary>
        /// Updates the list if a contact is to be added
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ReadInput())
            {
                if (contacts.AddContact(this.contact))
                    UpdateGUI();    
            }
        }

        /// <summary>
        /// Changes an item in the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (CheckSelectedIndex() && ReadInput()) 
            {
                if (contacts.ChangeContact(this.contact, GetSelectedIndex())) 
                    UpdateGUI();   
            }
        }

        /// <summary>
        /// Deletes an item in the contact list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckSelectedIndex() && contacts.DeleteContact(GetSelectedIndex())) 
                UpdateGUI();
            else
                MessageBox.Show("Invalid delete", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Check if ListBox items are selected
        /// </summary>
        /// <returns>true if selection was made or false otherwise</returns>
        private bool CheckSelectedIndex()
        {
            return (lstResults.SelectedIndex >= 0);
        }
        /// <summary>
        /// Return selected ListBox index
        /// </summary>
        /// <returns></returns>
        private int GetSelectedIndex()
        {
            return lstResults.SelectedIndex;
        }
        #endregion
    }
}
