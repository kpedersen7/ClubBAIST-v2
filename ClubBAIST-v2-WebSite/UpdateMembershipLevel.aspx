<%@ Page Title="Update Existing Membership Level" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdateMembershipLevel.aspx.cs" Inherits="UpdateMembershipLevel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row">
        <div class="col-12">
            <h2>Update Existing Membership Level</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:Table runat="server" ID="FormTable">
                <asp:TableRow>
                    <asp:TableCell>
                <asp:Label runat="server">Select a membership level</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:DropDownList runat="server" ID="MembershipLevelDD"></asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <div class="col-6">
            <asp:Table runat="server" ID="FormTable2">
                <asp:TableRow>
                    <asp:TableCell>
                <asp:Label runat="server">Membership Level Name</asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox runat="server" ID="DescriptionTB"></asp:TextBox>
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

