// Programming Using C# @MAH
// Assignment 5
// Author: Per Jonsson
// Version 1
// Created: 2013-07-11
// Project: CustomerRegistry
// Class: ContactManager.cs


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactRegistry
{
    /// <summary>
    /// This class is a container class for Contact objects. It saves contact
    /// objects in a dynamic list of the type List. 
    /// 
    /// The class has methods for adding a new contact, deleting and
    /// changing an existing contact.
    /// </summary>
    public class ContactManager
    {
        // Field
        private List<Contact> contactRegistry;

        /// <summary>
        /// Constructor
        /// </summary>
        public ContactManager()
        {
            contactRegistry = new List<Contact>(); // this.??..
        }

        /// <summary>
        /// Property
        /// </summary>
        public int Count
        {
            get { return contactRegistry.Count; }
        } 
        

        #region Methods
        /// <summary>
        /// Calls the overloaded method in order to add a Contact
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="addressIn"></param>
        /// <returns>True/false</returns>
        public bool AddContact(string firstName, string lastName, Address addressIn)
        {
            return AddContact(new Contact(firstName, lastName, addressIn));
        }

        /// <summary>
        /// Tries to add a contact in the registry
        /// </summary>
        /// <param name="contactIn"></param>
        /// <returns>True/false</returns>
        public bool AddContact(Contact contactIn) 
        {            
            // Check validity to avoid program termination
            if (contactIn != null)
            {
                // Use copy constructor
                contactRegistry.Add(new Contact(contactIn)); 
                return true;
            }
            return false;
        }

        /// <summary>
        /// Tries to change a selected contact, by removing the old record and adding a new
        /// </summary>
        /// <param name="contactIn"></param>
        /// <param name="index"></param>
        /// <returns>True/false</returns>
        public bool ChangeContact(Contact contactIn, int index)
        {
            // Check validity to avoid program termination
            if (contactIn != null)
            {
                // Use copy constructor
                contactRegistry.Insert(index, new Contact(contactIn));
                // Delete old record
                contactRegistry.RemoveAt(index+1);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Tries to delete a specified Contact
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True/false</returns>
        public bool DeleteContact(int index)
        {
            if (!(CheckIndexOutOfRange(index)))
            {
                contactRegistry.RemoveAt(index);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if contact registry contains the selected index
        /// </summary>
        /// <param name="index"></param>
        /// <returns>True/false</returns>
        private bool CheckIndexOutOfRange(int index)
        {
            return (index < 0 || index >= this.contactRegistry.Count);
        }

        /// <summary>
        /// A method that returns an element of the list saved in a given position.
        /// </summary>
        /// <param name="index"></param>
        /// <returns>A deep copy</returns>
        public Contact GetContact(int index)
        {
            if (CheckIndexOutOfRange(index))
            {
                return null;
            }
            else
            {
                return GetContactCopy(index); 
            }
        }

        /// <summary>
        /// Creates a deep copy instead of a reference
        /// </summary>
        /// <param name="index"></param>
        /// <returns>A copy of a Contact object</returns>
        public Contact GetContactCopy(int index)
        {
            // Fetch reference to item at selected index
            Contact origObj = this.contactRegistry[index];

            // Use copy constructor to allocate a new object on the heap
            Contact copyObj = new Contact(origObj);
            return copyObj;
        }

        /// <summary>
        /// This method prepares an array of strings, where every string is
        /// made up of information about the Contact object.
        /// </summary>
        /// <returns>An array of strings where every string represents a contact</returns>
        public string[] GetContactsInfo()
        {
            string[] strInfoStrings = new string[this.contactRegistry.Count];

            int i = 0;
            foreach (Contact contact in this.contactRegistry)
            {
                strInfoStrings[i++] = contact.ToString();
            }
            return strInfoStrings;
        }
        #endregion
    }
}
