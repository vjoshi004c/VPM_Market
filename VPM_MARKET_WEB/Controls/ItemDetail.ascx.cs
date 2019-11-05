using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.HtmlControls;

public partial class Controls_ItemDetail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string subCategoryId = string.Empty;
        string categoryId = string.Empty;
        string itemId = string.Empty ;
         if (Request.QueryString["SubCategoryID"] != null)        {
            subCategoryId = Request.QueryString["SubCategoryID"].ToString();
        }

        if (Request.QueryString["CategoryID"] != null)
        {
            categoryId = Request.QueryString["CategoryID"].ToString();
        }
         if (Request.QueryString["ItemId"] != null)        {
            itemId = Request.QueryString["ItemId"].ToString();
        }


         if (Request.QueryString["ItemId"] != null)
         {

             DataSet dsItem = GetItem(Convert.ToInt16(Request.QueryString["ItemId"].ToString()));

             if (dsItem != null && dsItem.Tables != null && dsItem.Tables.Count > 0 && dsItem.Tables[0].Rows != null && dsItem.Tables[0].Rows.Count > 0)
             {
                 string subItemImageUrlPath = "~/images/Item/";
                 int totalItem = dsItem.Tables[0].Rows.Count;
                 int totalItemWidthPercentage = Convert.ToInt16(100 / totalItem);

                 DataRow drItem = dsItem.Tables[0].Rows[0];
                 string ItemId = drItem["ITEMID"].ToString();
                 string ItemName = drItem["ITEMNAME"].ToString();
                 string ItemDescription = drItem["ITEMDESCRIPTION"].ToString();
                 string ItemPrice = drItem["ITEMPRICE"].ToString();
                 string ItemImagePath = drItem["ImagePath"].ToString();

                 this.txtItemID.Text = ItemId;
                 this.txtItemName.Text = ItemName;
                 this.lblItemDescription.Text = ItemDescription;
                 this.txtPrice.Text = ItemPrice;

                    imgItemDetail.Width = (Unit)300;
                    imgItemDetail.Height = (Unit)300;

                    imgItemDetail.ImageUrl = subItemImageUrlPath + ItemImagePath;
                    imgItemDetail.AlternateText = ItemName;
                 
             }
         }
    }

    protected DataSet GetItem(int itemId)
    {
        try
        {
            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //string sql = "select loginid, password , firstname, lastname, userstatus,address1, address2,sex, matriastatus,zipcode,emaiid, isadmin ";
            //sql = sql + " from UserMaster ";

            //string sql = " SELECT SubCategoryID, SubCategoryName , subCategoryDescription , imagePath ";
            // sql = sql + "FROM SubCategoryMaster where categoryID=" + subCategoryId + " and  active = true ;";


            string sql = "select im.ITEMID, im.ITEMNAME, im.ITEMDESCRIPTION, im.ITEMPRICE, im.active , im.ImagePath,im.IsStock ";
            sql = sql + " from ITEMMASTER  im  where   im.itemId=" + Convert.ToInt16(itemId);


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

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {

        string itemId = this.txtItemID.Text ;
        string ItemName = this.txtItemName.Text;
        string ItemPrice = this.txtPrice.Text;
        string ItemQunaity = this.txtQuantity.Text;
        if (Session["Cart"] != null)
        {
            DataTable dtCart = (DataTable)Session["Cart"];
            addCartItem(dtCart, itemId, ItemName, ItemPrice, ItemQunaity);
           
        }
        else
        {
            DataTable dtCart = GetCart(itemId, ItemName, ItemPrice, ItemQunaity);
            Session["Cart"] = dtCart;
        }
        Response.Redirect("~/user/pages/home.aspx");
    }

    protected void btnCheckOut_Click(object sender, EventArgs e)
    {

        string itemId = this.txtItemID.Text ;
        string ItemName = this.txtItemName.Text;
        string ItemPrice = this.txtPrice.Text;
        string ItemQunaity = this.txtQuantity.Text;
        if (Session["Cart"] != null)
        {
            DataTable dtCart = (DataTable)Session["Cart"];
            addCartItem(dtCart, itemId, ItemName, ItemPrice, ItemQunaity);
           
        }
        else
        {
            DataTable dtCart = GetCart(itemId, ItemName, ItemPrice, ItemQunaity);
            Session["Cart"] = dtCart;
        }
        Response.Redirect("~/user/pages/OrderPayment.aspx");
    }
    private DataTable addCartItem(DataTable dtCart, string itemId, string ItemName, string ItemPrice, string ItemQunaity)
    {
        DataRow dataRow = dtCart.NewRow();
        dataRow["ItemId"] = itemId;
        dataRow["ItemName"] = ItemName;
        dataRow["ItemPrice"] = ItemPrice;
        dataRow["ItemQuantity"] = ItemQunaity;
        dtCart.Rows.Add(dataRow);

        return dtCart;

    }
    private DataTable GetCart(string itemId, string ItemName, string ItemPrice, string ItemQunaity)
    {
        DataTable dtCart = new DataTable();

        DataColumn dataColumn = new DataColumn("ItemId", System.Type.GetType("System.String"));
        dtCart.Columns.Add(dataColumn);

        dataColumn = new DataColumn("ItemName", System.Type.GetType("System.String"));
        dtCart.Columns.Add(dataColumn);

        dataColumn = new DataColumn("ItemPrice", System.Type.GetType("System.String"));
        dtCart.Columns.Add(dataColumn);

        dataColumn = new DataColumn("ItemQuantity", System.Type.GetType("System.String"));
        dtCart.Columns.Add(dataColumn);

        DataRow dataRow = dtCart.NewRow();
        dataRow["ItemId"] = itemId;
        dataRow["ItemName"] = ItemName;
        dataRow["ItemPrice"] = ItemPrice;
        dataRow["ItemQuantity"] = ItemQunaity;

        dtCart.Rows.Add(dataRow);

        
        return dtCart;
    }
}
