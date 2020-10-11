<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="b2c2inleveropdracht2.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Bepaalde style elementen zijn hier en bij de about page inline gecodeerd, omdat dit voor nu even makkelijker was dan een aparte
        id of class aanmaken om in de style.css te gaan bewerken. Uiteraard weet ik dat dit niet altijd de ideale
        'way to go' is. -->

    <h2 id="welkom"> Welcome to the Whiskey collection manager! </h2>
    <p style="margin:auto; text-align:center">In this web application you can manage your whiskey collection, along with its elaborate 
        categories, which you can manage too! You can also calculate the value of your whiskeys. 
        <br />
        Whether you like scotch, irish, bourbon or any other type!
        <br /><br /><br /><br /><img height="400px" src="Images/whiskey-and-natural-ice-royalty-free-image-533957701-1550830204.jpg" />
    </p>

</asp:Content>
