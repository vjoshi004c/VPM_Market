using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class Admin_Pages_ManageItem : System.Web.UI.Page
{
    private void RegisterClientScript()
    {
        string scripthdnEdit = "<script language=javascript>var hdnEditClientId ='" + hdnEdit.ClientID + "'</script>";
        // this.Page.RegisterClientScriptBlock("variableDeclare6", scripttxtSelectedTimeSlotDescription);
        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "variableDeclare7", scripthdnEdit);
        string scripthdnDelete = "<script language=javascript>var hdnDeleteClientId ='" + htnDelete.ClientID + "'</script>";
        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "variableDeclare8", scripthdnDelete);
        string scripthdnOperationMode = "<script language=javascript>var hdnOperationModeClientId ='" + hdnOperationMode.ClientID + "'</script>";
        this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "variableDeclare8", scripthdnOperationMode);
    }

    protected void EditAffiliate()
    {
        hdnClientHit.Value = string.Empty;
        divAddEdit.Visible = true;
        pnlAffiliateABB.Visible = false;
        string itemId = string.Empty;
        string itemName = string.Empty;
        string itemDescription = string.Empty;
        string itemPrice = string.Empty;

        string itemActive = string.Empty;
        string SubCategoryId = string.Empty;
        string SubCategoryName = string.Empty;
        string ItemImagePath = string.Empty;
        string ItemIsStock = string.Empty;


        string selectedOptioin = hdnEdit.Value;
        string[] selectedOptions = null;
        try
        {
            if (selectedOptioin != null)
            {
                selectedOptions = selectedOptioin.Split('@');
            }
            if (selectedOptions.Length > 0 && selectedOptions.Length == 9)
            {
                itemId = selectedOptions[0];
                itemName = selectedOptions[1];
                itemDescription = selectedOptions[2];
                itemPrice = selectedOptions[3];
                itemActive = selectedOptions[4];
                SubCategoryId = selectedOptions[5];
                SubCategoryName = selectedOptions[6];
                ItemImagePath = selectedOptions[7];
                ItemIsStock = selectedOptions[8];
            }
            BindAffiliateCodeData("EDIT", string.Empty, string.Empty, string.Empty, string.Empty);
            // DeleteAffiliateAbberation(affiliateId);
            this.txtItemId.Text = itemId;
            this.txtItemName.Text = itemName;
            this.txtDescription.Text = itemDescription;
            this.txtItemPrice.Text = itemPrice;
            divAddEdit.Visible = true;
            divDeleteConfirmation.Visible = false;
            pnlAffiliateABB.Visible = false;

            this.ddlItemIsStock.SelectedValue = ItemIsStock;
            this.ddlSubCategory.SelectedValue = SubCategoryId;
            this.txtSubCategoryId.Text = SubCategoryId;
            this.txtItemImagePath.Text = ItemImagePath;
            this.ddlItemActive.SelectedValue = itemActive;
            //ddlAffiliateCode.Enabled = false;
            imgItem.ImageUrl = "~/images/item/"  +ItemImagePath;
            imgItem.Width = Unit.Pixel(150);
            imgItem.Height = Unit.Pixel(150);
        }
        catch (Exception ex)
        {
            BindAffiliateData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlAffiliateABB.Visible = true;
            // this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }
    }
    private void BindSubCategoryData()
    {
        DataSet dsCategory = RetrieveSubCategoryData();
        if (dsCategory != null)
        {
            if (dsCategory != null && dsCategory.Tables.Count > 0)
            {
                DataTable dtCategory = dsCategory.Tables[0];
                ddlSubCategory.DataValueField = "SubCategoryId";
                ddlSubCategory.DataTextField = "SubCategoryName";
                ddlSubCategory.DataSource = dtCategory;
                ddlSubCategory.DataBind();

            }
        }
    }

    protected DataSet RetrieveSubCategoryData()
    {
        string connString = ConfigurationManager.AppSettings["ConnectionString"];
        string sql = "select scm.SubCategoryID,scm.SubCategoryName ";
        sql = sql + " from  SubCategoryMaster scm ";

        DataSet dsSubCategoryData = new DataSet();
        OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);

        myDataConnection.Open();
        using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dsSubCategoryData);
        }
        return dsSubCategoryData;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        this.pnlAffiliateABB.Visible = true;
        //this.btnAddAffiliate.Visible = true;
        if (!IsPostBack)
        {
            BindSubCategoryData();
            BindAffiliateData();
            EnableAddAffiliateAbberationButton();
        }
        else
        {
            if (hdnClientHit.Value == "TRUE")
            {

                string affiliateId = string.Empty;
                string affiliateCode = string.Empty;
                string affiliateName = string.Empty;
                string affiliateAbberation = string.Empty;
                if (hdnOperationMode.Value == "EDIT")
                {
                    this.btnAddAffiliate.Visible = false;
                    EditAffiliate();
                }
                if (hdnOperationMode.Value == "DELETE")
                {
                    this.btnAddAffiliate.Visible = false;
                    divDeleteConfirmation.Visible = true;

                }
            }
            //else
            //{
            //    BindAffiliateData();
            //    EnableAddAffiliateAbberationButton();
            //}
        }
        RegisterClientScript();
    }

    private void EnableAddAffiliateAbberationButton()
    {
        this.btnAddAffiliate.Visible = true;
        //DataSet dsAffiliateCode = RetrieveAffiliateCodeData("ADD");
        //if (dsAffiliateCode != null && dsAffiliateCode.Tables != null && dsAffiliateCode.Tables.Count > 0 && dsAffiliateCode.Tables[0].Rows != null && dsAffiliateCode.Tables[0].Rows.Count>0)
        ////if (dsAffiliateCode == null)
        //{
        //    this.btnAddAffiliate.Enabled = true;
        //}
        //else
        //{
        //    this.btnAddAffiliate.Enabled = false;
        //}
    }

    protected void AddAffiliate(object sender, EventArgs e)
    {
        // ddlAffiliateCode.Enabled = true;
        hdnOperationMode.Value = "ADD";
        hdnClientHit.Value = string.Empty;
        divAddEdit.Visible = true;
        divDeleteConfirmation.Visible = false;
        pnlAffiliateABB.Visible = false;
        BindAffiliateCodeData("ADD", string.Empty, string.Empty, string.Empty, string.Empty);
        // this.txtAFFILIATE_ABBR.Text = string.Empty;
        this.btnAddAffiliate.Visible = false;
    }


    private bool UpdateAffiliateAbberation(string itemId, string itemName, string itemDescription, string itemPrice, bool  itemIsStock, string SubCategoryId, string ItemImagePath,bool  itemActive)
    {
        try
        {
            string sql = @"Update ITEMMASTER set ItemName = '" + itemName + "', ItemDescription = '" + itemDescription + "', ItemPrice = '" + itemPrice + "', IsStock = " + itemIsStock + ", SubCategoryID = " + SubCategoryId + ", ImagePath = '" + ItemImagePath + "', active = " + itemActive + " where itemId = " + itemId + "";
            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //SQL statement to insert new Configuration
            OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
            //using (OracleConnection conn = new OracleConnection(connString))
            //{
            myDataConnection.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
            {
                cmd.ExecuteNonQuery();
                BindAffiliateData();
            }
            //}
            return true;
        }
        catch (Exception ex)
        {
            BindAffiliateData();
            divAddEdit.Visible = false;
            pnlAffiliateABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
            return false;
        }
    }

    private void DeleteAffiliateAbberation(string itemId)
    {
        try
        {
            if (!string.IsNullOrEmpty(itemId))
            {
                //string connString = ConfigurationManager.AppSettings["ConnectionString"];
                string connString = ConfigurationManager.AppSettings["ConnectionString"];
                string deletesql = @"delete from ItemMaster where ItemId= " + itemId + "";
                OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
                //using (OracleConnection conn = new OracleConnection(connString))
                //{
                myDataConnection.Open();
                using (OleDbCommand cmd = new OleDbCommand(deletesql, myDataConnection))
                {
                    cmd.ExecuteNonQuery();
                    //BindAffiliateData();

                }
                //}
            }
        }
        catch (Exception ex)
        {
            //BindAffiliateData();
            //divAddEdit.Visible = false;
            //pnlAffiliateABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
            throw ex;
        }
    }

    protected void DeleteSave(object sender, EventArgs e)
    {
        string itemId = string.Empty;
        string itemName = string.Empty;
        string itemDescription = string.Empty;
        string itemPrice = string.Empty;
        string selectedOptioin = htnDelete.Value;
        string[] selectedOptions = null;
        try
        {
            if (selectedOptioin != null)
            {
                selectedOptions = selectedOptioin.Split('@');
            }
            if (selectedOptions.Length > 0 && selectedOptions.Length == 9)
            {
                itemId = selectedOptions[0];
                itemName = selectedOptions[1];
                itemDescription = selectedOptions[2];
                itemPrice = selectedOptions[3];
            }
            DeleteAffiliateAbberation(itemId);

            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlAffiliateABB.Visible = true;
            BindAffiliateData();
            EnableAddAffiliateAbberationButton();
            hdnOperationMode.Value = string.Empty;
        }
        catch (Exception ex)
        {
            BindAffiliateData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlAffiliateABB.Visible = true;
            hdnOperationMode.Value = string.Empty;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }
    }
    protected void DeleteCancel(object sender, EventArgs e)
    {
        divAddEdit.Visible = false;
        divDeleteConfirmation.Visible = false;
        pnlAffiliateABB.Visible = true;
        BindAffiliateData();
        this.btnAddAffiliate.Visible = true;
    }
    protected void Save(object sender, EventArgs e)
    {
        try
        {
            if (hdnOperationMode.Value == "ADD")
            {
                divAddEdit.Visible = false;
                pnlAffiliateABB.Visible = true;

                string itemName = this.txtItemName.Text;
                string itemDescription = this.txtDescription.Text;
                string itemPrice = this.txtItemPrice.Text;

                bool itemIsStock = Convert.ToBoolean(this.ddlItemIsStock.SelectedValue);
                string SubCategoryId = this.ddlSubCategory.SelectedValue;
                // string SubCategoryId this.txtSubCategoryId.Text ;
               // string ItemImagePath = this.txtItemImagePath.Text;
               // string ItemImagePath = fileItemImagegPath.PostedFile.FileName;

                string ItemImagePath = string.Empty;
                if (fileItemImagegPath.PostedFile.FileName == string.Empty)
                {
                    ItemImagePath = this.txtItemImagePath.Text;
                }
                else
                {
                    ItemImagePath = fileItemImagegPath.PostedFile.FileName;
                }


                bool itemActive = Convert.ToBoolean(this.ddlItemActive.SelectedValue);

                if (this.txtItemName.Text.Trim() != string.Empty)
                {
                    if (fileItemImagegPath.PostedFile.FileName != string.Empty)
                    {
                        string fn = System.IO.Path.GetFileName(fileItemImagegPath.PostedFile.FileName);
                        ItemImagePath = fn;
                        string SaveLocation = Request.MapPath("~/images/item/") + fn;
                        try
                        {

                            fileItemImagegPath.PostedFile.SaveAs(SaveLocation);
                            //Response.Write("The file has been uploaded.");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    bool flag = insertAffiliateAbberation("0", itemName, itemDescription, itemPrice, itemIsStock, SubCategoryId, ItemImagePath, itemActive);
                    if (flag == true)
                    {
                        BindAffiliateData();
                        EnableAddAffiliateAbberationButton();
                    }
                }
            }
            if (hdnOperationMode.Value == "EDIT")
            {
                divAddEdit.Visible = false;
                divDeleteConfirmation.Visible = false;
                pnlAffiliateABB.Visible = true;
                //string affiliateId = ddlAffiliateCode.SelectedValue.ToString();
                //string affiliateAbberation = txtAFFILIATE_ABBR.Text;
                string itemId = this.txtItemId.Text;
                string itemName = this.txtItemName.Text;
                string itemDescription = this.txtDescription.Text;
                string itemPrice = this.txtItemPrice.Text;

                bool itemIsStock = Convert.ToBoolean(this.ddlItemIsStock.SelectedValue);
                string SubCategoryId = this.ddlSubCategory.SelectedValue;
                // string SubCategoryId this.txtSubCategoryId.Text ;
                //string ItemImagePath = this.txtItemImagePath.Text;
                string ItemImagePath = string.Empty;
                if (fileItemImagegPath.PostedFile.FileName == string.Empty)
                {
                    ItemImagePath = this.txtItemImagePath.Text;
                }
                else
                {
                    ItemImagePath = fileItemImagegPath.PostedFile.FileName;
                }

                

               // string ItemImagePath = this.txtItemImagePath.Text;
                bool  itemActive = Convert.ToBoolean(this.ddlItemActive.SelectedValue);

                if (this.txtItemName.Text.Trim() != string.Empty)
                {
                    if (fileItemImagegPath.PostedFile.FileName != string.Empty)
                    {
                        string fn = System.IO.Path.GetFileName(fileItemImagegPath.PostedFile.FileName);
                        ItemImagePath = fn;
                       string SaveLocation = Request.MapPath("~/images/item/") + fn;
                        //string SaveLocation = "~/IMAGES/item/" + fn;
                        try
                        {

                            fileItemImagegPath.PostedFile.SaveAs(SaveLocation);
                            //Response.Write("The file has been uploaded.");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    bool flag = UpdateAffiliateAbberation(itemId, itemName, itemDescription, itemPrice, itemIsStock, SubCategoryId, ItemImagePath, itemActive);
                    if (flag == true)
                    {
                        BindAffiliateData();
                        EnableAddAffiliateAbberationButton();
                    }
                }
            }
            hdnOperationMode.Value = string.Empty;
        }
        catch (Exception ex)
        {
            BindAffiliateData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlAffiliateABB.Visible = true;
            hdnOperationMode.Value = string.Empty;
            // this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }
    }

    private bool insertAffiliateAbberation(string ITEMID, string ITEMNAME, string ITEMDESCRIPTION, string ITEMPRICE, bool  itemIsStock, string SubCategoryId, string ItemImagePath,bool  itemActive)
    {
        if (!string.IsNullOrEmpty(ITEMNAME) && !string.IsNullOrEmpty(ITEMPRICE))
        {
            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //string insertsql = @"Insert into CHANNEL_code_mapping(CHANNEL_code_mapping_id , CHANNEL_ID, CHANNEL_ABBR,  Creation_Date, Last_Update) 
            // values('" + Guid.NewGuid() + "','" + affiliateId + "','" + affiliateAbberation + "', '" + DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + "', '" + DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + "')";
            string insertsql = @"Insert into ITEMMASTER(ITEMNAME , ITEMDESCRIPTION, ITEMPRICE,IsStock,SubCategoryID,ImagePath,active)  values('" + ITEMNAME + "','" + ITEMDESCRIPTION + "', '" + ITEMPRICE + "', " + itemIsStock + ", " + Convert.ToInt16(SubCategoryId) + ", '" + ItemImagePath + "', " + itemActive + ")";
            OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
            //using (OracleConnection conn = new OracleConnection(connString))
            // {
            myDataConnection.Open();
            using (OleDbCommand cmd = new OleDbCommand(insertsql, myDataConnection))
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            // }
        }
        else
        {
            BindAffiliateData();
            divAddEdit.Visible = false;
            pnlAffiliateABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog("Please enter Channel Id /Channel Abberation.", false);
            return false;
        }
    }


    protected void Cancel(object sender, EventArgs e)
    {
        divAddEdit.Visible = false;
        pnlAffiliateABB.Visible = true;
        divDeleteConfirmation.Visible = false;
        BindAffiliateData();
        this.btnAddAffiliate.Visible = true;
    }



    private HtmlTable DisplayAffiliateAbb(DataTable dtAffilateAbb)
    {
        try
        {
            HtmlTable htCharges = new HtmlTable();
            htCharges.CellPadding = 0;
            htCharges.CellSpacing = 0;
            htCharges.Width = "100%";

            HtmlTableRow hrItemHeader = new HtmlTableRow();
            HtmlTableCell hcItemHeaderFirst = new HtmlTableCell();
            hcItemHeaderFirst.Visible = false;
            hcItemHeaderFirst.Width = "50%";
            hcItemHeaderFirst.Attributes.Add("class", "gridHeader");
            hcItemHeaderFirst.InnerText = "Item ID";
            hrItemHeader.Cells.Add(hcItemHeaderFirst);

            HtmlTableCell hcItemHeaderSecond = new HtmlTableCell();
            hcItemHeaderSecond.Width = "25%";
            hcItemHeaderSecond.Attributes.Add("class", "gridHeader");
            hcItemHeaderSecond.InnerText = "Item Name";
            hrItemHeader.Cells.Add(hcItemHeaderSecond);
            HtmlTableCell hcItemHeaderThird = new HtmlTableCell();
            hcItemHeaderThird.Width = "25%";
            hcItemHeaderThird.Attributes.Add("class", "gridHeader");
            hcItemHeaderThird.InnerText = "Item Description";
            hrItemHeader.Cells.Add(hcItemHeaderThird);
            //htCharges.Rows.Add(hrItemHeader);

            HtmlTableCell hcItemHeaderForth = new HtmlTableCell();
            hcItemHeaderForth.Width = "25%";
            hcItemHeaderForth.Attributes.Add("class", "gridHeader");
            hcItemHeaderForth.InnerText = "Item Price";
            hrItemHeader.Cells.Add(hcItemHeaderForth);
            //htCharges.Rows.Add(hrItemHeader);

            
                HtmlTableCell hcItemHeaderForth1 = new HtmlTableCell();
            hcItemHeaderForth1.Width = "25%";
            hcItemHeaderForth1.Attributes.Add("class", "gridHeader");
            hcItemHeaderForth1.InnerText = "Active";
            hrItemHeader.Cells.Add(hcItemHeaderForth1);
            //htCharges.Rows.Add(hrItemHeader);

            HtmlTableCell hcItemHeaderForth2 = new HtmlTableCell();
            hcItemHeaderForth2.Width = "25%";
            hcItemHeaderForth2.Attributes.Add("class", "gridHeader");
            hcItemHeaderForth2.InnerText = "SubCategory Id";
            hcItemHeaderForth2.Visible = false;
            hrItemHeader.Cells.Add(hcItemHeaderForth2);
            //htCharges.Rows.Add(hrItemHeader);

            HtmlTableCell hcItemHeaderForth3 = new HtmlTableCell();
            hcItemHeaderForth3.Width = "25%";
            hcItemHeaderForth3.Attributes.Add("class", "gridHeader");
            hcItemHeaderForth3.InnerText = "Sub Category Name";
            hrItemHeader.Cells.Add(hcItemHeaderForth3);
            //htCharges.Rows.Add(hrItemHeader);



            HtmlTableCell hcItemHeaderFifth = new HtmlTableCell();
            hcItemHeaderFifth.Width = "25%";
            hcItemHeaderFifth.Attributes.Add("class", "gridHeader");
            hcItemHeaderFifth.InnerText = "Action";
            hrItemHeader.Cells.Add(hcItemHeaderFifth);
            // htCharges.Rows.Add(hrItemHeader);

            HtmlTableCell hcItemHeaderSixth = new HtmlTableCell();
            hcItemHeaderSixth.Width = "25%";
            hcItemHeaderSixth.Attributes.Add("class", "gridHeader");
            hcItemHeaderSixth.InnerText = "Action";
            hrItemHeader.Cells.Add(hcItemHeaderSixth);
            htCharges.Rows.Add(hrItemHeader);

            if (dtAffilateAbb != null && dtAffilateAbb.Rows.Count > 0)
            {
                for (int i = 0; i < dtAffilateAbb.Rows.Count; i++)
                {
                    HtmlTableRow hrItem = new HtmlTableRow();
                    DataRow dr = dtAffilateAbb.Rows[i];
                    string ItemId = dr["ItemId"].ToString();
                    string ItemName = dr["ItemName"].ToString();
                    string ItemDescription = dr["ItemDescription"].ToString();
                    string ItemPrice = dr["ItemPrice"].ToString();

                    string Active = dr["Active"].ToString();
                    string SubCategoryId = dr["SubCategoryID"].ToString();
                    string SubCategoryName = dr["SubCategoryNAME"].ToString();
                    string ItemImagePath = dr["ImagePath"].ToString();
                    string ItemIsStock = dr["IsStock"].ToString();


                    HtmlTableCell hcItemFirst = new HtmlTableCell();
                    hcItemFirst.Width = "5%";
                    hcItemFirst.Attributes.Add("class", "gridRows1");
                    hcItemFirst.InnerText = ItemId;
                    hcItemFirst.Visible = false;
                    hrItem.Cells.Add(hcItemFirst);

                    HtmlTableCell hcItemSecond = new HtmlTableCell();
                    hcItemSecond.Width = "30%";
                    hcItemSecond.Attributes.Add("class", "gridRows1");
                    hcItemSecond.InnerText = ItemName;
                    hcItemSecond.InnerHtml = "<span style=\"color:black;\"><b>" + ItemName + "</b></span>";
                    hcItemSecond.BgColor = "#EDEDEC";
                    hrItem.Cells.Add(hcItemSecond);
                    HtmlTableCell hcItemThird = new HtmlTableCell();
                    hcItemThird.Width = "30%";
                    hcItemThird.Attributes.Add("class", "gridRows1");
                    hcItemThird.InnerText = ItemDescription;
                    // hcItemThird.BgColor = "#DCDCDC";
                    hrItem.Cells.Add(hcItemThird);
                    //htCharges.Rows.Add(hrItem);

                    HtmlTableCell hcItemForth = new HtmlTableCell();
                    hcItemForth.Width = "15%";
                    hcItemForth.Attributes.Add("class", "gridRows1");
                    hcItemForth.InnerText = ItemPrice;
                    hcItemForth.Align = HorizontalAlign.Center.ToString();
                    hrItem.Cells.Add(hcItemForth);
                    // htCharges.Rows.Add(hrItemHeader);

                    HtmlTableCell hcItemForth1 = new HtmlTableCell();
                    hcItemForth1.Width = "15%";
                    hcItemForth1.Attributes.Add("class", "gridRows1");
                    hcItemForth1.InnerText = Active;
                    hcItemForth1.Align = HorizontalAlign.Center.ToString();
                    hrItem.Cells.Add(hcItemForth1);

                    HtmlTableCell hcItemForth2 = new HtmlTableCell();
                    hcItemForth2.Width = "15%";
                    hcItemForth2.Attributes.Add("class", "gridRows1");
                    hcItemForth2.Visible = false;
                    hcItemForth2.InnerText = SubCategoryId;
                    hcItemForth2.Align = HorizontalAlign.Center.ToString();
                    hrItem.Cells.Add(hcItemForth2);

                    HtmlTableCell hcItemForth3 = new HtmlTableCell();
                    hcItemForth3.Width = "15%";
                    hcItemForth3.Attributes.Add("class", "gridRows1");
                    hcItemForth3.InnerText = SubCategoryName;
                    hcItemForth3.Align = HorizontalAlign.Center.ToString();
                    hrItem.Cells.Add(hcItemForth3);





                    HtmlTableCell hcItemFifth = new HtmlTableCell();
                    hcItemFifth.Width = "10%";
                    hcItemFifth.Attributes.Add("class", "gridRows1");
                    hcItemFifth.Align = HorizontalAlign.Center.ToString();
                    ImageButton imgEdit = new ImageButton();



                    imgEdit.OnClientClick = "onEditSelection" + "('" + ItemId + "','" + ItemName + "','" + ItemDescription + "','" + ItemPrice + "','" + Active + "','" + SubCategoryId + "','" + SubCategoryName + "','" + ItemImagePath + "','" + ItemIsStock + "')";
                    imgEdit.Width = new Unit(20);
                    imgEdit.Height = new Unit(20);
                    imgEdit.ID = i.ToString(); ;
                    imgEdit.ToolTip = "Edit";
                    imgEdit.ImageUrl = "~/Images/EditThird.png";
                    hcItemFifth.Controls.Add(imgEdit);
                    //Button btnEdit = new Button();
                    //btnEdit.OnClientClick = "onEditSelection" + "('" + ItemId + "','" + AFFILIATE_CODE + "','" + AFFILIATE_NAME + "','" + AFFILIATE_ABBR + "')";
                    //btnEdit.ID = i.ToString(); ;
                    //btnEdit.Text = "Edit";
                    //hcItemFifth.Controls.Add(btnEdit);
                    hrItem.Cells.Add(hcItemFifth);
                    //htCharges.Rows.Add(hrItemHeader);

                    HtmlTableCell hcItemSixth = new HtmlTableCell();
                    hcItemSixth.Align = HorizontalAlign.Center.ToString();
                    hcItemSixth.Width = "10%";
                    hcItemSixth.Attributes.Add("class", "gridRows1");
                    //HtmlButton btnDelete = new HtmlButton();
                    ImageButton imgDelete = new ImageButton();
                    imgDelete.Width = new Unit(20);
                    imgDelete.Height = new Unit(20);
                    imgDelete.OnClientClick = "onDeleteSelection" +"('" + ItemId + "','" + ItemName + "','" + ItemDescription + "','" + ItemPrice + "','" + Active + "','" + SubCategoryId + "','" + SubCategoryName + "','" + ItemImagePath + "','" + ItemIsStock + "')";
                    imgDelete.ID = i.ToString(); ;
                    imgDelete.ToolTip = "Delete";
                    imgDelete.ImageUrl = "~/Images/DeleteThird.png";
                    hcItemSixth.Controls.Add(imgDelete);

                    //Button btnDelete = new Button();
                    //btnDelete.ID = i.ToString(); ;
                    //btnDelete.Text = "Delete";
                    //btnDelete.OnClientClick = "onDeleteSelection" + "('" + AFFILIATE_ID + "','" + AFFILIATE_CODE + "','" + AFFILIATE_NAME + "','" + AFFILIATE_ABBR + "')";
                    //hcItemSixth.Controls.Add(btnDelete);
                    // hcItemSixth.InnerText = "Delete";
                    hrItem.Cells.Add(hcItemSixth);
                    htCharges.Rows.Add(hrItem);
                }
            }
            return htCharges;
        }
        catch (Exception ex)
        {
            // string exceptionMessages = GetExceptionMessages(ex);
            return null;
        }

    }


    protected void BindAffiliateCodeData(string ADD, string affiliateId, string affiliateCode, string affiliateName, string affiliateAbberation)
    {
        DataSet dsAffiliateCode = RetrieveAffiliateCodeData(ADD);
        if (dsAffiliateCode != null)
        {
            if (dsAffiliateCode != null && dsAffiliateCode.Tables.Count > 0)
            {
                // DataTable dtAffiliateCode = dsAffiliateCode.Tables[0];
                // ddlAffiliateCode.DataValueField = "Channel_ID";
                //ddlAffiliateCode.DataTextField = "Channel_CODE";
                // ddlAffiliateCode.DataSource = dtAffiliateCode;
                //ddlAffiliateCode.DataBind();

                // pnlAffiliateABB.Controls.Add(DisplayAffiliateAbb(dtAffiliateCode));
            }
        }
        //if (ADD == "EDIT")
        //{
        //    this.txtAFFILIATE_ABBR.Text = affiliateAbberation;
        //    ddlAffiliateCode.SelectedValue = affiliateCode;
        //    ddlAffiliateCode.Enabled = false;
        //}
    }
    protected void BindAffiliateData()
    {
        DataSet dsAffiliate = RetrieveAffiliateData();
        if (dsAffiliate != null && dsAffiliate.Tables.Count > 0)
        {
            DataTable dtAffiliate = dsAffiliate.Tables[0];
            pnlAffiliateABB.Controls.Clear();
            pnlAffiliateABB.Controls.Add(DisplayAffiliateAbb(dtAffiliate));
        }
    }

    protected DataSet RetrieveAffiliateData()
    {
        string connString = ConfigurationManager.AppSettings["ConnectionString"];
        //string sql = @"select AFFILIATE_ID, AFFILIATE_CODE, AFFILIATE_NAME from AFFILIATE";
        //string sql = "select aff.AFFILIATE_ID, aff.AFFILIATE_CODE, aff.AFFILIATE_NAME, affMap.AFFILIATE_ABBR ";
        //sql = sql + " from Affiliate aff LEFT JOIN   Affiliate_code_mapping affMap ";
        //sql = sql + " on  aff.Affiliate_Id = affMap.Affiliate_Id ";

        string sql = "select im.ITEMID, im.ITEMNAME, im.ITEMDESCRIPTION, im.ITEMPRICE, im.active , im.ImagePath,im.IsStock, scm.SubCategoryID, scm.SubCategoryNAME ";
        sql = sql + " from ITEMMASTER  im , SubCategoryMASTER scm where im.SubCategoryID= scm.SubCategoryID";
        //sql = sql + " where   chn.channel_Id = chnMap.channel_Id ";

        DataSet dsAffiliateData = new DataSet();
        OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
        //using (OracleConnection conn = new OracleConnection(connString))
        // {
        myDataConnection.Open();
        using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dsAffiliateData);
        }
        // }
        return dsAffiliateData;
    }

    protected DataSet RetrieveAffiliateCodeData(string mode)
    {
        //string connString = ConfigurationManager.AppSettings["ConnectionString"];
        ////string sql = @"select AFFILIATE_ID, AFFILIATE_CODE, AFFILIATE_NAME from AFFILIATE";
        //string sql = string.Empty;
        //if (mode == "ADD")
        //{
        //    sql = "select chn.CHANNEL_ID, chn.CHANNEL_CODE from CHANNEL chn where chn.CHANNEL_ID NOT IN(  select CHANNEL_ID from CHANNEL_code_mapping)";
        //}
        //else
        //{
        //    sql = "select CHANNEL_ID, CHANNEL_CODE from CHANNEL   ";

        //}
        //DataSet dsAffiliateCodeData = new DataSet();
        //using (OracleConnection conn = new OracleConnection(connString))
        //{
        //    conn.Open();
        //    using (OracleCommand cmd = new OracleCommand(sql, conn))
        //    {
        //        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
        //        adapter.Fill(dsAffiliateCodeData);
        //    }
        //}

        //return dsAffiliateCodeData;
        return null;
    }

    protected void DisplayError(Exception ex)
    {
        //string exceptionMessages = GetExceptionMessages(ex);
        //if (!string.IsNullOrEmpty(exceptionMessages))
        //    this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(exceptionMessages, false);

    }
}
