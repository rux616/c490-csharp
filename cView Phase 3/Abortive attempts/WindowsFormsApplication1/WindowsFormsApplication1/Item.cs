using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    abstract class Item
    {
        /*------------------------------------------------------------------------------------------
         * BEGIN UNTOUCHABLE CODE -->
        ------------------------------------------------------------------------------------------*/
        //Create an ID for each item. So if you have 10 parks and 5 businesses, ID will be 1 to 15.
        public abstract int ItemID { get; set; }

        //Value will be "business", "park", or "publicfacility".
        public abstract string ItemType { get; set; }

        //Populate from CSV
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

        public enum Fields
        {
            Name,
            Type,
            StreetAddress,
            City,
            State,
            Zip,
            Latitude,
            Longitude,
            Phone,

            //Business Specific
            LicenseFiscalYear,
            LicenseNumber,
            LicenseIssueDate,
            LicenseExpirDate,
            LicenseStatus,
            CouncilDistrict,

            //Parks Specific
            FeatureBaseball,
            FeatureBasketball,
            FeatureGolf,
            FeatureLargeMPField,
            FeatureTennis,
            FeatureVolleyball
        }

        /*------------------------------------------------------------------------------------------
         * Method:  ToString
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public override string ToString()
        {
            //Returns a string formatted as follows:
            // Name (Type)
            // StreetAddress, City, State Zip
            // (Latitude, Longitude)
            // Phone
            return String.Format("{0} ({1})\n{2}, {3}, {4} {5}\n({6}, {7})\n{8}",
                Name, Type, StreetAddress, City, State, Zip, Latitude, Longitude, Phone);
        }

    }
}
