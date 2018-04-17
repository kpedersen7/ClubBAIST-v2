<%@ Page Title="Update Standing Reservation Request" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateStandingReservation.aspx.cs" Inherits="UpdateStandingReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-12"><h2>Update Standing Reservation</h2></div>
    </div>
    <div class="row">
        <div class="col-6">
            <h3>From</h3>
            <asp:Calendar runat="server" OnSelectionChanged="DaySelected" ID="Calendar"></asp:Calendar>
            <h3 runat="server">Until</h3>
            <asp:Calendar runat="server" OnSelectionChanged="DaySelected" ID="EndCalendar"></asp:Calendar>
        </div>
        <div class="col-6">
            <asp:Table runat="server" ID="StandingReservationTable">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Time</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="TeeTimesDD">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Course</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="CourseDD">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Holes</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="NumberHolesDD">
                <asp:ListItem Value="1">Front 9</asp:ListItem>
                <asp:ListItem Value="2">Back 9</asp:ListItem>
                <asp:ListItem Value="3">18 Holes</asp:ListItem>
            </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Carts</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="NumberCartsDD">
                <asp:ListItem Value="1">1</asp:ListItem>
                <asp:ListItem Value="2">2</asp:ListItem>
            </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Player 2</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="Player2TB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Player 3</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="Player3TB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Player 4</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="Player4TB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:LinkButton runat="server" ID="SubmitButton" Text="Update" OnClick="SubmitButton_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>   
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Button runat="server" ID="Approve" Text="Approve This Standing Reservation" OnClick="Approve_Click" />
        </div>
    </div>
</asp:Content>

