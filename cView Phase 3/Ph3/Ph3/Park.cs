/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy and Dr. Raman Adaikkalavan
 * Date:        2015-06-17
 * Assignment:  cView-P3
 * Source File: Park.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Contains the Park class, derived from the Item abstract class, and supporting
 *              methods.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ph3
{
    public class Park : Item
    {
        /*------------------------------------------------------------------------------------------
         * Type:    Helper Constants
        ------------------------------------------------------------------------------------------*/
        public new const FieldMenuHelper FieldMin = FieldMenuHelper.FeatureBaseball;
        public new const FieldMenuHelper FieldMax = FieldMenuHelper.BackPark;
        public const int FieldOffset = 8;

        /*------------------------------------------------------------------------------------------
         * Type:    Private Fields
        ------------------------------------------------------------------------------------------*/
        private string itemType = "park";
        private int featureBaseball;
        private float featureBasketball;
        private float featureGolf;
        private int featureLargeMPField;
        private int featureTennis;
        private int featureVolleyball;

        /*------------------------------------------------------------------------------------------
         * Type:    Constructor
         * Purpose: Basic no-parameter constructor.
         * Input:   Nothing.
        ------------------------------------------------------------------------------------------*/
        public Park()
        {
            // Nothing else to do.
        }

        /*------------------------------------------------------------------------------------------
         * Type:    Constructor
         * Purpose: Copy constructor.
         * Input:   Park fromItem, reference to the other Park from which fields should be copied.
        ------------------------------------------------------------------------------------------*/
        public Park(Park fromItem)
            : base(fromItem)
        {
            itemType = fromItem.itemType;

            FeatureBaseball = fromItem.FeatureBaseball;
            FeatureBasketball = fromItem.FeatureBasketball;
            FeatureGolf = fromItem.FeatureGolf;
            FeatureLargeMPField = fromItem.FeatureLargeMPField;
            FeatureTennis = fromItem.FeatureTennis;
            FeatureVolleyball = fromItem.FeatureVolleyball;
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
         * Input:   int featureBaseball, contains the desired FeatureBaseball for the object.
         * Input:   float featureBasketball, contains the desired FeatureBasketball for the object.
         * Input:   float featureGolf, contains the desired FeatureGolf for the object.
         * Input:   int featureLargeMPField, contains the desired FeatureLargeMPField for the
         *          object.
         * Input:   int featureTennis, contains the desired FeatureTennis for the object.
         * Input:   int featureVolleyball, contains the desired FeatureVolleyball for the object.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        public Park(string name, string type, string streetAddress, string city, string state,
            string zip, string latitude, string longitude, string phone, int featureBaseball,
            float featureBasketball, float featureGolf, int featureLargeMPField,
            int featureTennis, int featureVolleyball)
            : base(name, type, streetAddress, city, state, zip, latitude, longitude, phone)
        {
            FeatureBaseball = featureBaseball;
            FeatureBasketball = featureBasketball;
            FeatureGolf = featureGolf;
            FeatureLargeMPField = featureLargeMPField;
            FeatureTennis = featureTennis;
            FeatureVolleyball = featureVolleyball;
        }

        /*------------------------------------------------------------------------------------------
         * Type:    Auto-implemented Properties
        ------------------------------------------------------------------------------------------*/
        public override int ItemID { get; set; }            // Item ID

        public override string Name { get; set; }           // Park Name
        public override string Type { get; set; }           // Park Type
        public override string StreetAddress { get; set; }  // Street Address
        public override string City { get; set; }           // City
        public override string State { get; set; }          // State
        public override string Zip { get; set; }            // Zip Code
        public override string Latitude { get; set; }       // Latitude
        public override string Longitude { get; set; }      // Longitude
        public override string Phone { get; set; }          // Phone Number

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
         * Name:    FeatureBaseball
         * Type:    Property
         * Purpose: Provides access to the featureBaseball field, and validation for the same.
        ------------------------------------------------------------------------------------------*/
        public int FeatureBaseball
        {
            get
            {
                return featureBaseball;
            }
            set
            {
                if (value >= 0)
                    featureBaseball = value;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    FeatureBasketball
         * Type:    Property
         * Purpose: Provides access to the featureBasketball field, and validation for the same.
        ------------------------------------------------------------------------------------------*/
        public float FeatureBasketball
        {
            get
            {
                return featureBasketball;
            }
            set
            {
                if (value >= 0 && value % 0.5 == 0)
                    featureBasketball = value;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    FeatureGolf
         * Type:    Property
         * Purpose: Provides access to the featureGolf field, and validation for the same.
        ------------------------------------------------------------------------------------------*/
        public float FeatureGolf
        {
            get
            {
                return featureGolf;
            }
            set
            {
                if (value >= 0 && value % 0.5 == 0)
                    featureGolf = value;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    FeatureLargeMPField
         * Type:    Property
         * Purpose: Provides access to the featureLargeMPField field, and validation for the same.
        ------------------------------------------------------------------------------------------*/
        public int FeatureLargeMPField
        {
            get
            {
                return featureLargeMPField;
            }
            set
            {
                if (value >= 0)
                    featureLargeMPField = value;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    FeatureTennis
         * Type:    Property
         * Purpose: Provides access to the featureTennis field, and validation for the same.
        ------------------------------------------------------------------------------------------*/
        public int FeatureTennis
        {
            get
            {
                return featureTennis;
            }
            set
            {
                if (value >= 0)
                    featureTennis = value;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    FeatureVolleyball
         * Type:    Property
         * Purpose: Provides access to the featureVolleyball field, and validation for the same.
        ------------------------------------------------------------------------------------------*/
        public int FeatureVolleyball
        {
            get
            {
                return featureVolleyball;
            }
            set
            {
                if (value >= 0)
                    featureVolleyball = value;
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
                    case FieldMenuHelper.FeatureBaseball:
                        return FeatureBaseball;
                    case FieldMenuHelper.FeatureBasketball:
                        return FeatureBasketball;
                    case FieldMenuHelper.FeatureGolf:
                        return FeatureGolf;
                    case FieldMenuHelper.FeatureLargeMPField:
                        return FeatureLargeMPField;
                    case FieldMenuHelper.FeatureTennis:
                        return FeatureTennis;
                    case FieldMenuHelper.FeatureVolleyball:
                        return FeatureVolleyball;
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
            return base.ToStringCSV() + separator + FeatureBaseball + separator + 
                FeatureBasketball + separator + FeatureGolf + separator + FeatureLargeMPField + 
                separator + FeatureTennis + separator + FeatureVolleyball;
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
            // Returns a the base a string formatted as follows:
            //  Item ID (Item Type): <ItemID> (<ItemType>)
            //     Park Name (Type): <Name> (<Type>)
            //              Address: <StreetAddress>, <City>, <State> <Zip>
            //      GPS Coordinates: (<Latitude>, <Longitude>)
            //         Phone Number: <Phone>
            //    Baseball Diamonds: <FeatureBaseball>
            //    Basketball Courts: <FeatureBasketball>
            //         Golf Courses: <FeatureGolf>
            //      Large MP Fields: <FeatureLargeMPField>
            //        Tennis Courts: <FeatureTennis>
            //    Volleyball Courts: <FeatureVolleyball>
            return string.Format(
                " Item ID (Item Type): {0} ({1})\n" +
                "    Park Name (Type): {2} ({3})\n" +
                "             Address: {4}, {5}, {6} {7}\n" +
                "     GPS Coordinates: ({8}, {9})\n" +
                "        Phone Number: {10}\n" +
                "   Baseball Diamonds: {11}\n" +
                "   Basketball Courts: {12}\n" +
                "        Golf Courses: {13}\n" +
                "     Large MP Fields: {14}\n" +
                "       Tennis Courts: {15}\n" +
                "   Volleyball Courts: {16}",
                ItemID, ItemType,
                Name, Type,
                StreetAddress, City, State, Zip,
                Latitude, Longitude,
                Phone,
                FeatureBaseball,
                FeatureBasketball,
                FeatureGolf,
                FeatureLargeMPField,
                FeatureTennis,
                FeatureVolleyball);
        }
    }
}
