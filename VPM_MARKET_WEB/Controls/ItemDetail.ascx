<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ItemDetail.ascx.cs" Inherits="Controls_ItemDetail" %>
<table width="100%"  cellpadding="0" cellspacing="0" >
<tr class="ItemNameLabel" >
<td width="5%" valign="top"  align="center" >
</td>
<td width="60%" >
<table  width="100%" >
<tr>
<td colspan="2"  align="left"   > <h1>Item Details</h1></td>
</tr>
<tr>
<td width="50%"  align="left" class="labelSection"  style="visibility:hidden;" > Item ID</td>
<td width="50%" align="left"  ><asp:TextBox ID="txtItemID"  Visible="false" runat="server"  BorderStyle="None" MaxLength="10" Width="250px"  ReadOnly="true" ></asp:TextBox></td>
</tr>
<tr>
<td width="50%" align="left" class="labelSection"  > Item Name</td>
<td width="50%" align="left" ><asp:TextBox ID="txtItemName" runat="server"  MaxLength="10" BorderStyle="None" Width="250px" ReadOnly="true" ></asp:TextBox></td>
</tr>
<tr>
<td width="50%" align="left"  valign="top" class="labelSection"  > Item Description </td>
<td width="50%" align="left" ><asp:Label ID="lblItemDescription"  BackColor="White" runat="server" BorderStyle="None"  Width="250px"  ReadOnly="true"  Height="200px"></asp:Label>
<%--</asp:Label><asp:TextBox ID="txtItemDescription" runat="server"  BorderStyle="None" MaxLength="10" Width="250px"  ReadOnly="true" TextMode="MultiLine" Height="200px" ></asp:TextBox>--%>
</td>
</tr>
<tr>
<td width="50%" align="left" class="labelSection"  > Price </td>
<td width="50%" align="left" ><asp:TextBox ID="txtPrice" runat="server"  BorderStyle="None"  MaxLength="10" Width="50px"  ReadOnly="true" ></asp:TextBox></td>
</tr>
<tr>
<td width="50%" align="left" class="labelSection"  > Quantity</td>
<td width="50%" align="left" ><asp:TextBox ID="txtQuantity" runat="server"   MaxLength="10" Width="50px"  ></asp:TextBox></td>
</tr>

<tr>
<td width="50%" align="left" class="labelSection"  ></br></td>
<td width="50%" align="left" ></td>
</tr>
<tr>
<td width="50%" align="left" class="labelSection"  ></td>
<td width="50%" align="center" ><asp:Button ID="btnAddToCart"   
        CssClass="buttonAction"  runat="server" Text="Add to Cart" 
        onclick="btnAddToCart_Click" />
        &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp
        
        <asp:Button ID="btnChechOut"   
        CssClass="buttonAction"  runat="server" Text="Check Out" 
        onclick="btnCheckOut_Click" />
        </td>
</tr>
</table>
</td>
<td width="30%" valign="center"  align="center" >
<asp:Image ID="imgItemDetail" runat="server"  ImageUrl="#"  Width="200px" Height="300px"  Visible="true" />

</td>
<td width="5%" valign="top"  align="center" >
</td>
</tr>
</table>


