<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Market.master" AutoEventWireup="true" CodeFile="OrderPayment.aspx.cs" Inherits="User_Pages_OrderPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSubMenu" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">

<table width="100%" >
<%--<tr>
<td colspan="2"> <asp:Label id="lblShippingAdress" runat="server" Text="Shipping Address" ></asp:Label></td>
</tr>--%>
<tr>
        <td width="100%" colspan="2" align="left" class="gridHeader" >Shipping Address </td>
        </tr> 
<tr>
<td align="left" width="25%" > <asp:Label id="Label1" runat="server" CssClass="labelSection" Text="First Name" ></asp:Label></td>
<td align="left" > <asp:TextBox ID="txtAddress1" runat="server" ></asp:TextBox></td>
</tr>

<tr>
<td  align="left" width="25%" > <asp:Label id="Label2" runat="server" CssClass="labelSection" Text="LastName" ></asp:Label></td>
<td  align="left" > <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td align="left" width="25%" > <asp:Label id="Label3" runat="server" CssClass="labelSection" Text="Address Line 1" ></asp:Label></td>
<td  align="left" > <asp:TextBox ID="TextBox2" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td  align="left" width="25%" > <asp:Label id="Label4" runat="server" CssClass="labelSection" Text="Address Line 2" ></asp:Label></td>
<td  align="left" > <asp:TextBox ID="TextBox3" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td align="left" width="25%" > <asp:Label id="Label5" runat="server" CssClass="labelSection" Text="City" ></asp:Label></td>
<td  align="left" > <asp:TextBox ID="TextBox4" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td  align="left" width="25%" > <asp:Label id="Label6" runat="server" CssClass="labelSection" Text="State/Province/Region" ></asp:Label></td>
<td align="left" > <asp:TextBox ID="TextBox5" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td align="left" width="25%" > <asp:Label id="Label7" runat="server" CssClass="labelSection" Text="Country" ></asp:Label></td>
<td align="left" > <asp:TextBox ID="TextBox6" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td align="left" width="25%" > <asp:Label id="Label8" runat="server" CssClass="labelSection"  Text="Phone Number" ></asp:Label></td>
<td align="left" > <asp:TextBox ID="TextBox7" runat="server" ></asp:TextBox></td>
</tr>

<%--<tr>
<td > </td>
<td > <asp:Button ID="btnShippingContinue" runat="server" Text="Continue" /></td>
</tr>--%>
</table>
<br /><br />

<table width="100%" >
<%--<tr>
<td colspan="2"> <asp:Label id="Label9" runat="server" Text="Payment " ></asp:Label></td>
</tr>--%>
<tr>
        <td colspan="2" align="left" class="gridHeader" >Payment </td>
        </tr> 
<tr>
<td align="left" width="25%" > <asp:Label id="Label10" runat="server" CssClass="labelSection" Text="Payment Type" ></asp:Label></td>
<td align="left" > 
<asp:DropDownList ID="ddlPaymentType" runat="server"  Width="100px" >
            <asp:ListItem Text="Debit" Value="Debit" ></asp:ListItem>
            <asp:ListItem Text="Credit" Value="Credit"  Selected="True"   ></asp:ListItem>
            </asp:DropDownList>
</td>
</tr>
<tr>
<td align="left" width="25%" > <asp:Label id="Label11" runat="server" CssClass="labelSection" Text="Cart Number" ></asp:Label></td>
<td align="left" > <asp:TextBox ID="TextBox9" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td align="left" width="25%" > <asp:Label id="Label12" runat="server" CssClass="labelSection" Text="Name on Card" ></asp:Label></td>
<td align="left" > <asp:TextBox ID="TextBox10" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td align="left" width="25%" > <asp:Label id="Label13" runat="server" CssClass="labelSection" Text="Expiration Date" ></asp:Label></td>
<td align="left" > <asp:TextBox ID="TextBox11" runat="server" ></asp:TextBox></td>
</tr>
<tr>
<td align="left" width="25%" > <asp:Label id="Label14" runat="server" CssClass="labelSection" Text="CVV Number" ></asp:Label></td>
<td align="left" > <asp:TextBox ID="TextBox12" runat="server"  Width="30px"  MaxLength="3"  TextMode="Password" ></asp:TextBox></td>
</tr>


<%--<tr>
<td > </td>
<td > <asp:Button ID="btnContinue" runat="server" Text="Continue" /></td>
</tr>--%>
</table>


<br />
<table width="100%" >
<%--<tr>
<td colspan="2"> <asp:Label id="Label9" runat="server" Text="Payment " ></asp:Label></td>
</tr>--%>

<tr>
<td align="left" width="25%" > <asp:Button ID="btnBackToHome"   
        CssClass="buttonAction"  runat="server" Text="BackToHome" 
        onclick="btnBackToHome_Click" /></asp:Label></td>
<td align="center" > <asp:Button ID="btnOrderReview"   
        CssClass="buttonAction"  runat="server" Text="Next"  Width="100px"
        onclick="btnOrderReview_Click" /></td>
</tr>
</table> 



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>

