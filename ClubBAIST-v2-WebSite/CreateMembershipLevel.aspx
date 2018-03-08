<%@ Page Title="Create Membership Level" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateMembershipLevel.aspx.cs" Inherits="CreateMembershipLevel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Create New Membership Level</h2>
    <asp:Label runat="server">Membership Level Name</asp:Label>
    <asp:TextBox runat="server" ID="DescriptionTB"></asp:TextBox>
    <asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="SubmitButton_Click"/>
</asp:Content>

