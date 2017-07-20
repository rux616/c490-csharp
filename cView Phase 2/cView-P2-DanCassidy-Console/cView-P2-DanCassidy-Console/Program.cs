/*--------------------------------------------------------------------------------------------------
 * Name:        Dan Cassidy
 * Date:        2015-06-09
 * Assignment:  cView-P2
 * Source File: Program.cs
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Project:     The overall goal of this project is to capitalize on the fact that government, from
 *              local to national, has made some of its data open by developing a way to explore
 *              this data and present it to a user in a meaningful fashion. This phase of the
 *              project is meant to explore a subset of fields in a Public Facility dataset as
 *              represented in the dataset at https://data.southbendin.gov/d/jeef-dsq9.
 * Purpose:     Small wrapper program for demonstrating the CViewDataInteractive class.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CView;

namespace cView_P2_DanCassidy_Console
{
    class Program
    {
        /*------------------------------------------------------------------------------------------
         * Method:  Main
         * Purpose: Serves as the entry point to the program.
         * Input:   String array object representing any command line arguments. Ignored.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        static void Main(string[] args)
        {
            //Declare a new CViewDataInteractive object.
            var data = new CViewDataInteractive();

            //Interactively manipulate said object.
            data.InteractiveManipulation();
        }
    }
}
