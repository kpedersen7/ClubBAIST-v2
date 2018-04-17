<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OverWriteScore.aspx.cs" Inherits="OverWriteScore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Notice</h5>
                </div>
                <div class="modal-body">
                    You have already submitted a score for this reservation! Overwrite?
                </div>
                <div class="modal-footer">
                    <asp:LinkButton runat="server" ID="CancelButton" OnClick="CancelButton_Click" Text="NO"></asp:LinkButton>
                    <div class="col-10"></div>
                    <asp:LinkButton runat="server" ID="ConfirmButton" OnClick="ConfirmButton_Click" Text="YES"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        $('#exampleModal').modal('show')
    </script>
</asp:Content>

