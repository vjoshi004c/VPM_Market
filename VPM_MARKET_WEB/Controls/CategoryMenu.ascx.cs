﻿using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_CategoryMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HtmlTable htItem = new HtmlTable();
        htItem.CellPadding = 2;
        htItem.CellSpacing = 2;
        htItem.Width = "100%";

        DataSet dsItem = GetItem();
        if (dsItem != null && dsItem.Tables != null && dsItem.Tables.Count > 0 && dsItem.Tables[0].Rows != null && dsItem.Tables[0].Rows.Count > 0)
         {
             
             int totalItem = dsItem.Tables[0].Rows.Count;
             int totalItemWidthPercentage = Convert.ToInt16(100 / totalItem);

             for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
             {
                 HtmlTableRow hrItem = new HtmlTableRow();
                 DataRow drItem = dsItem.Tables[0].Rows[i];
                 
                 string CategoryID = drItem["CategoryID"].ToString();
                 string CategoryName = drItem["CategoryName"].ToString();
                 string CategoryDescription = drItem["CategoryDescription"].ToString();
                 //string ItemPrice = drItem["ItemPrice"].ToString();
                 HtmlTableCell hcItemSecond = new HtmlTableCell();
                 hcItemSecond.Attributes.Add("class", "tdMenu");
                 hcItemSecond.Align = "Left";
                 //hcItemSecond.Width = "20%";
                 hcItemSecond.Width = totalItemWidthPercentage.ToString() + "%";
               
                // hcItemSecond.InnerText = "hsodfhkldlkdsjklfdjfkj";
                //hcItemSecond.InnerHtml = "<span style=\"color:black;\"><b>" + CategoryName + "</b></span>";
                 hcItemSecond.Attributes.Add("class", "tdMenu");
                HyperLink hyperLink = new HyperLink();
                hyperLink.CssClass = "linkMenu";
                if (Request.QueryString["CategoryID"] != null)
                {
                    if (Request.QueryString["CategoryID"].ToString() == CategoryID.ToString())
                    {
                        hyperLink.CssClass = "linkMenuReverse";
                        hcItemSecond.Attributes.Add("class", "tdMenuReverse");
                        
                    }
                    else
                    {
                        hyperLink.CssClass = "linkMenu";
                        hcItemSecond.Attributes.Add("class", "tdMenu");
                    }
                }

                hyperLink.Font.Underline = false;
                hyperLink.Text = CategoryName;
                hyperLink.NavigateUrl = "~/User/Pages/Home.aspx?CategoryID=" + CategoryID +"&SubCategoryID="+"0"+"&ItemId="+"0";


                 //<asp:HyperLink id="hlkUser" runat="server"  CssClass="linkMenu"  Font-Underline="false" Text="Mangeg User" NavigateUrl="~/Admin/Pages/ManageUser.aspx"></asp:HyperLink>


                hcItemSecond.Controls.Add(hyperLink);

                // hcItemSecond.BgColor = "#EDEDEC";
                 hrItem.Cells.Add(hcItemSecond);
                 htItem.Rows.Add(hrItem);
             }
            
             pnlItem.Controls.Clear();
             pnlItem.Controls.Add(htItem);
         }
       
    }

    protected DataSet GetItem()
    {
        try
        {
            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //string sql = "select loginid, password , firstname, lastname, userstatus,address1, address2,sex, matriastatus,zipcode,emaiid, isadmin ";
            //sql = sql + " from UserMaster ";

            string sql = " SELECT CategoryID, CategoryName , CategoryDescription ";
            sql = sql + "FROM CategoryMaster  where active = true ;";


            DataSet dsItemData = new DataSet();
            OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
            myDataConnection.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dsItemData);
            }
            return dsItemData;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}
