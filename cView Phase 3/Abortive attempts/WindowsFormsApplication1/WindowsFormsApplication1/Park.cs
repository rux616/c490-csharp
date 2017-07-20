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

        public object this[Fields field]
        {
            get
            {
                switch (field)
                {
                    case Fields.Name:
                        return Name;
                    case Fields.Type:
                        return Type;
                    case Fields.StreetAddress:
                        return StreetAddress;
                    case Fields.City:
                        return City;
                    case Fields.State:
                        return State;
                    case Fields.Zip:
                        return Zip;
                    case Fields.Latitude:
                        return Latitude;
                    case Fields.Longitude:
                        return Longitude;
                    case Fields.Phone:
                        return Phone;
                    default:
                        return null;
                }
            }
        }

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
