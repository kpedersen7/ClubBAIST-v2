<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewStandingReservations.aspx.cs" Inherits="ViewStandingReservations" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h2 runat="server" id="H2Title"></h2>
    <asp:Panel runat="server" ID="StandingReservations"></asp:Panel>
    <asp:LinkButton runat="server" ID="ApprovedReservations" OnClick="ApprovedReservations_Click">View Approved Reservations</asp:LinkButton>
</asp:Content>

