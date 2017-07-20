/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-23
 * Assignment:  cView-P4
 * Source File: Statistics.aspx.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Code-behind file for Statistics.aspx.  Controls the statistics displayed.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cView_P4_DanCassidy
{
    public partial class Statistics : System.Web.UI.Page
    {
        /*------------------------------------------------------------------------------------------
         * Name:    Page_Load
         * Type:    Event Handler Method
         * Purpose: Handles anything that should happen on page load. In this case, it calculates
         *          and displays some statistics.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                using (CViewDataEntities database = new CViewDataEntities())
                {
                    // Hijacked from http://stackoverflow.com/a/1206029.
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

                    // Total number of parks.
                    lblStatistics1.Text = database.Parks.Count().ToString();

                    // Total number of parks, grouped by park type.
                    lblStatistics2.Text = "";
                    var parksByType = database.Parks.GroupBy(p => p.Type);
                    foreach (var parkType in parksByType)
                        lblStatistics2.Text += (parkType.Key == "" ? "(Empty)" : 
                            textInfo.ToTitleCase(parkType.Key.ToLower())) + ": " + 
                            parkType.Count() + "<br />";

                    // Total number of businesses.
                    lblStatistics3.Text = database.Businesses.Count().ToString();

                    // Total number of license renewals for each business.
                    lblStatistics4.Text = "";
                    var businessRenewals = database.Businesses.Where(
                        b => b.LicenseStatus == "Renewed").GroupBy(b => b.Name);
                    foreach (var business in businessRenewals)
                        lblStatistics4.Text += (business.Key == "" ? "(Empty)" : 
                            textInfo.ToTitleCase(business.Key.ToLower())) + ": " + 
                            business.Count() + "<br />";

                    // Total number of facilities that have the substring "Fire"
                    lblStatistics5.Text = database.PublicFacilities.Where(pf => pf.Name.Contains(
                        "fire")).Count().ToString();
                }
            }
            catch
            {
                lblError.Text = "Error: Could not calculate statistics.";
                lblError.Visible = true;
            }
        }
    }
}