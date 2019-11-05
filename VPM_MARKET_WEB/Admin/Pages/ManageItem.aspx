<%@ Page Title="" Language="C#" MasterPageFile="~/Master/VPM_Master_Admin.master" AutoEventWireup="true" CodeFile="ManageItem.aspx.cs" Inherits="Admin_Pages_ManageItem" %>
<%@ Register src="~/Controls/AdminMenu.ascx" tagname="adminMenu" tagprefix="ucAdminMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderSubMenu" Runat="Server">
<h3><span  class="sectionHeader" >Manage Item</span></h3>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
 <ucAdminMenu:adminMenu ID="adminMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainPlaceHolder" Runat="Server">
<script language="javascript">

    function onDeleteSelection(AFFILIATE_ID, AFFILIATE_CODE, AFFILIATE_NAME, AFFILIATE_ABBR, Active , SubCategoryId , SubCategoryName , ItemImagePath ,ItemIsStock ) {

        // objDeleteParam = document.getElementById(hdnDeleteClientId);
        objDeleteParam = document.getElementById('ctl00_MainPlaceHolder_htnDelete');


        objClientHitParam = document.getElementById('ctl00_MainPlaceHolder_hdnClientHit');


        //objOperationMode = document.getElementById(hdnOperationModeClientId);
        objOperationMode = document.getElementById('ctl00_MainPlaceHolder_hdnOperationMode');

        //alert("hdnProSelectedChargesClientId --" + objPro.value);
        if (objDeleteParam != null) {
            // alert(objDeleteParam.value);
            objDeleteParam.value = AFFILIATE_ID + '@' + AFFILIATE_CODE + '@' + AFFILIATE_NAME + '@' + AFFILIATE_ABBR;
        }
        if (objOperationMode != null) {
            // alert(objOperationMode.value);
            objOperationMode.value = "DELETE";
            objClientHitParam.value = "TRUE";
        }

       // alert(objOperationMode.value);
        //alert(objDeleteParam.value);
    }

    function onEditSelection(AFFILIATE_ID, AFFILIATE_CODE, AFFILIATE_NAME, AFFILIATE_ABBR, Active, SubCategoryId, SubCategoryName, ItemImagePath, ItemIsStock) {
        //alert('START');
        // objEdit = document.getElementById(hdnEditClientId);
        // objOperationMode = document.getElementById(hdnOperationModeClientId);
        objEdit = document.getElementById('ctl00_MainPlaceHolder_hdnEdit');
        objClientHitParam = document.getElementById('ctl00_MainPlaceHolder_hdnClientHit');
        objOperationMode = document.getElementById('ctl00_MainPlaceHolder_hdnOperationMode');
        if (objEdit != null) {
            objEdit.value = AFFILIATE_ID + '@' + AFFILIATE_CODE + '@' + AFFILIATE_NAME + '@' + AFFILIATE_ABBR + '@' + Active + '@' + SubCategoryId + '@' + SubCategoryName + '@' + ItemImagePath + '@' + ItemIsStock;
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
                <label class="customerInformationFrame"><H2>Manage Items. </H2></label>
            </td>
        </tr>--%>
      
        <tr>
            <td align="right" >
              <asp:Button ID="btnAddAffiliate" runat="server" Text="Add Item"  CssClass="buttonAction"  OnClick="AddAffiliate" />
            </td>
        </tr>
      
        <tr>
            <td>
                <asp:Panel ID="pnlAffiliateABB" runat="server" ></asp:Panel>
            </td>
        </tr>
        </table>

        
        <div id="divAddEdit"  class="editDeleteSection" runat="server" visible= "false"  >
        <table width="100%" >

        <tr>
        <td width="25%" colspan=2"  class="gridHeader" >
       <b><span style="EditDeleteHeader" >Add /Edit Item</span></b> 
        </td>
       
        </tr>
         <tr>
        <td width="25%" colspan="2"  >
       <br />

        </td>
        </tr>
        <tr>
        <td width="25%" align="left" >
        <b><span class="labelSection" style="visibility:hidden;" >Item Id</span></b>
        </td>
        <td  width="75%" align="left" >
        <asp:TextBox ID="txtItemId" runat="server"   Visible="false" ReadOnly="true" Width="300px" ></asp:TextBox>
        <%--<asp:DropDownList ID="ddlAffiliateCode" runat="server" ></asp:DropDownList>--%>
        </td>
        </tr>
        
        
        <tr>
        <td width="25%" align="left" >
         <b><span class="labelSection">Item Name</span></b>
   
        </td>
        <td  width="75%" align="left" >
        <asp:TextBox ID="txtItemName" runat="server" Width="300px" ></asp:TextBox>
        <%--<asp:DropDownList ID="ddlAffiliateCode" runat="server" ></asp:DropDownList>--%>

        </td>
        </tr>

         <tr>
        <td width="25%" align="left" >
         <b><span class="labelSection">Item Description</span></b>

        </td>
        <td  width="75%" align="left" >
        
        <asp:TextBox ID="txtDescription" runat="server"   TextMode="MultiLine"  Height="100px" Width="300px" ></asp:TextBox>
        

        </td>
        </tr>
         <tr>
            <td width="25%" align="left" >
                <b><span class="labelSection">Item Price</span></b>
            </td>
            <td  width="75%" align="left" >
                <asp:TextBox ID="txtItemPrice" runat="server"  MaxLength="10" Width="50px" ></asp:TextBox>
            </td>
        </tr>
        
         <tr>
        <td width="25%" align="left" >
        <b><span class="labelSection"  >Item ImagePath </span></b>
        </td>
        <td  width="75%" align="left" >
        <INPUT type=file id="fileItemImagegPath" name="File1" runat="server" />
        </br>
            <asp:Image ID="imgItem" runat="server" />
        <asp:TextBox ID="txtItemImagePath" runat="server"   Visible="false"  ReadOnly="true" Width="300px" ></asp:TextBox>
        <%--<asp:DropDownList ID="ddlAffiliateCode" runat="server" ></asp:DropDownList>--%>
        </td>
        </tr>
         <tr>
        <td width="25%" align="left" >
        <b><span class="labelSection"   style="visibility:hidden;" >SubCategoryId</span></b>
        </td>
        <td  width="75%" align="left" >
        <asp:TextBox ID="txtSubCategoryId" runat="server"    Visible="false"  ReadOnly="true" Width="300px" ></asp:TextBox>
        <%--<asp:DropDownList ID="ddlAffiliateCode" runat="server" ></asp:DropDownList>--%>
        </td>
        </tr>
        <tr>
            <td width="25%" align="left" >
                 <b><span class="labelSection">Sub Category</span></b>
            </td>
            <td  width="75%" align="left" >
                <asp:DropDownList ID="ddlSubCategory" runat="server" >
               
               </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td width="25%" align="left" >
                 <b><span class="labelSection"> Item Available In Stock</span></b>
            </td>
            <td  width="75%" align="left" >
                <asp:DropDownList ID="ddlItemIsStock" runat="server" >
                <asp:ListItem Text="True" Value="True" Selected="True" ></asp:ListItem>
                <asp:ListItem Text="False" Value="False"   ></asp:ListItem>
               </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td width="25%" align="left" >
                 <b><span class="labelSection"> Item Active</span></b>
            </td>
            <td  width="75%" align="left" >
                <asp:DropDownList ID="ddlItemActive" runat="server" >
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
       <b><span style="EditDeleteHeader" >Delete Confirmation</span> </b> 
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

