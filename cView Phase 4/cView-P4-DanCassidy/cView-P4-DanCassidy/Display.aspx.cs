/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-23
 * Assignment:  cView-P4
 * Source File: Display.aspx.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Code-behind file for Display.aspx.  Controls the display of the different tables of
 *              items.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cView_P4_DanCassidy
{
    public partial class Display : System.Web.UI.Page
    {
        /*------------------------------------------------------------------------------------------
         * Name:    ddlItemType_SelectedIndexChanged
         * Type:    Event Handler Method
         * Purpose: Handles showing and hiding the data views.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void ddlItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((Global.Enums.ItemTypes)ddlItemType.SelectedIndex)
            {
                case Global.Enums.ItemTypes.Business:
                    mViewData.ActiveViewIndex = 0;
                    break;

                case Global.Enums.ItemTypes.Park:
                    mViewData.ActiveViewIndex = 1;
                    break;

                case Global.Enums.ItemTypes.PublicFacility:
                    mViewData.ActiveViewIndex = 2;
                    break;

                default:
                    mViewData.ActiveViewIndex = -1;
                    break;
            }
        }
    }
}