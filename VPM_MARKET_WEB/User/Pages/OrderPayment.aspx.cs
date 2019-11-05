using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_Pages_OrderPayment : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnBackToHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
    protected void btnOrderReview_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/user/pages/OrderReview.aspx");
    }
}
