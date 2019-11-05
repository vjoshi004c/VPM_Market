<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Master_Admin.master" AutoEventWireup="true" CodeFile="ViewOrder.aspx.cs" Inherits="Admin_Pages_ViewOrder" %>
<%@ Register src="~/Controls/AdminMenu.ascx" tagname="adminMenu" tagprefix="ucAdminMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSubMenu" Runat="Server">
<h3><span  class="sectionHeader" >View Order</span></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
<ucAdminMenu:adminMenu ID="adminMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderFooter" Runat="Server">
</asp:Content>

