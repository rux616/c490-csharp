/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-23
 * Assignment:  cView-P4
 * Source File: Modify.aspx.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Code-behind file for Modify.aspx.  Controls the process of modifying an item in the
 *              database via the Entity Framework model.
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
    public partial class Modify : System.Web.UI.Page
    {
        /*------------------------------------------------------------------------------------------
         * Name:    btnModify_Click
         * Type:    Event Handler Method
         * Purpose: Handles showing and hiding the various controls to aid in allowing the user to
         *          change the data associated with the chosen item.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void btnModify_Click(object sender, EventArgs e)
        {
            // Quick check to make sure that something is selected.
            switch ((Global.Enums.ItemTypes)ddlItemType.SelectedIndex)
            {
                case Global.Enums.ItemTypes.Business:
                    if (gViewBusiness.SelectedIndex == -1)
                        return;
                    break;

                case Global.Enums.ItemTypes.Park:
                    if (gViewPark.SelectedIndex == -1)
                        return;
                    break;

                case Global.Enums.ItemTypes.PublicFacility:
                    if (gViewPublicFacility.SelectedIndex == -1)
                        return;
                    break;

                default:
                    break;
            }

            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;
            mViewDisplay.ActiveViewIndex = -1;
            mViewModifyBasic.ActiveViewIndex = -1;
            mViewModifySpecific.ActiveViewIndex = -1;
            btnModify.Visible = false;
            btnSaveChanges.Visible = false;
            btnBack.Visible = false;

            try
            {
                using (CViewDataEntities database = new CViewDataEntities())
                {
                    object keyToModify = null;

                    // Choose what to display based on the selected item type.
                    switch ((Global.Enums.ItemTypes)ddlItemType.SelectedIndex)
                    {
                        case Global.Enums.ItemTypes.Business:
                            // Basic UI prep.
                            mViewModifyBasic.ActiveViewIndex = 0;
                            mViewModifySpecific.ActiveViewIndex = 0;
                            lblName.Text = Global.Strings.BusinessName + Global.Strings.Separator;
                            lblType.Text = Global.Strings.BusinessType + Global.Strings.Separator;
                            btnSaveChanges.Visible = true;
                            btnBack.Visible = true;

                            // Get object to modify.
                            keyToModify = gViewBusiness.SelectedDataKey.Value;
                            Business businessToModify = database.Businesses.Find(keyToModify);

                            // Fill in textbox values.
                            txtName.Text = businessToModify.Name;
                            txtName.Enabled = true;
                            txtType.Text = businessToModify.Type;
                            txtStreetAddress.Text = businessToModify.StreetAddress;
                            txtCity.Text = businessToModify.City;
                            txtState.Text = businessToModify.State;
                            txtZip.Text = businessToModify.Zip;
                            txtLatitude.Text = businessToModify.Latitude.ToString();
                            txtLongitude.Text = businessToModify.Longitude.ToString();
                            txtPhone.Text = businessToModify.Phone;
                            txtLicenseNumber.Text = businessToModify.LicenseNumber;
                            txtLicenseIssueDate.Text = string.Format("{0:d}", 
                                businessToModify.LicenseIssueDate);
                            txtLicenseExpirDate.Text = string.Format("{0:d}",
                                businessToModify.LicenseExpirDate);
                            txtLicenseStatus.Text = businessToModify.LicenseStatus;
                            txtCouncilDistrict.Text = businessToModify.CouncilDistrict;
                            break;

                        case Global.Enums.ItemTypes.Park:
                            // Basic UI prep.
                            mViewModifyBasic.ActiveViewIndex = 0;
                            mViewModifySpecific.ActiveViewIndex = 1;
                            lblName.Text = Global.Strings.ParkName + Global.Strings.Separator;
                            lblType.Text = Global.Strings.ParkType + Global.Strings.Separator;
                            btnSaveChanges.Visible = true;
                            btnBack.Visible = true;

                            // Get object to modify.
                            keyToModify = gViewPark.SelectedDataKey.Value;
                            Park parkToModify = database.Parks.Find(keyToModify);

                            // Fill in textbox values.
                            txtName.Text = parkToModify.Name;
                            txtName.Enabled = false;
                            txtType.Text = parkToModify.Type;
                            txtStreetAddress.Text = parkToModify.StreetAddress;
                            txtCity.Text = parkToModify.City;
                            txtState.Text = parkToModify.State;
                            txtZip.Text = parkToModify.Zip;
                            txtLatitude.Text = parkToModify.Latitude.ToString();
                            txtLongitude.Text = parkToModify.Longitude.ToString();
                            txtPhone.Text = parkToModify.Phone;
                            txtFeatureBaseball.Text = parkToModify.FeatureBaseball.ToString();
                            txtFeatureBasketball.Text = parkToModify.FeatureBasketball.ToString();
                            txtFeatureGolf.Text = parkToModify.FeatureGolf.ToString();
                            txtFeatureLargeMPField.Text = parkToModify.FeatureLargeMPField.
                                ToString();
                            txtFeatureTennis.Text = parkToModify.FeatureTennis.ToString();
                            txtFeatureVolleyball.Text = parkToModify.FeatureVolleyball.ToString();
                            break;

                        case Global.Enums.ItemTypes.PublicFacility:
                            // Basic UI prep.
                            mViewModifyBasic.ActiveViewIndex = 0;
                            lblName.Text = Global.Strings.PublicFacilityName + 
                                Global.Strings.Separator;
                            lblType.Text = Global.Strings.PublicFacilityType + 
                                Global.Strings.Separator;
                            btnSaveChanges.Visible = true;
                            btnBack.Visible = true;

                            // Get object to modify.
                            keyToModify = gViewPublicFacility.SelectedDataKey.Value;
                            PublicFacility publicFacilityToModify = database.PublicFacilities.
                                Find(keyToModify);

                            // Fill in textbox values.
                            txtName.Text = publicFacilityToModify.Name;
                            txtName.Enabled = false;
                            txtType.Text = publicFacilityToModify.Type;
                            txtStreetAddress.Text = publicFacilityToModify.StreetAddress;
                            txtCity.Text = publicFacilityToModify.City;
                            txtState.Text = publicFacilityToModify.State;
                            txtZip.Text = publicFacilityToModify.Zip;
                            txtLatitude.Text = publicFacilityToModify.Latitude.ToString();
                            txtLongitude.Text = publicFacilityToModify.Longitude.ToString();
                            txtPhone.Text = publicFacilityToModify.Phone;
                            break;

                        default:
                            throw new InvalidOperationException(
                                "Invalid item type dropdown value.");
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
                lblError.Visible = true;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    btnSaveChanges_Click
         * Type:    Event Handler Method
         * Purpose: Handles saving the changed data for the specific item back to the database via
         *          the Entity Framework model.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;
            mViewDisplay.ActiveViewIndex = -1;
            mViewModifyBasic.ActiveViewIndex = -1;
            mViewModifySpecific.ActiveViewIndex = -1;
            btnModify.Visible = false;
            btnSaveChanges.Visible = false;
            btnBack.Visible = false;

            try
            {
                using (CViewDataEntities database = new CViewDataEntities())
                {
                    object keyToModify = null;

                    // Choose what to do based on the selected item type.
                    switch ((Global.Enums.ItemTypes)ddlItemType.SelectedIndex)
                    {
                        case Global.Enums.ItemTypes.Business:
                            // Get object to modify.
                            keyToModify = gViewBusiness.SelectedDataKey.Value;
                            Business businessToModify = database.Businesses.Find(keyToModify);

                            // Save values to object.
                            businessToModify.Name = txtName.Text.Trim();
                            businessToModify.Type = txtType.Text.Trim();
                            businessToModify.StreetAddress = txtStreetAddress.Text.Trim();
                            businessToModify.City = txtCity.Text.Trim();
                            businessToModify.State = txtState.Text.Trim();
                            businessToModify.Zip = txtZip.Text.Trim();
                            businessToModify.Latitude = SimpleConvert.ToDecimal(txtLatitude.Text.
                                Trim());
                            businessToModify.Longitude = SimpleConvert.ToDecimal(txtLongitude.Text.
                                Trim());
                            businessToModify.Phone = txtPhone.Text.Trim();
                            businessToModify.LicenseIssueDate = SimpleConvert.ToDateTime(
                                txtLicenseIssueDate.Text.Trim());
                            businessToModify.LicenseExpirDate = SimpleConvert.ToDateTime(
                                txtLicenseExpirDate.Text.Trim());
                            businessToModify.LicenseStatus = txtLicenseStatus.Text.Trim();
                            businessToModify.CouncilDistrict = txtCouncilDistrict.Text.Trim();

                            // Modelled off http://stackoverflow.com/a/15339512.
                            database.Businesses.Attach(businessToModify);
                            database.Entry(businessToModify).State = EntityState.Modified;
                            break;

                        case Global.Enums.ItemTypes.Park:
                            // Get object to modify.
                            keyToModify = gViewPark.SelectedDataKey.Value;
                            Park parkToModify = database.Parks.Find(keyToModify);

                            // Save values to object.
                            parkToModify.Type = txtType.Text.Trim();
                            parkToModify.StreetAddress = txtStreetAddress.Text.Trim();
                            parkToModify.City = txtCity.Text.Trim();
                            parkToModify.State = txtState.Text.Trim();
                            parkToModify.Zip = txtZip.Text.Trim();
                            parkToModify.Latitude = SimpleConvert.ToDecimal(txtLatitude.Text.
                                Trim());
                            parkToModify.Longitude = SimpleConvert.ToDecimal(txtLongitude.Text.
                                Trim());
                            parkToModify.Phone = txtPhone.Text.Trim();
                            parkToModify.FeatureBaseball = SimpleConvert.ToByte(
                                txtFeatureBaseball.Text.Trim());
                            parkToModify.FeatureBasketball = SimpleConvert.ToDecimal(
                                txtFeatureBasketball.Text.Trim());
                            parkToModify.FeatureGolf = SimpleConvert.ToDecimal(
                                txtFeatureGolf.Text.Trim());
                            parkToModify.FeatureLargeMPField = SimpleConvert.ToByte(
                                txtFeatureLargeMPField.Text.Trim());
                            parkToModify.FeatureTennis = SimpleConvert.ToByte(
                                txtFeatureTennis.Text.Trim());
                            parkToModify.FeatureVolleyball = SimpleConvert.ToByte(
                                txtFeatureVolleyball.Text.Trim());

                            // Modelled off http://stackoverflow.com/a/15339512.
                            database.Parks.Attach(parkToModify);
                            database.Entry(parkToModify).State = EntityState.Modified;
                            break;

                        case Global.Enums.ItemTypes.PublicFacility:
                            // Get object to modify.
                            keyToModify = gViewPublicFacility.SelectedDataKey.Value;
                            PublicFacility publicFacilityToModify = database.PublicFacilities.
                                Find(keyToModify);

                            // Save values to object.
                            publicFacilityToModify.Type = txtType.Text.Trim();
                            publicFacilityToModify.StreetAddress = txtStreetAddress.Text.Trim();
                            publicFacilityToModify.City = txtCity.Text.Trim();
                            publicFacilityToModify.State = txtState.Text.Trim();
                            publicFacilityToModify.Zip = txtZip.Text.Trim();
                            publicFacilityToModify.Latitude = SimpleConvert.ToDecimal(
                                txtLatitude.Text.Trim());
                            publicFacilityToModify.Longitude = SimpleConvert.ToDecimal(
                                txtLongitude.Text.Trim());
                            publicFacilityToModify.Phone = txtPhone.Text.Trim();

                            // Modelled off http://stackoverflow.com/a/15339512.
                            database.PublicFacilities.Attach(publicFacilityToModify);
                            database.Entry(publicFacilityToModify).State = EntityState.Modified;
                            break;

                        default:
                            throw new InvalidOperationException(
                                "Invalid item type dropdown value.");
                    }
                    // Save any changes to the database and refresh gridviews.
                    database.SaveChanges();
                    mViewDisplay.DataBind();
                }
                // Go back to item selection and let the user know the operation was successful.
                ddlItemType_SelectedIndexChanged(sender, e);
                lblResult.Text = "Item modified successfully.";
                lblResult.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = "Error: " + ex.Message;
                lblError.Visible = true;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    ddlItemType_SelectedIndexChanged
         * Type:    Event Handler Method
         * Purpose: Handles showing and hiding the various controls to aid in allowing the user to
         *          select an item to modify.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void ddlItemType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblError.Visible = false;
            lblResult.Visible = false;
            mViewDisplay.ActiveViewIndex = -1;
            mViewModifyBasic.ActiveViewIndex = -1;
            mViewModifySpecific.ActiveViewIndex = -1;
            btnModify.Visible = false;
            btnSaveChanges.Visible = false;
            btnBack.Visible = false;

            // Reset selected indexes of GridView controls.
            gViewBusiness.SelectedIndex = -1;
            gViewPark.SelectedIndex = -1;
            gViewPublicFacility.SelectedIndex = -1;

            // Show the appropriate view.
            switch ((Global.Enums.ItemTypes)ddlItemType.SelectedIndex)
            {
                case Global.Enums.ItemTypes.Business:
                    mViewDisplay.ActiveViewIndex = 0;
                    btnModify.Visible = true;
                    break;

                case Global.Enums.ItemTypes.Park:
                    mViewDisplay.ActiveViewIndex = 1;
                    btnModify.Visible = true;
                    break;

                case Global.Enums.ItemTypes.PublicFacility:
                    mViewDisplay.ActiveViewIndex = 2;
                    btnModify.Visible = true;
                    break;

                default:
                    break;
            }
        }
    }
}