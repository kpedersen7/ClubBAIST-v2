<%@ Page Title="View Reservations" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewReservations.aspx.cs" Inherits="ViewReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-12">
            <h2>View Reservations</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Label runat="server" ID="msg"></asp:Label>
        </div>
    </div>
    <asp:Panel runat="server" ID="MemberSearch" CssClass="row">
        <div class="col-12">
            <asp:Table runat="server" ID="SearchTable">
                <asp:TableRow>
                    <asp:TableCell><asp:Label runat="server" Text="Search for member:"></asp:Label></asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="UserSearchTB"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton runat="server" ID="UserSearchButton" OnClick="UserSearchButton_Click" Text="Search"></asp:LinkButton>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="FoundUsers">
        <div class="col-12">
            <asp:Label runat="server" ID="FoundUsersTableLabel" Font-Size="X-Large">Found Members</asp:Label>
            <asp:Table runat="server" ID="FoundUsersTable"></asp:Table>
        </div>
    </asp:Panel>
    <div class="row">
        <div class="col-12">
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Filter by time frame: </asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" TextMode="Date" ID="MinDay"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        TO
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" TextMode="Date" ID="MaxDay"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:LinkButton runat="server" ID="SearchByTimeFrameButton" OnClick="SearchByTimeFrameButton_Click" Text="Filter" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Table runat="server" ID="TeeTimesTable" Width="100%">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Member</asp:TableHeaderCell>
                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Date</asp:TableHeaderCell>
                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Reserved Time</asp:TableHeaderCell>
                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Course</asp:TableHeaderCell>
                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Golf Carts</asp:TableHeaderCell>
                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Holes</asp:TableHeaderCell>
                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Player 2 Email</asp:TableHeaderCell>
                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Player 3 Email</asp:TableHeaderCell>
                    <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Player 4 Email</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>

