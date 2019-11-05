using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class Admin_Pages_ManageCategory : System.Web.UI.Page
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

    protected void EditCategory()
    {
        hdnClientHit.Value = string.Empty;
        divAddEdit.Visible = true;
        pnlCategoryABB.Visible = false;
        string categoryId = string.Empty;
        string categoryName = string.Empty;
        string categoryDescription = string.Empty;
        string categoryActive = string.Empty;
        string selectedOptioin = hdnEdit.Value;
        string[] selectedOptions = null;

        try
        {
            if (selectedOptioin != null)
            {
                selectedOptions = selectedOptioin.Split('@');
            }
            if (selectedOptions.Length > 0 && selectedOptions.Length == 4)
            {
                categoryId = selectedOptions[0];
                categoryName = selectedOptions[1];
                categoryDescription = selectedOptions[2];
                categoryActive = selectedOptions[3];
            }

            BindCategoryCodeData("EDIT", string.Empty, string.Empty, string.Empty, string.Empty);
            // DeleteCategoryAbberation(CategoryId);
            this.txtcategoryId.Text = categoryId;
            this.txtcategoryName.Text = categoryName;
            this.txtDescription.Text = categoryDescription;
            //this.txtcategoryActive.Text = categoryActive;
            this.ddlActive.SelectedValue = categoryActive;
            divAddEdit.Visible = true;
            divDeleteConfirmation.Visible = false;
            pnlCategoryABB.Visible = false;
            //ddlCategoryCode.Enabled = false;
        }
        catch (Exception ex)
        {
            BindCategoryData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlCategoryABB.Visible = true;
            // this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.pnlCategoryABB.Visible = true;
        //this.btnAddCategory.Visible = true;
        if (!IsPostBack)
        {
            BindCategoryData();
            EnableAddCategoryAbberationButton();
        }
        else
        {
            if (hdnClientHit.Value == "TRUE")
            {
                string CategoryId = string.Empty;
                string CategoryCode = string.Empty;
                string CategoryName = string.Empty;
                string CategoryAbberation = string.Empty;
                if (hdnOperationMode.Value == "EDIT")
                {
                    this.btnAddCategory.Visible = false;
                    EditCategory();
                }
                if (hdnOperationMode.Value == "DELETE")
                {
                    this.btnAddCategory.Visible = false;
                    divDeleteConfirmation.Visible = true;

                }
            }
        }
        RegisterClientScript();
    }

    private void EnableAddCategoryAbberationButton()
    {
        this.btnAddCategory.Visible = true;
        //DataSet dsCategoryCode = RetrieveCategoryCodeData("ADD");
        //if (dsCategoryCode != null && dsCategoryCode.Tables != null && dsCategoryCode.Tables.Count > 0 && dsCategoryCode.Tables[0].Rows != null && dsCategoryCode.Tables[0].Rows.Count>0)
        ////if (dsCategoryCode == null)
        //{
        //    this.btnAddCategory.Enabled = true;
        //}
        //else
        //{
        //    this.btnAddCategory.Enabled = false;
        //}
    }

    protected void AddCategory(object sender, EventArgs e)
    {
        // ddlCategoryCode.Enabled = true;
        hdnOperationMode.Value = "ADD";
        hdnClientHit.Value = string.Empty;
        divAddEdit.Visible = true;
        divDeleteConfirmation.Visible = false;
        pnlCategoryABB.Visible = false;
        BindCategoryCodeData("ADD", string.Empty, string.Empty, string.Empty, string.Empty);
        // this.txtCategory_ABBR.Text = string.Empty;
        this.btnAddCategory.Visible = false;
    }


    private bool UpdateCategoryAbberation(string categoryId, string categoryName, string categoryDescription, bool categoryActive)
    {
        try
        {
            string sql = @"Update categoryMASTER set categoryName = '" + categoryName + "', categoryDescription = '" + categoryDescription + "', active = " + categoryActive + " where categoryId = " + categoryId + "";
            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //SQL statement to insert new Configuration
            OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
            //using (OracleConnection conn = new OracleConnection(connString))
            //{
            myDataConnection.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
            {
                cmd.ExecuteNonQuery();
                BindCategoryData();
            }
            //}
            return true;
        }
        catch (Exception ex)
        {
            BindCategoryData();
            divAddEdit.Visible = false;
            pnlCategoryABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
            return false;
        }

    }

    private void DeleteCategoryAbberation(string categoryId)
    {
        try
        {
            if (!string.IsNullOrEmpty(categoryId))
            {
                //string connString = ConfigurationManager.AppSettings["ConnectionString"];
                string connString = ConfigurationManager.AppSettings["ConnectionString"];
                string deletesql = @"delete from categoryMaster where categoryId= " + categoryId + "";
                OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
                //using (OracleConnection conn = new OracleConnection(connString))
                //{
                myDataConnection.Open();
                using (OleDbCommand cmd = new OleDbCommand(deletesql, myDataConnection))
                {
                    cmd.ExecuteNonQuery();
                    //BindCategoryData();
                }
                //}
            }
        }
        catch (Exception ex)
        {
            //BindCategoryData();
            //divAddEdit.Visible = false;
            //pnlCategoryABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
            throw ex;
        }
    }

    protected void DeleteSave(object sender, EventArgs e)
    {
        string categoryId = string.Empty;
        string categoryName = string.Empty;
        string categoryDescription = string.Empty;
        string categoryPrice = string.Empty;
        string selectedOptioin = htnDelete.Value;
        string[] selectedOptions = null;

        try
        {
            if (selectedOptioin != null)
            {
                selectedOptions = selectedOptioin.Split('@');
            }
            if (selectedOptions.Length > 0 && selectedOptions.Length == 4)
            {
                categoryId = selectedOptions[0];
                categoryName = selectedOptions[1];
                categoryDescription = selectedOptions[2];
                categoryPrice = selectedOptions[3];
            }
            DeleteCategoryAbberation(categoryId);
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlCategoryABB.Visible = true;
            BindCategoryData();
            EnableAddCategoryAbberationButton();
            hdnOperationMode.Value = string.Empty;
        }
        catch (Exception ex)
        {
            BindCategoryData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlCategoryABB.Visible = true;
            hdnOperationMode.Value = string.Empty;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }

    }
    protected void DeleteCancel(object sender, EventArgs e)
    {
        divAddEdit.Visible = false;
        divDeleteConfirmation.Visible = false;
        pnlCategoryABB.Visible = true;
        BindCategoryData();
        this.btnAddCategory.Visible = true;

    }
    protected void Save(object sender, EventArgs e)
    {
        try
        {
            if (hdnOperationMode.Value == "ADD")
            {
                divAddEdit.Visible = false;
                pnlCategoryABB.Visible = true;
                string categoryName = this.txtcategoryName.Text;
                string categoryDescription = this.txtDescription.Text;
               // string categoryActive = this.txtcategoryActive.Text;
                string categoryActive = this.ddlActive.SelectedValue;
                bool categoryIsActive = false;
                if (categoryActive.ToUpper() == "TRUE")
                {
                    categoryIsActive = true;
                }
                else
                {
                    categoryIsActive = false;
                }
                //string CategoryId = ddlCategoryCode.SelectedValue.ToString();
                //string CategoryAbberation = txtCategory_ABBR.Text;
                if (this.txtcategoryName.Text.Trim() != string.Empty)
                {
                    bool flag = insertCategoryAbberation("0", categoryName, categoryDescription, categoryIsActive);
                    if (flag == true)
                    {
                        BindCategoryData();
                        EnableAddCategoryAbberationButton();
                    }
                }
            }
            if (hdnOperationMode.Value == "EDIT")
            {
                divAddEdit.Visible = false;
                divDeleteConfirmation.Visible = false;
                pnlCategoryABB.Visible = true;
                //string CategoryId = ddlCategoryCode.SelectedValue.ToString();
                //string CategoryAbberation = txtCategory_ABBR.Text;
                string categoryId = this.txtcategoryId.Text;
                string categoryName = this.txtcategoryName.Text;
                string categoryDescription = this.txtDescription.Text;
               // string categoryActive = this.txtcategoryActive.Text;
                string categoryActive = this.ddlActive.SelectedValue;
                bool categoryIsActive = false;
                if (categoryActive.ToUpper() == "TRUE")
                {
                    categoryIsActive = true ;
                }
                else
                {
                    categoryIsActive = false;
                }


                if (this.txtcategoryName.Text.Trim() != string.Empty)
                {
                    bool flag = UpdateCategoryAbberation(categoryId, categoryName, categoryDescription, categoryIsActive);
                    if (flag == true)
                    {
                        BindCategoryData();
                        EnableAddCategoryAbberationButton();
                    }
                }
            }

            hdnOperationMode.Value = string.Empty;
        }
        catch (Exception ex)
        {
            BindCategoryData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlCategoryABB.Visible = true;
            hdnOperationMode.Value = string.Empty;
            // this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }
    }

    private bool insertCategoryAbberation(string categoryID, string categoryNAME, string categoryDESCRIPTION, bool categoryActive)
    {

        if (!string.IsNullOrEmpty(categoryNAME) )
        {
            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //string insertsql = @"Insert into CHANNEL_code_mapping(CHANNEL_code_mapping_id , CHANNEL_ID, CHANNEL_ABBR,  Creation_Date, Last_Update) 
            // values('" + Guid.NewGuid() + "','" + CategoryId + "','" + CategoryAbberation + "', '" + DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + "', '" + DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + "')";
            string insertsql = @"Insert into categoryMASTER(categoryNAME , categoryDESCRIPTION, active)  values('" + categoryNAME + "','" + categoryDESCRIPTION + "', " + categoryActive + ")";
            OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
            myDataConnection.Open();
            using (OleDbCommand cmd = new OleDbCommand(insertsql, myDataConnection))
            {
                cmd.ExecuteNonQuery();
                return true;
            }
        }
        else
        {
            BindCategoryData();
            divAddEdit.Visible = false;
            pnlCategoryABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog("Please enter Channel Id /Channel Abberation.", false);
            return false;
        }
    }


    protected void Cancel(object sender, EventArgs e)
    {
        divAddEdit.Visible = false;
        pnlCategoryABB.Visible = true;
        divDeleteConfirmation.Visible = false;
        BindCategoryData();
        this.btnAddCategory.Visible = true;
    }



    private HtmlTable DisplayCategoryAbb(DataTable dtAffilateAbb)
    {
        try
        {
            HtmlTable htCharges = new HtmlTable();
            htCharges.CellPadding = 0;
            htCharges.CellSpacing = 0;
            htCharges.Width = "100%";

            HtmlTableRow hrcategoryHeader = new HtmlTableRow();
            HtmlTableCell hccategoryHeaderFirst = new HtmlTableCell();
            hccategoryHeaderFirst.Visible = false;
            hccategoryHeaderFirst.Width = "50%";
            hccategoryHeaderFirst.Attributes.Add("class", "gridHeader");
            hccategoryHeaderFirst.InnerText = "category ID";
            hrcategoryHeader.Cells.Add(hccategoryHeaderFirst);

            HtmlTableCell hccategoryHeaderSecond = new HtmlTableCell();
            hccategoryHeaderSecond.Width = "25%";
            hccategoryHeaderSecond.Attributes.Add("class", "gridHeader");
            hccategoryHeaderSecond.InnerText = "category Name";
            hrcategoryHeader.Cells.Add(hccategoryHeaderSecond);
            HtmlTableCell hccategoryHeaderThird = new HtmlTableCell();
            hccategoryHeaderThird.Width = "25%";
            hccategoryHeaderThird.Attributes.Add("class", "gridHeader");
            hccategoryHeaderThird.InnerText = "category Description";
            hrcategoryHeader.Cells.Add(hccategoryHeaderThird);
            //htCharges.Rows.Add(hrcategoryHeader);


            HtmlTableCell hccategoryHeaderForth = new HtmlTableCell();
            hccategoryHeaderForth.Width = "25%";
            hccategoryHeaderForth.Attributes.Add("class", "gridHeader");
            hccategoryHeaderForth.InnerText = "Active";
            hrcategoryHeader.Cells.Add(hccategoryHeaderForth);
            //htCharges.Rows.Add(hrcategoryHeader);

            HtmlTableCell hccategoryHeaderFifth = new HtmlTableCell();
            hccategoryHeaderFifth.Width = "25%";
            hccategoryHeaderFifth.Attributes.Add("class", "gridHeader");
            hccategoryHeaderFifth.InnerText = "Action";
            hrcategoryHeader.Cells.Add(hccategoryHeaderFifth);
            // htCharges.Rows.Add(hrcategoryHeader);

            HtmlTableCell hccategoryHeaderSixth = new HtmlTableCell();
            hccategoryHeaderSixth.Width = "25%";
            hccategoryHeaderSixth.Attributes.Add("class", "gridHeader");
            hccategoryHeaderSixth.InnerText = "Action";
            hrcategoryHeader.Cells.Add(hccategoryHeaderSixth);
            htCharges.Rows.Add(hrcategoryHeader);

            if (dtAffilateAbb != null && dtAffilateAbb.Rows.Count > 0)
            {
                for (int i = 0; i < dtAffilateAbb.Rows.Count; i++)
                {
                    HtmlTableRow hrcategory = new HtmlTableRow();
                    DataRow dr = dtAffilateAbb.Rows[i];
                    string categoryId = dr["categoryId"].ToString();
                    string categoryName = dr["categoryName"].ToString();
                    string categoryDescription = dr["categoryDescription"].ToString();
                    string categoryActive = dr["Active"].ToString();

                    HtmlTableCell hccategoryFirst = new HtmlTableCell();
                    hccategoryFirst.Width = "5%";
                    hccategoryFirst.Attributes.Add("class", "gridRows1");
                    hccategoryFirst.InnerText = categoryId;
                    hccategoryFirst.Visible = false;
                    hrcategory.Cells.Add(hccategoryFirst);

                    HtmlTableCell hccategorySecond = new HtmlTableCell();
                    hccategorySecond.Width = "30%";
                    hccategorySecond.Attributes.Add("class", "gridRows1");
                    hccategorySecond.InnerText = categoryName;
                    hccategorySecond.InnerHtml = "<span style=\"color:black;\"><b>" + categoryName + "</b></span>";
                    hccategorySecond.BgColor = "#EDEDEC";
                    hrcategory.Cells.Add(hccategorySecond);
                    HtmlTableCell hccategoryThird = new HtmlTableCell();
                    hccategoryThird.Width = "30%";
                    hccategoryThird.Attributes.Add("class", "gridRows1");
                    hccategoryThird.InnerText = categoryDescription;
                    // hccategoryThird.BgColor = "#DCDCDC";
                    hrcategory.Cells.Add(hccategoryThird);
                    //htCharges.Rows.Add(hrcategory);

                    HtmlTableCell hccategoryForth = new HtmlTableCell();
                    hccategoryForth.Width = "15%";
                    hccategoryForth.Attributes.Add("class", "gridRows1");
                    hccategoryForth.InnerText = categoryActive;
                    hccategoryForth.Align = HorizontalAlign.Center.ToString();
                    hrcategory.Cells.Add(hccategoryForth);
                    // htCharges.Rows.Add(hrcategoryHeader);

                    HtmlTableCell hccategoryFifth = new HtmlTableCell();
                    hccategoryFifth.Width = "10%";
                    hccategoryFifth.Attributes.Add("class", "gridRows1");
                    hccategoryFifth.Align = HorizontalAlign.Center.ToString();
                    ImageButton imgEdit = new ImageButton();

                    imgEdit.OnClientClick = "onEditSelection" + "('" + categoryId + "','" + categoryName + "','" + categoryDescription + "','" + categoryActive + "')";
                    imgEdit.Width = new Unit(20);
                    imgEdit.Height = new Unit(20);
                    imgEdit.ID = i.ToString(); ;
                    imgEdit.ToolTip = "Edit";
                    imgEdit.ImageUrl = "~/Images/EditThird.png";
                    hccategoryFifth.Controls.Add(imgEdit);
                    //Button btnEdit = new Button();
                    //btnEdit.OnClientClick = "onEditSelection" + "('" + categoryId + "','" + Category_CODE + "','" + Category_NAME + "','" + Category_ABBR + "')";
                    //btnEdit.ID = i.ToString(); ;
                    //btnEdit.Text = "Edit";
                    //hccategoryFifth.Controls.Add(btnEdit);
                    hrcategory.Cells.Add(hccategoryFifth);
                    //htCharges.Rows.Add(hrcategoryHeader);

                    HtmlTableCell hccategorySixth = new HtmlTableCell();
                    hccategorySixth.Align = HorizontalAlign.Center.ToString();
                    hccategorySixth.Width = "10%";
                    hccategorySixth.Attributes.Add("class", "gridRows1");
                    //HtmlButton btnDelete = new HtmlButton();
                    ImageButton imgDelete = new ImageButton();
                    imgDelete.Width = new Unit(20);
                    imgDelete.Height = new Unit(20);
                    imgDelete.OnClientClick = "onDeleteSelection" + "('" + categoryId + "','" + categoryName + "','" + categoryDescription + "','" + categoryActive + "')";
                    imgDelete.ID = i.ToString(); ;
                    imgDelete.ToolTip = "Delete";
                    imgDelete.ImageUrl = "~/Images/DeleteThird.png";
                    hccategorySixth.Controls.Add(imgDelete);

                    //Button btnDelete = new Button();
                    //btnDelete.ID = i.ToString(); ;
                    //btnDelete.Text = "Delete";
                    //btnDelete.OnClientClick = "onDeleteSelection" + "('" + Category_ID + "','" + Category_CODE + "','" + Category_NAME + "','" + Category_ABBR + "')";
                    //hccategorySixth.Controls.Add(btnDelete);

                    // hccategorySixth.InnerText = "Delete";
                    hrcategory.Cells.Add(hccategorySixth);
                    htCharges.Rows.Add(hrcategory);

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


    protected void BindCategoryCodeData(string ADD, string CategoryId, string CategoryCode, string CategoryName, string CategoryAbberation)
    {
        DataSet dsCategoryCode = RetrieveCategoryCodeData(ADD);
        if (dsCategoryCode != null)
        {
            if (dsCategoryCode != null && dsCategoryCode.Tables.Count > 0)
            {
                // DataTable dtCategoryCode = dsCategoryCode.Tables[0];
                // ddlCategoryCode.DataValueField = "Channel_ID";
                //ddlCategoryCode.DataTextField = "Channel_CODE";
                // ddlCategoryCode.DataSource = dtCategoryCode;
                //ddlCategoryCode.DataBind();

                // pnlCategoryABB.Controls.Add(DisplayCategoryAbb(dtCategoryCode));
            }
        }
        //if (ADD == "EDIT")
        //{
        //    this.txtCategory_ABBR.Text = CategoryAbberation;
        //    ddlCategoryCode.SelectedValue = CategoryCode;
        //    ddlCategoryCode.Enabled = false;
        //}
    }
    protected void BindCategoryData()
    {
        DataSet dsCategory = RetrieveCategoryData();
        if (dsCategory != null && dsCategory.Tables.Count > 0)
        {
            DataTable dtCategory = dsCategory.Tables[0];
            pnlCategoryABB.Controls.Clear();
            pnlCategoryABB.Controls.Add(DisplayCategoryAbb(dtCategory));
        }
    }

    protected DataSet RetrieveCategoryData()
    {
        string connString = ConfigurationManager.AppSettings["ConnectionString"];
        //string sql = @"select Category_ID, Category_CODE, Category_NAME from Category";
        //string sql = "select aff.Category_ID, aff.Category_CODE, aff.Category_NAME, affMap.Category_ABBR ";
        //sql = sql + " from Category aff LEFT JOIN   Category_code_mapping affMap ";
        //sql = sql + " on  aff.Category_Id = affMap.Category_Id ";
        string sql = "select categoryID, categoryNAME, categoryDESCRIPTION, active  ";
        sql = sql + " from categoryMASTER ";
        //sql = sql + " where   chn.channel_Id = chnMap.channel_Id ";
        DataSet dsCategoryData = new DataSet();
        OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
        //using (OracleConnection conn = new OracleConnection(connString))
        // {
        myDataConnection.Open();
        using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dsCategoryData);
        }
        // }
        return dsCategoryData;
    }

    protected DataSet RetrieveCategoryCodeData(string mode)
    {
        //string connString = ConfigurationManager.AppSettings["ConnectionString"];
        ////string sql = @"select Category_ID, Category_CODE, Category_NAME from Category";
        //string sql = string.Empty;
        //if (mode == "ADD")
        //{
        //    sql = "select chn.CHANNEL_ID, chn.CHANNEL_CODE from CHANNEL chn where chn.CHANNEL_ID NOT IN(  select CHANNEL_ID from CHANNEL_code_mapping)";
        //}
        //else
        //{
        //    sql = "select CHANNEL_ID, CHANNEL_CODE from CHANNEL   ";

        //}
        //DataSet dsCategoryCodeData = new DataSet();
        //using (OracleConnection conn = new OracleConnection(connString))
        //{
        //    conn.Open();
        //    using (OracleCommand cmd = new OracleCommand(sql, conn))
        //    {
        //        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
        //        adapter.Fill(dsCategoryCodeData);
        //    }
        //}
        //return dsCategoryCodeData;
        return null;
    }

    protected void DisplayError(Exception ex)
    {
        //string exceptionMessages = GetExceptionMessages(ex);
        //if (!string.IsNullOrEmpty(exceptionMessages))
        //    this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(exceptionMessages, false);

    }
}
