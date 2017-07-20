using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    class Park : Item
    {
        public override int ItemID { get; set; }            //Item ID
        public override string ItemType { get; set; }       //Item Type ("park")

        //Imported from CSV
        public override string Name { get; set; }           //Park Name
        public override string Type { get; set; }           //Park Type
        public override string StreetAddress { get; set; }  //Street Address
        public override string City { get; set; }           //City
        public override string State { get; set; }          //State
        public override string Zip { get; set; }            //Zip Code
        public override string Latitude { get; set; }       //Latitude
        public override string Longitude { get; set; }      //Longitude
        public override string Phone { get; set; }          //Phone Number

        public float FeatureBaseball { get; set; }          //Number of baseball diamonds
        public float FeatureBasketball { get; set; }        //Number of basketball courts
        public float FeatureGolf { get; set; }              //Number of golf courses
        public float FeatureLargeMPField { get; set; }      //Number of large multipurpose fields
        public float FeatureTennis { get; set; }            //Number of tennis courts
        public float FeatureVolleyball { get; set; }        //Number of volleyball courts

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
            FeatureBaseball,
            FeatureBasketball,
            FeatureGolf,
            FeatureLargeMPField,
            FeatureTennis,
            FeatureVolleyball
        }

        //public

        /*------------------------------------------------------------------------------------------
         * Method:  
         * Purpose: 
         * Input:   
         * Output:  
        ------------------------------------------------------------------------------------------*/
        public override string ToString()
        {
            return base.ToString() + String.Format("\nBaseball Diamonds: {0}, " + 
                "Basketball Courts: {1}, Golf Courses: {2}, Large Multipurpose Fields: {3}, " +
                "Tennis Courts: {4}, Volleyball Courts: {5}", FeatureBaseball, FeatureBasketball,
                FeatureGolf, FeatureLargeMPField, FeatureTennis, FeatureVolleyball);
        }
    }
}
