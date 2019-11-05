<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Master_Admin.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSubMenu" Runat="Server">
<h3><span  class="sectionHeader" > Customer Login</span></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
<table width="100%" >
<tr>
<td width="25%"></td>
<td width="30%" >
<br /><br />
<table width="100%"  id="tlbError" runat="server" class="editDeleteSection" visible="false"  >
<tr>
<td colspan="2" align="center" class="gridHeader"   > 
<asp:Label ID="lblErrorMessage" runat="server"  CssClass="errorLabel" Visible="false"></asp:Label>
</td>

</tr>
</table> 
<br /><br />
<table width="100%"  class="editDeleteSection" >
<tr>
<td colspan="2" align="center" class="gridHeader"> Login</td>

</tr>
<tr>
<td align="left"="  width="40%" ><asp:Label ID="lblUserId" runat="server" Text="User ID" CssClass="labelSection" ></asp:Label></td>
<td align="left"  ><asp:TextBox ID="txtUserID" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td align="left" width="40%" ><asp:Label ID="lblPassword" runat="server" Text="Password"  CssClass="labelSection" ></asp:Label></td>
<td align="left"  ><asp:TextBox ID="txtPassword" runat="server"  TextMode="Password" ></asp:TextBox></td>
</tr>
<tr>
<td align="right" ><asp:Button ID="btnLogin" runat="server"  CssClass="buttonAction"  Text="LogIn"  OnClick="Login_Click" /></td>
<td align="left"  ><asp:Button ID="btnCancel" runat="server" CssClass="buttonAction" Text="Cancel"  OnClick="Cancel_Click" /></td>
</tr>
</table>

</td>
<td width="45%"></td>
</tr>
<tr>
<td width="25%" ></td>
<td width="30%" >
<table  width="100%" >
<tr>
<td align="right"  width="40%"><asp:HyperLink id="hlkItem" runat="server"  CssClass="linkMenu"   Font-Underline="false" Text="Forgot your password?" NavigateUrl="~/User/Pages/ForgetPassword.aspx" ></asp:HyperLink>
</td>
</tr>
<tr>
<td align="right" width="40%" ><b>Don't have an account? </b>
<asp:HyperLink id="HyperLink1" runat="server"  CssClass="linkMenu"   Font-Underline="false" Text="create one now" NavigateUrl="~/User/Pages/CreateCustomer.aspx" ></asp:HyperLink>

</td>
</tr>
</table>



</td>
<td width="45%" ></td>
</tr>

</table>







</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>

