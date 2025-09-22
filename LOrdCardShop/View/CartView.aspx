<%@ Page Title="" Language="C#" MasterPageFile="~/View/MasterPage/Customer.Master" AutoEventWireup="true" CodeBehind="CartView.aspx.cs" Inherits="LOrdCardShop.View.CartView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="masterContentCustomer" runat="server">

    <style>
        * {
            color: white;
            font-family: "OpenSans-Regular", sans-serif;
        }

        .cart {
            display: flex;
            flex-direction: column;
            margin: 50px 10% 50px;
            gap: 35px;
            width: 100%;
        }

        .title {
            font-weight: bold;
            font-size: 32px;
        }

        .content {
            display: flex;
            width: 100%;
        }

        .item {
            display: flex;
            width: 100%;
        }

        .itemImage {
            width: 100px;
        }

        .name-price-description {
            display: flex;
            width: 100%;
            flex-direction: column;
            padding: 15px 0 0 30px;
            gap: 5px;
        }

        .name {
            color: lightgray;
            font-size: 18px;
        }

        .price {
            font-size: 16px;
        }

        .description {
            font-size: 13px;
        }

        .quantity {
            display: flex;
            margin-top: auto;
            gap: 10px;
            border: 2px solid white;
            border-radius: 20px;
            width: contain;
            height: 40px;
        }

        .cardQuantity[type=number]::-webkit-inner-spin-button, .cartQuantity[type=number]::-webkit-outer-spin-button {
            -webkit-appearance: none;
            margin: 0;
        }

        .quantity_text {
            margin: auto;
            font-size: 16px;
        }

        .quantity [class*="_button"] {
            display: flex;
            align-self: center;
            color: white;
            font-size: 20px;
            background-color: transparent;
            width: 35px;
            border: none;
        }

    </style>

    <asp:Repeater ID="cartRepeater" runat="server">
        <HeaderTemplate>
            <div class="cart">
                <div style="display: flex; justify-content: space-between; align-items: center">
                    <div class="title">
                        Your Cart
                    </div>
                    <div class="clear-cart-wrap">
                        <asp:Button ID="clearCartButton" Style="color: white; width: 120px; font-size: 16px" runat="server" CssClass="btn check_out_button bg-danger" Text="Clear Cart" OnClick="clearCartButton_Click"/>
                    </div>
                </div>
                
        </HeaderTemplate>
        <ItemTemplate>
                <div class="content">
                    <div class="item">
                        <asp:Image ID="itemImage" runat="server" class="itemImage" ImageUrl=<%# GetCardUrl(Eval("CardID").ToString())%>/>
                        <div class="name-price-description">
                            <div class="name">
                                <asp:Label ID="name" runat="server" Text=<%# GetCardName(Eval("CardID").ToString()) %>></asp:Label>                        
                            </div>
                            <div class="description">
                                <asp:Label ID="description" runat="server" Style="color: lightgray" Text=<%# GetCardDescription(Eval("CardID").ToString())%>></asp:Label>
                            </div>
                            <div class="price">
                                <asp:Label ID="price" runat="server" Text=<%# GetCardPrice(Eval("CardID").ToString())%>></asp:Label>
                            </div>
                        </div>
                        <div class="quantity">
                            <asp:Button ID="decrease" runat="server" class="decrease_button" Text="-" CommandName="Decrease" CommandArgument='<%# Eval("CartID") %>' OnCommand="Quantity_Command"/>
                            <asp:TextBox TextMode="Number" ID="cardQuantity" runat="server" Style="width: 50px; color: black; outline: none" Text=<%# Eval("Quantity") %> CssClass="cardQuantity" AutoPostBack="True" OnTextChanged="cardQuantity_TextChanged"></asp:TextBox>
                            <asp:Button ID="increase" runat="server" class="increase_button" Text="+" CommandName="Increase" CommandArgument='<%# Eval("CartID") %>' OnCommand="Quantity_Command" />
                        </div>
                    </div>
                </div>
        </ItemTemplate>
        <FooterTemplate>
                <div class="check_out_total_price">
                    <asp:Button ID="checkOutButton" Style="color: white; width: 120px; font-size: 16px" runat="server" CssClass="btn check_out_button bg-danger" Text="Check Out" OnClick="checkOutButton_Click"/>
                    <asp:Label ID="totalPrice" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
