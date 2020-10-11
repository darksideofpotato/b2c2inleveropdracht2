<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="manageUsers.aspx.cs" Inherits="b2c2inleveropdracht2.manageUsers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <h2> Manage Users</h2>
    <p> This page displays all the current users in the database. User information can be seen, edited, deleted and added.</p>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="collectionId" DataSourceID="SqlDataSource1" AllowPaging="True" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" GridLines="Both">
        <EditItemTemplate>
            collectionId:
            <asp:Label ID="collectionIdLabel1" runat="server" Text='<%# Eval("collectionId") %>' />
            <br />
            userName:
            <asp:TextBox ID="userNameTextBox" runat="server" Text='<%# Bind("userName") %>' />
            <br />
            userRol:
            <asp:TextBox ID="userRolTextBox" runat="server" Text='<%# Bind("userRol") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" CssClass="allButtons" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="allButtons" />
        </EditItemTemplate>
        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
        <InsertItemTemplate>
            userName:
            <asp:TextBox ID="userNameTextBox" runat="server" Text='<%# Bind("userName") %>' />
            <br />
            userRol:
            <asp:TextBox ID="userRolTextBox" runat="server" Text='<%# Bind("userRol") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" CssClass="allButtons" />
        </InsertItemTemplate>
        <ItemTemplate>
            collectionId:
            <asp:Label ID="collectionIdLabel" runat="server" Text='<%# Eval("collectionId") %>' />
            <br />
            userName:
            <asp:Label ID="userNameLabel" runat="server" Text='<%# Bind("userName") %>' />
            <br />
            userRol:
            <asp:Label ID="userRolLabel" runat="server" Text='<%# Bind("userRol") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" CssClass="allButtons" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" CssClass="allButtons" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" CssClass="allButtons" />
        </ItemTemplate>
        <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
    </asp:FormView>
    <br />
    <asp:GridView ID="userGridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="collectionId" DataSourceID="SqlDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
        <Columns>
            <asp:BoundField DataField="collectionId" HeaderText="collectionId" InsertVisible="False" ReadOnly="True" SortExpression="collectionId" />
            <asp:BoundField DataField="userName" HeaderText="userName" SortExpression="userName" />
            <asp:BoundField DataField="userRol" HeaderText="userRol" SortExpression="userRol" />
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
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:CollectionsDBConnectionString %>" DeleteCommand="DELETE FROM [Collections] WHERE [collectionId] = @original_collectionId AND [userName] = @original_userName AND [userRol] = @original_userRol" InsertCommand="INSERT INTO [Collections] ([userName], [userRol]) VALUES (@userName, @userRol)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Collections]" UpdateCommand="UPDATE [Collections] SET [userName] = @userName, [userRol] = @userRol WHERE [collectionId] = @original_collectionId AND [userName] = @original_userName AND [userRol] = @original_userRol">
        <DeleteParameters>
            <asp:Parameter Name="original_collectionId" Type="Int32" />
            <asp:Parameter Name="original_userName" Type="String" />
            <asp:Parameter Name="original_userRol" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="userName" Type="String" />
            <asp:Parameter Name="userRol" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="userName" Type="String" />
            <asp:Parameter Name="userRol" Type="String" />
            <asp:Parameter Name="original_collectionId" Type="Int32" />
            <asp:Parameter Name="original_userName" Type="String" />
            <asp:Parameter Name="original_userRol" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>
