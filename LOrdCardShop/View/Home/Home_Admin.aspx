<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="Home_Admin.aspx.cs" Inherits="LOrdCardShop.View.Home.Home_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentAdmin" runat="server">
    <div class="d-flex justify-content-evenly align-items-center" style="height: calc(100vh - 60px)">
        <div class="left d-flex flex-column align-items-center text-white" style="width: 40%">
            <asp:Label ID="greetingLabel" CssClass="h1" runat="server"></asp:Label>
            <div class="h5">
                How's your day?
            </div>
        </div>
        <div class="right d-flex h-100">
            <img src="../../Media/pokemon_trainer_male.png" class="h-100"/>
            <img src="../../Media/pokemon_trainer_female.png" class="h-100 d-none d-xl-block"/>        
        </div>
    </div>
</asp:Content>