<%@ Page Title="Edit Existing Member" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateMember.aspx.cs" Inherits="UpdateMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Edit Existing Member</h2>
    <asp:Label runat="server">Find a member</asp:Label>
    <asp:TextBox runat="server" ID="FindMemberTB"></asp:TextBox>

    <asp:TextBox runat="server" ID="EmailTB"></asp:TextBox>
    <asp:TextBox runat="server" ID="PasswordTB"></asp:TextBox>
    <asp:TextBox runat="server" ID="FirstNameTB"></asp:TextBox>
    <asp:TextBox runat="server" ID="LastNameTB"></asp:TextBox>
    <asp:TextBox runat="server" ID="PhoneTB"></asp:TextBox>
    <asp:DropDownList runat="server" ID="MembershipLevelDD"></asp:DropDownList>
    <asp:Button runat="server" ID="SubmitButton" Text="Submit"/>
</asp:Content>

