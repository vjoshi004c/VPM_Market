<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Master_Admin.master" AutoEventWireup="true" CodeFile="ManageCategory.aspx.cs" Inherits="Admin_Pages_ManageCategory" %>
<%@ Register src="~/Controls/AdminMenu.ascx" tagname="adminMenu" tagprefix="ucAdminMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSubMenu" Runat="Server">
<h3><span  class="sectionHeader" >Manage Category</span></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
 <ucAdminMenu:adminMenu ID="adminMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
<script language="javascript">

    function onDeleteSelection(CategoryID, CategoryName, CategoryDescription, Active) {

        // objDeleteParam = document.getElementById(hdnDeleteClientId);
        objDeleteParam = document.getElementById('ctl00_MainPlaceHolder_htnDelete');


        objClientHitParam = document.getElementById('ctl00_MainPlaceHolder_hdnClientHit');


        //objOperationMode = document.getElementById(hdnOperationModeClientId);
        objOperationMode = document.getElementById('ctl00_MainPlaceHolder_hdnOperationMode');

        //alert("hdnProSelectedChargesClientId --" + objPro.value);
        if (objDeleteParam != null) {
            // alert(objDeleteParam.value);
            objDeleteParam.value = CategoryID + '@' + CategoryName + '@' + CategoryDescription + '@' + Active;
        }
        if (objOperationMode != null) {
            // alert(objOperationMode.value);
            objOperationMode.value = "DELETE";
            objClientHitParam.value = "TRUE";
        }

       // alert(objOperationMode.value);
        //alert(objDeleteParam.value);
    }

    function onEditSelection(CategoryID, CategoryName, CategoryDescription, Active) {
        //alert('START');
        // objEdit = document.getElementById(hdnEditClientId);
        // objOperationMode = document.getElementById(hdnOperationModeClientId);
        objEdit = document.getElementById('ctl00_MainPlaceHolder_hdnEdit');
        objClientHitParam = document.getElementById('ctl00_MainPlaceHolder_hdnClientHit');
        objOperationMode = document.getElementById('ctl00_MainPlaceHolder_hdnOperationMode');
        if (objEdit != null) {
            objEdit.value = CategoryID + '@' + CategoryName + '@' + CategoryDescription + '@' + Active;
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
                <label class="customerInformationFrame"><H2>Manage categorys. </H2></label>
            </td>
        </tr>--%>
      
        <tr>
            <td align="right" >
              <asp:Button ID="btnAddCategory" runat="server" Text="Add category"  CssClass="buttonAction"  OnClick="AddCategory" />
            </td>
        </tr>
      
        <tr>
            <td>
                <asp:Panel ID="pnlCategoryABB" runat="server" ></asp:Panel>
            </td>
        </tr>
        </table>

        
        <div id="divAddEdit"  class="editDeleteSection" runat="server" visible= "false"  >
        <table width="100%" >

        <tr>
        <td width="25%" colspan=2"  class="gridHeader" >
       <b><span style="EditDeleteHeader" >Add /Edit Category</span></b> 
        </td>
       
        </tr>
         <tr>
        <td width="25%" colspan="2"  >
       <br />

        </td>
        </tr>
        <tr>
        <td width="25%" align="left" >
        <b><span class="labelSection"  style="visibility:hidden" ><Category Id</span></b>
        </td>
        <td  width="75%" align="left" >
        <asp:TextBox ID="txtcategoryId" runat="server"  visible="false" ReadOnly="true" Width="300px" ></asp:TextBox>
        <%--<asp:DropDownList ID="ddlCategoryCode" runat="server" ></asp:DropDownList>--%>

        </td>
        </tr>
        
        
        <tr>
        <td width="25%" align="left" >
         <b><span class="labelSection">Cateogory Name</span></b>
   
        </td>
        <td  width="75%" align="left" >
        <asp:TextBox ID="txtcategoryName" runat="server" Width="300px"  MaxLength="50" ></asp:TextBox>
        <%--<asp:DropDownList ID="ddlCategoryCode" runat="server" ></asp:DropDownList>--%>

        </td>
        </tr>

         <tr>
        <td width="25%" align="left" >
         <b><span class="labelSection">Category Description</span></b>

        </td>
        <td  width="75%" align="left" >
        
        <asp:TextBox ID="txtDescription" runat="server"   TextMode="MultiLine"  Height="100px" Width="300px" ></asp:TextBox>
        

        </td>
        </tr>
         <tr>
        <td width="25%" align="left" >
         <b><span class="labelSection">Active</span></b>
        </td>
        <td  width="75%" align="left" >
        <%--<asp:TextBox ID="txtcategoryActive" runat="server"  MaxLength="10" Width="50px" ></asp:TextBox>--%>
         <asp:DropDownList ID="ddlActive" runat="server" >
            <asp:ListItem Text="True" Value="True" Selected="True" ></asp:ListItem>
            <asp:ListItem Text="False" Value="False"   ></asp:ListItem>
           </asp:DropDownList>

        </td>
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
       <b><span style="EditDeleteHeader" >Category :Delete Confirmation</span> </b> 
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


