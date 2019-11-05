<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Market.master" AutoEventWireup="true" CodeFile="ItemwithDetail.aspx.cs" Inherits="User_Pages_ItemwithDetail" %>

<%@ Register src="~/Controls/ItemDetail.ascx"  tagname="ItemDetail" tagprefix="ucItemDetail" %>
<%@ Register src="~/Controls/ItemMainMenu.ascx" tagname="ItemMainMenu" tagprefix="ucItemMainMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSubMenu" Runat="Server">

<h3><span  class="sectionHeader"  style="vertical-align:middle;"  ><a href="Home.aspx"  style="color:White;" > Home</a></span></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">

 <ucItemMainMenu:ItemMainMenu ID="ItemMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
<ucItemDetail:ItemDetail ID="itemDetail1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>


