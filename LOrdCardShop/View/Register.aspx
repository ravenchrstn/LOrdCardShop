<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/LoginRegister.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="LOrdCardShop.View.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server"> 
    <style>
        .calendar-styled {
            width: 100%;
            max-width: 400px;
            background: white;
            border-radius: 10px;
            padding: 10px;
            box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
        }

        .calendar-styled thead {
            background: #007bff;
            color: white;
        }

        .calendar-styled th {
            padding: 10px;
            text-align: center;
        }

        .calendar-styled td {
            text-align: center;
            padding: 7px;
            cursor: pointer;
            transition: background 0.3s;
            text-decoration: none;
        }

        .calendar-styled td .SelectedDate {
            background-color: none;
            font-weight: bold;
        }   

    </style>
    <div class="right d-flex flex-column justify-content-center gap-3" style="background-color: white; width: 75%; outline: 1px solid red">
        <div class="title power-clear-normal text-center text-black w-100" style="height: 36px; line-height: 36px; font-size: 36px">
            Register
        </div>
        <div class="form open-sans-normal w-100 d-flex flex-column gap-2 align-items-center">
            <div class="username" style="width: clamp(150px, 75%, 450px); font-size: 14px">
                <label for="inputUsernameLabel" class="form-label">Username</label>
                <asp:TextBox ID="usernameInput" class="form-control w-100" style="height: 30px; font-size: 13px" runat="server" aria-describedby="errorUsername"></asp:TextBox>
                <asp:Label ID="errorUsername" runat="server" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
            </div>
            <div class="email" style="width: clamp(150px, 75%, 450px); font-size: 14px"">
                <label for="inputEmailLabel" class="form-label">Email</label>
                <asp:TextBox ID="emailInput" class="form-control w-100" style="height: 30px; font-size: 13px" runat="server" aria-describedby="errorEmail"></asp:TextBox>
                <asp:Label ID="errorEmail" runat="server" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
            </div>
            <div class="password" style="width: clamp(150px, 75%, 450px); font-size: 14px"">
                <label for="inputPassword" class="form-label">Password</label>
                <asp:TextBox type="password" ID="passwordInput" class="form-control w-100" style="height: 30px; font-size: 13px" runat="server" aria-describedby="errorPassword"></asp:TextBox>
                <asp:Label ID="errorPassword" runat="server" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
            </div>
            <div class="calendar" style="width: clamp(150px, 75%, 450px); font-size: 14px"">
                <label for="inputDOB" class="form-label">Date Of Birth</label>
                <asp:Calendar ID="calendarInput" runat="server" CssClass="calendar-styled" Style="width: 100%"></asp:Calendar>
                <asp:Label ID="errorDOB" runat="server" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
            </div>
            <div class="gender" style="width: clamp(150px, 75%, 450px); font-size: 14px"">
                <label for="inputGender" class="form-label">Gender</label>
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="RadioButtonGender" runat="server">
                    <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                    <asp:ListItem Value="Female" style="padding-left: 110px" Text="Female"></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="errorGender" runat="server" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
            </div>
            <div class="confirmation_password" style="width: clamp(150px, 75%, 450px); font-size: 14px"">
                <label for="inputConfirmationPassword" class="form-label">Confirmation Password</label>
                <asp:TextBox type="password" ID="confirmationPasswordInput" class="form-control w-100" style="height: 30px; font-size: 13px" runat="server" aria-describedby="errorConfirmation"></asp:TextBox>
                <asp:Label ID="errorConfirmation" runat="server" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
            </div>
            <div class="role" style="width: clamp(150px, 75%, 450px); font-size: 14px"">
                <label for="inputRole" class="form-label">Role</label>
                <asp:RadioButtonList RepeatDirection="Horizontal" ID="RadioButtonRole" runat="server">
                    <asp:ListItem Value="Customer" Text="Customer"></asp:ListItem>
                    <asp:ListItem Value="Admin" style="padding-left: 75px" Enabled="false" Customer="Admin" ></asp:ListItem>
                </asp:RadioButtonList>
                <asp:Label ID="errorRole" runat="server" Text="" CssClass="error" Style="font-size: 14px"></asp:Label>
            </div>
        </div>
        <div class="bottom text-center d-flex flex-column gap-4 mx-auto align-items-center" style="width: clamp(150px, 75%, 450px)">
            <asp:Button ID="submitButton" runat="server" Text="Submit" CssClass="btn w-100" Style="background-color: #ee1515; color: white" OnClick="submitButton_Click"/>
            <div class="register w-100">
                Already have an account? <a href="Login.aspx" style="text-decoration: none">Sign In</a>
            </div>
        </div>
    </div>
</asp:Content>