<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Login</h2>

    <asp:Label runat="server">Username</asp:Label>
    <asp:TextBox runat="server" ID="UserEmail"></asp:TextBox>
    <asp:Label runat="server">Password</asp:Label>
    <asp:TextBox runat="server" ID="Password"></asp:TextBox>
    <asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="SubmitButton_Click" />
    <asp:Label runat="server" ID="Msg"></asp:Label>
</asp:Content>

