<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Market.master" AutoEventWireup="true" CodeFile="OrderReview.aspx.cs" Inherits="User_Pages_OrderReview" %>

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
        <td width="100%" colspan="2" align="left" class="gridHeader" >Order Review </td>
        </tr> 
         <tr>
        <td colspan="2" align="left" class="gridHeader" >Shipping Address </td>
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

<tr>
        <td colspan="2" align="left" class="gridHeader" >Items Details </td>
        </tr> 
        

<tr>
<td  colspan="2"  > 
<table width="100%"  style="margin-top:5px;"  >
<tr>
<td width="100%" style="margin-left:5px; margin-right:5px; " > 
<asp:Panel ID="pnlCart" runat="server"  Width="100%" ></asp:Panel>
</td>
</tr></table>

</td>
</tr>


</table>


<br />
<table width="100%" >
<tr>
<td align="left" width="25%" > <asp:Button ID="btnBackToHome"   
        CssClass="buttonAction"  runat="server" Text="BackToHome" 
        onclick="btnBackToHome_Click" /></td>
<td align="center" ><asp:Button ID="btnOrderSubmit"   
        CssClass="buttonAction"  runat="server" Text="Order Submit" 
        onclick="btnOrderSubmit_Click" /></td>
</tr>
</table> 



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>

