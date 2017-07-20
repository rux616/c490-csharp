using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    class PublicFacility : Item
    {
        public override int ItemID { get; set; }            //Item ID
        public override string ItemType { get; set; }       //Item Type ("publicfacility")

        //Imported from CSV
        public override string Name { get; set; }           //Facility Name
        public override string Type { get; set; }           //Facility Type
        public override string StreetAddress { get; set; }  //Street Address
        public override string City { get; set; }           //City
        public override string State { get; set; }          //State
        public override string Zip { get; set; }            //Zip Code
        public override string Latitude { get; set; }       //Latitude
        public override string Longitude { get; set; }      //Longitude
        public override string Phone { get; set; }          //Phone Number
    }
}
