using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["CategoryID"] == null)
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
