<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="manageWhiskeys.aspx.cs" Inherits="b2c2inleveropdracht2.manageWhiskeys" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Welcome to the manage whiskeys page</h2>
    <p>Here you can see the whiskeys per user, add new whiskeys, change current whiskey, delete whiskeys and check the 
    current profit margin of the whiskey in the 'sum value' column!
    </p>
    <p> Choose a user to see their collection </p>

        <asp:Label ID="collectorLabel" runat="server" Text="Collection of"></asp:Label>&nbsp; <asp:DropDownList ID="dropdownCollections" runat="server" DataSourceID="SqlDataSource1" DataTextField="userName" DataValueField="collectionId" AutoPostBack="True" OnSelectedIndexChanged="selectedIndexChanged_user">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CollectionsDBConnectionString %>" SelectCommand="SELECT * FROM [Collections]"></asp:SqlDataSource>
    <br /><br />
        <div id="addwhiskeyForm" runat="server">
            <asp:Label ID="idLabel" runat="server" Text="" ></asp:Label>
            <asp:Label ID="whiskeyNameLabel" runat="server" Text="Whiskey name"></asp:Label>&nbsp; <input id="whiskeyName" type="text" runat="server"/><br />
            <asp:Label ID="ageLabel" runat="server" Text="Age"></asp:Label>&nbsp; <input id="whiskeyAge" type="text" runat="server"/><br />
            <asp:Label ID="categoryLabel" runat="server" Text="Category"></asp:Label>&nbsp; <asp:DropDownList ID="dropDownCategory" runat="server" AutoPostBack="True" ></asp:DropDownList><br />
            <asp:Label ID="Valuelabel" runat="server" Text="Current value in euro's"></asp:Label>&nbsp; <input id="currentWhiskeyValue" type="text" runat="server"/><br />
            <asp:Label ID="priceLabel" runat="server" Text="Purchase price"></asp:Label>&nbsp; <input id="whiskeyPurchasePrice" type="text" runat="server"/><br />
            <asp:Label ID="descriptionLabel" runat="server" Text="Description"></asp:Label>&nbsp; <input id="whiskeyDescription" type="text" runat="server" multiple="multiple" /><br />
            <asp:Label ID="brandLabel" runat="server" Text="Brand"></asp:Label> &nbsp; <asp:DropDownList ID="whiskeyBrand" runat="server" DataSourceID="SqlDataSource2" DataTextField="brandName" DataValueField="brandId"></asp:DropDownList><br />
            <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:CollectionsDBConnectionString %>" SelectCommand="SELECT * FROM [Brands]"></asp:SqlDataSource>
            <asp:Label ID="percentageLabel" runat="server" Text="Alcohol percantage"></asp:Label>&nbsp; <input id="whiskeyAlcoholPercentage" type="text" runat="server"/><br />
            <asp:Label ID="sealedLabel" runat="server" Text="Is the bottle sealed?"></asp:Label>&nbsp; <asp:DropDownList ID="isWhiskeySealed" runat="server">
                <asp:ListItem Value="yes">Yes</asp:ListItem>
                <asp:ListItem Value="no">No</asp:ListItem>
            </asp:DropDownList><br />
            <asp:Label ID="ingredientLabel" runat="server" Text="Base ingredient"></asp:Label>&nbsp; <input id="whiskeyBaseIngredient" type="text" runat="server"/><br />
            <asp:Button class="allButtons" ID="addAWhiskey" runat="server" Text="Add!" OnClick="addAWhiskey_Click" />
            <asp:Button class="allButtons" ID="updateWhiskey" runat="server" Text="Update!" OnClick="updateWhiskey_Click" />
        </div>
     <br />
    <p>Sort the whiskeys by category</p>
    <asp:DropDownList ID="dropDownSortCategories" runat="server" AutoPostBack="True" ></asp:DropDownList>
    <br />
    <br />
    <asp:GridView ID="gridViewWhiskeys" runat="server" BackColor="#DEBA84" onrowcommand="gridViewWhiskeys_RowCommand" BorderColor ="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" AllowPaging="True" OnRowDataBound="whiskey_onRowDataBound">
        <Columns>
            
            <asp:TemplateField HeaderText="Sum value" runat="server">
               <ItemTemplate runat="server">
                    <asp:Label id="calculationLabel" runat="server" Text="Label"></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            
            <asp:ButtonField ButtonType="Button" CommandName="EditWhiskey" ShowHeader="True" Text="Edit" FooterStyle-VerticalAlign="NotSet" ControlStyle-CssClass="allButtons" />
            
            <asp:ButtonField ButtonType="Button" CommandName="deleteWhiskey" ShowHeader="true" Text="Delete" ControlStyle-CssClass="allButtons" />
           
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
    <br />
    <br />
</asp:Content>
