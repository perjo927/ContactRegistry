// Project: Programming Using C# (MAH)
// Class: InputUtility.cs
// Author: Per Jonsson, 2013-06-28
// Revised: 
// Input and output related logic
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactRegistry
{
    /// <summary>
    /// Input and Output (I/O) validation
    /// </summary>
    class InputUtility
    {
        /// <summary>
        /// A method that converts a given string to an integer  
        /// This method can then be used to parse an integer value from the contents
        /// of a TextBox provided that the TextBox contains text that can represent 
        /// a valid integer
        /// </summary>
        /// <param name="stringToConvert"></param>
        /// <param name="intOutValue"></param>
        /// <returns>
        /// Returns true if successful, false otherwise
        /// </returns>
        public static bool GetInteger(string stringToConvert, out int intOutValue)
        {
            bool converted = int.TryParse(stringToConvert, out intOutValue);
            return converted && ValidatePositiveNumber(intOutValue);
        }

        /// <summary>
        /// A method  that converts a given string to a double 
        /// </summary>
        /// <param name="stringToConvert"></param>
        /// <param name="dblOutValue"></param>
        /// <returns>
        /// True if successful, false otherwise.
        /// </returns>
        public static bool GetDouble(string stringToConvert, out double dblOutValue)
        {
            // Try to parse and also validate if the number is positive
            bool converted = double.TryParse(stringToConvert, out dblOutValue);
            return converted && ValidatePositiveNumber(dblOutValue);
        }

        /// <summary>
        /// A method that validates so a given (double or int) number is not negative.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// Returns true if value is not negative
        /// </returns>
        private static bool ValidatePositiveNumber(int value)
        {
            return (value >= 0);
        }

        /// <summary>
        /// Overrides the above, but with doubles instead
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// Returns true if value is not negative
        /// </returns>
        private static bool ValidatePositiveNumber(double value)
        {
            return (value >= 0f);
        }

        /// <summary>
        /// A method which controls that a given string is neither null nor empty 
        /// and should at least have one character other than a blank space 
        /// (or escape sequences).
        /// </summary>
        /// <returns>
        /// Returns false if one or both of the above conditions are present
        /// </returns>
        public static bool ValidateString(string stringToValidate)
        {
            return (!(string.IsNullOrEmpty(stringToValidate) || string.IsNullOrWhiteSpace(stringToValidate)));
        }
    } 
}
