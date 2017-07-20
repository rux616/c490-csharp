/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy and Dr. Raman Adaikkalavan
 * Date:        2015-06-17
 * Assignment:  cView-P3
 * Source File: ItemDBTest.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Project:     The overall goal of this project is to capitalize on the fact that government, from
 *              local to national, has made some of its data open by developing a way to explore
 *              this data and present it to a user in a meaningful fashion. This phase of the
 *              project is meant to explore data from any combination of the Business dataset
 *              (https://data.southbendin.gov/d/imxu-7m5i), the Parks and Features dataset
 *              (https://data.southbendin.gov/d/yf5x-7tkb), and the Public Facility dataset
 *              (https://data.southbendin.gov/d/jeef-dsq9).
 * Purpose:     Small wrapper program for demonstrating the ItemDBInteractive class.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    public class ItemDBTest
    {
        /*------------------------------------------------------------------------------------------
         * Name:    Main
         * Type:    Method
         * Purpose: Serves as the entry point to the program.
         * Input:   (Ignored) string[] args, represents any command line arguments.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        static void Main(string[] args)
        {
            // Declare a new ItemDBInteractive object and interactively manipulate said object.
            ItemDBInteractive itemDBTest = new ItemDBInteractive();
            itemDBTest.InteractiveManipulation();
        }
    }
}
