<%@ Page Language="C#" Title="Student Information" MasterPageFile="~/lab02.Master" AutoEventWireup="true" CodeBehind="student.aspx.cs" Inherits="lab02.student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student info</h1>

    <h5>*Note: All fields are required!</h5>

    <div class="form-group">
        <label for="txtlast" class="col-sm-3">Last Name:</label>
        <asp:TextBox ID="txtlast" runat="server" required MaxLength="50"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtfirst" class="col-sm-3">First Name:</label>
        <asp:TextBox ID="txtfirst" runat="server" required MaxLength="50"></asp:TextBox>
    </div>
    <div class="text-center">
        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" />
    </div>
</asp:Content>
