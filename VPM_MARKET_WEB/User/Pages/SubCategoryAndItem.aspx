<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Market.master" AutoEventWireup="true" CodeFile="SubCategoryAndItem.aspx.cs" Inherits="User_Pages_SubCategoryAndItem" %>

<%@ Register src="~/Controls/SubCategoryMenu.ascx" tagname="SubCategoryMenu" tagprefix="ucSubCategoryMenu" %>
<%@ Register src="~/Controls/ItemMenu.ascx" tagname="ItemMenu" tagprefix="ucItemMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSubMenu" Runat="Server">

<h3><span  class="sectionHeader"  style="vertical-align:middle;"  ><a href="Home.aspx"  style="color:White;" > Home</a></span></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">

 <ucSubCategoryMenu:SubCategoryMenu ID="categoryMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
<ucItemMenu:ItemMenu ID="subCategoryMenu2" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>

