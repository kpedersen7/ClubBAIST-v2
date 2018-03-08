<%@ Page Title="Update Existing Membership Level" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateMembershipLevel.aspx.cs" Inherits="UpdateMembershipLevel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Update Existing Membership Level</h2>
    <asp:Label runat="server">Select a membership level</asp:Label>
    <asp:DropDownList runat="server" ID="MembershipLevelDD"></asp:DropDownList>

    <asp:Label runat="server">Membership Level Name</asp:Label>
    <asp:TextBox runat="server" ID="DescriptionTB"></asp:TextBox>
    <asp:Button runat="server" ID="SubmitButton" Text="Submit"/>
</asp:Content>

