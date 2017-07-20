/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-23
 * Assignment:  cView-P4
 * Source File: SimpleConvert.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Provides simplified variants and extensions of some Convert methods.
--------------------------------------------------------------------------------------------------*/

namespace System
{
    public static class SimpleConvert
    {
        /*------------------------------------------------------------------------------------------
         * Name:    ToByte
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns the default object value if
         *          it fails for any reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  byte object containing either the converted value or the default object value.
        ------------------------------------------------------------------------------------------*/
        public static byte ToByte(string value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return default(byte);
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToByteN
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns a null if it fails for any
         *          reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  Nullable<byte> object containing either the converted value or a null.
        ------------------------------------------------------------------------------------------*/
        public static Nullable<byte> ToByteN(string value)
        {
            try
            {
                return Convert.ToByte(value);
            }
            catch
            {
                return null;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToDateTime
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns the default object value if
         *          it fails for any reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  DateTime object containing either the converted value or the default object
         *          value.
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
         * Name:    ToDateTimeN
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns a null if it fails for any
         *          reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  Nullable<DateTime> object containing either the converted value or a null.
        ------------------------------------------------------------------------------------------*/
        public static Nullable<DateTime> ToDateTimeN(string value)
        {
            try
            {
                return Convert.ToDateTime(value);
            }
            catch
            {
                return null;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToDecimal
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns the default object value if
         *          it fails for any reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  Decimal object containing either the converted value or the default object
         *          value.
        ------------------------------------------------------------------------------------------*/
        public static decimal ToDecimal(string value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return default(decimal);
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToDecimalN
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns a null if it fails for any
         *          reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  Nullable<Decimal> object containing either the converted value or a null.
        ------------------------------------------------------------------------------------------*/
        public static Nullable<decimal> ToDecimalN(string value)
        {
            try
            {
                return Convert.ToDecimal(value);
            }
            catch
            {
                return null;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToInt32
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns the default object value if
         *          it fails for any reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  int object containing either the converted value or the default object value.
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
         * Name:    ToInt32N
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns a null if it fails for any
         *          reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  Nullable<int> object containing either the converted value or a null.
        ------------------------------------------------------------------------------------------*/
        public static Nullable<int> ToInt32N(string value)
        {
            try
            {
                return Convert.ToInt32(value);
            }
            catch
            {
                return null;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToSingle
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns the default object value if
         *          it fails for any reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  float object containing either the converted value or the default object value.
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

        /*------------------------------------------------------------------------------------------
         * Name:    ToSingleN
         * Type:    Method
         * Purpose: Attempts to convert the given parameter, but returns the default object value if
         *          it fails for any reason.
         * Input:   string value, containing the value on which conversion will be attempted.
         * Output:  Nullable<float> object containing either the converted value or a null.
        ------------------------------------------------------------------------------------------*/
        public static Nullable<float> ToSingleN(string value)
        {
            try
            {
                return Convert.ToSingle(value);
            }
            catch
            {
                return null;
            }
        }
    }
}
