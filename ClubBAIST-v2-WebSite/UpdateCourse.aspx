<%@ Page Title="Change Course Settings" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateCourse.aspx.cs" Inherits="UpdateCourse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-12">
            <h2>Change Course Settings</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Select a course:</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="CourseDD">
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Table runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label runat="server">Course Name</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="DescriptionTB"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Label runat="server">Hole Pars</asp:Label>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:Table runat="server">
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
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par2">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par3">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par4">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par5">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par6">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par7">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par8">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par9">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par10">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par11">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par12">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par13">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par14">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par15">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par16">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par17">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="Par18">
                            <asp:ListItem Value="1">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Course Rating:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="CourseRatingTB" TextMode="Number"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        Slope Rating:
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="SlopeRatingTB" TextMode="Number"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Button runat="server" ID="SubmitButton" Text="Submit" />
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
</asp:Content>

