<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Market.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<%@ Register src="~/Controls/CategoryMenu.ascx" tagname="categoryMenu" tagprefix="ucCategoryMenu" %>
<%@ Register src="~/Controls/SubCategory.ascx"tagname="subCategoryMenu" tagprefix="ucSubCategoryMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSubMenu" Runat="Server">

<h3><span  class="sectionHeader"  style="vertical-align:middle;"  ><a href="Home.aspx"  style="color:White;" > Home</a></span></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">

 <ucCategoryMenu:categoryMenu ID="categoryMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
<asp:Image ID="imgMainContentThird" runat="server"  ImageUrl="~/IMAGES/MainContentThird.jpg" Visible="false" />
<asp:Image ID="imgMainContentSecond" runat="server"  ImageUrl="~/IMAGES/MainContent2.jpg" Visible="false" />
<asp:Image ID="imgMainContentFirst" runat="server"  ImageUrl="~/IMAGES/ContentHome1.jpg"  Visible="false" />


<ucSubCategoryMenu:subCategoryMenu ID="subCategoryMenu2" runat="server" />

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
<%--<asp:Image ID="Image1" runat="server"  ImageUrl="~/IMAGES/RightHomeFirst.jpg"   Width="200px" />--%>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>
