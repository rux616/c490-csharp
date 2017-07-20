/*
Name:			Dan Cassidy
Date:			2015-05-23
Assignment:		A1-P1
Source File:	Program.cs
Class:          CSCI-C 490, C# Programming, MoWe 08:00
Action:			Implements a very simple console program that asks for the user's name, then
                says hello followed by the time, as demonstrated by the video at
                https://www.youtube.com/watch?v=oIhNea3_vPw.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1_P1_DanCassidy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ask user for their name.
            Console.WriteLine("Please Enter Your Name:");
            string userName = Console.ReadLine();

            //Welcome the user and display the time.
            Console.WriteLine("Hello {0}, the current time is {1}.", userName, System.DateTime.Now.ToLongTimeString());

            //Prompt the user to exit.
            Console.WriteLine("Press any key to quit.");
            Console.ReadKey();

        }
    }
}
