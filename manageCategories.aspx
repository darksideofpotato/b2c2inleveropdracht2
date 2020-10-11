<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="manageCategories.aspx.cs" Inherits="b2c2inleveropdracht2.manageCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2> An overview of all categories </h2>
    <asp:Button class="allButtons" ID="addCategoryButton" runat="server" Text="Add or edit a category" OnClick="addCategoryButton_Click" />
    <div id="addCategoryForm" runat="server">
            <asp:Label ID="idLabel" runat="server" Text=""></asp:Label>
        <asp:DropDownList ID="dropDownCountryName" runat="server" DataSourceID="SqlDataSource2" DataTextField="countryName" DataValueField="countryId"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CollectionsDBConnectionString %>" SelectCommand="SELECT * FROM [Countries]"></asp:SqlDataSource>
        <asp:DropDownList ID="DropDownTasteName" runat="server" DataSourceID="SqlDataSource3" DataTextField="tasteName" DataValueField="tasteId"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:CollectionsDBConnectionString %>" SelectCommand="SELECT * FROM [Tastes]"></asp:SqlDataSource>
        <asp:DropDownList ID="DropDownTypeName" runat="server" DataSourceID="SqlDataSource4" DataTextField="typeName" DataValueField="typeId"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:CollectionsDBConnectionString %>" SelectCommand="SELECT * FROM [Types]"></asp:SqlDataSource>
          <asp:Button class="allButtons" ID="addCategory" runat="server" Text="Add" OnClick="addCategory_Click" />
           <asp:Button class="allButtons" ID="updateCategory" runat="server" Text="Update" OnClick="updateCategory_Click" />
        </div>

    <asp:GridView ID="gridViewCategories" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="categoryId" DataSourceID="SqlDataSource1" OnRowCommand="gridViewCategories_RowCommand" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
        <Columns>
            <asp:BoundField DataField="categoryId" HeaderText="categoryId" ReadOnly="True" SortExpression="categoryId" />
            <asp:BoundField DataField="countryName" HeaderText="countryName" SortExpression="countryName" />
            <asp:BoundField DataField="tasteName" HeaderText="tasteName" SortExpression="tasteName" />
            <asp:BoundField DataField="typeName" HeaderText="typeName" SortExpression="typeName" />
            <asp:ButtonField ButtonType="Button" CommandName="editCategory" HeaderText="Edit" ShowHeader="True" Text="Edit" ControlStyle-CssClass="allButtons" >
<ControlStyle CssClass="allButtons"></ControlStyle>
            </asp:ButtonField>
            <asp:ButtonField ButtonType="Button" CommandName="deleteCategory" HeaderText="Delete" ShowHeader="True" Text="Delete" ControlStyle-CssClass="allButtons" >
<ControlStyle CssClass="allButtons"></ControlStyle>
            </asp:ButtonField>
        </Columns>
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FFF1D4" />
        <SortedAscendingHeaderStyle BackColor="#B95C30" />
        <SortedDescendingCellStyle BackColor="#F1E5CE" />
        <SortedDescendingHeaderStyle BackColor="#93451F" />
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CollectionsDBConnectionString %>" SelectCommand="SELECT * FROM [categoryView]"></asp:SqlDataSource>
</asp:Content>
