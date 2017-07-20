/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-17
 * Assignment:  cView-P3
 * Source File: Business.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Contains the Business class, derived from the Item abstract class, and supporting
 *              methods.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    public class Business : Item
    {
        /*------------------------------------------------------------------------------------------
         * Type:    Helper Constants
        ------------------------------------------------------------------------------------------*/
        public new const FieldMenuHelper FieldMin = FieldMenuHelper.LicenseFiscalYear;
        public new const FieldMenuHelper FieldMax = FieldMenuHelper.BackBusiness;
        public const int FieldOffset = 1;

        /*------------------------------------------------------------------------------------------
         * Type:    Private Fields
        ------------------------------------------------------------------------------------------*/
        private string itemType = "business";
        private int licenseFiscalYear;
        private int licenseNumber;

        /*------------------------------------------------------------------------------------------
         * Type:    Constructor
         * Purpose: Basic no-parameter constructor.
         * Input:   Nothing.
        ------------------------------------------------------------------------------------------*/
        public Business()
        {
            // Nothing else to do.
        }

        /*------------------------------------------------------------------------------------------
         * Type:    Constructor
         * Purpose: Copy constructor.
         * Input:   Business fromItem, reference to the other Business from which fields should be
         *          copied.
        ------------------------------------------------------------------------------------------*/
        public Business(Business fromItem)
            : base(fromItem)
        {
            itemType = fromItem.itemType;

            LicenseFiscalYear = fromItem.LicenseFiscalYear;
            LicenseNumber = fromItem.LicenseNumber;
            LicenseIssueDate = fromItem.LicenseIssueDate;
            LicenseExpirDate = fromItem.LicenseExpirDate;
            LicenseStatus = fromItem.LicenseStatus;
            CouncilDistrict = fromItem.CouncilDistrict;
        }

        /*------------------------------------------------------------------------------------------
         * Type:    Constructor
         * Purpose: Constructor that will fill all the properties except ItemID and ItemType.
         * Input:   string name, contains the desired Name for the object.
         * Input:   string type, contains the desired Type for the object.
         * Input:   string streetAddress, contains the desired StreetAddress for the object.
         * Input:   string city, contains the desired City for the object.
         * Input:   string state, contains the desired State for the object.
         * Input:   string zip, contains the desired Zip for the object.
         * Input:   string latitude, contains the desired Latitude for the object.
         * Input:   string longitude, contains the desired Longitude for the object.
         * Input:   string phone, contains the desired Phone for the object.
         * Input:   int licenseFiscalYear, contains the desired LicenseFiscalYear for the object.
         * Input:   int licenseNumber, contains the desired LicenseNumber for the object.
         * Input:   DateTime licenseIssueDate, contains the desired LicenseIssueDate for the object.
         * Input:   DateTime licenseExpirDate, contains the desired LicenseExpirDate for the object.
         * Input:   string licenseStatus, contains the desired LicenseStatus for the object.
         * Input:   string councilDistrict, contains the desired CouncilDistrict for the object.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public Business(string name, string type, string streetAddress, string city, string state,
            string zip, string latitude, string longitude, string phone, int licenseFiscalYear,
            int licenseNumber, DateTime licenseIssueDate, DateTime licenseExpirDate,
            string licenseStatus, string councilDistrict)
            : base(name, type, streetAddress, city, state, zip, latitude, longitude, phone)
        {
            LicenseFiscalYear = licenseFiscalYear;
            LicenseNumber = licenseNumber;
            LicenseIssueDate = licenseIssueDate;
            LicenseExpirDate = licenseExpirDate;
            LicenseStatus = licenseStatus;
            CouncilDistrict = councilDistrict;
        }

        /*------------------------------------------------------------------------------------------
         * Type:    Auto-implemented Properties
        ------------------------------------------------------------------------------------------*/
        public override int ItemID { get; set; }            // Item ID

        public override string Name { get; set; }           // Business Name
        public override string Type { get; set; }           // Business Classification
        public override string StreetAddress { get; set; }  // Street Address
        public override string City { get; set; }           // City
        public override string State { get; set; }          // State
        public override string Zip { get; set; }            // Zip Code
        public override string Latitude { get; set; }       // Latitude
        public override string Longitude { get; set; }      // Longitude
        public override string Phone { get; set; }          // Phone Number

        public DateTime LicenseIssueDate { get; set; }      // Business License Issue Date
        public DateTime LicenseExpirDate { get; set; }      // Business License Expiration Date
        public string LicenseStatus { get; set; }           // Business License Status
        public string CouncilDistrict { get; set; }         // Council District

        /*------------------------------------------------------------------------------------------
         * Name:    ItemType
         * Type:    Property
         * Purpose: Provides access to the itemType field.
        ------------------------------------------------------------------------------------------*/
        public override string ItemType
        {
            get
            {
                return itemType;
            }
            set
            {
                // Do nothing.
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    LicenseFiscalYear
         * Type:    Property
         * Purpose: Provides access to the licenseFiscalYear field, and validation for the same.
        ------------------------------------------------------------------------------------------*/
        public int LicenseFiscalYear
        {
            get
            {
                return licenseFiscalYear;
            }
            set
            {
                if (value >= 0)
                    licenseFiscalYear = value;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    LicenseNumber
         * Type:    Property
         * Purpose: Provides access to the licenseNumber field, and validation for the same.
        ------------------------------------------------------------------------------------------*/
        public int LicenseNumber
        {
            get
            {
                return licenseNumber;
            }
            set
            {
                if (value >= 0)
                    licenseNumber = value;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    this[]
         * Type:    Indexer
         * Purpose: Provides easy access to the properties of the class.
         * Input:   FieldMenuHelper fiendNum, represents the desired property.
         * Output:  object, contains whichever property was desired, or 0 if the property was not
         *          found.
        ------------------------------------------------------------------------------------------*/
        public override object this[FieldMenuHelper fieldNum]
        {
            get
            {
                switch (fieldNum)
                {
                    case FieldMenuHelper.LicenseFiscalYear:
                        return LicenseFiscalYear;
                    case FieldMenuHelper.LicenseNumber:
                        return LicenseNumber;
                    case FieldMenuHelper.LicenseIssueDate:
                        return LicenseIssueDate;
                    case FieldMenuHelper.LicenseExpirDate:
                        return LicenseExpirDate;
                    case FieldMenuHelper.LicenseStatus:
                        return LicenseStatus;
                    case FieldMenuHelper.CouncilDistrict:
                        return CouncilDistrict;
                    default:
                        return base[fieldNum];
                }
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToStringCSV
         * Type:    Method
         * Purpose: Serializes the data contained in the object into a comma-separated value string.
         * Input:   Nothing.
         * Output:  string, representing the data of this object as serialized to a CSV string.
        ------------------------------------------------------------------------------------------*/
        public override string ToStringCSV()
        {
            char separator = ',';
            return base.ToStringCSV() + separator + LicenseFiscalYear + '-' + LicenseNumber + 
                separator + LicenseIssueDate.ToShortDateString() + separator + 
                LicenseExpirDate.ToShortDateString() + separator + LicenseStatus + separator + 
                CouncilDistrict;
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToString
         * Type:    Method
         * Purpose: Override of ToString() method. Formats the data contained in this object so it
         *          looks pretty.
         * Input:   Nothing.
         * Output:  string, containing serialized object data.
        ------------------------------------------------------------------------------------------*/
        public override string ToString()
        {
            // Returns a string formatted as follows:
            //  Item ID (Item Type): <ItemID> (<ItemType>)
            // Business Name (Type): <Name> (<Type>)
            //              Address: <StreetAddress>, <City>, <State> <Zip>
            //      GPS Coordinates: (<Latitude>, <Longitude>)
            //         Phone Number: <Phone>
            //       License Number: <LicenseFiscalYear>-<LicenseNumber>
            //                Valid: From <LicenseIssueDate> to <LicenseExpirDate>
            //               Status: <LicenseStatus>
            //     Council District: <CouncilDistrict>
            return string.Format(
                " Item ID (Item Type): {0} ({1})\n" +
                "Business Name (Type): {2} ({3})\n" +
                "             Address: {4}, {5}, {6} {7}\n" +
                "     GPS Coordinates: ({8}, {9})\n" +
                "        Phone Number: {10}\n" +
                "      License Number: {11}-{12}\n" +
                "               Valid: From {13} to {14}\n" +
                "              Status: {15}\n" +
                "    Council District: {16}",
                ItemID, ItemType,
                Name, Type,
                StreetAddress, City, State, Zip,
                Latitude, Longitude,
                Phone,
                LicenseFiscalYear, LicenseNumber,
                LicenseIssueDate.ToShortDateString(), LicenseExpirDate.ToShortDateString(),
                LicenseStatus,
                CouncilDistrict);
        }
    }
}
