using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Controls_ItemMainMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        HtmlTable htItem = new HtmlTable();
        htItem.CellPadding = 2;
        htItem.CellSpacing = 2;
        htItem.Width = "100%";
        string subCategoryId = string.Empty;
        string categoryId = string.Empty;

        if (Request.QueryString["SubCategoryID"] != null)
        {
            subCategoryId = Request.QueryString["SubCategoryID"].ToString();
            {

                //dsItem = GetItem( subCategoryId);
            }
        }

        if (Request.QueryString["CategoryID"] != null)
        {
            categoryId = Request.QueryString["CategoryID"].ToString();
            {

                // dsItem = GetItem(subCategoryId);
            }
        }
        if (Request.QueryString["SubCategoryID"] != null)
        {

            // DataSet dsItem = GetItem(Convert.ToInt16(Request.QueryString["SubCategoryID"].ToString()));
            DataSet dsItem = GetItem(subCategoryId);
            if (dsItem != null && dsItem.Tables != null && dsItem.Tables.Count > 0 && dsItem.Tables[0].Rows != null && dsItem.Tables[0].Rows.Count > 0)
            {

                int totalItem = dsItem.Tables[0].Rows.Count;
                int totalItemWidthPercentage = Convert.ToInt16(100 / totalItem);

                for (int i = 0; i < dsItem.Tables[0].Rows.Count; i++)
                {
                    HtmlTableRow hrItem = new HtmlTableRow();
                    DataRow drItem = dsItem.Tables[0].Rows[i];

                    //string CategoryID = drItem["CategoryID"].ToString();
                    //string CategoryName = drItem["CategoryName"].ToString();
                    //string CategoryDescription = drItem["CategoryDescription"].ToString();

                    string ItemId = drItem["ITEMID"].ToString();
                    string ItemName = drItem["ITEMNAME"].ToString();
                    string ItemDescription = drItem["ITEMDESCRIPTION"].ToString();
                    string ItemPrice = drItem["ITEMPRICE"].ToString();
                    string ItemImagePath = drItem["ImagePath"].ToString();


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
                        if (Request.QueryString["ItemId"].ToString() == ItemId.ToString())
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
                    hyperLink.Text = ItemName;
                    hyperLink.NavigateUrl = "~/User/Pages/ItemwithDetail.aspx?CategoryID=" + categoryId + "&SubCategoryID=" + subCategoryId + "&ItemId=" + ItemId;


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

    }

    protected DataSet GetItem(string  subCategoryId)
    {
        try
        {
            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //string sql = "select loginid, password , firstname, lastname, userstatus,address1, address2,sex, matriastatus,zipcode,emaiid, isadmin ";
            //sql = sql + " from UserMaster ";

            //string sql = " SELECT SubCategoryID, SubCategoryName , subCategoryDescription , imagePath ";
            // sql = sql + "FROM SubCategoryMaster where categoryID=" + subCategoryId + " and  active = true ;";


            string sql = "select im.ITEMID, im.ITEMNAME, im.ITEMDESCRIPTION, im.ITEMPRICE, im.active , im.ImagePath,im.IsStock, scm.SubCategoryID, scm.SubCategoryNAME ";
            sql = sql + " from ITEMMASTER  im , SubCategoryMASTER scm where im.SubCategoryID= scm.SubCategoryID AND im.active= true and im.SubCategoryID=" + Convert.ToInt16(subCategoryId);


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
