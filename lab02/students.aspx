<%@ Page Language="C#" Title="Student Information" MasterPageFile="~/lab02.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="lab02.students" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Students</h1>
    <a href="student.aspx">Add Student</a>
    <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped" AutoGenerateColumns="false"
        DataKeyNames="StudentID" OnRowDeleting="grdStudents_DeleteRow" >
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" />
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="~/student.aspx" Text="Edit" DataNavigateUrlFields="StudentID"
                 DataNavigateUrlFormatString="student.aspx?StudentID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true"/>      
        </Columns>
    </asp:GridView>
</asp:Content>
