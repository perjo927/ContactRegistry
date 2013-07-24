// Programming Using C# @MAH
// Assignment 5
// Author: Per Jonsson
// Version 1
// Created: 2013-07-11
// Project: CustomerRegistry
// Class: Address.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactRegistry
{
    /// <summary>
    /// A class for handling addresses. 
    /// </summary>
    public class Address
    {
        #region Fields
        private string street;
        private string zip;
        private string city;
        private Countries country;
        #endregion


        #region Constructors
        /// <summary>
        /// Default constructor, using chain callin
        /// </summary>
        public Address()
            : this(string.Empty, string.Empty, "Norrköping") {}

        /// <summary>
        /// 2nd constructor, calls the overloaded constructor
        /// </summary>
        /// <param name="street"></param>
        /// <param name="zip"></param>
        /// <param name="city"></param>
        public Address(string street, string city, string zip)
            : this(street, city, zip, Countries.Sverige) {}
        
        /// <summary>
        /// Code only at one place
        /// </summary>
        /// <param name="street"></param>
        /// <param name="zip"></param>
        /// <param name="city"></param>
        /// <param name="country"></param>
        public Address(string street, string city, string zip, Countries country)
        {
            this.street = street;
            this.zip = zip;
            this.city = city;
            this.country = country;
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="theOther"></param>
        public Address(Address origAddress)
        {
            this.street = origAddress.street; 
            this.zip = origAddress.zip; 
            this.city = origAddress.city;
            this.country = origAddress.country;
        }
        #endregion


        #region Properties
        public string Street 
        { 
         get { return street; }
        }
        public string City
        {
            get { return city; }
        }
        public string Zip
        {
            get { return zip; }
        }
        public Countries Country
        {
            get { return country; }
        }
        #endregion


        #region Methods
        /// <summary>
        /// Deletes the '_' from country names saved in the enum
        /// </summary>
        /// <returns>The country name without the '_'</returns>
        public string GetCountryString()
        {
            string strCountry = Country.ToString();
            strCountry = strCountry.Replace("_", " ");
            return strCountry;
        }

        /// <summary>
        /// overrides the ToString method
        /// </summary>
        /// <returns>A string with the address formatted in one line</returns>
        public override string ToString()
        {
            string strOut = string.Format("{0,-25} {1,-8} {2,-10} {3}",
                Street, City, Zip, GetCountryString());
            return strOut;
        }
        #endregion
    }
}
