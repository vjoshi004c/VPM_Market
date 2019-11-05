using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class User_Pages_OrderReview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string RemoveItemId = string.Empty;
        if (Request.QueryString["RemoveItem"] != null)
        {
            RemoveItemId = Request.QueryString["RemoveItem"].ToString();

        }
        if (Session["Cart"] != null)
        {
            DataTable dtCart = (DataTable)Session["Cart"];
            //if (RemoveItemId != string.Empty)
            //{
            //    dtCart = RemoveItemFromCart(dtCart, RemoveItemId);
            //}
            // addCartItem(dtCart, itemId, ItemName, ItemPrice);

            DisplayCart(dtCart);
        }
    }
    private void DisplayCart(DataTable dtItem)
    {

        HtmlTable htItem = new HtmlTable();
        htItem.CellPadding = 0;
        htItem.CellSpacing = 0;
        htItem.Width = "100%";


        HtmlTableRow hrItemMainHeader = new HtmlTableRow();
        //hrItemMainHeader.BgColor = System.Drawing.Color.Red.ToString();
        hrItemMainHeader.Height = "40px";
        HtmlTableCell hcItemMainHeader = new HtmlTableCell();
        hcItemMainHeader.Attributes.Add("class", "tdCartHeader");
        hcItemMainHeader.Align = "Center"; ;
        hcItemMainHeader.ColSpan = 4;

        //hcItemForthHeader.Width = totalItemWidthPercentage.ToString() + "%";
        hcItemMainHeader.InnerHtml = "Cart ";
        hrItemMainHeader.Cells.Add(hcItemMainHeader);
        htItem.Rows.Add(hrItemMainHeader);

        HtmlTableRow hrItemHeader = new HtmlTableRow();
        HtmlTableCell hcItemForthHeader = new HtmlTableCell();
        hcItemForthHeader.Attributes.Add("class", "tdCartColumHeader");
        hcItemForthHeader.Align = "Left"; ;
        //hcItemForthHeader.Width = totalItemWidthPercentage.ToString() + "%";
        hcItemForthHeader.InnerHtml = "<b>" + "ItemName" + "</b>";
        hrItemHeader.Cells.Add(hcItemForthHeader);

        HtmlTableCell hcItemThirdHeader = new HtmlTableCell();
        hcItemThirdHeader.Attributes.Add("class", "tdCartColumHeader");
        hcItemThirdHeader.Align = "Center"; ;
        // hcItemThirdHeader.Width = totalItemWidthPercentage.ToString() + "%";
        //hcItemThird.InnerHtml = "<span style=\"color:black;\"><b>" + ItemPrice + "</b></span>";
        hcItemThirdHeader.InnerHtml = "<b>" + "ItemPrice" + "</b>";
        hrItemHeader.Cells.Add(hcItemThirdHeader);

        HtmlTableCell hcItemThirdQuantity = new HtmlTableCell();
        hcItemThirdQuantity.Attributes.Add("class", "tdCartColumHeader");
        hcItemThirdQuantity.Align = "Center"; ;
        // hcItemThirdHeader.Width = totalItemWidthPercentage.ToString() + "%";
        //hcItemThird.InnerHtml = "<span style=\"color:black;\"><b>" + ItemPrice + "</b></span>";
        hcItemThirdQuantity.InnerHtml = "<b>" + "ItemQuanity" + "</b>";
        hrItemHeader.Cells.Add(hcItemThirdQuantity);

        HtmlTableCell hcItemSecondHeader = new HtmlTableCell();
        hcItemSecondHeader.Attributes.Add("class", "tdCartColumHeader");
        hcItemSecondHeader.Align = "Right"; ;
        hcItemSecondHeader.Attributes.Add("class", "tdCartColumHeader");
        hcItemSecondHeader.InnerHtml = "<b>" + "Action" + "</b>>";
        hrItemHeader.Cells.Add(hcItemSecondHeader);
        htItem.Rows.Add(hrItemHeader);



        if (dtItem != null && dtItem.Rows != null && dtItem.Rows.Count > 0)
        {

            int totalItem = dtItem.Rows.Count;
            int totalItemWidthPercentage = Convert.ToInt16(100 / totalItem);
            decimal totalPrice = 0;
            for (int i = 0; i < dtItem.Rows.Count; i++)
            {
                HtmlTableRow hrItem = new HtmlTableRow();
                DataRow drItem = dtItem.Rows[i];
                string ItemID = drItem["ItemID"].ToString();
                string ItemName = drItem["ItemName"].ToString();
                string ItemPrice = drItem["ItemPrice"].ToString();
                string ItemQuantity = drItem["ItemQuantity"].ToString();
                totalPrice = totalPrice + Convert.ToDecimal(ItemPrice) * Convert.ToDecimal(ItemQuantity);

                HtmlTableCell hcItemForth = new HtmlTableCell();
                hcItemForth.Attributes.Add("class", "tdCart");
                hcItemForth.Align = "Left"; ;
                hcItemForth.Width = totalItemWidthPercentage.ToString() + "%";
                hcItemForth.InnerHtml = "<span style=\"color:black;\"><b>" + ItemName + "</b></span>";
                hrItem.Cells.Add(hcItemForth);

                HtmlTableCell hcItemThird = new HtmlTableCell();
                hcItemThird.Attributes.Add("class", "tdCart");
                hcItemThird.Align = "Center"; ;
                hcItemThird.Width = totalItemWidthPercentage.ToString() + "%";
                //hcItemThird.InnerHtml = "<span style=\"color:black;\"><b>" + ItemPrice + "</b></span>";
                hcItemThird.InnerHtml = "<span style=\"color:black;\"><b>" + ItemPrice + "</b></span>";
                hrItem.Cells.Add(hcItemThird);


                HtmlTableCell hcItemQuantity = new HtmlTableCell();
                hcItemQuantity.Attributes.Add("class", "tdCart");
                hcItemQuantity.Align = "Center"; ;
                hcItemQuantity.Width = totalItemWidthPercentage.ToString() + "%";
                //hcItemThird.InnerHtml = "<span style=\"color:black;\"><b>" + ItemPrice + "</b></span>";
                hcItemQuantity.InnerHtml = "<span style=\"color:black;\"><b>" + ItemQuantity + "</b></span>";
                hrItem.Cells.Add(hcItemQuantity);

                HtmlTableCell hcItemSecond = new HtmlTableCell();
                hcItemSecond.Attributes.Add("class", "tdCart");
                hcItemSecond.Align = "Right"; ;
                hcItemSecond.Width = totalItemWidthPercentage.ToString() + "%";
                //hcItemSecond.InnerHtml = "<span style=\"color:black;\"><b>" + CategoryName + "</b></span>";
                hcItemSecond.Attributes.Add("class", "tdCart");
                HyperLink hyperLink = new HyperLink();
                hyperLink.Font.Underline = false;
                hyperLink.Text = "Remove";
                // hyperLink.NavigateUrl = "~/User/Pages/Home.aspx?CategoryID=" + ItemID + "&SubCategoryID=" + "0" + "&ItemId=" + "0";

               // hyperLink.NavigateUrl = createRedirectUrl() + "&RemoveItem=" + ItemID;

                hcItemSecond.Controls.Add(hyperLink);
                hrItem.Cells.Add(hcItemSecond);
                htItem.Rows.Add(hrItem);
            }


            HtmlTableRow hrItemFooter = new HtmlTableRow();
            hrItemFooter.Height = "25px";

            //hrItemFooter.Attributes.Add("class", "tdCartFooter");
            HtmlTableCell hcItemForthFooter = new HtmlTableCell();
            hcItemForthFooter.Attributes.Add("class", "tdCartFooter");
            hcItemForthFooter.Align = "Right"; ;

            //hcItemForthFooter.Width = totalItemWidthPercentage.ToString() + "%";
            hcItemForthFooter.InnerHtml = "<span style=\"color:black;\"><b>" + "Total" + "</b></span>";
            hrItemFooter.Cells.Add(hcItemForthFooter);

            HtmlTableCell hcItemThirdFooter = new HtmlTableCell();
            hcItemThirdFooter.Attributes.Add("class", "tdCartFooter");
            hcItemThirdFooter.Align = "left"; ;
            hcItemThirdFooter.ColSpan = 3;
            // hcItemThirdFooter.Width = totalItemWidthPercentage.ToString() + "%";
            //hcItemThird.InnerHtml = "<span style=\"color:black;\"><b>" + ItemPrice + "</b></span>";
            hcItemThirdFooter.InnerHtml = "<span style=\"color:black;\"><b>" + totalPrice + "</b></span>";
            hrItemFooter.Cells.Add(hcItemThirdFooter);

            //HtmlTableCell hcItemQuantityFooter = new HtmlTableCell();
            //hcItemQuantityFooter.Attributes.Add("class", "tdCartFooter");
            //hcItemQuantityFooter.Align = "Center"; ;
            //// hcItemThirdFooter.Width = totalItemWidthPercentage.ToString() + "%";
            ////hcItemThird.InnerHtml = "<span style=\"color:black;\"><b>" + ItemPrice + "</b></span>";
            //hcItemQuantityFooter.InnerHtml = "<b>" + "" + "</b>";
            //hrItemFooter.Cells.Add(hcItemQuantityFooter);


            //HtmlTableCell hcItemSecondFooter = new HtmlTableCell();
            //hcItemSecondFooter.Attributes.Add("class", "tdCartFooter");
            //hcItemSecondFooter.Align = "Right"; ;
            //hcItemSecondFooter.Attributes.Add("class", "tdCartFooter");
            //hcItemSecondFooter.InnerHtml = "<b>" + "" + "</b>";
            //hrItemFooter.Cells.Add(hcItemSecondFooter);
            htItem.Rows.Add(hrItemFooter);


            HtmlTableRow hrItemFooterCheckOut = new HtmlTableRow();
            hrItemFooterCheckOut.Height = "30px";


            //hrItemFooter.Attributes.Add("class", "tdCartFooter");
            HtmlTableCell hcItemForthFooterCheckOut = new HtmlTableCell();
            //hcItemForthFooterCheckOut.Attributes.Add("class", "tdCartFooter");
            hcItemForthFooterCheckOut.Align = "Center"; ;
            hcItemForthFooterCheckOut.ColSpan = 4;

            HyperLink hyperLinkCheckOut = new HyperLink();
            hyperLinkCheckOut.Width = Unit.Pixel(100);
            hyperLinkCheckOut.Height = Unit.Pixel(20);
            hyperLinkCheckOut.CssClass = "linkMenuCheckOut";
            hyperLinkCheckOut.Font.Underline = false;
            hyperLinkCheckOut.Text = "Check Out";
            hyperLinkCheckOut.NavigateUrl = "~/User/Pages/OrderPayment.aspx";
            hcItemForthFooterCheckOut.Controls.Add(hyperLinkCheckOut);

            //hcItemForthFooter.Width = totalItemWidthPercentage.ToString() + "%";
            //hcItemForthFooterCheckOut.InnerHtml = "<span style=\"color:black;\"><b>" + "Total" + "</b></span>";
            hrItemFooterCheckOut.Cells.Add(hcItemForthFooterCheckOut);
            htItem.Rows.Add(hrItemFooterCheckOut);


            pnlCart.Controls.Clear();
            pnlCart.Controls.Add(htItem);
        }
    }
    protected void btnBackToHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("home.aspx");
    }
    protected void btnOrderSubmit_Click(object sender, EventArgs e)
    {
        if (Session["Cart"] != null)
        {
            Session["Cart"] = null;
        }

        Response.Redirect("~/user/pages/OrderConfirmation.aspx");
    }
}
