<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Customer.Master" AutoEventWireup="true" CodeBehind="TransactionHistory_Customer.aspx.cs" Inherits="LOrdCardShop.View.TransactionHistory.TransactionHistory_Customer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentCustomer" runat="server">
    <style>
        * {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .transaction_history {
            display: flex;
            flex-direction: column;
            margin: 50px 10% 0;
            gap: 35px;
        }

        .title {
            font-weight: bold;
            font-size: 32px;
        }

        .blank_container {
            margin-bottom: 35px;
        }

        .each_transaction {
            display: flex;
            flex-direction: column;
            border-radius: 10px;
            padding: 20px 50px 25px;
            gap: 10px;
        }

        .header {
            display: flex;
            height: 50px;
            padding: 0 10px;
            gap: 15px;
        }

        .receipt-image {
            display: flex;
            align-items: center;
        }

        .receipt-image img {
            width: 40px;
        }

        .header_transaction_detail {
            display: flex;
            flex-direction: column;
            justify-content: center
        }

        .shopping_text {
            font-weight: bold;
            line-height: normal;
        }

        .date {
            font-size: 14px;
        }

        .separator {
            width: 100%;
            height: 1px;
            background-color: rgb(255, 255, 255, 0.5);
        }

        .each_transaction_content {
            display: flex;
            flex-direction: column;
        }

        .each_transaction_content .img {
            width: 175px;
        }

        .product {
            display: flex;
            justify-content: center;
            align-items: center;
            margin-top: 10px;
            gap: 12%;
        }

        .image_other_products {
            display: flex;
            flex-direction: column;
            gap: 10px;
        }

        .information {
            display: flex;
            flex-direction: column;
            gap: 5px;
        }

        .product_name .product_name_label {
            font-size: clamp(24px, 3vw, 32px);
            font-weight: bold;
        }

        .product_quantity_label {
            font-size: 18px;
            padding-left: 10px;
            color: lightgray;
        }

        .footer {
            display: flex;
            flex-direction: column;
            padding-top: 10px;
            align-items: flex-end;
            gap: 10px;
        }

        .total_price {
            display: flex;
            gap: 30px;
        }

    </style>

    <asp:Repeater ID="transactionHistoryRepeater" runat="server">
        <HeaderTemplate>
            <div class="transaction_history">
                <div class="title">
                    Transaction History
                </div>

                <div class="transactions row d-flex flex-wrap justify-content-between">
        </HeaderTemplate>
        <ItemTemplate>
                    <div class="blank_container col-xxl-6 col-12">
                        <div class="content each_transaction bg-dark">
                            <div class="header">
                                <div class="receipt-image">
                                    <image src="../../Media/receipt.png"></image>
                                </div>
                                <div class="header_transaction_detail">
                                    <div class="shopping_text">
                                        Shopping
                                    </div>
                                    <asp:Label ID="shoppingDate" runat="server" Text=<%# GetDate(Eval("TransactionID").ToString())%>></asp:Label>
                                </div>
                            </div>
                            <div class="separator"></div>
                            <div class="each_transaction_content">
                                <div class="product">
                                    <div class="image_other_products">
                                        <asp:Image ID="productImage" CssClass="img" runat="server" ImageUrl=<%# GetCardUrl(GetCardNameByCardID((Eval("CardID").ToString()))) %>/>
                                    </div>
                                    <div class="information">
                                        <div class="product_name">
                                            <asp:Label ID="product_name" runat="server" Text=<%# GetCardNameByCardID(Eval("CardID").ToString()) %> CssClass="product_name_label"></asp:Label>
                                        </div>
                                        <div class="product_quantity">
                                            <asp:Label ID="product_quantity" runat="server" Text=<%# GetQuantity(Eval("Quantity").ToString())%> CssClass="product_quantity_label"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="footer">
                                    <div class="total_price">
                                        <div class="total_price_text">
                                            Total Price:
                                        </div>
                                        <asp:Label ID="total_price_amount" runat="server" Text=<%# GetPrice(Eval("CardID").ToString(), Eval("Quantity").ToString())%>></asp:Label>
                                    </div>
                                    <div class="detail_container">
                                        <div class="detail_button">
                                            <asp:Button ID="detail_button" runat="server" class="btn bg-danger" Style="width: 75px; color: white" Text="Detail" CommandName="Detail" CommandArgument=<%# Eval("TransactionID") %> OnCommand="detail_button_Command"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
        </ItemTemplate>
        <FooterTemplate>
                </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>       
</asp:Content>
