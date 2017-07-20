/*--------------------------------------------------------------------------------------------------
 * Name:        Dan Cassidy
 * Date:        2015-06-02
 * Assignment:  cView-P1
 * Source File: Program.cs
 * Class:       CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Small wrapper program for demonstrating the CViewDataInteractive class.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cView_P1_DanCassidy
{
    class Program
    {
        /*------------------------------------------------------------------------------------------
         * Method:  Main
         * Purpose: Serves as the entry point to the program.
         * Input:   String array object representing any command line arguments.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        static void Main(string[] args)
        {
            //Declare a new CViewDataInteractive object.
            var data = new CViewDataInteractive();

            //Interactively manupulate said object.
            data.InteractiveManipulation();
        }
    }
}
