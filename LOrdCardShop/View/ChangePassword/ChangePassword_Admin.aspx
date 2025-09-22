<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="ChangePassword_Admin.aspx.cs" Inherits="LOrdCardShop.View.ChangePassword.ChangePassword_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentAdmin" runat="server">
    <style>
        * {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .change_password {
            display: flex;
            flex-direction: column;
            gap: 35px;
            margin: 50px 10% 0;
        }

        .change_password .form-text {
            font-size: 15px;
        }

        .change_password_title {
             font-weight: bold;
             font-size: 32px;
        }

        .change_password_content {
            display: flex;
            flex-direction: column;
            gap: 25px;
        }

        .each_form {
            display: flex;
/*            background-color: aquamarine;*/
            gap: 50px;
            height: contain;
        }

        .form-text {
            width: calc(25% + 150px);
            color: white;
/*            background-color: bisque;*/
        }

        [class*="_password_form"] {
            display: flex;
            flex-direction: column;
/*            background-color: blue; */
            width: calc(25% + 100px);
            height: 100%;
            gap: 5px;
        }

        [class*="_password_form"] input {
            height: 100%;
        }

        [class*="_password_form"] .error {
            color: red;
            padding-left: 10px;
        }

    </style>
    
    <div class="change_password">
        <div class="change_password_title">
            Change Password
        </div>
        <div class="change_password_content">
            <div class="old_password each_form">
                <div class="old_password_text form-text">
                    Old Password
                </div>
                <div class="old_password_form">
                    <asp:TextBox type="password" ID="oldPasswordInput" class="form-control w-100" style="height: 30px; font-size: 14px" runat="server" aria-describedby="errorOldPassword"></asp:TextBox>
                    <asp:Label ID="errorOldPassword" runat="server" Visible="true" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
                </div>
            </div>
            <div class="new_password each_form">
                <div class="new_password_text form-text">
                    New Password
                </div>
                <div class="new_password_form">
                    <asp:TextBox type="password" ID="newPassowordInput" class="form-control w-100" style="height: 30px; font-size: 14px" runat="server" aria-describedby="errorNewPassword"></asp:TextBox>
                    <asp:Label ID="errorNewPassword" runat="server" Visible="true" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
                </div>
            </div>
            <div class="confirmation_password each_form">
                <div class="confirmation_password_text form-text">
                    Confirmation Password
                </div>
                <div class="confirmation_password_form">
                    <asp:TextBox type="password" ID="confirmationPasswordInput" class="form-control w-100" style="height: 30px; font-size: 14px" runat="server" aria-describedby="errorConfirmationPassword"></asp:TextBox>
                    <asp:Label ID="errorConfirmationPassword" runat="server" Visible="true" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
                </div>
            </div>
        </div>
        <div class="change_password_button">
            <asp:Button ID="changeButton" runat="server" Text="Change" CssClass="btn bg-danger" Style="color: white; width: 80px; font-size: 15px;" OnClick="changeButton_Click"/>
        </div>
    </div>
    
</asp:Content>
