<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="TransactionReport.aspx.cs" Inherits="LOrdCardShop.View.TransactionReport" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentAdmin" runat="server">
    <style>
        .cr_viewer {
            margin: auto auto;
        }
    </style>

    <CR:CrystalReportViewer ID="CrystalReportViewer_TransactionReport" CssClass="cr_viewer" runat="server" AutoDataBind="true"/>
</asp:Content>