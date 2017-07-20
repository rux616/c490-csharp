/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-23
 * Assignment:  cView-P4
 * Source File: Global.asax.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Code-behind file for Global.asax.  Contains things that should be globally
 *              accessible, such as enums, exceptions, and strings.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace cView_P4_DanCassidy
{
    public class Global : System.Web.HttpApplication
    {
        public static class Enums
        {
            /*--------------------------------------------------------------------------------------
             * Name:    BusinessFields
             * Type:    Enum
             * Purpose: Represents the different fields present in the Business class.
            --------------------------------------------------------------------------------------*/
            public enum BusinessFields
            {
                Name = 1,
                Type,
                StreetAddress,
                City,
                State,
                Zip,
                Latitude,
                Longitude,
                Phone,
                LicenseNumber,
                LicenseIssueDate,
                LicenseExpirDate,
                LicenseStatus,
                CouncilDistrict
            }

            /*--------------------------------------------------------------------------------------
             * Name:    ComparatorsNotStrings
             * Type:    Enum
             * Purpose: Represents the possible comparators available for use on non-strings.
            --------------------------------------------------------------------------------------*/
            public enum ComparatorsNotStrings
            {
                Contain = 1,
                NotContain,
                Equal,
                NotEqual,
                Greater,
                Less,
                GreaterEqual,
                LessEqual
            }

            /*--------------------------------------------------------------------------------------
             * Name:    ComparatorsStrings
             * Type:    Enum
             * Purpose: Represents the possible comparators available for use on strings.
            --------------------------------------------------------------------------------------*/
            public enum ComparatorsStrings
            {
                Contain = 1,
                NotContain,
                Equal,
                NotEqual
            }

            /*--------------------------------------------------------------------------------------
             * Name:    ItemTypes
             * Type:    Enum
             * Purpose: Represents the different types of items.
            --------------------------------------------------------------------------------------*/
            public enum ItemTypes
            {
                Business = 1,
                Park,
                PublicFacility,
            }

            /*--------------------------------------------------------------------------------------
             * Name:    ParkFields
             * Type:    Enum
             * Purpose: Represents the different fields present in the Park class.
            --------------------------------------------------------------------------------------*/
            public enum ParkFields
            {
                Name = 1,
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

            /*--------------------------------------------------------------------------------------
             * Name:    PublicFacilityFields
             * Type:    Enum
             * Purpose: Represents the different fiels present in the Public Facility class.
            --------------------------------------------------------------------------------------*/
            public enum PublicFacilityFields
            {
                Name = 1,
                Type,
                StreetAddress,
                City,
                State,
                Zip,
                Latitude,
                Longitude,
                Phone
            }

        }

        public class FieldDataTypes
        {
            public string this[string fieldName]
            {
                get
            }
        }

        public class Exceptions
        {
            /*--------------------------------------------------------------------------------------
             * Name:    DuplicatePKException
             * Type:    Exception
             * Purpose: Intended to describe a situation where an object with a duplicate primary
             *          key attempted to be inserted into a primary keyed data structure.
            --------------------------------------------------------------------------------------*/
            [Serializable]
            public class DuplicatePKException : Exception
            {
                public DuplicatePKException() { }

                public DuplicatePKException(string message)
                    : base(message) { }

                public DuplicatePKException(string keyName, object keyValue)
                    : base(string.Format("An item already exists with a {0} of {1}.",
                           keyName, keyValue)) { }

                public DuplicatePKException(string message, Exception inner)
                    : base(message, inner) { }

                protected DuplicatePKException(
                  System.Runtime.Serialization.SerializationInfo info,
                  System.Runtime.Serialization.StreamingContext context)
                    : base(info, context) { }
            }

            /*--------------------------------------------------------------------------------------
             * Name:    EmptyOrNullPKException
             * Type:    Exception
             * Purpose: Inteded to describe a situation where an object with an empty or null
             *          primary key attempted to be inserted into a primary keyed data structure.
            --------------------------------------------------------------------------------------*/
            [Serializable]
            public class EmptyOrNullPKException : Exception
            {
                public EmptyOrNullPKException() { }

                public EmptyOrNullPKException(string keyName)
                    : base(string.Format("{0} cannot be empty or null.", keyName)) { }

                public EmptyOrNullPKException(string message, Exception inner)
                    : base(message, inner) { }

                protected EmptyOrNullPKException(
                  System.Runtime.Serialization.SerializationInfo info,
                  System.Runtime.Serialization.StreamingContext context)
                    : base(info, context) { }
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    Strings
         * Type:    Class
         * Purpose: Contains common strings used throughout the application in a centrally-managed
         *          location.
        ------------------------------------------------------------------------------------------*/
        public static class Strings
        {
            public const string Separator = ":";

            public const string BusinessName = "Business Name";
            public const string ParkName = "Park Name";
            public const string PublicFacilityName = "Public Facility Name";

            public const string BusinessType = "Type of Business";
            public const string ParkType = "Type of Park";
            public const string PublicFacilityType = "Type of Public Facility";

            public const string BusinessKey = "License Number";
            public const string ParkKey = ParkName;
            public const string PublicFacilityKey = PublicFacilityName;
        }

    }
}