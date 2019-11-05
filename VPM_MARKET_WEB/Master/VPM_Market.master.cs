using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VPM_Entity;

public partial class Master_VPM_Market : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Url.ToString().IndexOf("OrderReview.aspx") != -1 || Request.Url.ToString().IndexOf("OrderPayment.aspx") != -1)
        {
            adminMenu1.Visible = false;
        }
        else
        {
            adminMenu1.Visible = true ;
        }


        if (Session["CURRENT_CONTEXT"] != null)
        {
            CurrentContext currentContext = (CurrentContext)Session["CURRENT_CONTEXT"];
            User user = (User)currentContext.user;

            this.lblLoginUser.Text = "Login User : " + user.FirstName + " " + user.LastName;
            if (user.IsAdmin == true)
            {
                // HyperLink hlkAdmin = (HyperLink)Master.FindControl("hlkAdmin");
                hlkAdmin.Visible = true;
                // HyperLink hlkSignOff = (HyperLink)Master.FindControl("hlkSignOff");
                hlkSignOff.Visible = true;
                hlkSignIn.Visible = false;


            }
            else
            {
                // HyperLink hlkAdmin = (HyperLink)Master.FindControl("hlkAdmin");
                hlkAdmin.Visible = false;
                //HyperLink hlkSignOff = (HyperLink)Master.FindControl("hlkSignOff");
                hlkSignOff.Visible = true;
                hlkSignIn.Visible = false;
            }



        }
        else
        {
            hlkSignIn.Visible = true;
           
        }

    }
}
