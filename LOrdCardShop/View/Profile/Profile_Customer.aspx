<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Customer.Master" AutoEventWireup="true" CodeBehind="Profile_Customer.aspx.cs" Inherits="LOrdCardShop.View.Profile.Profile_Customer1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentCustomer" runat="server">
     <style>
        * {
            color: white;
        }

        .profile {
            display: flex;
            flex-direction: column;
            gap: 35px;
            padding: 50px 10% 0;
        }
        .profile-header, .profile-content {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .profile-header {
            font-weight: bold;
            font-size: 32px;
        }

        .profile-content {
            display: flex;
            flex-direction: column;
            gap: 20px;
            padding-bottom: 5px;
        }

        .profile-name, .profile-email, .profile-password, .profile-gender {
            display: flex;
            justify-content: space-between;
        }

        .value, .navigate_change_password {
            display: flex;
            justify-content: center;
            width: calc(75% + 100px);
        }

        .navigate_change_password {
            padding-right: calc(21% + 15px);
        }

        .navigate_change_password a {
            text-decoration: none;
        }

        .value .input {
            display: flex;
            flex-direction: column;
            justify-content: center;
            width: calc(30% + 100px);
            color: black;
        }

        .profile-gender input {
            width: auto;
        }

        .error {
            color: red;
        }

    </style>

    <div class="profile">
        <div class="profile-header">
            Profile
        </div>
        <div class="profile-content">
            <div class="profile-name">
                <div class="label">
                    Name
                </div>
                <div class="value">
                    <div class="input">
                        <asp:TextBox ID="usernameInput" class="form-control w-100" style="height: 30px; font-size: 14px" runat="server" aria-describedby="errorUsername" Text="Raven Christian"></asp:TextBox>
                        <asp:Label ID="errorUsername" class="error" runat="server" Visible="true" Text="" CssClass="error text-danger" Style="font-size: 14px"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="profile-email">
                <div class="label">
                    Email
                </div>
                 <div class="value">
                    <div class="input">
                        <asp:TextBox ID="emailInput" class="form-control w-100" style="height: 30px; font-size: 14px" runat="server" aria-describedby="errorEmail" Text="raven.christian@binus.ac.id"></asp:TextBox>
                        <asp:Label ID="errorEmail" runat="server" Text="" Visible="true" CssClass="error text-danger" Style="font-size: 14px"></asp:Label>
                    </div>
                </div>
            </div>
            <div class="profile-password">
                <div class="label">
                    Password
                </div>
                <div class="navigate_change_password">
                    <asp:HyperLink ID="changePassword" NavigateUrl="~/View/ChangePassword/ChangePassword_Customer.aspx" runat="server">Change Password</asp:HyperLink>
                </div>
            </div>
            <div class="profile-gender">
                <div class="label">
                    Gender
                </div>
                <div class="value">
                    <div class="input">
                        <asp:RadioButtonList RepeatDirection="Horizontal" ID="RadioButtonGender" runat="server">
                            <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                            <asp:ListItem Value="Female" style="padding-left: 75px" Text="Female"></asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:Label ID="errorGender" runat="server" Text="" Visible="true" CssClass="error" Style="font-size: 14px"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="button">
            <asp:Button ID="updateButton" runat="server" Text="Update" CssClass="btn bg-danger" Style="background-color: #ee1515; color: white; width: 90px" OnClick="updateButton_Click"/>
        </div>
    </div>
</asp:Content>
