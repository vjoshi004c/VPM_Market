using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VPM_Entity;

public partial class User_Pages_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         if (Request.QueryString["CategoryID"] == null ||Request.QueryString["CategoryID"]=="0")
        {
            imgMainContentFirst.Visible = true;
            imgMainContentSecond.Visible = true;
            imgMainContentThird.Visible = true;
        }
        else
        {
            imgMainContentFirst.Visible = false;
            imgMainContentSecond.Visible = false;
            imgMainContentThird.Visible = false;
        }




    }
}
