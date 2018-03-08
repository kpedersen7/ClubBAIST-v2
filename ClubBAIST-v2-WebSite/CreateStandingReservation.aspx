<%@ Page Title="Request Standing Reservation" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CreateStandingReservation.aspx.cs" Inherits="CreateStandingReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2>Request Standing Reservation</h2>

    <asp:Panel runat="server" ID="AStuff">
        <asp:Label runat="server" Text="Search for member:"></asp:Label>
        <asp:TextBox runat="server" ID="UserSearchTB"></asp:TextBox>
        <asp:LinkButton runat="server" ID="UserSearchButton" OnClick="UserSearchButton_Click" Text="Search"></asp:LinkButton>
    </asp:Panel>

    <asp:Calendar runat="server" OnSelectionChanged="DaySelected" ID="Calendar"></asp:Calendar>

    <label runat="server">Until</label>
    <asp:Calendar runat="server" OnSelectionChanged="DaySelected" ID="EndCalendar"></asp:Calendar>

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

    <asp:Label runat="server">Player 2</asp:Label>
    <asp:TextBox runat="server" ID="Player2TB"></asp:TextBox>

    <asp:Label runat="server">Player 3</asp:Label>
    <asp:TextBox runat="server" ID="Player3TB" ></asp:TextBox>

    <asp:Label runat="server">Player 4</asp:Label>
    <asp:TextBox runat="server" ID="Player4TB"></asp:TextBox>

    <asp:Button runat="server" ID="SubmitButton" Text="Submit" OnClick="SubmitButton_Click"/>
    <asp:Label runat="server" ID="msg"></asp:Label>
</asp:Content>

