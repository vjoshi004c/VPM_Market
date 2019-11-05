using System;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;

public partial class Admin_Pages_ManageUser : System.Web.UI.Page
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

    protected void EditUser()
    {
        hdnClientHit.Value = string.Empty;
        divAddEdit.Visible = true;
        pnlUserABB.Visible = false;
        string UserId = string.Empty;
        string UserEmail = string.Empty;
        string UserLogin = string.Empty;
        string UserPassword = string.Empty;

        string UserFirstName = string.Empty;
        string UserLastName = string.Empty;
        string UserSex = string.Empty;
        string UserMaritalStatus = string.Empty;
        string UserSatus = string.Empty;
        string UserAddress1 = string.Empty;
        string UserAddress2 = string.Empty;
        string UserZipCode = string.Empty;
        string UserContactNumber = string.Empty;
        string UserIsAdmin = string.Empty;
        string UserCreationDate = string.Empty;
        string UserLastUpdatedDate = string.Empty;
        string UserCity = string.Empty;
        string UserState = string.Empty;


        string selectedOptioin = hdnEdit.Value;
        string[] selectedOptions = null;

        try
        {
            if (selectedOptioin != null)
            {
                selectedOptions = selectedOptioin.Split('^');
            }
            if (selectedOptions.Length > 0 && selectedOptions.Length == 18)
            {
                UserId = selectedOptions[0];
                UserEmail = selectedOptions[1];
                UserLogin = selectedOptions[2];
                UserPassword = selectedOptions[3];
                 UserFirstName = selectedOptions[4];
                 UserLastName = selectedOptions[5];
                 UserSex = selectedOptions[6];
                 UserMaritalStatus = selectedOptions[7];
                 UserSatus = selectedOptions[8];
                 UserAddress1 = selectedOptions[9];
                 UserAddress2 = selectedOptions[10];
                 UserZipCode = selectedOptions[11];
                 UserContactNumber = selectedOptions[12];
                 UserIsAdmin = selectedOptions[13];
                 UserCreationDate = selectedOptions[14];
                 UserLastUpdatedDate = selectedOptions[15];
                 UserCity = selectedOptions[16];
                 UserState = selectedOptions[17];
            }

            BindUserCodeData("EDIT", string.Empty, string.Empty, string.Empty, string.Empty);
            // DeleteUserAbberation(UserId);
            this.txtUserId.Text = UserId;
            this.txtUserEmail.Text = UserEmail;
            this.txtUserLogin.Text = UserLogin;
            this.txtUserPassword.Text = UserPassword;
            this.txtUserFirstName.Text = UserFirstName;
            this.txtUserLastName.Text = UserLastName;
            //this.txtUserSex.Text = UserSex;
            this.ddlSex.SelectedValue = UserSex;
           // this.txtUserMaritalStatus.Text = UserMaritalStatus;
            this.ddlMaritalStatus.SelectedValue = UserMaritalStatus;
           // this.txtUserStatus.Text = UserSatus;
            this.txtUserAddress1.Text = UserAddress1;
            this.txtUserAddress2.Text = UserAddress2;
            this.txtUserZipCode.Text = UserZipCode;
            this.txtUserContactNumber.Text = UserContactNumber;
           // this.txtUserIsAdmin.Text = UserIsAdmin;
            this.ddlIsAdmin.SelectedValue = UserIsAdmin;
            this.txtUserCreatedDate.Text = UserCreationDate;
            this.txtUserModifiedDate.Text = UserLastUpdatedDate;
            this.txtUserCity.Text = UserCity;
            this.txtUserState.Text = UserState;



            divAddEdit.Visible = true;
            divDeleteConfirmation.Visible = false;
            pnlUserABB.Visible = false;
            //ddlUserCode.Enabled = false;
        }
        catch (Exception ex)
        {
            BindUserData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlUserABB.Visible = true;
            // this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        this.pnlUserABB.Visible = true;
        //this.btnAddUser.Visible = true;
        if (!IsPostBack)
        {

            BindUserData();
            EnableAddUserAbberationButton();
        }
        else
        {
            if (hdnClientHit.Value == "TRUE")
            {

                string UserId = string.Empty;
                string UserCode = string.Empty;
                string UserName = string.Empty;
                string UserAbberation = string.Empty;
                if (hdnOperationMode.Value == "EDIT")
                {
                    this.btnAddUser.Visible = false;
                    EditUser();
                }
                if (hdnOperationMode.Value == "DELETE")
                {
                    this.btnAddUser.Visible = false;
                    divDeleteConfirmation.Visible = true;

                }
            }
            //else
            //{
            //    BindUserData();
            //    EnableAddUserAbberationButton();
            //}


        }

        RegisterClientScript();




    }

    private void EnableAddUserAbberationButton()
    {
        this.btnAddUser.Visible = true;
        //DataSet dsUserCode = RetrieveUserCodeData("ADD");
        //if (dsUserCode != null && dsUserCode.Tables != null && dsUserCode.Tables.Count > 0 && dsUserCode.Tables[0].Rows != null && dsUserCode.Tables[0].Rows.Count>0)
        ////if (dsUserCode == null)
        //{
        //    this.btnAddUser.Enabled = true;
        //}
        //else
        //{
        //    this.btnAddUser.Enabled = false;
        //}
    }

    protected void AddUser(object sender, EventArgs e)
    {
        // ddlUserCode.Enabled = true;
        hdnOperationMode.Value = "ADD";
        hdnClientHit.Value = string.Empty;
        divAddEdit.Visible = true;
        divDeleteConfirmation.Visible = false;
        pnlUserABB.Visible = false;
        BindUserCodeData("ADD", string.Empty, string.Empty, string.Empty, string.Empty);
        // this.txtUser_ABBR.Text = string.Empty;
        this.btnAddUser.Visible = false;
    }


    private bool UpdateUserAbberation(string UserId, string UserEmail, string UserLogin, string UserPassword, string UserFirstName, string UserLastName, string UserSex, string UserMaritalStatus, string UserSatus, string UserAddress1, string UserAddress2, string UserZipCode, string UserContactNumber, string UserIsAdmin, string UserCreationDate, string UserLastUpdatedDate, string UserCity, string UserState)
    {
        try
        {
            string sql = @"Update UserMASTER set ";
            sql=sql +" Email = '" + UserEmail ;
            sql = sql + "', LoginID = '" + UserLogin;
            sql = sql + "', Pwd = '" + UserPassword;

            sql = sql + "', FirstName = '" + UserFirstName;
            sql = sql + "', LastName= '" + UserLastName;
              sql = sql + "', Sex = '" + UserSex;
              sql = sql + "', MaritalStatus = '" + UserMaritalStatus;
              sql = sql + "', UserStatus = '" + UserSatus;
              sql = sql + "', Address1 = '" + UserAddress1;
              sql = sql + "', Address2 = '" + UserAddress2;
              sql = sql + "', ZipCode = '" + UserZipCode;
              sql = sql + "', ContactNumber = '" + UserContactNumber;
              if (UserIsAdmin == "True")
              {

                  sql = sql + "', IsAdmin = " + true;
              }
              else
              {
                  sql = sql + "', IsAdmin = " + false ;
              }

             // sql = sql + ", CreationDate = " + System.DateTime.Now;
              sql = sql + ", LastUpdatedDate = '" + System.DateTime.Now;
              sql = sql + "', City = '" + UserCity;
              sql = sql + "', State = '" + UserState;
              sql=sql    + "' where UserId = " + UserId + "";

            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //SQL statement to insert new Configuration
            OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
            //using (OracleConnection conn = new OracleConnection(connString))
            //{
            myDataConnection.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
            {
                cmd.ExecuteNonQuery();
                BindUserData();
            }
            //}
            return true;
        }
        catch (Exception ex)
        {
            BindUserData();
            divAddEdit.Visible = false;
            pnlUserABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
            return false;
        }

    }

    private void DeleteUserAbberation(string UserId)
    {
        try
        {
            if (!string.IsNullOrEmpty(UserId))
            {

                //string connString = ConfigurationManager.AppSettings["ConnectionString"];

                string connString = ConfigurationManager.AppSettings["ConnectionString"];
                string deletesql = @"delete from UserMaster where UserId= " + UserId + "";
                OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
                //using (OracleConnection conn = new OracleConnection(connString))
                //{
                myDataConnection.Open();
                using (OleDbCommand cmd = new OleDbCommand(deletesql, myDataConnection))
                {
                    cmd.ExecuteNonQuery();
                    //BindUserData();

                }
                //}


            }
        }
        catch (Exception ex)
        {
            //BindUserData();
            //divAddEdit.Visible = false;
            //pnlUserABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
            throw ex;


        }


    }

    protected void DeleteSave(object sender, EventArgs e)
    {
        string UserId = string.Empty;
        string UserEmail = string.Empty;
        string UserLogin= string.Empty;
        string UserPassword = string.Empty;
        string selectedOptioin = htnDelete.Value;
        string[] selectedOptions = null;

        try
        {
            if (selectedOptioin != null)
            {
                selectedOptions = selectedOptioin.Split('^');
            }
            if (selectedOptions.Length > 0 && selectedOptions.Length ==18)
            {
                UserId = selectedOptions[0];
                UserEmail = selectedOptions[1];
                UserLogin = selectedOptions[2];
                UserPassword = selectedOptions[3];
            }
            DeleteUserAbberation(UserId);

            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlUserABB.Visible = true;
            BindUserData();
            EnableAddUserAbberationButton();
            hdnOperationMode.Value = string.Empty;
        }
        catch (Exception ex)
        {
            BindUserData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlUserABB.Visible = true;
            hdnOperationMode.Value = string.Empty;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }

    }
    protected void DeleteCancel(object sender, EventArgs e)
    {
        divAddEdit.Visible = false;
        divDeleteConfirmation.Visible = false;
        pnlUserABB.Visible = true;
        BindUserData();
        this.btnAddUser.Visible = true;

    }
    protected void Save(object sender, EventArgs e)
    {

        string  UserId = string.Empty ;
        string UserEmail = string.Empty;
        string UserLogin = string.Empty;
        string UserPassword = string.Empty;
        string UserFirstName = string.Empty;
        string UserLastName = string.Empty;
        string UserSex = string.Empty;
        string UserMaritalStatus = string.Empty;
        string UserSatus = string.Empty;
        string UserAddress1 = string.Empty;
        string UserAddress2 = string.Empty;
        string UserZipCode = string.Empty;
        string UserContactNumber = string.Empty;
        string UserIsAdmin = string.Empty;
        string UserCreationDate = string.Empty;
        string UserLastUpdatedDate = string.Empty;
        string UserCity = string.Empty;
        string UserState = string.Empty;
        try
        {

            if (hdnOperationMode.Value == "ADD")
            {
                divAddEdit.Visible = false;
                pnlUserABB.Visible = true;

                //string UserEmail = this.txtUserEmail.Text;
                //string UserLogin = this.txtUserLogin.Text;
                //string UserPassword = this.txtUserPassword.Text;
                //string UserId = ddlUserCode.SelectedValue.ToString();
                //string UserAbberation = txtUser_ABBR.Text;


                 UserId =this.txtUserId.Text ;
                UserEmail =this.txtUserEmail.Text  ;
                 UserLogin =this.txtUserLogin.Text ;
                 UserPassword =this.txtUserPassword.Text ;
                 UserFirstName =this.txtUserFirstName.Text ;
                UserLastName = this.txtUserLastName.Text ;
                //UserSex =this.txtUserSex.Text ;
                UserSex = ddlSex.SelectedValue; ;

                 //UserMaritalStatus =this.txtUserMaritalStatus.Text ;
                 UserMaritalStatus = ddlMaritalStatus.SelectedValue;
                 //UserSatus =this.txtUserStatus.Text  ;
                 UserSatus = ddlUserStatus.SelectedValue;
                 UserAddress1 =this.txtUserAddress1.Text ;
                 UserAddress2= this.txtUserAddress2.Text ;
                 UserZipCode =this.txtUserZipCode.Text ;
                 UserContactNumber =this.txtUserContactNumber.Text ;
                // UserIsAdmin =this.txtUserIsAdmin.Text ;
                 UserIsAdmin = this.ddlIsAdmin.SelectedValue;
                 UserCreationDate= this.txtUserCreatedDate.Text  ;
                 UserLastUpdatedDate =this.txtUserModifiedDate.Text  ;
                 UserCity =this.txtUserCity.Text ;
                 UserState =this.txtUserState.Text ;


                if (this.txtUserEmail.Text.Trim() != string.Empty)
                {
                    bool flag = insertUserAbberation(UserId, UserEmail, UserLogin, UserPassword, UserFirstName, UserLastName, UserSex, UserMaritalStatus, UserSatus, UserAddress1, UserAddress2, UserZipCode, UserContactNumber, UserIsAdmin, UserCreationDate, UserLastUpdatedDate, UserCity, UserState);
                    if (flag == true)
                    {
                        BindUserData();
                        EnableAddUserAbberationButton();
                    }
                }
            }
            if (hdnOperationMode.Value == "EDIT")
            {
                divAddEdit.Visible = false;
                divDeleteConfirmation.Visible = false;
                pnlUserABB.Visible = true;
                //string UserId = ddlUserCode.SelectedValue.ToString();
                //string UserAbberation = txtUser_ABBR.Text;
                UserId = this.txtUserId.Text;
                UserEmail = this.txtUserEmail.Text;
                UserLogin = this.txtUserLogin.Text;
                UserPassword = this.txtUserPassword.Text;
                UserFirstName = this.txtUserFirstName.Text;
                UserLastName = this.txtUserLastName.Text;
                //UserSex = this.txtUserSex.Text;
                UserSex = ddlSex.SelectedValue; ;
                //UserMaritalStatus = this.txtUserMaritalStatus.Text;
                UserMaritalStatus = ddlMaritalStatus.SelectedValue;
                //UserSatus = this.txtUserStatus.Text;
                UserSatus = ddlUserStatus.SelectedValue;
                UserAddress1 = this.txtUserAddress1.Text;
                UserAddress2 = this.txtUserAddress2.Text;
                UserZipCode = this.txtUserZipCode.Text;
                UserContactNumber = this.txtUserContactNumber.Text;
               // UserIsAdmin = this.txtUserIsAdmin.Text;
                UserIsAdmin = this.ddlIsAdmin.SelectedValue;
                UserCreationDate = this.txtUserCreatedDate.Text;
                UserLastUpdatedDate = this.txtUserModifiedDate.Text;
                UserCity = this.txtUserCity.Text;
                UserState = this.txtUserState.Text;

                if (this.txtUserEmail.Text.Trim() != string.Empty)
                {
                    bool flag = UpdateUserAbberation(UserId, UserEmail, UserLogin, UserPassword, UserFirstName, UserLastName, UserSex, UserMaritalStatus, UserSatus, UserAddress1, UserAddress2, UserZipCode, UserContactNumber, UserIsAdmin, UserCreationDate, UserLastUpdatedDate, UserCity, UserState);
                    if (flag == true)
                    {
                        BindUserData();
                        EnableAddUserAbberationButton();
                    }
                }
            }

            hdnOperationMode.Value = string.Empty;

        }
        catch (Exception ex)
        {
            BindUserData();
            divAddEdit.Visible = false;
            divDeleteConfirmation.Visible = false;
            pnlUserABB.Visible = true;
            hdnOperationMode.Value = string.Empty;
            // this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(ex.Message.ToString(), false);
        }



    }

    private bool insertUserAbberation(string UserId, string UserEmail, string UserLogin, string UserPassword, string UserFirstName, string UserLastName, string UserSex, string UserMaritalStatus, string UserSatus, string UserAddress1, string UserAddress2, string UserZipCode,string  UserContactNumber, string UserIsAdmin,string  UserCreationDate, string UserLastUpdatedDate, string UserCity, string UserState)
    {

        if (!string.IsNullOrEmpty(UserEmail) && !string.IsNullOrEmpty(UserLogin))
        {

            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //string insertsql = @"Insert into CHANNEL_code_mapping(CHANNEL_code_mapping_id , CHANNEL_ID, CHANNEL_ABBR,  Creation_Date, Last_Update) 
            // values('" + Guid.NewGuid() + "','" + UserId + "','" + UserAbberation + "', '" + DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + "', '" + DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + "')";


            string insertsql = @"Insert into UserMASTER(Email , LoginID, pwd, FirstName , LastName, Sex, MaritalStatus, UserStatus, Address1, Address2,ZipCode,ContactNumber, IsAdmin,CreationDate,  City, State)  ";
            insertsql = insertsql + "values('" + UserEmail + "','" + UserLogin + "', '" + UserPassword + "', '" + UserFirstName + "', '" + UserLastName + "', '" + UserSex + "', '" + UserMaritalStatus + "', '" + UserSatus + "', '" + UserAddress1 + "', '" + UserAddress2 + "', '" + UserZipCode + "', '" + UserContactNumber + "', " + UserIsAdmin + ", '" + System.DateTime.Now  + "', '" + UserCity + "', '" + UserState + "')";

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
            BindUserData();
            divAddEdit.Visible = false;
            pnlUserABB.Visible = true;
            //this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog("Please enter Channel Id /Channel Abberation.", false);


            return false;
        }
    }


    protected void Cancel(object sender, EventArgs e)
    {
        divAddEdit.Visible = false;
        pnlUserABB.Visible = true;
        divDeleteConfirmation.Visible = false;
        BindUserData();
        this.btnAddUser.Visible = true;

    }



    private HtmlTable DisplayUserAbb(DataTable dtAffilateAbb)
    {

        try
        {


            HtmlTable htCharges = new HtmlTable();
            htCharges.CellPadding = 0;
            htCharges.CellSpacing = 0;
            htCharges.Width = "100%";

            HtmlTableRow hrUserHeader = new HtmlTableRow();
            HtmlTableCell hcUserHeaderFirst = new HtmlTableCell();
            hcUserHeaderFirst.Visible = false;
            hcUserHeaderFirst.Width = "50%";
            hcUserHeaderFirst.Attributes.Add("class", "gridHeader");
            hcUserHeaderFirst.InnerText = "User ID";
            hrUserHeader.Cells.Add(hcUserHeaderFirst);

            HtmlTableCell hcUserHeaderSecond = new HtmlTableCell();
            hcUserHeaderSecond.Width = "25%";
            hcUserHeaderSecond.Attributes.Add("class", "gridHeader");
            hcUserHeaderSecond.InnerText = "User Name";
            hrUserHeader.Cells.Add(hcUserHeaderSecond);
            HtmlTableCell hcUserHeaderThird = new HtmlTableCell();
            hcUserHeaderThird.Width = "25%";
            hcUserHeaderThird.Attributes.Add("class", "gridHeader");
            hcUserHeaderThird.InnerText = "User Description";
            hrUserHeader.Cells.Add(hcUserHeaderThird);
            //htCharges.Rows.Add(hrUserHeader);


            HtmlTableCell hcUserHeaderForth = new HtmlTableCell();
            hcUserHeaderForth.Width = "25%";
            hcUserHeaderForth.Attributes.Add("class", "gridHeader");
            hcUserHeaderForth.InnerText = "User Price";
            hrUserHeader.Cells.Add(hcUserHeaderForth);
            //htCharges.Rows.Add(hrUserHeader);

            HtmlTableCell hcUserHeaderFifth = new HtmlTableCell();
            hcUserHeaderFifth.Width = "25%";
            hcUserHeaderFifth.Attributes.Add("class", "gridHeader");
            hcUserHeaderFifth.InnerText = "Action";
            hrUserHeader.Cells.Add(hcUserHeaderFifth);
            // htCharges.Rows.Add(hrUserHeader);

            HtmlTableCell hcUserHeaderSixth = new HtmlTableCell();
            hcUserHeaderSixth.Width = "25%";
            hcUserHeaderSixth.Attributes.Add("class", "gridHeader");
            hcUserHeaderSixth.InnerText = "Action";
            hrUserHeader.Cells.Add(hcUserHeaderSixth);
            htCharges.Rows.Add(hrUserHeader);

            if (dtAffilateAbb != null && dtAffilateAbb.Rows.Count > 0)
            {
                for (int i = 0; i < dtAffilateAbb.Rows.Count; i++)
                {
                    HtmlTableRow hrUser = new HtmlTableRow();
                    DataRow dr = dtAffilateAbb.Rows[i];
                    string UserId = dr["UserID"].ToString();
                    string UserEmail = dr["Email"].ToString();
                    string UserLogin = dr["LoginID"].ToString();
                    string UserPassword = dr["pwd"].ToString();

                    string UserFirstName = dr["FirstName"].ToString();
                    string UserLastName = dr["LastName"].ToString();
                    string UserSex = dr["Sex"].ToString();
                    string UserMaritalStatus = dr["MaritalStatus"].ToString();
                    string UserSatus = dr["UserStatus"].ToString();
                    string UserAddress1 = dr["Address1"].ToString();
                    string UserAddress2 = dr["Address2"].ToString();
                    string UserZipCode = dr["ZipCode"].ToString();
                    string UserContactNumber = dr["ContactNumber"].ToString();
                    string UserIsAdmin = dr["IsAdmin"].ToString();
                    string UserCreationDate = dr["CreationDate"].ToString();
                    string UserLastUpdatedDate = dr["LastUpdatedDate"].ToString();
                    string UserCity = dr["City"].ToString();
                    string UserState = dr["State"].ToString();






                    HtmlTableCell hcUserFirst = new HtmlTableCell();
                    hcUserFirst.Width = "5%";
                    hcUserFirst.Attributes.Add("class", "gridRows1");
                    hcUserFirst.InnerText = UserId;
                    hcUserFirst.Visible = false;
                    hrUser.Cells.Add(hcUserFirst);

                    HtmlTableCell hcUserSecond = new HtmlTableCell();
                    hcUserSecond.Width = "30%";
                    hcUserSecond.Attributes.Add("class", "gridRows1");
                    hcUserSecond.InnerText = UserEmail;
                    hcUserSecond.InnerHtml = "<span style=\"color:black;\"><b>" + UserLogin + "</b></span>";
                    hcUserSecond.BgColor = "#EDEDEC";
                    hrUser.Cells.Add(hcUserSecond);
                    HtmlTableCell hcUserThird = new HtmlTableCell();
                    hcUserThird.Width = "30%";
                    hcUserThird.Attributes.Add("class", "gridRows1");
                    hcUserThird.InnerText = UserPassword;
                    // hcUserThird.BgColor = "#DCDCDC";
                    hrUser.Cells.Add(hcUserThird);
                    //htCharges.Rows.Add(hrUser);


                    HtmlTableCell hcUserForth = new HtmlTableCell();
                    hcUserForth.Width = "15%";
                    hcUserForth.Attributes.Add("class", "gridRows1");
                    hcUserForth.InnerText = UserPassword;
                    hcUserForth.Align = HorizontalAlign.Center.ToString();
                    hrUser.Cells.Add(hcUserForth);
                    // htCharges.Rows.Add(hrUserHeader);

                    HtmlTableCell hcUserFifth = new HtmlTableCell();
                    hcUserFifth.Width = "10%";
                    hcUserFifth.Attributes.Add("class", "gridRows1");
                    hcUserFifth.Align = HorizontalAlign.Center.ToString();
                    ImageButton imgEdit = new ImageButton();

                    imgEdit.OnClientClick = "onEditSelection" + "('" + UserId + "','" + UserEmail + "','" + UserLogin + "','" + UserPassword + "','" + UserFirstName + "','" + UserLastName + "','" + UserSex + "','" + UserMaritalStatus + "','" + UserSatus + "','" + UserAddress1 + "','" + UserAddress2 + "','" + UserZipCode + "','" + UserContactNumber + "','" + UserIsAdmin + "','" + UserCreationDate + "','" + UserLastUpdatedDate + "','" + UserCity + "','" + UserState + "')";
                    imgEdit.Width = new Unit(20);
                    imgEdit.Height = new Unit(20);
                    imgEdit.ID = i.ToString(); ;
                    imgEdit.ToolTip = "Edit";
                    imgEdit.ImageUrl = "~/Images/EditThird.png";
                    hcUserFifth.Controls.Add(imgEdit);
                    //Button btnEdit = new Button();
                    //btnEdit.OnClientClick = "onEditSelection" + "('" + UserId + "','" + User_CODE + "','" + User_NAME + "','" + User_ABBR + "')";
                    //btnEdit.ID = i.ToString(); ;
                    //btnEdit.Text = "Edit";
                    //hcUserFifth.Controls.Add(btnEdit);
                    hrUser.Cells.Add(hcUserFifth);
                    //htCharges.Rows.Add(hrUserHeader);

                    HtmlTableCell hcUserSixth = new HtmlTableCell();
                    hcUserSixth.Align = HorizontalAlign.Center.ToString();
                    hcUserSixth.Width = "10%";
                    hcUserSixth.Attributes.Add("class", "gridRows1");
                    //HtmlButton btnDelete = new HtmlButton();
                    ImageButton imgDelete = new ImageButton();
                    imgDelete.Width = new Unit(20);
                    imgDelete.Height = new Unit(20);

                    imgDelete.OnClientClick = "onDeleteSelection" + "('" + UserId + "','" + UserEmail + "','" + UserLogin + "','" + UserPassword + "','" + UserFirstName + "','" + UserLastName + "','" + UserSex + "','" + UserMaritalStatus + "','" + UserSatus + "','" + UserAddress1 + "','" + UserAddress2 + "','" + UserZipCode + "','" + UserContactNumber + "','" + UserIsAdmin + "','" + UserCreationDate + "','" + UserLastUpdatedDate + "','" + UserCity + "','" + UserState + "')";
                    imgDelete.ID = i.ToString(); ;
                    imgDelete.ToolTip = "Delete";
                    imgDelete.ImageUrl = "~/Images/DeleteThird.png";
                    hcUserSixth.Controls.Add(imgDelete);


                    //Button btnDelete = new Button();
                    //btnDelete.ID = i.ToString(); ;
                    //btnDelete.Text = "Delete";
                    //btnDelete.OnClientClick = "onDeleteSelection" + "('" + User_ID + "','" + User_CODE + "','" + User_NAME + "','" + User_ABBR + "')";
                    //hcUserSixth.Controls.Add(btnDelete);



                    // hcUserSixth.InnerText = "Delete";
                    hrUser.Cells.Add(hcUserSixth);
                    htCharges.Rows.Add(hrUser);


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


    protected void BindUserCodeData(string ADD, string UserId, string UserCode, string UserName, string UserAbberation)
    {

        DataSet dsUserCode = RetrieveUserCodeData(ADD);


        if (dsUserCode != null)
        {

            if (dsUserCode != null && dsUserCode.Tables.Count > 0)
            {
                // DataTable dtUserCode = dsUserCode.Tables[0];
                // ddlUserCode.DataValueField = "Channel_ID";
                //ddlUserCode.DataTextField = "Channel_CODE";
                // ddlUserCode.DataSource = dtUserCode;
                //ddlUserCode.DataBind();

                // pnlUserABB.Controls.Add(DisplayUserAbb(dtUserCode));
            }
        }
        //if (ADD == "EDIT")
        //{
        //    this.txtUser_ABBR.Text = UserAbberation;
        //    ddlUserCode.SelectedValue = UserCode;
        //    ddlUserCode.Enabled = false;
        //}


    }
    protected void BindUserData()
    {

        DataSet dsUser = RetrieveUserData();
        if (dsUser != null && dsUser.Tables.Count > 0)
        {
            DataTable dtUser = dsUser.Tables[0];
            pnlUserABB.Controls.Clear();
            pnlUserABB.Controls.Add(DisplayUserAbb(dtUser));
        }

    }

    protected DataSet RetrieveUserData()
    {




        string connString = ConfigurationManager.AppSettings["ConnectionString"];

        //string sql = @"select User_ID, User_CODE, User_NAME from User";

        //string sql = "select aff.User_ID, aff.User_CODE, aff.User_NAME, affMap.User_ABBR ";
        //sql = sql + " from User aff LEFT JOIN   User_code_mapping affMap ";
        //sql = sql + " on  aff.User_Id = affMap.User_Id ";


        //string sql = "select UserID, Email, Login,password ";

        string sql = " SELECT UserMaster.[UserID], UserMaster.[GroupID], UserMaster.[FirstName], UserMaster.[LastName], UserMaster.[Address1], UserMaster.[Address2], UserMaster.[ContactNumber], UserMaster.[Sex], UserMaster.[MaritalStatus], UserMaster.[ZipCode], UserMaster.[Email], UserMaster.[IsAdmin], UserMaster.[LoginID], UserMaster.[Pwd], UserMaster.[UserStatus], UserMaster.[CreationDate], UserMaster.[LastUpdatedDate], UserMaster.[City],UserMaster.[State]";
        sql = sql + "FROM UserMaster ;";
       // sql = sql + " from UserMASTER ";
        //sql = sql + " where   chn.channel_Id = chnMap.channel_Id ";



        DataSet dsUserData = new DataSet();
        OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
        //using (OracleConnection conn = new OracleConnection(connString))
        // {
        myDataConnection.Open();
        using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dsUserData);
        }
        // }

        return dsUserData;
    }

    protected DataSet RetrieveUserCodeData(string mode)
    {



        //string connString = ConfigurationManager.AppSettings["ConnectionString"];

        ////string sql = @"select User_ID, User_CODE, User_NAME from User";
        //string sql = string.Empty;
        //if (mode == "ADD")
        //{
        //    sql = "select chn.CHANNEL_ID, chn.CHANNEL_CODE from CHANNEL chn where chn.CHANNEL_ID NOT IN(  select CHANNEL_ID from CHANNEL_code_mapping)";
        //}
        //else
        //{
        //    sql = "select CHANNEL_ID, CHANNEL_CODE from CHANNEL   ";

        //}




        //DataSet dsUserCodeData = new DataSet();
        //using (OracleConnection conn = new OracleConnection(connString))
        //{
        //    conn.Open();
        //    using (OracleCommand cmd = new OracleCommand(sql, conn))
        //    {
        //        OracleDataAdapter adapter = new OracleDataAdapter(cmd);
        //        adapter.Fill(dsUserCodeData);
        //    }
        //}

        //return dsUserCodeData;
        return null;
    }

    protected void DisplayError(Exception ex)
    {
        //string exceptionMessages = GetExceptionMessages(ex);
        //if (!string.IsNullOrEmpty(exceptionMessages))
        //    this.Master.ErrorWarningDialogForAll.DisplayErrorWarningDialog(exceptionMessages, false);

    }
}
