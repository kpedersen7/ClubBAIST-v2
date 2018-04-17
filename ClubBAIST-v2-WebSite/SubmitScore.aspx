<%@ Page Title="Submit Score" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SubmitScore.aspx.cs" Inherits="SubmitScore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h2>Submit New Score</h2>
    <p>Green boxes indicate that a score has already been submitted.</p>
    <asp:Panel runat="server" ID="PageControls">
        <asp:Panel runat="server" ID="MessageBox">
            <div class="alert alert-warning">
                WARNING: You will be overwriting an existing score!
            </div>
        </asp:Panel>
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

        <asp:Label runat="server" ID="FoundUsersTableLabel" Font-Size="X-Large">Found Members</asp:Label>
        <asp:Table runat="server" ID="FoundUsersTable">
        </asp:Table>

        <asp:Label runat="server" ID="ReservationsTableLabel" Font-Size="X-Large">Reservations for this member</asp:Label>
        <asp:Table runat="server" ID="ReservationsTable">
        </asp:Table>

        <asp:Label runat="server" ID="ThisReservationTableLabel" Font-Size="X-Large">This Reservation</asp:Label>
        <asp:Table runat="server" ID="ThisReservation" Width="100%" BorderStyle="Solid" BorderWidth="1">
            <asp:TableHeaderRow BorderStyle="Solid" BorderWidth="1">
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Date & Time</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Member Name</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Course</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Carts</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Holes</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Player 2</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Player 3</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">Player 4</asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>

        <asp:Table runat="server" ID="SelectUserTable">
            <asp:TableRow>
                <asp:TableCell>Submit score for: </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="UsersOnReservationDD"></asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>

        <asp:Label runat="server" ID="HoleScoresTableLabel" Font-Size="X-Large">Hole Scores</asp:Label>
        <asp:Table runat="server" ID="HoleScoresTable" Width="100%">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">1</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">2</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">3</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">4</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">5</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">6</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">7</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">8</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">9</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">10</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">11</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">12</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">13</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">14</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">15</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">16</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">17</asp:TableHeaderCell>
                <asp:TableHeaderCell BorderStyle="Solid" BorderWidth="1" BackColor="WhiteSmoke">18</asp:TableHeaderCell>
            </asp:TableHeaderRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par1">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par2">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par3">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par4">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par5">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par6">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par7">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par8">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par9">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par10">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par11">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par12">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par13">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par14">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par15">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par16">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par17">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:DropDownList runat="server" ID="Par18">
                        <asp:ListItem Value="0">0</asp:ListItem>
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="6">6</asp:ListItem>
                        <asp:ListItem Value="7">7</asp:ListItem>
                        <asp:ListItem Value="8">8</asp:ListItem>
                        <asp:ListItem Value="9">9</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                    </asp:DropDownList>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <asp:Button runat="server" ID="SubmitButton" OnClick="SubmitButton_Click" Text="Submit" />
    </asp:Panel>
    <div class="row">
        <div class="col-11"></div>
        <div class="col-1"><a href="SubmitScore.aspx">Start Over</a></div>
    </div>
</asp:Content>

