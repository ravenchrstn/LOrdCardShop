<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="AddCard.aspx.cs" Inherits="LOrdCardShop.View.CardView.AddCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentAdmin" runat="server">
    <style>
        * {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .add_card {
            display: flex;
            flex-direction: column;
            margin: 50px 10% 0;
            gap: 35px;
        }

        .add_card_text {
            font-weight: bold;
            font-size: 32px;
        }

        .add_card_content {
            display: flex;
            flex-wrap: wrap;
            width: 100%;
            gap: 50px;
            justify-content: space-between;
        }

        .information {
            width: 100%;
            display: flex;
            flex-direction: column;
            justify-content: space-evenly;
            font-size: 18px;
            gap: 25px;
        }

        .information > div {
            width: 100%;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }

        .information [class*=_text] {
            font-size: 16px;
        }

        .information [class*=_value] {
            width: 50%;
        }

        [class*=_value] [id*=Input] {
            height: 30px;
            font-size: 14px;
        }

        .insert_button_container {
            padding-bottom: 70px;
            margin-left: auto;
        }

        .insert_button {
            width: 75px;
        }

        [id*=error] {
            color: red;
        }

    </style>

    <div class="add_card">
        <div class="add_card_text">
            Add Card
        </div>
        <div class="add_card_content">
            <div class="information">
                <div class="name">
                    <div class="name_text">
                        Name
                    </div>
                    <div class="name_value">
                        <asp:TextBox ID="nameInput" runat="server" CssClass="form-control w-100" aria-describedby="errorName"></asp:TextBox>
                        <asp:Label ID="errorName" runat="server" Visible="true" Style="font-size: 14px"></asp:Label>
                    </div>
                </div>
                <div class="price">
                    <div class="price_text">
                        Price
                    </div>
                    <div class="price_value">
                        <asp:TextBox ID="priceInput" runat="server" CssClass="form-control w-100" aria-describedby="errorPrice"></asp:TextBox>
                        <asp:Label ID="errorPrice" runat="server" Visible="true" Style="font-size: 14px"></asp:Label>
                    </div>
                </div>
                <div class="description">
                    <div class="description_text">
                        Description
                    </div>
                    <div class="description_value">
                        <asp:TextBox ID="descriptionInput" runat="server" CssClass="form-control w-100" aria-describedby="errorDescription"></asp:TextBox>
                        <asp:Label ID="errorDescription" runat="server" Visible="true" Style="font-size: 14px"></asp:Label>
                    </div>
                </div>
                <div class="type">
                    <div class="type_text">
                        Type
                    </div>
                    <div class="type_value">
                        <asp:TextBox ID="typeInput" runat="server" CssClass="form-control w-100" aria-describedby="errorType"></asp:TextBox>
                        <asp:Label ID="errorType" runat="server" Visible="true" Style="font-size: 14px"></asp:Label>
                    </div>
                </div>
                <div class="is_foil">
                    <div class="is_foil_text">
                        Is Foil
                    </div>
                    <div class="is_foil_value">
                        <asp:TextBox ID="isFoilInput" runat="server" CssClass="form-control w-100" aria-describedby="errorIsFoil"></asp:TextBox>
                        <asp:Label ID="errorIsFoil" runat="server" Visible="true" Style="font-size: 14px"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="insert_button_container">
            <asp:Button ID="insert_button" class="btn bg-danger text-white insert_button" runat="server" Text="Insert" OnClick="insert_button_Click"/>
        </div>
    </div>
</asp:Content>
