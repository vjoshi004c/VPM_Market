<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="Controls_AdminMenu" %>

<table width="100%"   style="vertical-align:top" >
    <tr>
        <td  align="left" id="tdUser" class="tdMenu" runat="server" >
<%--<asp:LinkButton ID="lnkUser" runat="server"  PostBackUrl="#"  Text="Manage User" ></asp:LinkButton>--%>
 <asp:HyperLink id="hlkUser" runat="server"  CssClass="linkMenu"  Font-Underline="false" Text="Mangeg User" NavigateUrl="~/Admin/Pages/ManageUser.aspx?Mode=MU"></asp:HyperLink>
        </td>
    </tr>
    
    <tr>
        <td align="left"  id="tdCategory"  class="tdMenu" runat="server" >
         <asp:HyperLink id="hlkCategory" runat="server"  Font-Underline="false" CssClass="linkMenu"   Text="Manage Category" NavigateUrl="~/Admin/Pages/ManageCategory.aspx?Mode=MC"></asp:HyperLink>

        </td>
    </tr>
    <tr>
        <td align="left" id="tdSubCategory" class="tdMenu" runat="server" >
        <asp:HyperLink id="hlkSubCategory" runat="server"  Font-Underline="false" CssClass="linkMenu"   Text="Manage Sub Category" NavigateUrl="~/Admin/Pages/ManageSubCategory.aspx?Mode=MSC"></asp:HyperLink>

        </td>
    </tr>
    <tr>
        <td align="left" id="tdItem" class="tdMenu" runat="server" >
        <asp:HyperLink id="hlkItem" runat="server"  CssClass="linkMenu"   Font-Underline="false" Text="Manage Item" NavigateUrl="~/Admin/Pages/ManageItem.aspx?Mode=MI"></asp:HyperLink>
       <%-- <a href="../../Admin/Pages/ManageItem.aspx" >Manage Item</a>--%>
<%--<asp:LinkButton ID="lnkManageItem" runat="server"  PostBackUrl="/ManageItem.aspx" Text="Manage Item" ></asp:LinkButton>--%>
        </td>
    </tr>
    <tr>
        <td align="left"  id="tdViewOrder" class="tdMenu" runat="server" >

<asp:HyperLink id="hlkViewOrder" runat="server"  CssClass="linkMenu"   Font-Underline="false" Text="View Order" NavigateUrl="~/Admin/Pages/ViewOrder.aspx?Mode=VO"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td align="left" id="tdViewLogs" class="tdMenu" runat="server" >
        <asp:HyperLink id="hlkViewLogs" runat="server"  CssClass="linkMenu"   Font-Underline="false" Text="View Logs" NavigateUrl="~/Admin/Pages/ViewLogs.aspx?Mode=VL"></asp:HyperLink>

        </td>
    </tr>
    <tr>
        <td align="left"  id="tdGroup" class="tdMenu" runat="server"  >
        <asp:HyperLink id="hlkGroup" runat="server"  Font-Underline="false"  CssClass="linkMenu"  Text="Manage Group" NavigateUrl="~/Admin/Pages/ManageGroup.aspx?Mode=MG"></asp:HyperLink>

        </td>
    </tr>
</table>