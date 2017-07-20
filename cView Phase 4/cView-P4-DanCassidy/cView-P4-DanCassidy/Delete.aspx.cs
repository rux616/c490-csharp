/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-23
 * Assignment:  cView-P4
 * Source File: Delete.aspx.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Code-behind file for Delete.aspx.  Controls the deletion of a single row of data (1
 *              object) from a table.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cView_P4_DanCassidy
{
    public partial class Delete : System.Web.UI.Page
    {
        /*------------------------------------------------------------------------------------------
         * Name:    btnDelete_Click
         * Type:    Event Handler Method
         * Purpose: Handles deleting an object from the database.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Dummy polymorphoc object.
            object keyToDelete = null;

            // Attempt to delete a record.
            try
            {
                using (CViewDataEntities database = new CViewDataEntities())
                {
                    switch ((Global.Enums.ItemTypes)ddlItemType.SelectedIndex)
                    {
                        case Global.Enums.ItemTypes.Business:
                            if (gViewBusiness.SelectedIndex == -1)
                                return;
                            keyToDelete = gViewBusiness.SelectedDataKey.Value;
                            gViewBusiness.SelectRow(-1);
                            Business businessToDelete = database.Businesses.Find(keyToDelete);
                            database.Businesses.Remove(businessToDelete);
                            break;

                        case Global.Enums.ItemTypes.Park:
                            if (gViewPark.SelectedIndex == -1)
                                return;
                            keyToDelete = gViewPark.SelectedDataKey.Value;
                            gViewPark.SelectRow(-1);
                            Park parkToDelete = database.Parks.Find(keyToDelete);
                            database.Parks.Remove(parkToDelete);
                            break;

                        case Global.Enums.ItemTypes.PublicFacility:
                            if (gViewPublicFacility.SelectedIndex == -1)
                                return;
                            keyToDelete = gViewPublicFacility.SelectedDataKey.Value;
                            gViewPublicFacility.SelectRow(-1);
                            PublicFacility publicFacilityToDelete =
                                database.PublicFacilities.Find(keyToDelete);
                            database.PublicFacilities.Remove(publicFacilityToDelete);
                            break;

                        default:
                            // ... How?
                            return;
                    }

                    database.SaveChanges();
                    mViewData.DataBind();
                }

                lblResult.Text = "Row successfully deleted.";
                lblResult.Visible = true;
                lblError.Visible = false;
            }
            catch
            {
                lblError.Text = "Error: Could not delete the specified row.";
                lblError.Visible = true;
                lblResult.Visible = false;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ddlItemType_SelectedIndexChanged
         * Type:    Event Handler Method
         * Purpose: Handles showing and hiding the various controls to allow a user to choose an
         *          item to be deleted from the database.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void ddlItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;

            mViewData.ActiveViewIndex = -1;
            btnDelete.Visible = false;

            // Decide which controls should be shown to enable user to delete an item.
            switch ((Global.Enums.ItemTypes)ddlItemType.SelectedIndex)
            {
                case Global.Enums.ItemTypes.Business:
                    mViewData.ActiveViewIndex = 0;
                    btnDelete.Visible = true;
                    break;

                case Global.Enums.ItemTypes.Park:
                    mViewData.ActiveViewIndex = 1;
                    btnDelete.Visible = true;
                    break;

                case Global.Enums.ItemTypes.PublicFacility:
                    mViewData.ActiveViewIndex = 2;
                    btnDelete.Visible = true;
                    break;

                default:
                    break;
            }
        }

    }
}