﻿<%@ Page Title="Register New Member" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewMember.aspx.cs" Inherits="NewMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-12">
            <h2>Register A New Member</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Email</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="EmailTB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Password</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="PasswordTB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">First Name</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="FirstNameTB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Last Name</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="LastNameTB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Phone</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="PhoneTB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Membership Level</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="MembershipLevelDD">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="SubmitButton_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>

