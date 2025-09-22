<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="EditCard.aspx.cs" Inherits="LOrdCardShop.View.CardView.EditCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentAdmin" runat="server">
        <style>
        * {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .edit_card {
            display: flex;
            flex-direction: column;
            padding: 50px 10% 50px;
            gap: 30px;
        }

        .edit_card_text {
            font-weight: bold;
            font-size: 32px;
        }

        .edit_card_content {
            display: flex;
            flex-wrap: wrap;
            width: 100%;
            justify-content: space-between;
        }

        .image {
            max-width: 250px;
        }

        .card_image {
            width: 100%;
        }

        .information {
            width: 65%;
            display: flex;
            flex-direction: column;
            justify-content: space-evenly;
            font-size: 18px;
        }

        .information > div {
            width: 100%;
            display: flex;
            justify-content: space-between;
        }

        .information [class*=_text] {
            font-size: 15px;
        }

        .information [class*=_value] {
            width: 50%;
        }

        [class*=_value] [id*=Input] {
            font-size: 14px;
            height: 30px;
        }

        .description_value {
            justify-content: flex-end;
        }

        .description_value .value {
            text-align: end;
        }

        .update_button_container {
            margin-left: auto;
            margin-top: -15px;
        }

        .update_button {
            width: 85px;
            height: 40px;
            font-size: 15px;
        }

        [id*=error] {
            color: red;
        }

        @media (max-width: 1095px) {
            .edit_card_content {
                justify-content: center;
                gap: 50px;
            }

            .information {
                width: 100%;
                height: 350px;
            }
        }
    </style>

    <div class="edit_card">
        <div class="edit_card_text">
            Edit Card
        </div>
        <div class="edit_card_content">
            <div class="image">
                <asp:Image ID="card_image" runat="server" CssClass="card_image"/>
            </div>
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
        <div class="update_button_container">
            <asp:Button ID="update_button" class="btn bg-danger text-white update_button" runat="server" Text="Update" OnClick="update_button_Click"/>
        </div>
    </div>
</asp:Content>
