<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/LoginRegister.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LOrdCardShop.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
    <div class="right d-flex flex-column vh-100 justify-content-center gap-4" style="background-color: white; width: 75%; outline: 1px solid red">
        <div class="title power-clear-normal text-center text-black w-100" style="font-size: 5vh">
            Login
        </div>
        <div class="form open-sans-normal w-100 d-flex flex-column gap-3 align-items-center">
            <div class="username" style="width: clamp(150px, 75%, 450px); font-size: 14px">
                <label for="inputUsernameLabel" class="form-label">Username</label>
                <asp:TextBox ID="usernameInput" class="form-control w-100" style="height: 30px; font-size: 13px" runat="server" aria-describedby="errorUsername"></asp:TextBox>
                <asp:Label ID="errorUsername" runat="server" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
            </div>
            <div class="password" style="width: clamp(150px, 75%, 450px); font-size: 14px"">
                <label for="inputPasswordLabel" class="form-label">Password</label>
                <asp:TextBox type="password" ID="passwordInput" class="form-control w-100" style="height: 30px; font-size: 13px" runat="server" aria-describedby="errorPassword"></asp:TextBox>
                <asp:Label ID="errorPassword" runat="server" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
            </div>
            <div class="bottom text-center d-flex flex-column mx-auto pt-3 align-items-center" style="width: clamp(150px, 75%, 450px)">
                <asp:CheckBox ID="rememberMeCheckbox" class="d-flex gap-2 me-auto pb-2" Style="font-size: 14px" runat="server" Text="Remember me"/>
                <asp:Button ID="submitButton" runat="server" Text="Submit" CssClass="btn w-100" Style="background-color: #ee1515; color: white" OnClick="submitButton_Click"/>
                <asp:Label ID="errorLogin" runat="server" CssClass="text-danger me-auto pb-4" Style="font-size: 14px" Text=""></asp:Label>
                <div class="register w-100" style="font-size: 15px">
                    Don't have an account? <a href="Register.aspx" style="text-decoration: none">Register</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
