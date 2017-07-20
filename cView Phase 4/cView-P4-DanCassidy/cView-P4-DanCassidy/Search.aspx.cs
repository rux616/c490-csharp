/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-23
 * Assignment:  cView-P4
 * Source File: Search.aspx.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Code-behind file for Search.aspx. Controls the interface whereby a user can search
 *              the tables.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cView_P4_DanCassidy
{
    public partial class Search : System.Web.UI.Page
    {
        /*------------------------------------------------------------------------------------------
         * Name:    btnSearch_Click
         * Type:    Event Handler Method
         * Purpose: Handles the actual search and display of the results.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;
            mViewSearchResults.ActiveViewIndex = -1;

            // Pre-conversions to save some space.
            string toSearchFor = txtSearch.Text.Trim();
            byte toSearchForByte = SimpleConvert.ToByte(toSearchFor);
            DateTime toSearchForDateTime = SimpleConvert.ToDateTime(toSearchFor);
            decimal toSearchForDecimal = SimpleConvert.ToDecimal(toSearchFor);

            int resultCount = 0;
            int viewToDisplay = -1;
            GridView gViewToDisplay;

            int selectedIndex;
            object baseObject;

            string table;
            string control;
            string field = ;
            Business something = new Business();
            something.GetType().GetProperty(field).GetType().ToString();

            // Determine what comparator to use; default is "|" for "contains".
            string comparator = "|";
            if (ddlComparatorsStrings.Visible == true)
            {
                switch ((Global.Enums.ComparatorsStrings)ddlComparatorsStrings.SelectedIndex)
                {
                    case Global.Enums.ComparatorsStrings.NotContain:
                        comparator = "!|";
                        break;

                    case Global.Enums.ComparatorsStrings.Equal:
                        comparator = "==";
                        break;

                    case Global.Enums.ComparatorsStrings.NotEqual:
                        comparator = "!=";
                        break;

                    default:
                        break;
                }
            }
            else if (ddlComparatorsNotStrings.Visible == true)
            {
                switch ((Global.Enums.ComparatorsNotStrings)ddlComparatorsNotStrings.SelectedIndex)
                {
                    //case Global.Enums.ComparatorsNotStrings.NotContain:
                    //    comparator = "!|";
                    //    break;

                    case Global.Enums.ComparatorsNotStrings.Equal:
                        comparator = "==";
                        break;

                    case Global.Enums.ComparatorsNotStrings.NotEqual:
                        comparator = "!=";
                        break;

                    case Global.Enums.ComparatorsNotStrings.Greater:
                        comparator = "&gt;";
                        break;

                    case Global.Enums.ComparatorsNotStrings.Less:
                        comparator = "&lt;";
                        break;

                    case Global.Enums.ComparatorsNotStrings.GreaterEqual:
                        comparator = "&gt;=";
                        break;

                    case Global.Enums.ComparatorsNotStrings.LessEqual:
                        comparator = "&lt;=";
                        break;

                    default:
                        return;
                        //break;
                }
            }

            

            // Do the search.
            //
            // The method I ended up using is a bit kludgy, but I had to resort to this because LINQ
            // to Entities is stupid and doesn't even try to evaluate what it can server-side prior
            // to attempting to translate the query to SQL and failing because indexers are not a
            // SQL thing.
            //try
            //{
            //    using (CViewDataEntities database = new CViewDataEntities())
            //    {
            //        switch ((Global.Enums.ItemTypes)ddlItemType.SelectedIndex)
            //        {
            //            case Global.Enums.ItemTypes.Business:
            //                viewToDisplay = 0;
            //                gViewToDisplay = gViewBusinessResults;



            //                selectedIndex = ddlBusiness.SelectedIndex;
            //                baseObject = database.Businesses.First()[selectedIndex];
            //                if (baseObject != null)
            //                {
            //                    IEnumerable<Business> searchResults = null;
            //                    DbSet<Business> tableToSearch = database.Businesses;
            //                    switch (comparator)
            //                    {
            //                        case "|":
            //                            searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                i[selectedIndex].ToString().IndexOf(
            //                                toSearchFor, StringComparison.OrdinalIgnoreCase) >= 0);
            //                            break;

            //                        case "!|":
            //                            searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                i[selectedIndex].ToString().IndexOf(
            //                                toSearchFor, StringComparison.OrdinalIgnoreCase) < 0);
            //                            break;

            //                        case "==":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] ==
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] ==
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] ==
            //                                    toSearchForDecimal);
            //                            else
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    ((string)i[selectedIndex]).ToLower() == toSearchFor.
            //                                    ToLower());
            //                            break;

            //                        case "!=":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] !=
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] !=
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] !=
            //                                    toSearchForDecimal);
            //                            else
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    ((string)i[selectedIndex]).ToLower() != toSearchFor.
            //                                    ToLower());
            //                            break;

            //                        case ">":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] >
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] >
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] >
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \">\" cannot be applied to strings.");
            //                            break;

            //                        case "<":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] <
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] <
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] <
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \"<\" cannot be applied to strings.");
            //                            break;

            //                        case ">=":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] >=
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] >=
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] >=
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \">=\" cannot be applied to strings.");
            //                            break;

            //                        case "<=":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] <=
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] <=
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] <=
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \"<=\" cannot be applied to strings.");
            //                            break;

            //                        default:
            //                            throw new InvalidOperationException("Invalid comparator.");
            //                    }
            //                    resultCount = searchResults.Count();
            //                    gViewToDisplay.DataSource = searchResults.ToList();
            //                }
            //                break;

            //            case Global.Enums.ItemTypes.Park:
            //                viewToDisplay = 1;
            //                gViewToDisplay = gViewParkResults;
            //                selectedIndex = ddlPark.SelectedIndex;
            //                baseObject = database.Parks.First()[selectedIndex];
            //                if (baseObject != null)
            //                {
            //                    IEnumerable<Park> searchResults = null;
            //                    DbSet<Park> tableToSearch = database.Parks;
            //                    switch (comparator)
            //                    {
            //                        case "|":
            //                            searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                i[selectedIndex].ToString().IndexOf(
            //                                toSearchFor, StringComparison.OrdinalIgnoreCase) >= 0);
            //                            break;

            //                        case "!|":
            //                            searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                i[selectedIndex].ToString().IndexOf(
            //                                toSearchFor, StringComparison.OrdinalIgnoreCase) < 0);
            //                            break;

            //                        case "==":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] ==
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] ==
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] ==
            //                                    toSearchForDecimal);
            //                            else
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    ((string)i[selectedIndex]).ToLower() == toSearchFor.
            //                                    ToLower());
            //                            break;

            //                        case "!=":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] !=
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] !=
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] !=
            //                                    toSearchForDecimal);
            //                            else
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    ((string)i[selectedIndex]).ToLower() != toSearchFor.
            //                                    ToLower());
            //                            break;

            //                        case ">":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] >
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] >
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] >
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \">\" cannot be applied to strings.");
            //                            break;

            //                        case "<":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] <
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] <
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] <
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \"<\" cannot be applied to strings.");
            //                            break;

            //                        case ">=":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] >=
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] >=
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] >=
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \">=\" cannot be applied to strings.");
            //                            break;

            //                        case "<=":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] <=
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] <=
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] <=
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \"<=\" cannot be applied to strings.");
            //                            break;

            //                        default:
            //                            throw new InvalidOperationException("Invalid comparator.");
            //                    }
            //                    resultCount = searchResults.Count();
            //                    gViewToDisplay.DataSource = searchResults.ToList();
            //                }
            //                break;

            //            case Global.Enums.ItemTypes.PublicFacility:
            //                viewToDisplay = 2;
            //                gViewToDisplay = gViewPublicFacilityResults;
            //                selectedIndex = ddlPublicFacility.SelectedIndex;
            //                baseObject = database.PublicFacilities.First()[selectedIndex];
            //                if (baseObject != null)
            //                {
            //                    IEnumerable<PublicFacility> searchResults = null;
            //                    DbSet<PublicFacility> tableToSearch = database.PublicFacilities;
            //                    switch (comparator)
            //                    {
            //                        case "|":
            //                            searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                i[selectedIndex].ToString().IndexOf(
            //                                toSearchFor, StringComparison.OrdinalIgnoreCase) >= 0);
            //                            break;

            //                        case "!|":
            //                            searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                i[selectedIndex].ToString().IndexOf(
            //                                toSearchFor, StringComparison.OrdinalIgnoreCase) < 0);
            //                            break;

            //                        case "==":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] ==
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] ==
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] ==
            //                                    toSearchForDecimal);
            //                            else
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    ((string)i[selectedIndex]).ToLower() == toSearchFor.
            //                                    ToLower());
            //                            break;

            //                        case "!=":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] !=
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] !=
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] !=
            //                                    toSearchForDecimal);
            //                            else
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    ((string)i[selectedIndex]).ToLower() != toSearchFor.
            //                                    ToLower());
            //                            break;

            //                        case ">":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] >
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] >
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] >
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \">\" cannot be applied to strings.");
            //                            break;

            //                        case "<":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] <
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] <
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] <
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \"<\" cannot be applied to strings.");
            //                            break;

            //                        case ">=":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] >=
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] >=
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] >=
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \">=\" cannot be applied to strings.");
            //                            break;

            //                        case "<=":
            //                            if (baseObject is byte)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (byte)i[selectedIndex] <=
            //                                    toSearchForByte);
            //                            else if (baseObject is DateTime)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (DateTime)i[selectedIndex] <=
            //                                    toSearchForDateTime);
            //                            else if (baseObject is decimal)
            //                                searchResults = tableToSearch.AsEnumerable().Where(i =>
            //                                    (decimal)i[selectedIndex] <=
            //                                    toSearchForDecimal);
            //                            else
            //                                throw new InvalidOperationException(
            //                                    "Comparator \"<=\" cannot be applied to strings.");
            //                            break;

            //                        default:
            //                            throw new InvalidOperationException("Invalid comparator.");
            //                    }
            //                    resultCount = searchResults.Count();
            //                    gViewToDisplay.DataSource = searchResults.ToList();
            //                }
            //                break;

            //            default:
            //                throw new InvalidOperationException(
            //                    "Invalid item type dropdown value.");
            //        }
            //        lblResult.Text = string.Format("{0} result{1} found.", resultCount,
            //            resultCount == 1 ? "" : "s");
            //        lblResult.Visible = true;
            //        mViewSearchResults.ActiveViewIndex = viewToDisplay;
            //        gViewToDisplay.DataBind();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblError.Text = "Error: " + ex.Message;
            //    lblError.Visible = true;
            //}
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ddlBusiness_SelectedIndexChanged
         * Type:    Event Handler Method
         * Purpose: Handles the change of visibility on controls when the user chooses a business
         *          field.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void ddlBusiness_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;

            ddlComparatorsStrings.Visible = false;
            ddlComparatorsStrings.SelectedIndex = 0;
            ddlComparatorsNotStrings.Visible = false;
            ddlComparatorsNotStrings.SelectedIndex = 0;

            txtSearch.Visible = false;
            txtSearch.Text = "";
            btnSearch.Visible = false;

            mViewSearchResults.ActiveViewIndex = -1;

            // Display the needed control.
            switch ((Global.Enums.BusinessFields)ddlBusiness.SelectedIndex)
            {
                case Global.Enums.BusinessFields.Name:
                case Global.Enums.BusinessFields.Type:
                case Global.Enums.BusinessFields.StreetAddress:
                case Global.Enums.BusinessFields.City:
                case Global.Enums.BusinessFields.State:
                case Global.Enums.BusinessFields.Zip:
                case Global.Enums.BusinessFields.Phone:
                case Global.Enums.BusinessFields.LicenseNumber:
                case Global.Enums.BusinessFields.LicenseStatus:
                case Global.Enums.BusinessFields.CouncilDistrict:
                    ddlComparatorsStrings.Visible = true;
                    break;

                case Global.Enums.BusinessFields.Latitude:
                case Global.Enums.BusinessFields.Longitude:
                case Global.Enums.BusinessFields.LicenseIssueDate:
                case Global.Enums.BusinessFields.LicenseExpirDate:
                    ddlComparatorsNotStrings.Visible = true;
                    break;

                default:
                    ddlComparatorsStrings.Visible = false;
                    ddlComparatorsNotStrings.Visible = false;
                    break;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ddlComparatorsNotStrings_SelectedIndexChanged
         * Type:    Event Handler Method
         * Purpose: Handles the change of visibility on controls when the user chooses what type of
         *          comparison to make.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void ddlComparatorsNotStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;

            txtSearch.Visible = false;
            txtSearch.Text = "";
            btnSearch.Visible = false;

            mViewSearchResults.ActiveViewIndex = -1;

            // Display the needed control.
            switch ((Global.Enums.ComparatorsNotStrings)ddlComparatorsNotStrings.SelectedIndex)
            {
                case Global.Enums.ComparatorsNotStrings.Contain:
                case Global.Enums.ComparatorsNotStrings.NotContain:
                case Global.Enums.ComparatorsNotStrings.Equal:
                case Global.Enums.ComparatorsNotStrings.NotEqual:
                case Global.Enums.ComparatorsNotStrings.Greater:
                case Global.Enums.ComparatorsNotStrings.Less:
                case Global.Enums.ComparatorsNotStrings.GreaterEqual:
                case Global.Enums.ComparatorsNotStrings.LessEqual:
                    txtSearch.Visible = true;
                    btnSearch.Visible = true;
                    break;

                default:
                    break;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ddlComparatorsStrings_SelectedIndexChanged
         * Type:    Event Handler Method
         * Purpose: Handles the change of visibility on controls when the user chooses what type of
         *          comparison to make.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void ddlComparatorsStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;

            txtSearch.Visible = false;
            txtSearch.Text = "";
            btnSearch.Visible = false;

            mViewSearchResults.ActiveViewIndex = -1;

            // Display the needed control.
            switch ((Global.Enums.ComparatorsStrings)ddlComparatorsStrings.SelectedIndex)
            {
                case Global.Enums.ComparatorsStrings.Contain:
                case Global.Enums.ComparatorsStrings.NotContain:
                case Global.Enums.ComparatorsStrings.Equal:
                case Global.Enums.ComparatorsStrings.NotEqual:
                    txtSearch.Visible = true;
                    btnSearch.Visible = true;
                    break;

                default:
                    break;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ddlItemType_SelectedIndexChanged
         * Type:    Event Handler Method
         * Purpose: Handles showing and hiding the various controls to allow a user to search the
         *          database.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void ddlItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;

            ddlBusiness.Visible = false;
            ddlBusiness.SelectedIndex = 0;
            ddlPark.Visible = false;
            ddlPark.SelectedIndex = 0;
            ddlPublicFacility.Visible = false;
            ddlPublicFacility.SelectedIndex = 0;
            ddlComparatorsStrings.Visible = false;
            ddlComparatorsStrings.SelectedIndex = 0;
            ddlComparatorsNotStrings.Visible = false;
            ddlComparatorsNotStrings.SelectedIndex = 0;

            txtSearch.Visible = false;
            txtSearch.Text = "";
            btnSearch.Visible = false;

            mViewSearchResults.ActiveViewIndex = -1;

            // Display the needed control.
            switch ((Global.Enums.ItemTypes)ddlItemType.SelectedIndex)
            {
                case Global.Enums.ItemTypes.Business:
                    ddlBusiness.Visible = true;
                    break;

                case Global.Enums.ItemTypes.Park:
                    ddlPark.Visible = true;
                    break;

                case Global.Enums.ItemTypes.PublicFacility:
                    ddlPublicFacility.Visible = true;
                    break;

                default:
                    break;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ddlPark_SelectedIndexChanged
         * Type:    Event Handler Method
         * Purpose: Handles the change of visibility on controls when the user chooses a park field.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void ddlPark_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;

            ddlComparatorsStrings.Visible = false;
            ddlComparatorsStrings.SelectedIndex = 0;
            ddlComparatorsNotStrings.Visible = false;
            ddlComparatorsNotStrings.SelectedIndex = 0;

            txtSearch.Visible = false;
            txtSearch.Text = "";
            btnSearch.Visible = false;

            mViewSearchResults.ActiveViewIndex = -1;

            // Display the needed control.
            switch ((Global.Enums.ParkFields)ddlPark.SelectedIndex)
            {
                case Global.Enums.ParkFields.Name:
                case Global.Enums.ParkFields.Type:
                case Global.Enums.ParkFields.StreetAddress:
                case Global.Enums.ParkFields.City:
                case Global.Enums.ParkFields.State:
                case Global.Enums.ParkFields.Zip:
                case Global.Enums.ParkFields.Phone:
                    ddlComparatorsStrings.Visible = true;
                    break;

                case Global.Enums.ParkFields.Latitude:
                case Global.Enums.ParkFields.Longitude:
                case Global.Enums.ParkFields.FeatureBaseball:
                case Global.Enums.ParkFields.FeatureBasketball:
                case Global.Enums.ParkFields.FeatureGolf:
                case Global.Enums.ParkFields.FeatureLargeMPField:
                case Global.Enums.ParkFields.FeatureTennis:
                case Global.Enums.ParkFields.FeatureVolleyball:
                    ddlComparatorsNotStrings.Visible = true;
                    break;

                default:
                    break;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ddlPublicFacility_SelectedIndexChanged
         * Type:    Event Handler Method
         * Purpose: Handles the change of visibility on controls when the user chooses a public
         *          facility field.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void ddlPublicFacility_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;

            ddlComparatorsStrings.Visible = false;
            ddlComparatorsStrings.SelectedIndex = 0;
            ddlComparatorsNotStrings.Visible = false;
            ddlComparatorsNotStrings.SelectedIndex = 0;

            txtSearch.Visible = false;
            txtSearch.Text = "";
            btnSearch.Visible = false;

            mViewSearchResults.ActiveViewIndex = -1;

            // Display the needed control.
            switch ((Global.Enums.PublicFacilityFields)ddlPublicFacility.SelectedIndex)
            {
                case Global.Enums.PublicFacilityFields.Name:
                case Global.Enums.PublicFacilityFields.Type:
                case Global.Enums.PublicFacilityFields.StreetAddress:
                case Global.Enums.PublicFacilityFields.City:
                case Global.Enums.PublicFacilityFields.State:
                case Global.Enums.PublicFacilityFields.Zip:
                case Global.Enums.PublicFacilityFields.Phone:
                    ddlComparatorsStrings.Visible = true;
                    break;

                case Global.Enums.PublicFacilityFields.Latitude:
                case Global.Enums.PublicFacilityFields.Longitude:
                    ddlComparatorsNotStrings.Visible = true;
                    break;

                default:
                    break;
            }
        }
    }
}