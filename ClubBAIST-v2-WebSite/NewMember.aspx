<%@ Page Title="Register New Member" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewMember.aspx.cs" Inherits="NewMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Register A New Member</h2>

    <asp:Label runat="server">Email</asp:Label>
    <asp:TextBox runat="server" ID="EmailTB"></asp:TextBox>
    <asp:Label runat="server">Password</asp:Label>
    <asp:TextBox runat="server" ID="PasswordTB"></asp:TextBox>
    <asp:Label runat="server">First Name</asp:Label>
    <asp:TextBox runat="server" ID="FirstNameTB"></asp:TextBox>
    <asp:Label runat="server">Last Name</asp:Label>
    <asp:TextBox runat="server" ID="LastNameTB"></asp:TextBox>
    <asp:Label runat="server">Phone</asp:Label>
    <asp:TextBox runat="server" ID="PhoneTB"></asp:TextBox>
    <asp:Label runat="server">Membership Level</asp:Label>
    <asp:DropDownList runat="server" ID="MembershipLevelDD">
    </asp:DropDownList>
    <asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="SubmitButton_Click" />
</asp:Content>

