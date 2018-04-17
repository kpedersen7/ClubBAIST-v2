﻿<%@ Page Title="Login" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-12">
            <h2>Login</h2>
            <asp:Label runat="server" ID="Msg"></asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell><asp:Label runat="server">Username/Email</asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox runat="server" ID="UserEmail"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Label runat="server">Password</asp:Label></asp:TableCell>
                    <asp:TableCell><asp:TextBox runat="server" ID="Password"></asp:TextBox></asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell><asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="SubmitButton_Click" /></asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>

