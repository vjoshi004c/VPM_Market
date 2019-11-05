using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_AdminMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
            //hyperLink.CssClass = "linkMenuReverse";
            //hcItemSecond.Attributes.Add("class", "tdMenuReverse");

       
            this.hlkUser.CssClass = "linkMenu";
            this.tdUser.Attributes.Add("class", "tdMenu");
            this.hlkViewOrder.CssClass = "linkMenu";
            this.tdViewOrder.Attributes.Add("class", "tdMenu");
            this.hlkGroup.CssClass = "linkMenu";
            this.tdGroup.Attributes.Add("class", "tdMenu");
            this.hlkCategory.CssClass = "linkMenu";
            this.tdCategory.Attributes.Add("class", "tdMenu");
            this.hlkSubCategory.CssClass = "linkMenu";
            this.tdSubCategory.Attributes.Add("class", "tdMenu");
            this.hlkItem.CssClass = "linkMenu";
            this.tdItem.Attributes.Add("class", "tdMenu");
            this.hlkViewLogs.CssClass = "linkMenu";
            this.tdViewLogs.Attributes.Add("class", "tdMenu");



            if (Request.QueryString != null && Request.QueryString["Mode"] != null)
        {
            string mode = Request.QueryString["Mode"].ToString();
            switch (mode)
            {
                case "MU":
                    this.hlkUser.CssClass = "linkMenuReverse";
                    this.tdUser.Attributes.Add("class", "tdMenuReverse");
                    break;
                case "MC":
                    this.hlkCategory.CssClass = "linkMenuReverse";
                    this.tdCategory.Attributes.Add("class", "tdMenuReverse");
                    break;
                case "MSC":
                    this.tdSubCategory.Attributes.Add("class", "tdMenuReverse");
                    this.hlkSubCategory.CssClass = "linkMenuReverse";
                    break;
                case "MI":
                    this.hlkItem.CssClass = "linkMenuReverse";
                    this.tdItem.Attributes.Add("class", "tdMenuReverse");
                    break;
                case "VL":
                    this.hlkViewLogs.CssClass = "linkMenuReverse";
                    this.tdViewLogs.Attributes.Add("class", "tdMenuReverse");
                    break;
                case "VO":
                    this.hlkViewOrder.CssClass = "linkMenuReverse";
                    this.tdViewOrder.Attributes.Add("class", "tdMenuReverse");
                    break;
                case "MG":
                    this.hlkGroup.CssClass = "linkMenuReverse";
                    this.tdGroup.Attributes.Add("class", "tdMenuReverse");
                    break;
            }




        }

    }
}
