using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class Admin_Pages_ManageSubCategory : System.Web.UI.Page
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

    protected void EditSubCategory()
    {
        hdnClientHit.Value = string.Empty;
        divAddEdit.Visible = true;
        pnlSubCategoryABB.Visible = false;
        string SubCategoryId = string.Empty;
        string SubCategoryName = string.Empty;
        string SubCategoryDescription = string.Empty;
        string SubCategoryActive = string.Empty;
        string CategoryId = string.Empty;
        string CatergoryName = string.Empty;
        string selectedOptioin = hdnEdit.Value;
        string CategoryImagePath = string.Empty;
        string[] selectedOptions = null;

        try
        {
            if (selectedOptioin != null)
            {
                selectedOptions = selectedOptioin.Split('@');
            }
            if (selectedOptions.Length > 0 && selectedOptions.Length == 7)
            {
                SubCategoryId = selectedOptions[0];
                SubCategoryName = selectedOptions[1];
                SubCategoryDescription = selectedOptions[2];
                SubCategoryActive = selectedOptions[3];

                CategoryId = selectedOptions[4];

                CatergoryName = selectedOptions[5];
                CategoryImagePath = selectedOptions[6];
            }

            //BindSubCategoryCodeData("EDIT", string.Empty, string.Empty, string.Empty, string.Empty);
            // DeleteSubCategoryAbberation(SubCategoryId);
            this.txtSubCategoryId.Text = SubCategoryId;
            this.txtSubCategoryName.Text = SubCategoryName;
            this.txtDescription.Text = SubCategoryDescription;
           // this.txtSubCategoryPrice.Text = SubCategoryPrice;
            this.ddlActive.SelectedValue = SubCategoryActive;
            this.txtCategoryId.Text = CategoryId;
            this.ddlCategory.SelectedValue = CategoryId;
            divAddEdit.Visible = true;
            divDeleteConfirmation.Visible = false;
            pnlSubCategoryABB.Visible = false;
            //ddlSubCategoryCode.Enabled = false;
            imgSubCategory.ImageUrl = "~/images/subcategory/" + CategoryImagePath;
            imgSubCategory.Width = Unit.Pixel(150);
            imgSubCategory.Height = Unit.Pixel(150);
        }
        catch (Exception ex)
        {
            BindSubCategoryData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlSubCategoryABB.Visible = true;
            // this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }


    }


    private void BindCategoryData()
    {
        DataSet dsCategory = RetrieveCategoryData();
        if (dsCategory != null)
        {
            if (dsCategory != null && dsCategory.Tables.Count > 0)
            {
                DataTable dtCategory = dsCategory.Tables[0];
                ddlCategory.DataValueField = "CategoryId";
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataSource = dtCategory;
                ddlCategory.DataBind();

            }
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
       
        this.pnlSubCategoryABB.Visible = true;
        //this.btnAddSubCategory.Visible = true;
        if (!IsPostBack)
        {
            BindSubCategoryData();
            BindCategoryData();
            
            EnableAddSubCategoryAbberationButton();
        }
        else
        {
            if (hdnClientHit.Value == "TRUE")
            {
                string SubCategoryId = string.Empty;
                string SubCategoryCode = string.Empty;
                string SubCategoryName = string.Empty;
                string SubCategoryAbberation = string.Empty;
                if (hdnOperationMode.Value == "EDIT")
                {
                    this.btnAddSubCategory.Visible = false;
                    EditSubCategory();
                }
                if (hdnOperationMode.Value == "DELETE")
                {
                    this.btnAddSubCategory.Visible = false;
                    divDeleteConfirmation.Visible = true;

                }
            }
            //else
            //{
            //    BindSubCategoryData();
            //    EnableAddSubCategoryAbberationButton();
            //}
        }
        RegisterClientScript();
    }

    private void EnableAddSubCategoryAbberationButton()
    {
        this.btnAddSubCategory.Visible = true;
        //DataSet dsSubCategoryCode = RetrieveSubCategoryCodeData("ADD");
        //if (dsSubCategoryCode != null && dsSubCategoryCode.Tables != null && dsSubCategoryCode.Tables.Count > 0 && dsSubCategoryCode.Tables[0].Rows != null && dsSubCategoryCode.Tables[0].Rows.Count>0)
        ////if (dsSubCategoryCode == null)
        //{
        //    this.btnAddSubCategory.Enabled = true;
        //}
        //else
        //{
        //    this.btnAddSubCategory.Enabled = false;
        //}
    }

    protected void AddSubCategory(object sender, EventArgs e)
    {
        // ddlSubCategoryCode.Enabled = true;
        hdnOperationMode.Value = "ADD";
        hdnClientHit.Value = string.Empty;
        divAddEdit.Visible = true;
        divDeleteConfirmation.Visible = false;
        pnlSubCategoryABB.Visible = false;
        //BindSubCategoryCodeData("ADD", string.Empty, string.Empty, string.Empty, string.Empty);
        // this.txtSubCategory_ABBR.Text = string.Empty;
        this.btnAddSubCategory.Visible = false;
    }


    private bool UpdateSubCategoryAbberation(string SubCategoryId, string SubCategoryName, string SubCategoryDescription, string SubCategoryActive, string categoryId, string SubCateoryImagePath)
    {
        try
        {
            string sql = @"Update SubCategoryMASTER set SubCategoryName = '" + SubCategoryName + "', ImagePath = '" + SubCateoryImagePath + "', SubCategoryDescription = '" + SubCategoryDescription + "', categoryId = " + Convert.ToInt16(categoryId) + ", Active = " + SubCategoryActive + " where SubCategoryId = " + SubCategoryId + "";

            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //SQL statement to insert new Configuration
            OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
            //using (OracleConnection conn = new OracleConnection(connString))
            //{
            myDataConnection.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
            {
                cmd.ExecuteNonQuery();
                //BindSubCategoryData();
            }
            //}
            return true;
        }
        catch (Exception ex)
        {
            //BindSubCategoryData();
            divAddEdit.Visible = false;
            pnlSubCategoryABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
            return false;
        }

    }

    private void DeleteSubCategoryAbberation(string SubCategoryId)
    {
        try
        {
            if (!string.IsNullOrEmpty(SubCategoryId))
            {
                //string connString = ConfigurationManager.AppSettings["ConnectionString"];
                string connString = ConfigurationManager.AppSettings["ConnectionString"];
                string deletesql = @"delete from SubCategoryMaster where SubCategoryId= " + SubCategoryId + "";
                OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
                //using (OracleConnection conn = new OracleConnection(connString))
                //{
                myDataConnection.Open();
                using (OleDbCommand cmd = new OleDbCommand(deletesql, myDataConnection))
                {
                    cmd.ExecuteNonQuery();
                    //BindSubCategoryData();
                }
                //}
            }
        }
        catch (Exception ex)
        {
            //BindSubCategoryData();
            //divAddEdit.Visible = false;
            //pnlSubCategoryABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
            throw ex;
        }
    }

    protected void DeleteSave(object sender, EventArgs e)
    {
        string SubCategoryId = string.Empty;
        string SubCategoryName = string.Empty;
        string SubCategoryDescription = string.Empty;
        string SubCategoryPrice = string.Empty;
        string selectedOptioin = htnDelete.Value;
        string[] selectedOptions = null;
        try
        {
            if (selectedOptioin != null)
            {
                selectedOptions = selectedOptioin.Split('@');
            }
            if (selectedOptions.Length > 0 && selectedOptions.Length == 7)
            {
                SubCategoryId = selectedOptions[0];
                SubCategoryName = selectedOptions[1];
                SubCategoryDescription = selectedOptions[2];
                SubCategoryPrice = selectedOptions[3];
            }
            DeleteSubCategoryAbberation(SubCategoryId);
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlSubCategoryABB.Visible = true;
            BindSubCategoryData();
            EnableAddSubCategoryAbberationButton();
            hdnOperationMode.Value = string.Empty;
        }
        catch (Exception ex)
        {
            BindSubCategoryData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlSubCategoryABB.Visible = true;
            hdnOperationMode.Value = string.Empty;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }

    }
    protected void DeleteCancel(object sender, EventArgs e)
    {
        divAddEdit.Visible = false;
        divDeleteConfirmation.Visible = false;
        pnlSubCategoryABB.Visible = true;
        BindSubCategoryData();
        this.btnAddSubCategory.Visible = true;

    }
    protected void Save(object sender, EventArgs e)
    {
        try
        {
            if (hdnOperationMode.Value == "ADD")
            {
                divAddEdit.Visible = false;
                pnlSubCategoryABB.Visible = true;
                string SubCategoryName = this.txtSubCategoryName.Text;
                string SubCategoryDescription = this.txtDescription.Text;
                //string SubCategoryPrice = this.txtSubCategoryPrice.Text;
                string categoryActive = this.ddlActive.SelectedValue;
                string CatergoryId = this.ddlCategory.SelectedValue;
                //string SubCateoryImagePath = fileSubCategoryImagegPath.PostedFile.FileName;
                 //string SubCateoryImagePath=txtSubCategoryImagegPath.Text;
                 string SubCateoryImagePath = string.Empty;
                 if (fileSubCategoryImagegPath.PostedFile.FileName == string.Empty)
                 {
                     SubCateoryImagePath = txtSubCategoryImagegPath.Text;
                 }
                 else
                 {
                     SubCateoryImagePath = fileSubCategoryImagegPath.PostedFile.FileName;
                 }

                bool categoryIsActive = false;
                if (categoryActive.ToUpper() == "TRUE")
                {
                    categoryIsActive = true;
                }
                else
                {
                    categoryIsActive = false;
                }
                //string SubCategoryId = ddlSubCategoryCode.SelectedValue.ToString();
                //string SubCategoryAbberation = txtSubCategory_ABBR.Text;
                if (this.txtSubCategoryName.Text.Trim() != string.Empty)
                {

                    if (fileSubCategoryImagegPath.PostedFile.FileName != string.Empty)
                    {
                        string fn = System.IO.Path.GetFileName(fileSubCategoryImagegPath.PostedFile.FileName);
                        SubCateoryImagePath = fn;
                        string SaveLocation = Request.MapPath("~/images/subCategory/") + fn;
                        try
                        {

                            fileSubCategoryImagegPath.PostedFile.SaveAs(SaveLocation);
                           // Response.Write("The file has been uploaded.");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

                    bool flag = insertSubCategoryAbberation("0", SubCategoryName, SubCategoryDescription, categoryActive, CatergoryId, SubCateoryImagePath);
                    if (flag == true)
                    {
                        //Response.Redirect(Request.Url.ToString());
                        BindSubCategoryData();
                        EnableAddSubCategoryAbberationButton();
                    }
                }
            }
            if (hdnOperationMode.Value == "EDIT")
            {
                divAddEdit.Visible = false;
                divDeleteConfirmation.Visible = false;
                pnlSubCategoryABB.Visible = true;
                //string SubCategoryId = ddlSubCategoryCode.SelectedValue.ToString();
                //string SubCategoryAbberation = txtSubCategory_ABBR.Text;
                string SubCategoryId = this.txtSubCategoryId.Text;
                string SubCategoryName = this.txtSubCategoryName.Text;
                string SubCategoryDescription = this.txtDescription.Text;
                //string SubCategoryPrice = this.txtSubCategoryPrice.Text;
                string categoryActive = this.ddlActive.SelectedValue;
                string CatergoryId = this.ddlCategory.SelectedValue;
                //string SubCateoryImagePath = fileSubCategoryImagegPath.PostedFile.FileName;

                string SubCateoryImagePath = string.Empty;
                if (fileSubCategoryImagegPath.PostedFile.FileName == string.Empty)
                {
                    SubCateoryImagePath = txtSubCategoryImagegPath.Text;
                }
                else
                {
                    SubCateoryImagePath = fileSubCategoryImagegPath.PostedFile.FileName;
                }

                bool categoryIsActive = false;
                if (categoryActive.ToUpper() == "TRUE")
                {
                    categoryIsActive = true;
                }
                else
                {
                    categoryIsActive = false;
                }
                if (this.txtSubCategoryName.Text.Trim() != string.Empty)
                {
                    if (fileSubCategoryImagegPath.PostedFile.FileName != string.Empty)
                    {
                        string fn = System.IO.Path.GetFileName(fileSubCategoryImagegPath.PostedFile.FileName);
                        SubCateoryImagePath = fn;
                        string SaveLocation = Request.MapPath("~/images/subCategory/") + fn;
                        try
                        {

                            fileSubCategoryImagegPath.PostedFile.SaveAs(SaveLocation);
                            // Response.Write("The file has been uploaded.");
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    bool flag = UpdateSubCategoryAbberation(SubCategoryId, SubCategoryName, SubCategoryDescription, categoryActive, CatergoryId, SubCateoryImagePath);
                    if (flag == true)
                    {
                        Response.Redirect(Request.Url.ToString());
                        //BindSubCategoryData();
                        //EnableAddSubCategoryAbberationButton();
                    }
                }
            }
            hdnOperationMode.Value = string.Empty;

        }
        catch (Exception ex)
        {
            BindSubCategoryData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlSubCategoryABB.Visible = true;
            hdnOperationMode.Value = string.Empty;
            // this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }



    }

    private bool insertSubCategoryAbberation(string SubCategoryID, string SubCategoryNAME, string SubCategoryDESCRIPTION, string SubCategoryActive, string categoryId, string SubCateoryImagePath)
    {
        if (!string.IsNullOrEmpty(SubCategoryNAME) )
        {
            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //string insertsql = @"Insert into CHANNEL_code_mapping(CHANNEL_code_mapping_id , CHANNEL_ID, CHANNEL_ABBR,  Creation_Date, Last_Update) 
            // values('" + Guid.NewGuid() + "','" + SubCategoryId + "','" + SubCategoryAbberation + "', '" + DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + "', '" + DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + "')";
            string insertsql = @"Insert into SubCategoryMASTER(SubCategoryNAME , SubCategoryDESCRIPTION,ImagePath,categoryID, active)  values('" + SubCategoryNAME + "','" + SubCategoryDESCRIPTION + "','" + SubCateoryImagePath + "'," + Convert.ToInt16(categoryId) + ", " + SubCategoryActive + ")";
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
            //BindSubCategoryData();
            divAddEdit.Visible = false;
            pnlSubCategoryABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog("Please enter Channel Id /Channel Abberation.", false);
            return false;
        }
    }


    protected void Cancel(object sender, EventArgs e)
    {
        divAddEdit.Visible = false;
        pnlSubCategoryABB.Visible = true;
        divDeleteConfirmation.Visible = false;
        BindSubCategoryData();
        this.btnAddSubCategory.Visible = true;
    }



    private HtmlTable DisplaySubCategoryAbb(DataTable dtAffilateAbb)
    {
        try
        {
            HtmlTable htCharges = new HtmlTable();
            htCharges.CellPadding = 0;
            htCharges.CellSpacing = 0;
            htCharges.Width = "100%";

            HtmlTableRow hrSubCategoryHeader = new HtmlTableRow();
            HtmlTableCell hcSubCategoryHeaderFirst = new HtmlTableCell();
            hcSubCategoryHeaderFirst.Visible = false;
            hcSubCategoryHeaderFirst.Width = "50%";
            hcSubCategoryHeaderFirst.Attributes.Add("class", "gridHeader");
            hcSubCategoryHeaderFirst.InnerText = "SubCategory ID";
            hrSubCategoryHeader.Cells.Add(hcSubCategoryHeaderFirst);

            HtmlTableCell hcSubCategoryHeaderSecond = new HtmlTableCell();
            hcSubCategoryHeaderSecond.Width = "25%";
            hcSubCategoryHeaderSecond.Attributes.Add("class", "gridHeader");
            hcSubCategoryHeaderSecond.InnerText = "SubCategory Name";
            hrSubCategoryHeader.Cells.Add(hcSubCategoryHeaderSecond);
            HtmlTableCell hcSubCategoryHeaderThird = new HtmlTableCell();
            hcSubCategoryHeaderThird.Width = "25%";
            hcSubCategoryHeaderThird.Attributes.Add("class", "gridHeader");
            hcSubCategoryHeaderThird.InnerText = "SubCategory Description";
            hrSubCategoryHeader.Cells.Add(hcSubCategoryHeaderThird);
            //htCharges.Rows.Add(hrSubCategoryHeader);

            HtmlTableCell hcSubCategoryHeaderForth = new HtmlTableCell();
            hcSubCategoryHeaderForth.Width = "25%";
            hcSubCategoryHeaderForth.Attributes.Add("class", "gridHeader");
            hcSubCategoryHeaderForth.InnerText = "Active";
            hrSubCategoryHeader.Cells.Add(hcSubCategoryHeaderForth);


            HtmlTableCell hcSubCategoryHeaderForth0 = new HtmlTableCell();
            hcSubCategoryHeaderForth0.Width = "25%";
            hcSubCategoryHeaderForth0.Attributes.Add("class", "gridHeader");
            hcSubCategoryHeaderForth0.InnerText = "Category Id";
            hcSubCategoryHeaderForth0.Visible = false;
            hrSubCategoryHeader.Cells.Add(hcSubCategoryHeaderForth0);


            HtmlTableCell hcSubCategoryHeaderForth1 = new HtmlTableCell();
            hcSubCategoryHeaderForth1.Width = "25%";
            hcSubCategoryHeaderForth1.Attributes.Add("class", "gridHeader");
            hcSubCategoryHeaderForth1.InnerText = "Category Name";
            hrSubCategoryHeader.Cells.Add(hcSubCategoryHeaderForth1);
            //htCharges.Rows.Add(hrSubCategoryHeader);

            HtmlTableCell hcSubCategoryHeaderFifth = new HtmlTableCell();
            hcSubCategoryHeaderFifth.Width = "25%";
            hcSubCategoryHeaderFifth.Attributes.Add("class", "gridHeader");
            hcSubCategoryHeaderFifth.InnerText = "Action";
            hrSubCategoryHeader.Cells.Add(hcSubCategoryHeaderFifth);
            // htCharges.Rows.Add(hrSubCategoryHeader);

            HtmlTableCell hcSubCategoryHeaderSixth = new HtmlTableCell();
            hcSubCategoryHeaderSixth.Width = "25%";
            hcSubCategoryHeaderSixth.Attributes.Add("class", "gridHeader");
            hcSubCategoryHeaderSixth.InnerText = "Action";
            hrSubCategoryHeader.Cells.Add(hcSubCategoryHeaderSixth);
            htCharges.Rows.Add(hrSubCategoryHeader);

            if (dtAffilateAbb != null && dtAffilateAbb.Rows.Count > 0)
            {
                for (int i = 0; i < dtAffilateAbb.Rows.Count; i++)
                {
                    HtmlTableRow hrSubCategory = new HtmlTableRow();
                    DataRow dr = dtAffilateAbb.Rows[i];
                    string SubCategoryId = dr["SubCategoryId"].ToString();
                    string SubCategoryName = dr["SubCategoryName"].ToString();
                    string SubCategoryDescription = dr["SubCategoryDescription"].ToString();
                    string SubCategoryActive = dr["active"].ToString();
                    string CategoryName = dr["CategoryName"].ToString();
                    string CategoryId = dr["CategoryId"].ToString();
                    string CategoryImagePath = dr["ImagePath"].ToString();




                    HtmlTableCell hcSubCategoryFirst = new HtmlTableCell();
                    hcSubCategoryFirst.Width = "5%";
                    hcSubCategoryFirst.Attributes.Add("class", "gridRows1");
                    hcSubCategoryFirst.InnerText = SubCategoryId;
                    hcSubCategoryFirst.Visible = false;
                    hrSubCategory.Cells.Add(hcSubCategoryFirst);

                    HtmlTableCell hcSubCategorySecond = new HtmlTableCell();
                    hcSubCategorySecond.Width = "30%";
                    hcSubCategorySecond.Attributes.Add("class", "gridRows1");
                    hcSubCategorySecond.InnerText = SubCategoryName;
                    hcSubCategorySecond.InnerHtml = "<span style=\"color:black;\"><b>" + SubCategoryName + "</b></span>";
                    hcSubCategorySecond.BgColor = "#EDEDEC";
                    hrSubCategory.Cells.Add(hcSubCategorySecond);
                    HtmlTableCell hcSubCategoryThird = new HtmlTableCell();
                    hcSubCategoryThird.Width = "30%";
                    hcSubCategoryThird.Attributes.Add("class", "gridRows1");
                    hcSubCategoryThird.InnerText = SubCategoryDescription;
                    // hcSubCategoryThird.BgColor = "#DCDCDC";
                    hrSubCategory.Cells.Add(hcSubCategoryThird);
                    //htCharges.Rows.Add(hrSubCategory);


                    HtmlTableCell hcSubCategoryForth = new HtmlTableCell();
                    hcSubCategoryForth.Width = "15%";
                    hcSubCategoryForth.Attributes.Add("class", "gridRows1");
                    hcSubCategoryForth.InnerText = SubCategoryActive;
                    hcSubCategoryForth.Align = HorizontalAlign.Center.ToString();
                    hrSubCategory.Cells.Add(hcSubCategoryForth);
                    // htCharges.Rows.Add(hrSubCategoryHeader);

                    

                    HtmlTableCell hcSubCategoryForth0 = new HtmlTableCell();
                    hcSubCategoryForth0.Width = "15%";
                    hcSubCategoryForth0.Attributes.Add("class", "gridRows1");
                    hcSubCategoryForth0.InnerText = CategoryId;
                    hcSubCategoryForth0.Align = HorizontalAlign.Center.ToString();
                    hcSubCategoryForth0.Visible = false;
                    hrSubCategory.Cells.Add(hcSubCategoryForth0);



                     HtmlTableCell hcSubCategoryForth1 = new HtmlTableCell();
                    hcSubCategoryForth1.Width = "15%";
                    hcSubCategoryForth1.Attributes.Add("class", "gridRows1");
                    hcSubCategoryForth1.InnerText = CategoryName;
                    hcSubCategoryForth1.Align = HorizontalAlign.Center.ToString();
                    hrSubCategory.Cells.Add(hcSubCategoryForth1);
                    // htCharges.Rows.Add(hrSubCategoryHeader);

                    HtmlTableCell hcSubCategoryFifth = new HtmlTableCell();
                    hcSubCategoryFifth.Width = "10%";
                    hcSubCategoryFifth.Attributes.Add("class", "gridRows1");
                    hcSubCategoryFifth.Align = HorizontalAlign.Center.ToString();
                    ImageButton imgEdit = new ImageButton();

                    imgEdit.OnClientClick = "onEditSelection" + "('" + SubCategoryId + "','" + SubCategoryName + "','" + SubCategoryDescription + "','" + SubCategoryActive + "','" + CategoryId + "','" + CategoryName + "','" + CategoryImagePath + "')";
                    imgEdit.Width = new Unit(20);
                    imgEdit.Height = new Unit(20);
                    imgEdit.ID = i.ToString(); ;
                    imgEdit.ToolTip = "Edit";
                    imgEdit.ImageUrl = "~/Images/EditThird.png";
                    hcSubCategoryFifth.Controls.Add(imgEdit);
                    //Button btnEdit = new Button();
                    //btnEdit.OnClientClick = "onEditSelection" + "('" + SubCategoryId + "','" + SubCategory_CODE + "','" + SubCategory_NAME + "','" + SubCategory_ABBR + "')";
                    //btnEdit.ID = i.ToString(); ;
                    //btnEdit.Text = "Edit";
                    //hcSubCategoryFifth.Controls.Add(btnEdit);
                    hrSubCategory.Cells.Add(hcSubCategoryFifth);
                    //htCharges.Rows.Add(hrSubCategoryHeader);

                    HtmlTableCell hcSubCategorySixth = new HtmlTableCell();
                    hcSubCategorySixth.Align = HorizontalAlign.Center.ToString();
                    hcSubCategorySixth.Width = "10%";
                    hcSubCategorySixth.Attributes.Add("class", "gridRows1");
                    //HtmlButton btnDelete = new HtmlButton();
                    ImageButton imgDelete = new ImageButton();
                    imgDelete.Width = new Unit(20);
                    imgDelete.Height = new Unit(20);
                    imgDelete.OnClientClick = "onDeleteSelection" + "('" + SubCategoryId + "','" + SubCategoryName + "','" + SubCategoryDescription + "','" + SubCategoryActive + "','" + CategoryId + "','" + CategoryName + "','" + CategoryImagePath + "')";
                    imgDelete.ID = i.ToString(); ;
                    imgDelete.ToolTip = "Delete";
                    imgDelete.ImageUrl = "~/Images/DeleteThird.png";
                    hcSubCategorySixth.Controls.Add(imgDelete);

                    //Button btnDelete = new Button();
                    //btnDelete.ID = i.ToString(); ;
                    //btnDelete.Text = "Delete";
                    //btnDelete.OnClientClick = "onDeleteSelection" + "('" + SubCategory_ID + "','" + SubCategory_CODE + "','" + SubCategory_NAME + "','" + SubCategory_ABBR + "')";
                    //hcSubCategorySixth.Controls.Add(btnDelete);
                    // hcSubCategorySixth.InnerText = "Delete";
                    hrSubCategory.Cells.Add(hcSubCategorySixth);
                    htCharges.Rows.Add(hrSubCategory);
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


    //protected void BindSubCategoryCodeData(string ADD, string SubCategoryId, string SubCategoryCode, string SubCategoryName, string SubCategoryAbberation)
    //{
    //    DataSet dsSubCategoryCode = RetrieveSubCategoryCodeData();
    //    if (dsSubCategoryCode != null)
    //    {
    //        if (dsSubCategoryCode != null && dsSubCategoryCode.Tables.Count > 0)
    //        {
    //            // DataTable dtSubCategoryCode = dsSubCategoryCode.Tables[0];
    //            // ddlSubCategoryCode.DataValueField = "Channel_ID";
    //            //ddlSubCategoryCode.DataTextField = "Channel_CODE";
    //            // ddlSubCategoryCode.DataSource = dtSubCategoryCode;
    //            //ddlSubCategoryCode.DataBind();

    //            // pnlSubCategoryABB.Controls.Add(DisplaySubCategoryAbb(dtSubCategoryCode));
    //        }
    //    }
    //    //if (ADD == "EDIT")
    //    //{
    //    //    this.txtSubCategory_ABBR.Text = SubCategoryAbberation;
    //    //    ddlSubCategoryCode.SelectedValue = SubCategoryCode;
    //    //    ddlSubCategoryCode.Enabled = false;
    //    //}
    //}
    protected void BindSubCategoryData()
    {
        DataSet dsSubCategory = RetrieveSubCategoryData();
        if (dsSubCategory != null && dsSubCategory.Tables.Count > 0)
        {
            DataTable dtSubCategory = dsSubCategory.Tables[0];
            pnlSubCategoryABB.Controls.Clear();
            pnlSubCategoryABB.Controls.Add(DisplaySubCategoryAbb(dtSubCategory));
            //this.Controls.Add(DisplaySubCategoryAbb(dtSubCategory));
        }
    }

    protected DataSet RetrieveSubCategoryData()
    {
        string connString = ConfigurationManager.AppSettings["ConnectionString"];
        //string sql = @"select SubCategory_ID, SubCategory_CODE, SubCategory_NAME from SubCategory";
        //string sql = "select aff.SubCategory_ID, aff.SubCategory_CODE, aff.SubCategory_NAME, affMap.SubCategory_ABBR ";
        //sql = sql + " from SubCategory aff LEFT JOIN   SubCategory_code_mapping affMap ";
        //sql = sql + " on  aff.SubCategory_Id = affMap.SubCategory_Id ";
        string sql = "select scm.SubCategoryID, scm.SubCategoryNAME, scm.SubCategoryDESCRIPTION, scm.ImagePath,scm.active,cm.CategoryID,cm.CategoryName ";
        sql = sql + " from SubCategoryMASTER scm , CategoryMaster cm where scm.CategoryID= cm.CategoryID";
        //sql = sql + " where   chn.channel_Id = chnMap.channel_Id ";
        DataSet dsSubCategoryData = new DataSet();
        OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
        //using (OracleConnection conn = new OracleConnection(connString))
        // {
        myDataConnection.Open();
        using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dsSubCategoryData);
        }
        // }
        return dsSubCategoryData;
    }





    protected DataSet RetrieveCategoryData()
    {
        string connString = ConfigurationManager.AppSettings["ConnectionString"];
        string sql = "select cm.CategoryID,cm.CategoryName ";
        sql = sql + " from  CategoryMaster cm ";

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

    protected void DisplayError(Exception ex)
    {
        //string exceptionMessages = GetExceptionMessages(ex);
        //if (!string.IsNullOrEmpty(exceptionMessages))
        //    this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(exceptionMessages, false);

    }
}
