<%@ Page Title="Book New Tee Time" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateReservation.aspx.cs" Inherits="CreateReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Book New Tee Time</h2>
    <asp:Calendar runat="server" OnSelectionChanged="DaySelected" ID="Calendar"></asp:Calendar>

    <asp:Panel runat="server" ID="AStuff">
        <asp:Label runat="server" Text="Search for member:"></asp:Label>
        <asp:TextBox runat="server" ID="UserSearchTB"></asp:TextBox>
        <asp:LinkButton runat="server" ID="UserSearchButton" OnClick="UserSearchButton_Click" Text="Search"></asp:LinkButton>
    </asp:Panel>

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

    <asp:Button runat="server" Text="Submit" ID="SubmitButton" OnClick="SubmitButton_Click" />
    <asp:Label runat="server" ID="msg"></asp:Label>
</asp:Content>

