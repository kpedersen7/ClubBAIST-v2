<%@ Page Title="Update Tee Time" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateReservation.aspx.cs" Inherits="UpdateReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <h2>Update Existing Tee Time</h2>
    <div class="row">
        <div class="col-6">
            <asp:Calendar runat="server" OnSelectionChanged="DaySelected" ID="Calendar"></asp:Calendar>
        </div>
        <div class="col-6">
            <asp:Table runat="server">
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
                        <asp:Label runat="server">Player 2 Email</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="Player2TB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Player 3 Email</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="Player3TB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Player 4 Email</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="Player4TB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button runat="server" Text="Submit" ID="SubmitButton" OnClick="SubmitButton_Click" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>

