<%@ Page Title="View Scores" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewScores.aspx.cs" Inherits="ViewScores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>View Scores</h2>
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
    <asp:Table runat="server" ID="ScoresTable" Width="100%">
        <asp:TableHeaderRow>
            <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Date</asp:TableHeaderCell>
            <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Reserved Time</asp:TableHeaderCell>
            <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Course</asp:TableHeaderCell>
            <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Score</asp:TableHeaderCell>
            <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">HandicapDifferential</asp:TableHeaderCell>
        </asp:TableHeaderRow>
    </asp:Table>
</asp:Content>

