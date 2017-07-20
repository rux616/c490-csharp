using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    class Business : Item
    {
        //Keep track of the descriptions for ToString output.
        private static Dictionary<string, string> ClassificationDescription =
            new Dictionary<string, string>();

        private static Dictionary<string, string> LicenseStatusDescription =
            new Dictionary<string, string>();

        private static Dictionary<string, string> CouncilDistrictDescription =
            new Dictionary<string, string>();


        public override int ItemID { get; set; }            //Item ID
        public override string ItemType { get; set; }       //Item Type ("business")

        //Imported from CSV
        public override string Name { get; set; }           //Business Name
        public override string Type { get; set; }           //Business Classification
        public override string StreetAddress { get; set; }  //Street Address
        public override string City { get; set; }           //City
        public override string State { get; set; }          //State
        public override string Zip { get; set; }            //Zip Code
        public override string Latitude { get; set; }       //Latitude
        public override string Longitude { get; set; }      //Longitude
        public override string Phone { get; set; }          //Phone Number

        public DateTime LicenseFiscalYear { get; set; }     //Business License Fiscal Year
        public int LicenseNumber { get; set; }              //Business License Number
        public DateTime LicenseIssueDate { get; set; }      //Business License Issued Date
        public DateTime LicenseExpirDate { get; set; }      //Business License Expiration Date
        public string LicenseStatus { get; set; }           //Business License Status
        public string CouncilDistrict { get; set; }         //Council District

        public override enum Fields
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
            LicenseFiscalYear,
            LicenseNumber,
            LicenseIssueDate,
            LicenseExpirDate,
            LicenseStatus,
            CouncilDistrict
        }

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public override string ToString()
        {
            //return String.Format("{0}\n", base.ToString());
            return base.ToString();
        }
    }
}
