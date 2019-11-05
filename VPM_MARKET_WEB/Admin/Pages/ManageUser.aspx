<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Master_Admin.master" AutoEventWireup="true" CodeFile="ManageUser.aspx.cs" Inherits="Admin_Pages_ManageUser" %>
<%@ Register src="~/Controls/AdminMenu.ascx" tagname="adminMenu" tagprefix="ucAdminMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSubMenu" Runat="Server">
<h3><span  class="sectionHeader" >Manage User</span></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
 <ucAdminMenu:adminMenu ID="adminMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
<script language="javascript">

    function onDeleteSelection(User_ID, User_Email, User_Login, User_Password, UserFirstName, UserLastName, UserSex, UserMaritalStatus, UserSatus, UserAddress1, UserAddress2, UserZipCode, UserContactNumber, UserIsAdmin,UserCreationDate,UserLastUpdatedDate,UserCity,UserState) {



        // objDeleteParam = document.getElementById(hdnDeleteClientId);
        objDeleteParam = document.getElementById('ctl00_MainPlaceHolder_htnDelete');


        objClientHitParam = document.getElementById('ctl00_MainPlaceHolder_hdnClientHit');


        //objOperationMode = document.getElementById(hdnOperationModeClientId);
        objOperationMode = document.getElementById('ctl00_MainPlaceHolder_hdnOperationMode');

        //alert("hdnProSelectedChargesClientId --" + objPro.value);
        if (objDeleteParam != null) {
            // alert(objDeleteParam.value);
            objDeleteParam.value = User_ID + '^' + User_Email + '^' + User_Login + '^' + User_Password + '^' + UserFirstName + '^' + UserLastName + '^' + UserSex + '^' + UserMaritalStatus + '^' + UserSatus + '^' + UserAddress1 + '^' + UserAddress2 + '^' + UserZipCode + '^' + UserContactNumber + '^' + UserIsAdmin + '^' + UserCreationDate + '^' + UserLastUpdatedDate + '^' + UserCity + '^' + UserState;
        }
        if (objOperationMode != null) {
            // alert(objOperationMode.value);
            objOperationMode.value = "DELETE";
            objClientHitParam.value = "TRUE";
        }

       // alert(objOperationMode.value);
        //alert(objDeleteParam.value);
    }

    function onEditSelection(User_ID, User_Email, User_Login, User_Password, UserFirstName, UserLastName, UserSex, UserMaritalStatus, UserSatus, UserAddress1, UserAddress2, UserZipCode, UserContactNumber, UserIsAdmin,UserCreationDate,UserLastUpdatedDate,UserCity,UserState) {
        //alert('START');
        // objEdit = document.getElementById(hdnEditClientId);
        // objOperationMode = document.getElementById(hdnOperationModeClientId);
        objEdit = document.getElementById('ctl00_MainPlaceHolder_hdnEdit');
        objClientHitParam = document.getElementById('ctl00_MainPlaceHolder_hdnClientHit');
        objOperationMode = document.getElementById('ctl00_MainPlaceHolder_hdnOperationMode');
        if (objEdit != null) {

            objEdit.value = User_ID + '^' + User_Email + '^' + User_Login + '^' + User_Password + '^' + UserFirstName + '^' + UserLastName + '^' + UserSex + '^' + UserMaritalStatus + '^' + UserSatus + '^' + UserAddress1 + '^' + UserAddress2 + '^' + UserZipCode + '^' + UserContactNumber + '^' + UserIsAdmin + '^' + UserCreationDate + '^' + UserLastUpdatedDate + '^' + UserCity + '^' + UserState;
           // alert(objEdit.value);
        }
        if (objOperationMode != null) {
            objOperationMode.value = "EDIT";
            objClientHitParam.value = "TRUE";
        }
        // alert(objOperationMode.value);
        //alert(objEdit.value);

    }
</script>
<table width="100%">
        <%--<tr>
            <td align="left" >
                <label class="customerInformationFrame"><H2>Manage Users. </H2></label>
            </td>
        </tr>--%>
      
        <tr>
            <td align="right" >
              <asp:Button ID="btnAddUser" runat="server" Text="Add User"  CssClass="buttonAction"  OnClick="AddUser" />
            </td>
        </tr>
      
        <tr>
            <td>
                <asp:Panel ID="pnlUserABB" runat="server" ></asp:Panel>
            </td>
        </tr>
        </table>

        
        <div id="divAddEdit"  class="editDeleteSection" runat="server" visible= "false"  >
        <table width="100%" >

        <tr>
        <td width="25%" colspan=2"  class="gridHeader" >
       <b><span style="EditDeleteHeader" >Add /Edit User</span></b> 
        </td>
        </tr>
         <tr>
            <td width="25%" colspan="2"  >
                <br />
            </td>
        </tr>
        <tr>
        <td colspan="2" align="left"  class="gridHeader" > Personal Details</td>
        </tr> 
        <tr>
            <td width="25%" align="left" >
                <b><span class="labelSection" style="visibility:hidden;" >User Id</span></b>
            </td>
            <td  width="75%" align="left" >
                <asp:TextBox ID="txtUserId" runat="server"  Visible="false" ReadOnly="true" Width="300px" ></asp:TextBox>
                <%--<asp:DropDownList ID="ddlUserCode" runat="server" ></asp:DropDownList>--%>
            </td>
        </tr>
        <tr>
            <td width="25%" align="left" ><b><span class="labelSection">FirstName</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserFirstName" runat="server"   Width="300px"></asp:TextBox></td>
        </tr>
         <tr>
            <td width="25%" align="left" ><b><span class="labelSection">Last Name</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserLastName" runat="server"   Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> Contact Number</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserContactNumber"  MaxLength="12" runat="server"   Width="100px" ></asp:TextBox></td>
        </tr>
            
            <tr>
            <td width="25%" align="left" >
                <b><span class="labelSection">Email</span></b>
            </td>
        <td  width="75%" align="left" >
        <asp:TextBox ID="txtUserEmail" runat="server" Width="300px" ></asp:TextBox>
        <%--<asp:DropDownList ID="ddlUserCode" runat="server" ></asp:DropDownList>--%>
        </td>
        </tr>
        <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> Sex</span></b></td> 
            <td  width="75%" align="left" >
             <asp:DropDownList ID="ddlSex" runat="server" >
            <asp:ListItem Text="Male" Value="Male" Selected="True" ></asp:ListItem>
            <asp:ListItem Text="Female" Value="Female"   ></asp:ListItem>
           </asp:DropDownList>
           <%-- <asp:TextBox ID="txtUserSex" runat="server"   Width="100px" >--%>
            
            </asp:TextBox></td>
        </tr> <tr>
            <td width="25%" align="left" ><b><span class="labelSection">  Marital Status</span></b></td> 
            
            <td  width="75%" align="left" >
            <asp:DropDownList ID="ddlMaritalStatus" runat="server" >
            <asp:ListItem Text="Single" Value="Single" Selected="True" ></asp:ListItem>
            <asp:ListItem Text="Married" Value="Married"   ></asp:ListItem>
            </asp:DropDownList>
           <%-- <asp:TextBox ID="txtUserMaritalStatus" runat="server"  Width="100px" ></asp:TextBox>--%>
            </td>
        </tr>
<tr>
        <td colspan="2" align="left" class="gridHeader" > Login Details</td>
        </tr> 
         <tr>
            <td width="25%" align="left" > <b><span class="labelSection"> Login</span></b>        </td>
            <td  width="75%" align="left" > <asp:TextBox ID="txtUserLogin"   runat="server"    Width="300px" ></asp:TextBox>        </td>
        </tr>
        <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> Password</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserPassword" runat="server"   Width="300px"  ></asp:TextBox></td>
        </tr>
        </tr>  <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> Is Admin</span></b></td> 
            <td  width="75%" align="left" >
            <asp:DropDownList ID="ddlIsAdmin" runat="server" >
            <asp:ListItem Text="True" Value="True" ></asp:ListItem>
            <asp:ListItem Text="False" Value="False"   Selected="True"></asp:ListItem>
           </asp:DropDownList>
            
          <%--  <asp:TextBox ID="txtUserIsAdmin" runat="server"   Width="50px" ></asp:TextBox>--%>
            </td>
        </tr> 
         <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> Status</span></b></td> 
            <td  width="75%" align="left" >
             <asp:DropDownList ID="ddlUserStatus" runat="server" >
            <asp:ListItem Text="Active" Value="Active" Selected="True" ></asp:ListItem>
            <asp:ListItem Text="InActive" Value="InActive"   ></asp:ListItem>
           </asp:DropDownList>
           <%-- <asp:TextBox ID="txtUserStatus" runat="server"   Width="100px"></asp:TextBox>--%>
            </td>
        </tr>
           </tr>
            <tr>
        <td colspan="2" align="left" class="gridHeader" > Address Details </td>
        </tr> 
         <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> Address 1</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserAddress1" runat="server"   Width="300px" ></asp:TextBox></td>
        </tr> <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> Address 2</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserAddress2" runat="server"  Width="300px" ></asp:TextBox></td>
        </tr> 
         <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> City</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserCity" runat="server"   Width="100px" ></asp:TextBox></td>
        </tr> <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> State</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserState" runat="server"   Width="100px" ></asp:TextBox></td>
        </tr>
        <tr>
            <td width="25%" align="left" ><b><span class="labelSection"> ZipCode</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserZipCode" runat="server"   MaxLength="6"  Width="100px" ></asp:TextBox></td>
        
        
        <tr>
            <td width="25%" align="left" ><b><span class="labelSection" style="visibility:hidden;" > Created Date</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserCreatedDate"  Visible="false" runat="server"   Width="300px"></asp:TextBox></td>
        </tr> <tr>
            <td width="25%" align="left" ><b><span class="labelSection" style="visibility:hidden;" >  Modified Date</span></b></td> 
            <td  width="75%" align="left" ><asp:TextBox ID="txtUserModifiedDate"  Visible="false" runat="server"   Width="300px" ></asp:TextBox></td>
        </tr> 
      
       
        
        
        
        
         <tr>
        <td width="25%" colspan="2"  >
       <br />

        </td>
        </tr>
         <tr>
        <td width="25%" align="left"  >
       <asp:Button ID="btnSave" runat="server" Text="Save"  CssClass="buttonAction"   OnClick="Save" />
        </td>
        <td  width="75%" align="left"  >
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="buttonAction" OnClick="Cancel"  />
        

        </td>
        </tr>
        </table>
        </div>

        
        <div id="divDeleteConfirmation"  class="editDeleteSection"   runat="server" visible= "false"  >
        <table width="100%" >

        <tr>
        <td width="25%" colspan=2"  class="gridHeader" >
       <b><span style="EditDeleteHeader" >User : Delete Confirmation</span> </b> 
        </td>
       
        </tr>
        <tr>
         <td width="25%" colspan=2"  align="left"  >
        <h4>  <span class="deleteMessage" >Are you sure want to delete selected record?</span></h4>
        </td>
        
        </tr>

       

         <tr>
        <td width="25%" align="left"  >
       <asp:Button ID="btnDeleteSave" runat="server" Text="Save" OnClick="DeleteSave" CssClass="buttonAction"   />
        </td>
        <td  width="75%" align="left"  >
        <asp:Button ID="btnDeleteCancel" runat="server" Text="Cancel" OnClick="DeleteCancel" CssClass="buttonAction"   />
        

        </td>
        </tr>
        </table>
        </div>



        <asp:HiddenField ID="hdnEdit" runat="server" />
        <asp:HiddenField ID="htnDelete" runat="server" />
        <asp:HiddenField ID="hdnOperationMode" runat="server" />
        <asp:HiddenField ID="hdnClientHit" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
<h4><i>© 2013 VPM Market, Pvt Ltd.</i>  </h4>

</asp:Content>

