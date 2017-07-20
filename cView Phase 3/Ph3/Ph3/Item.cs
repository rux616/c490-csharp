/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy and Dr. Raman Adaikkalavan
 * Date:        2015-06-17
 * Assignment:  cView-P3
 * Source File: Item.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Provides the base abstract class for data items along with some supporting methods.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    public abstract class Item
    {
        /*------------------------------------------------------------------------------------------
         * Type:    Helper Constants
        ------------------------------------------------------------------------------------------*/
        public const FieldMenuHelper FieldCommonMin = FieldMenuHelper.Name;
        public const FieldMenuHelper FieldCommonMax = FieldMenuHelper.Phone;
        public const FieldMenuHelper FieldMin = FieldMenuHelper.Name;
        public const FieldMenuHelper FieldMax = FieldMenuHelper.BackPark;

        /*------------------------------------------------------------------------------------------
         * Type:    Constructor
         * Purpose: Basic no-parameter constructor.
         * Input:   Nothing.
        ------------------------------------------------------------------------------------------*/
        public Item()
        {
            // Nothing else to do.
        }

        /*------------------------------------------------------------------------------------------
         * Type:    Constructor
         * Purpose: Copy constructor.
         * Input:   Item fromItem, reference to the other Item from which fields should be copied.
        ------------------------------------------------------------------------------------------*/
        public Item(Item fromItem)
        {
            ItemID = fromItem.ItemID;

            Name = fromItem.Name;
            Type = fromItem.Type;
            StreetAddress = fromItem.StreetAddress;
            City = fromItem.City;
            State = fromItem.State;
            Zip = fromItem.Zip;
            Latitude = fromItem.Latitude;
            Longitude = fromItem.Longitude;
            Phone = fromItem.Phone;
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
        ------------------------------------------------------------------------------------------*/
        public Item(string name, string type, string streetAddress, string city, string state,
            string zip, string latitude, string longitude, string phone)
        {
            Name = name;
            Type = type;
            StreetAddress = streetAddress;
            City = city;
            State = state;
            Zip = zip;
            Latitude = latitude;
            Longitude = longitude;
            Phone = phone;
        }

        /*------------------------------------------------------------------------------------------
         * Name:    FieldMenuHelper
         * Type:    Enum
         * Purpose: Represents the fields in use in this class, with additions for its derived
         *          classes.
        ------------------------------------------------------------------------------------------*/
        public enum FieldMenuHelper
        {
            // Common Fields
            Name = 1,
            Type,
            StreetAddress,
            City,
            State,
            Zip,
            Latitude,
            Longitude,
            Phone,
            Back,

            // Business Fields
            LicenseFiscalYear,
            LicenseNumber,
            LicenseIssueDate,
            LicenseExpirDate,
            LicenseStatus,
            CouncilDistrict,
            BackBusiness,

            // Park Fields
            FeatureBaseball,
            FeatureBasketball,
            FeatureGolf,
            FeatureLargeMPField,
            FeatureTennis,
            FeatureVolleyball,
            BackPark
        }

        /*------------------------------------------------------------------------------------------
         * BEGIN UNTOUCHABLE CODE -->
        ------------------------------------------------------------------------------------------*/
        // Create an ID for each item. So if you have 10 parks and 5 businesses, ID will be 1 to 15.
        public abstract int ItemID { get; set; }

        // Value will be "business", "park", or "publicfacility".
        public abstract string ItemType { get; set; }

        // Populate from CSV
        public abstract string Name { get; set; }
        public abstract string Type { get; set; }
        public abstract string StreetAddress { get; set; }
        public abstract string City { get; set; }
        public abstract string State { get; set; }
        public abstract string Zip { get; set; }
        public abstract string Latitude { get; set; }
        public abstract string Longitude { get; set; }
        public abstract string Phone { get; set; }
        /*------------------------------------------------------------------------------------------
         * <-- END UNTOUCHABLE CODE
        ------------------------------------------------------------------------------------------*/

        /*------------------------------------------------------------------------------------------
         * Name:    this[]
         * Type:    Indexer
         * Purpose: Provides easy access to the properties of the class. Need to change the indexer
         *          name because its default is "Item" and the compiler throws a fit because the
         *          class is already named that.
         * Input:   FieldMenuHelper fiendNum, represents the desired property.
         * Output:  object, contains whichever property was desired, or 0 if the property was not
         *          found.
        ------------------------------------------------------------------------------------------*/
        [IndexerName("Index")]
        public virtual object this[FieldMenuHelper fieldNum]
        {
            get
            {
                switch (fieldNum)
                {
                    case FieldMenuHelper.Name:
                        return Name;
                    case FieldMenuHelper.Type:
                        return Type;
                    case FieldMenuHelper.StreetAddress:
                        return StreetAddress;
                    case FieldMenuHelper.City:
                        return City;
                    case FieldMenuHelper.State:
                        return State;
                    case FieldMenuHelper.Zip:
                        return Zip;
                    case FieldMenuHelper.Latitude:
                        return Latitude;
                    case FieldMenuHelper.Longitude:
                        return Longitude;
                    case FieldMenuHelper.Phone:
                        return Phone;
                    default:
                        return 0;
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
        public virtual string ToStringCSV()
        {
            char separator = ',';
            return Name + separator + Type + separator + StreetAddress + separator + City + 
                separator + State +separator + Zip + separator + Latitude + separator + Longitude + 
                separator + Phone;
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ToStringSimple
         * Type:    Method
         * Purpose: Formats the data contained in the object into a simplified string containing
         *          only the ItemID, ItemType, and Name properties.
         * Input:   Nothing.
         * Output:  string, representing a simplified view of this object.
        ------------------------------------------------------------------------------------------*/
        public virtual string ToStringSimple()
        {
            // Returns a string formatted as follows:
            //   Item ID: <ItemID>
            // Item Type: <ItemType>
            //      Name: <Name>
            return string.Format(
                "  Item ID: {0}\n" +
                "Item Type: {1}\n" +
                "     Name: {2}",
                ItemID,
                ItemType,
                Name);
        }
    }
}
