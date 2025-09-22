<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Admin.Master" AutoEventWireup="true" CodeBehind="TransactionDetail_Admin.aspx.cs" Inherits="LOrdCardShop.View.TransactionDetailView.TransactionDetail_Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentAdmin" runat="server">
    <style>
        * {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .transaction_detail {
            display: flex;
            flex-direction: column;
            margin: 50px 10% 0;
            gap: 35px;
        }

        .transaction_detail_text {
            font-weight: bold;
            font-size: 32px;
        }

        .transaction_detail_content {
            display: flex;
            flex-wrap: wrap;
            width: 100%;
            gap: 50px;
            justify-content: space-between;
        }

        .image {
            display: flex;
            width: 25%;
            justify-content: center;
        }

        .card_image {
            width: 100%;
            max-width: 250px;
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

        .information [class*="_text"] {
            font-size: 15px;
        }

        .information [class*="_value"] {
            font-size: 15px;
        }

        .description_value {
            display: flex;
            justify-content: flex-end;
            width: 100%;
        }

        .description_value .value {
            text-align: end;
        }

        .back_button_container {
            padding-top: 25px;
        }

        .back_button {
            width: 100px;
        }

        @media (max-width: 1095px) {
            .transaction_detail_content {
                justify-content: center;
            }

            .information {
                width: 100%;
                gap: 25px;
            }

            .back_button_container {
                padding-bottom: 40px;
            }

            .image {
                width: 100%;
                display: flex;
                justify-content: center;
            }

        }
    </style>

    <div class="transaction_detail">
        <div class="transaction_detail_text">
            Transaction Detail
        </div>
        <div class="transaction_detail_content">
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
                <div class="quantity">
                    <div class="quantity_text">
                        Quantity
                    </div>
                    <div class="quantity_value">
                        <asp:Label ID="quantity_value" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="transaction_date">
                    <div class="transaction_date_text">
                        Transaction Date
                    </div>
                    <div class="transaction_date_value">
                        <asp:Label ID="transaction_date" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="status">
                    <div class="status_text">
                        Status
                    </div>
                    <div class="status_value">
                        <asp:Label ID="status" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div class="total_price">
                    <div class="total_price_text">
                        Total Price
                    </div>
                    <div class="total_price_value">
                        <asp:Label ID="total_price_value" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
        <div class="back_button_container">
            <asp:Button ID="back_button" class="btn bg-danger text-white back_button" runat="server" Style="height: 40px; width: 80px" Text="Back" OnClick="back_button_Click"/>
        </div>
    </div>
</asp:Content>
