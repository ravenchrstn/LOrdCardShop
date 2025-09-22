<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Customer.Master" AutoEventWireup="true" CodeBehind="CardDetail.aspx.cs" Inherits="LOrdCardShop.View.CardView.CardDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentCustomer" runat="server">
    <style>
        * {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .card_detail {
            display: flex;
            flex-direction: column;
            margin: 50px 10% 0;
            gap: 35px;
        }

        .card_detail_text {
            font-weight: bold;
            font-size: 32px;
        }

        .card_detail_content {
            display: flex;
            flex-wrap: wrap;
            width: 100%;
            gap: 50px;
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
            display: flex;
            justify-content: space-between;
            gap: 75px;
        }

        .description_value {
            display: flex;
            justify-content: flex-end;
            width: 100%;
        }

        .description_value .value {
            text-align: end;
        }

        .back_button {
            width: 100px;
        }

        @media (max-width: 1095px) {
            .card_detail_content {
                justify-content: center;
            }

            .information {
                width: 100%;
                gap: 25px;
            }
        }
    </style>

    <div class="card_detail">
        <div class="card_detail_text">
            Card Detail
        </div>
        <div class="card_detail_content">
            <div class="image">
                <asp:Image ID="card_image" runat="server" CssClass="card_image"/>
            </div>
            <div class="information">
                <div class="name">
                    <div class="name_text">
                        Name
                    </div>
                    <div class="name_value">
                        <asp:Label ID="name_value" runat="server" Text="Sprigatito"></asp:Label>
                    </div>
                </div>
                <div class="price">
                    <div class="price_text">
                        Price
                    </div>
                    <div class="price_value">
                        <asp:Label ID="price_value" runat="server" Text="$2"></asp:Label>
                    </div>
                </div>
                <div class="description">
                    <div class="description_text">
                        Description
                    </div>
                    <div class="description_value">
                        <asp:Label ID="description_value" runat="server" CssClass="value" Text="quadrupedal feline Pokémon covered in pale green fur"></asp:Label>
                    </div>
                </div>
                <div class="type">
                    <div class="type_text">
                        Type
                    </div>
                    <div class="type_value">
                        <asp:Label ID="type_value" runat="server" Text="Monster"></asp:Label>
                    </div>
                </div>
                <div class="is_foil">
                    <div class="is_foil_text">
                        Is Foil
                    </div>
                    <div class="is_foil_value">
                        <asp:Label ID="is_foil_value" runat="server" Text="Yes"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="back_button_container">
            <asp:Button ID="back_button" class="btn bg-danger text-white back_button" runat="server" Style="height: 40px; width: 80px" Text="Back" OnClick="back_button_Click"/>
        </div>
    </div>
</asp:Content>
