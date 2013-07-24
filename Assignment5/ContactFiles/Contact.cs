// Programming Using C# @MAH
// Assignment 5
// Author: Per Jonsson
// Version 1
// Created: 2013-07-11
// Project: CustomerRegistry
// Class: Contact.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactRegistry
{
    /// <summary>
    /// The Contact class maintains data about the first name 
    /// and last name as well as the address of a person.
    /// </summary>
    public class Contact
    {
        #region Fields
        // Initialize strings
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        // Aggregation - "has a"
        private Address address;
        #endregion


        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Contact() 
        {
            // Initialize the address field
            this.address = new Address();
        }

        /// <summary>
        /// 2nd constructor
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="address"></param>
        public Contact(string firstName, string lastName, Address address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = new Address(address); 
        }

        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="origContact"></param>
        public Contact(Contact origContact)
        {
            this.firstName = origContact.firstName; 
            this.lastName = origContact.lastName;
            this.address = new Address(origContact.address);
        }
        #endregion


        #region Properties
        public Address AddressData
        {
            get { return address; }
        }

        public string FirstName
        {
            get { return firstName; }
        }

        public string LastName
        {
            get { return lastName; }
        }

        public string FullName
        {
            get { return LastName + "," + FirstName; }
        }
        #endregion


        #region Methods
        /// <summary>
        /// Format the contact details, call the Address' ToString() method
        /// </summary>
        /// <returns>A string</returns>
        public override string ToString()
        {
            string strOut = string.Format("{0,-20} {1}", 
                FullName, this.address.ToString());
            return strOut;
        }
        #endregion

    }
}
