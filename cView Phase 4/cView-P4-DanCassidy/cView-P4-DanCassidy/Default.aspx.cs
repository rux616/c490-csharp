/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-23
 * Assignment:  cView-P4
 * Source File: Default.aspx.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Project:     The overall goal of this project is to capitalize on the fact that government, from
 *              local to national, has made some of its data open by developing a way to explore
 *              this data and present it to a user in a meaningful fashion. This phase of the
 *              project is meant to explore data from any combination of the Business dataset
 *              (https://data.southbendin.gov/d/imxu-7m5i), the Parks and Features dataset
 *              (https://data.southbendin.gov/d/yf5x-7tkb), and the Public Facility dataset
 *              (https://data.southbendin.gov/d/jeef-dsq9) using a web-based ASP.NET UI interacting
 *              with a SQL backend via the Entity Framework.
 * Purpose:     Code-behind file for Default.aspx.  This file's only purpose is to redirect the
 *              client to the Main.aspx page.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cView_P4_DanCassidy
{
    public partial class Default : System.Web.UI.Page
    {
        /*------------------------------------------------------------------------------------------
         * Name:    Page_Load
         * Type:    Event Handler Method
         * Purpose: Handles anything that should happen on page load.  In this case, it shunts the
         *          client over to the Main.aspx page instead of this one.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void Page_Load(object sender, EventArgs e)
        {
            Server.Transfer("~/Main.aspx");
        }
    }
}