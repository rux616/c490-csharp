/*--------------------------------------------------------------------------------------------------
 * Name:        Dan Cassidy
 * Date:        2015-06-09
 * Assignment:  cView-P2
 * Source File: CViewData.cs
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Contains the basic data class for the cView program, along with some supporting
 *              methods.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CView
{
    class CViewData
    {
        //Exposes the min and max fields.
        public const Fields FIELDS_MIN = Fields.Name;
        public const Fields FIELDS_MAX = Fields.PhoneNumber;

        //Easily accessible string showing the data order in the ToString() method.
        public const string HEADER = "Facility Name (Type), Address, City [Phone Number]";

        //Represents the fields in use in this class. In lieu of inheritance and such, this is used
        //to help facilitate searching (versus using int literals).
        public enum Fields
        {
            Name = 1,
            FacilityType,
            Address,
            City,
            PhoneNumber
        }

        //Basic properties of the class.
        public string Name { get; set; }
        public string FacilityType { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }

        /*------------------------------------------------------------------------------------------
         * Method:  ToString
         * Purpose: Override of the ToString() method. Formats the return value so it looks pretty.
         * Input:   Nothing
         * Output:  String object containing serialized object data.
        ------------------------------------------------------------------------------------------*/
        public override string ToString()
        {
            return String.Format("{0} ({1}), {2}, {3} [{4}]",
                Name, FacilityType, Address, City, PhoneNumber);
        }
    }
}
