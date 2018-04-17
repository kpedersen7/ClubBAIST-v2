<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewStandingReservations.aspx.cs" Inherits="ViewStandingReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        td{
          border:1px solid black;   
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 runat="server" id="H2Title"></h2>
    <asp:Panel runat="server" ID="StandingReservations">
        <asp:Table runat="server" ID="StandingReservationsTable">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Member Name</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Course</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Start Date</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">End Date</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Time</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Holes</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Carts</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Player 2</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Player 3</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Player 4</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    </asp:Panel>
    <asp:LinkButton runat="server" ID="ApprovedReservationsButton" OnClick="ApprovedReservations_Click">View Approved Reservations</asp:LinkButton>
    <asp:LinkButton runat="server" ID="PendingReservationsButton" OnClick="PendingReservations_Click">View Pending Reservations</asp:LinkButton>
</asp:Content>

