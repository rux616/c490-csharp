/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-17
 * Assignment:  cView-P3
 * Source File: SimpleConvert.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Provides some simplifified variants of some Convert methods.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    public static class SimpleConvert
    {
        /*------------------------------------------------------------------------------------------
         * Name:    ToDateTime
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns the default object value if
         *          it fails for any reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  DateTime object representing either the converted value or the default DateTime.
        ------------------------------------------------------------------------------------------*/
        public static DateTime ToDateTime(string value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return default(DateTime);
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToInt32
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns the default object value if
         *          it fails for any reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  int object representing either the converted value or the default int.
        ------------------------------------------------------------------------------------------*/
        public static int ToInt32(string value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return default(int);
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToSingle
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns the default object value if
         *          it fails for any reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  float object representing either the converted value or the default float.
        ------------------------------------------------------------------------------------------*/
        public static float ToSingle(string value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return default(float);
            }
        }
    }
}
