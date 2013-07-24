// Programming Using C# @MAH
// Assignment 5
// Author: Per Jonsson
// Version 1
// Created: 2013-07-11
// Project: CustomerRegistry
// Class: Program.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactRegistry
{
    /// <summary>
    ///  A Windows Form Application that saves a list of contacts.
    ///  Every contact is a person that has the following data:
    ///   * First name
    ///   * Last name
    ///   * Address including:
    ///     + Street address
    ///     + Zip code
    ///     + City
    ///     + Country
    ///  The GUI should allow the user to add a new contact, change
    ///  or delete an existing one. It should also present a list of all
    ///  contacts saved in the registry. The list is to be updated after
    ///  every change in the registry.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
