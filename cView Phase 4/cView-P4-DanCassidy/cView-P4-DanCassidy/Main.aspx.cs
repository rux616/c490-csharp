/*--------------------------------------------------------------------------------------------------
 * Author:      Dan Cassidy
 * Date:        2015-06-23
 * Assignment:  cView-P4
 * Source File: Main.aspx.cs
 * Language:    C#
 * Course:      CSCI-C 490, C# Programming, MoWe 08:00
 * Purpose:     Code-behind file for Main.aspx. Controls randomization and resetting of the tables
 *              behind the application.
--------------------------------------------------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace cView_P4_DanCassidy
{
    public partial class Menu : System.Web.UI.Page
    {
        /*------------------------------------------------------------------------------------------
         * Name:    btnRandomize_Click
         * Type:    Event Handler Method
         * Purpose: Handles randomizing the tables when clicked.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void btnRandomize_Click(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblResult.Visible = false;
            lblError.Visible = false;

            try
            {
                using (CViewDataEntities db = new CViewDataEntities())
                {
                    // Used SQL statements because I didn't want to add more tables to the Entity
                    // Framework model just for this.  Also, it's easier.
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Business");
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.BusinessReset");
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Park");
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.ParkReset");
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.PublicFacility");
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.PublicFacilityReset");

                    db.Database.ExecuteSqlCommand("INSERT INTO dbo.BusinessReset SELECT " +
                        "TOP 50 * FROM dbo.BusinessBase ORDER BY NEWID()");
                    db.Database.ExecuteSqlCommand("INSERT INTO dbo.Business SELECT " +
                        "* FROM dbo.BusinessReset");
                    db.Database.ExecuteSqlCommand("INSERT INTO dbo.ParkReset SELECT " +
                        "TOP 50 * FROM dbo.ParkBase ORDER BY NEWID()");
                    db.Database.ExecuteSqlCommand("INSERT INTO dbo.Park SELECT " +
                        "* FROM dbo.ParkReset");
                    db.Database.ExecuteSqlCommand("INSERT INTO dbo.PublicFacilityReset SELECT " +
                        "TOP 50 * FROM dbo.PublicFacilityBase ORDER BY NEWID()");
                    db.Database.ExecuteSqlCommand("INSERT INTO dbo.PublicFacility SELECT " + 
                        "* FROM dbo.PublicFacilityReset");
                }

                lblResult.Text = "The tables have been randomized.";
                lblResult.Visible = true;
            }
            catch
            {
                lblError.Text = "Error: Could not randomize the tables.";
                lblError.Visible = true;
            }
        }

        /*------------------------------------------------------------------------------------------
         * Name:    btnReset_Click
         * Type:    Event Handler Method
         * Purpose: Handles resetting the tables to their prior randomized states.
         * Input:   object sender, holds a reference to the object that raised this event.
         * Input:   EventArgs e, holds data related to this event.
         * Output:  Nothing.
        ------------------------------------------------------------------------------------------*/
        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Hide things until needed.
            lblResult.Visible = false;
            lblError.Visible = false;

            try
            {
                using (CViewDataEntities db = new CViewDataEntities())
                {
                    // Again, used SQL statements because I didn't want to add more tables to the
                    // Entity Framework model just for this.  Also, it's easier.
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Business");
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.Park");
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE dbo.PublicFacility");

                    db.Database.ExecuteSqlCommand("INSERT INTO dbo.Business SELECT " +
                        "* FROM dbo.BusinessReset");
                    db.Database.ExecuteSqlCommand("INSERT INTO dbo.Park SELECT " +
                        "* FROM dbo.ParkReset");
                    db.Database.ExecuteSqlCommand("INSERT INTO dbo.PublicFacility SELECT " + 
                        "* FROM dbo.PublicFacilityReset");
                }

                lblResult.Text = "The tables have been reset to their prior randomized states.";
                lblResult.Visible = true;
            }
            catch
            {
                lblError.Text = "Error: Could not reset the tables.";
                lblError.Visible = true;
            }
        }
    }
}