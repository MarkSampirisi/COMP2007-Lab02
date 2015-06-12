﻿<%@ Page Language="C#" Title="Departments" MasterPageFile="~/lab02.Master" AutoEventWireup="true" CodeBehind="departments.aspx.cs" Inherits="lab02.departments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Departments</h1>
    <a href="department.aspx">Add Department</a>
    <asp:GridView ID="grdDepartments" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" 
        OnRowDeleting="grdDepartments_DeleteRow" DataKeyNames="DepartmentID">
        <Columns>
            <asp:BoundField DataField="DepartmentID" Visible="false" />
            <asp:BoundField DataField="Name" HeaderText="DepartmentName" />
            <asp:BoundField DataField="Budget" HeaderText="Budget" DataFormatString="{0:c}" />
            <asp:HyperLinkField HeaderText="Edit" NavigateUrl="~/department.aspx" Text="Edit" DataNavigateUrlFields="DepartmentID"
                 DataNavigateUrlFormatString="department.aspx?DepartmentID={0}" />
            <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton="true"/>      
        </Columns>
    </asp:GridView>
</asp:Content>