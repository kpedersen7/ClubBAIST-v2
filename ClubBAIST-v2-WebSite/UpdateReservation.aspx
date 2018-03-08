<%@ Page Title="Update Tee Time" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateReservation.aspx.cs" Inherits="UpdateReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <h2>Update Existing Tee Time</h2>

    <asp:Calendar runat="server" OnSelectionChanged="DaySelected" ID="Calendar"></asp:Calendar>

    <asp:Label runat="server">Time</asp:Label>
    <asp:DropDownList runat="server" ID="TeeTimesDD">
    </asp:DropDownList>

    <asp:Label runat="server">Course</asp:Label>
    <asp:DropDownList runat="server" ID="CourseDD">
    </asp:DropDownList>

    <asp:Label runat="server">Holes</asp:Label>
    <asp:DropDownList runat="server" ID="NumberHolesDD">
        <asp:ListItem Value="1">Front 9</asp:ListItem>
        <asp:ListItem Value="2">Back 9</asp:ListItem>
        <asp:ListItem Value="3">18 Holes</asp:ListItem>
    </asp:DropDownList>

    <asp:Label runat="server">Carts</asp:Label>
    <asp:DropDownList runat="server" ID="NumberCartsDD">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
    </asp:DropDownList>

    <asp:Label runat="server">Number of Players</asp:Label>
    <asp:DropDownList runat="server" ID="NumberPlayerDD">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem Value="4">4</asp:ListItem>
    </asp:DropDownList>

    <asp:Button runat="server" Text="Submit" ID="SubmitButton" OnClick="SubmitButton_Click"/>
</asp:Content>

