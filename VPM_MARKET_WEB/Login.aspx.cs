using System;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using VPM_Entity;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblErrorMessage.Visible = false;
        tlbError.Visible = false;
    }

    protected DataSet GetUser(string userID, string password)
    {
        try
        {
            string connString = ConfigurationManager.AppSettings["ConnectionString"];
            //string sql = "select loginid, password , firstname, lastname, userstatus,address1, address2,sex, matriastatus,zipcode,emaiid, isadmin ";
            //sql = sql + " from UserMaster ";

            string sql = " SELECT UserMaster.[UserID], UserMaster.[GroupID], UserMaster.[FirstName], UserMaster.[LastName], UserMaster.[Address1], UserMaster.[Address2], UserMaster.[ContactNumber], UserMaster.[Sex], UserMaster.[MaritalStatus], UserMaster.[ZipCode], UserMaster.[Email], UserMaster.[IsAdmin], UserMaster.[LoginID], UserMaster.[pwd], UserMaster.[UserStatus], UserMaster.[CreationDate], UserMaster.[LastUpdatedDate] ";
            sql = sql + "FROM UserMaster where UserMaster.[LoginID]='"+userID +"' and UserMaster.[pwd]='" + password+"';";


            DataSet dsUserData = new DataSet();
            OleDbConnection myDataConnection = new OleDbConnection(ConfigurationManager.ConnectionStrings["AccessConnectionString"].ConnectionString);
            myDataConnection.Open();
            using (OleDbCommand cmd = new OleDbCommand(sql, myDataConnection))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(dsUserData);
            }
            return dsUserData;
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
    protected void Login_Click(object sender, EventArgs e)
    {
        
        try
        {
            if (this.txtUserID.Text.Trim() != string.Empty)
            {
                if (this.txtPassword.Text.Trim() != string.Empty)
                {
                   DataSet dsUser=  GetUser( this.txtUserID.Text,this.txtPassword.Text);
                   if (dsUser != null && dsUser.Tables != null && dsUser.Tables.Count > 0 && dsUser.Tables[0].Rows != null && dsUser.Tables[0].Rows.Count > 0)
                   {
                       DataRow drUser = dsUser.Tables[0].Rows[0];
                       User user = new User();
                       user.LogIn = drUser["LogInId"].ToString();
                       user.Password = drUser["pwd"].ToString();
                       user.UserStatus  = drUser["UserStatus"].ToString();
                       user.EmailID  = drUser["Email"].ToString();
                       user.FirstName = drUser["FirstName"].ToString();
                      user.LastName = drUser["LastName"].ToString();
                       user.IsAdmin  = Convert.ToBoolean(drUser["IsAdmin"].ToString());
                       user.Address1 = drUser["Address1"].ToString();
                       user.Address2 = drUser["Address2"].ToString();
                       user.Sex  = drUser["Sex"].ToString();
                       user.MaritalStatus = drUser["MaritalStatus"].ToString();
                       user.zipcode = drUser["zipcode"].ToString();
                       CurrentContext currentContext = new CurrentContext();
                       currentContext.user = user;
                       Session["CURRENT_CONTEXT"] = currentContext;
                       
                           Response.Redirect("~/home.aspx");
                      


                   }

                   else
                   {
                       tlbError.Visible = true;
                       lblErrorMessage.Visible = true;
                       lblErrorMessage.Text = "UserID or Password is invalid.";
                   }




                }
                else
                {
                    tlbError.Visible = true;
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Password should not be blank.";
                }


            }
            else
            {
                tlbError.Visible = true;
                lblErrorMessage.Visible = true;
                lblErrorMessage.Text = "User ID should not be blank.";
            }

        }
        catch (Exception ex)
        {
            tlbError.Visible = true;
            lblErrorMessage.Visible = true ;
            lblErrorMessage.Text = ex.Message.ToString();
        }


    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        this.lblErrorMessage.Visible = false;
        this.lblErrorMessage.Text = string.Empty;
        this.txtPassword.Text = string.Empty;
        this.txtUserID.Text = string.Empty;
        tlbError.Visible = false;
    }
}
